namespace aasim
{
    internal class SimpleLossPicker : ILossPicker
    {
        public Type? PickLossType(Dictionary<Type, IUnitStack> units)
            => units.MaxBy<KeyValuePair<Type, IUnitStack>, (int, int)>(kv 
                => (kv.Value.SurplusHealth, -kv.Value.WorkerUnit.Cost))
            .Key;
    }
}
