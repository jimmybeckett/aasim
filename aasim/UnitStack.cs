using System.Runtime.CompilerServices;

namespace aasim
{
    public interface IUnitStack
    {
        int NumUnits { get; set; }
        int SurplusHealth { get; set; }
        Unit WorkerUnit { get; init; }
        void AddUnit();
        int SimulateAttack(Battle context);
        int SimulateDefense(Battle context);
        public IUnitStack Clone();
    }

    internal class UnitStack<T> : IUnitStack where T : Unit, new()
    {
        public int NumUnits { get; set; } = 0;
        public int SurplusHealth { get; set; } = 0;
        public Unit WorkerUnit { get; init; } = new T();

        public void AddUnit()
        {
            NumUnits++;
            SurplusHealth += WorkerUnit.Health - 1;
        }

        public int SimulateAttack(Battle context)
            => Enumerable.Range(0, NumUnits)
            .Where(i => WorkerUnit.Attack(context, i))
            .Count();

        public int SimulateDefense(Battle context)
            => Enumerable.Range(0, NumUnits)
            .Where(i => WorkerUnit.Defend(context, i))
            .Count();

        public IUnitStack Clone() => (IUnitStack) MemberwiseClone();
    }
}
