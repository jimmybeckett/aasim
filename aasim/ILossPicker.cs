namespace aasim
{
    internal interface ILossPicker
    {
        Type? PickLossType(Dictionary<Type, IUnitStack> units);
    }
}
