namespace aasim
{
    public class Force
    {
        private Dictionary<Type, IUnitStack> _units = new();
        private readonly ILossPicker _lossPicker;

        public Force(ILossPicker lossPicker)
             => _lossPicker = lossPicker;

        public Force(Force other) => (_lossPicker, _units) 
            = (other._lossPicker, other._units.ToDictionary(entry => entry.Key, entry => entry.Value.Duplicate()));

        public void AddUnit<T>(int n = 1) where T : Unit, new()
        {
            if (!_units.TryGetValue(typeof(T), out var unitStack))
            {
                _units.Add(typeof(T), unitStack = new UnitStack<T>());
            }
            unitStack.AddUnit(n);
        }

        public int SimulateAttack(Battle context)
            => SimulateCombat(unitStack => unitStack.SimulateAttack(context));

        public int SimulateDefense(Battle context)
            => SimulateCombat(unitStack => unitStack.SimulateDefense(context));

        private int SimulateCombat(Func<IUnitStack, int> simulateHit)
            => _units.Values.Select(simulateHit).Sum();

        public bool IsDefeated() => !_units.Any();

        public int ApplyHits(int hits)
        {
            int hitsApplied;
            for (hitsApplied = 0; hitsApplied < hits && !IsDefeated(); hitsApplied++)
            {
                var lostUnitType = _lossPicker.PickLossType(_units);
                if (lostUnitType == null || !_units.TryGetValue(lostUnitType, out var unitStack))
                {
                    throw new InvalidOperationException();
                }
                unitStack.ApplyHit();
                if (unitStack.NumUnits == 0)
                {
                    _units.Remove(lostUnitType);
                }
            }
            return hitsApplied;
        }

        public int Count<T>() where T : Unit, new()
        {
            if (_units.TryGetValue(typeof(T), out var unitStack))
            {
                return unitStack.NumUnits;
            }
            return 0;
        }
    }
}
