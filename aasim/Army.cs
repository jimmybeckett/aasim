namespace aasim
{
    public class Army : ICloneable
    {
        private Dictionary<Type, IUnitStack> _units = new();
        private readonly ILossPicker _lossPicker;

        public Army(ILossPicker lossPicker)
             => _lossPicker = lossPicker;

        public void AddUnit<T>() where T : Unit, new()
        {
            if (!_units.TryGetValue(typeof(T), out var unitStack))
            {
                _units.Add(typeof(T), unitStack = new UnitStack<T>());
            }
            unitStack.AddUnit();
        }

        public int SimulateAttack(Battle context)
            => _units.Values
            .Select(unitStack => unitStack.SimulateAttack(context))
            .Sum();

        public int SimulateDefense(Battle context)
            => _units.Values
            .Select(unitStack => unitStack.SimulateDefense(context))
            .Sum();

        public bool IsDestroyed() => !_units.Any();

        public int ApplyHits(int hits)
        {
            int hitsApplied;
            for (hitsApplied = 0; hitsApplied < hits && !IsDestroyed(); hitsApplied++)
            {
                ApplyHit();
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

        private void ApplyHit()
        {
            if (IsDestroyed())
            {
                throw new InvalidOperationException();
            }

            var lostUnitType = _lossPicker.PickLossType(_units);

            if (!_units.TryGetValue(lostUnitType, out var unitStack))
            {
                throw new InvalidOperationException();
            }
            
            if (unitStack.SurplusHealth > 0)
            {
                unitStack.SurplusHealth--;
            }
            else
            {
                unitStack.NumUnits--;
                if (unitStack.NumUnits == 0)
                {
                    _units.Remove(lostUnitType);
                }
            }
        }

        public object Clone() => new Army(_lossPicker)
        {
            _units = _units.ToDictionary(entry => entry.Key, entry => (IUnitStack) entry.Value.Clone())
        };
    }
}
