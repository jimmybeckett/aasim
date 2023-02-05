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

        public static BattleSimulationSummary operator +(
            BattleSimulationSummary s1, BattleSimulationSummary s2) => new()
            {
                AttackerWins = s1.AttackerWins + s2.AttackerWins,
                DefenderWins = s1.DefenderWins + s2.DefenderWins,
                Draws = s1.Draws + s2.Draws
            };

        public static BattleSimulationSummary operator +(
            BattleSimulationSummary summary, BattleResult result) => new()
            {
                AttackerWins = summary.AttackerWins + (result is BattleResult.AttackersWin ? 1 : 0),
                DefenderWins = summary.DefenderWins + (result is BattleResult.DefendersWin ? 1 : 0),
                Draws = summary.Draws + (result is BattleResult.Draw ? 1 : 0),
            };

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