namespace aasim
{
    internal class UnitInfo
    {
        public int SurplusHealth { get; set; }
        public int Count { get; set; }
    }

    public record BattleSimulationSummary
    {
        public int AttackerWins { get; init; }
        public int DefenderWins { get; init; }
        public int Draws { get; init; }
    }

    public record RatioBattleSimulationSummary
    {
        public double AttackerWinRatio { get; init; }
        public double DefenderWinRatio { get; init; }
        public double DrawRatio { get; init; }

        public RatioBattleSimulationSummary() { }

        public RatioBattleSimulationSummary(BattleSimulationSummary summary)
        {
            double rounds = summary.AttackerWins + summary.DefenderWins + summary.Draws;
            AttackerWinRatio = summary.AttackerWins / rounds;
            DefenderWinRatio = summary.DefenderWins / rounds;
            DrawRatio = summary.Draws / rounds;
        }
    }
}