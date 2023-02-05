using System.Diagnostics;

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
            attackingArmy.AddUnit<Fighter>();
            attackingArmy.AddUnit<Fighter>();
            attackingArmy.AddUnit<TacticalBomber>();
            attackingArmy.AddUnit<StrategicBomber>();

            var defendingArmy = new Army(new SimpleLossPicker());
            defendingArmy.AddUnit<Infantry>();
            defendingArmy.AddUnit<Infantry>();
            defendingArmy.AddUnit<Infantry>();
            defendingArmy.AddUnit<Infantry>();
            defendingArmy.AddUnit<Artillery>();
            defendingArmy.AddUnit<Tank>();
            defendingArmy.AddUnit<Fighter>();
            defendingArmy.AddUnit<TacticalBomber>();
            defendingArmy.AddUnit<TacticalBomber>();
            defendingArmy.AddUnit<StrategicBomber>();
            defendingArmy.AddUnit<StrategicBomber>();

            var battle = new Battle(attackingArmy, defendingArmy);

            var stopwatch = Stopwatch.StartNew();

            PrintSummary(new RatioBattleSimulationSummary(Analysis.Simulate(battle, 100000)));

            stopwatch.Stop();

            Console.WriteLine($"completed in {stopwatch.ElapsedMilliseconds} ms");
        }

        static void PrintSummary(RatioBattleSimulationSummary summary)
        {
            Console.WriteLine($"attacker wins: {summary.AttackerWinRatio}, " +
                $"defender wins: {summary.DefenderWinRatio}, draws: {summary.DrawRatio}");
        }
    }
}