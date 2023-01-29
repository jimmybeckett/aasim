namespace aasim
{
    class TestClass
    {
        static void Main(string[] args)
        {
            var attackingArmy = new Army(new SimpleLossPicker());
            attackingArmy.AddUnit<Infantry>();
            attackingArmy.AddUnit<Infantry>();
            attackingArmy.AddUnit<Artillery>();
            attackingArmy.AddUnit<Artillery>();

            var defendingArmy = new Army(new SimpleLossPicker());
            defendingArmy.AddUnit<Infantry>();
            defendingArmy.AddUnit<Infantry>();
            defendingArmy.AddUnit<Infantry>();

            var battle = new Battle(attackingArmy, defendingArmy);

            PrintSummary(Analysis.Simulate(battle, 100000));
        }

        static void PrintSummary(BattleSimulationSummary summary)
        {
            Console.WriteLine($"attacker wins: {summary.AttackerWins}, " +
                $"defender wins: {summary.DefenderWins}, draws: {summary.Draws}");
        }
    }
}