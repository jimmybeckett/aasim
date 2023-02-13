namespace aasim
{
    public interface IUnitStack
    {
        int NumUnits { get; set; }
        int SurplusHealth { get; set; }
        Unit WorkerUnit { get; init; }
        void AddUnit(int n);
        int SimulateAttack(Battle context);
        int SimulateDefense(Battle context);
        int SimulatePreBattleAttack(Battle context);
        int SimulatePreBattleDefense(Battle context);
        public void ApplyHit();
        public IUnitStack Duplicate();
    }

    internal class UnitStack<T> : IUnitStack where T : Unit, new()
    {
        public int NumUnits { get; set; } = 0;
        public int SurplusHealth { get; set; } = 0;
        public Unit WorkerUnit { get; init; } = new T();

        public void AddUnit(int n)
        {
            NumUnits += n;
            SurplusHealth += (WorkerUnit.Health - 1) * n;
        }

        public int SimulateAttack(Battle context)
            => SimulateCombat(context, WorkerUnit.Attack);

        public int SimulateDefense(Battle context)
            => SimulateCombat(context, WorkerUnit.Defend);

        public int SimulatePreBattleAttack(Battle context)
            => SimulateCombat(context, WorkerUnit.PreBattleAttack);

        public int SimulatePreBattleDefense(Battle context)
            => SimulateCombat(context, WorkerUnit.PreBattleDefense);

        private int SimulateCombat(Battle context, Func<Battle, int, int> simulateHit)
            => Enumerable.Range(0, NumUnits)
            .Select(i => simulateHit(context, i))
            .Sum();

        public void ApplyHit()
        {
            if (SurplusHealth > 0)
            {
                SurplusHealth--;
            }
            else if (NumUnits > 0)
            {
                NumUnits--;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public IUnitStack Duplicate() => (IUnitStack) MemberwiseClone();
    }
}
