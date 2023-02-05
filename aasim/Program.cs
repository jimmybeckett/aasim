namespace aasim
{
    class TestClass
    {
        static void Main(string[] args)
        {
            var attackingArmy = new Army(new SimpleLossPicker());
            attackingArmy.AddUnit<Fighter>();
            attackingArmy.AddUnit<Fighter>();
            attackingArmy.AddUnit<TacticalBomber>();
            attackingArmy.AddUnit<StrategicBomber>();

            var defendingArmy = new Army(new SimpleLossPicker());
            defendingArmy.AddUnit<Fighter>();
            defendingArmy.AddUnit<TacticalBomber>();
            defendingArmy.AddUnit<TacticalBomber>();
            defendingArmy.AddUnit<StrategicBomber>();
            defendingArmy.AddUnit<StrategicBomber>();

            var battle = new Battle(attackingArmy, defendingArmy);

            PrintSummary(new RatioBattleSimulationSummary(Analysis.Simulate(battle, 100000)));
        }

        static void PrintSummary(RatioBattleSimulationSummary summary)
        {
            Console.WriteLine($"attacker wins: {summary.AttackerWinRatio}, " +
                $"defender wins: {summary.DefenderWinRatio}, draws: {summary.DrawRatio}");
        }
    }
}