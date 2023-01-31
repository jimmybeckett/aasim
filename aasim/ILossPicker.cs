namespace aasim
{
    public interface ILossPicker
    {
        Type? PickLossType(Dictionary<Type, IUnitStack> units);
    }
}
