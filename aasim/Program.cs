namespace aasim
{
    class TestClass
    {
        static void Main(string[] args)
        {
            var attackingArmy = new Army(new SimpleLossPicker());
            attackingArmy.AddUnit<Infantry>();
            attackingArmy.AddUnit<Infantry>();
            attackingArmy.AddUnit<Infantry>();
            attackingArmy.AddUnit<Artillery>();
            attackingArmy.AddUnit<Artillery>();
            attackingArmy.AddUnit<Tank>();
            attackingArmy.AddUnit<Tank>();

            var defendingArmy = new Army(new SimpleLossPicker());
            defendingArmy.AddUnit<Infantry>();
            defendingArmy.AddUnit<Infantry>();
            defendingArmy.AddUnit<Infantry>();
            defendingArmy.AddUnit<Infantry>();
            defendingArmy.AddUnit<Artillery>();
            defendingArmy.AddUnit<Tank>();

            var battle = new Battle(attackingArmy, defendingArmy);

            PrintSummary(new RatioBattleSimulationSummary(Analysis.Simulate(battle, 1000000)));
        }

        static void PrintSummary(RatioBattleSimulationSummary summary)
        {
            Console.WriteLine($"attacker wins: {summary.AttackerWinRatio}, " +
                $"defender wins: {summary.DefenderWinRatio}, draws: {summary.DrawRatio}");
        }
    }
}