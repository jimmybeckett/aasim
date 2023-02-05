namespace aasim
{
    public class Analysis
    {
        public static BattleSimulationSummary Simulate(Battle battle, int rounds)
            => Enumerable.Range(0, rounds)
            .AsParallel()
            .Select(_ => new Battle(battle).Resolve())
            .Aggregate(new BattleSimulationSummary(), (summary, result) => summary + result);
    }
}
