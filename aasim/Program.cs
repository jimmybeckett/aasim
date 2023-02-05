using System.Diagnostics;

namespace aasim
{
    class TestClass
    {
        static void Main(string[] args)
        {
            var attackingForce = new Force(new SimpleLossPicker());
            attackingForce.AddUnit<Infantry>();
            attackingForce.AddUnit<Infantry>();
            attackingForce.AddUnit<Infantry>();
            attackingForce.AddUnit<Artillery>();
            attackingForce.AddUnit<Artillery>();
            attackingForce.AddUnit<Tank>();
            attackingForce.AddUnit<Tank>();
            attackingForce.AddUnit<Fighter>();
            attackingForce.AddUnit<Fighter>();
            attackingForce.AddUnit<TacticalBomber>();
            attackingForce.AddUnit<StrategicBomber>();

            var defendingForce = new Force(new SimpleLossPicker());
            defendingForce.AddUnit<Infantry>();
            defendingForce.AddUnit<Infantry>();
            defendingForce.AddUnit<Infantry>();
            defendingForce.AddUnit<Infantry>();
            defendingForce.AddUnit<Artillery>();
            defendingForce.AddUnit<Tank>();
            defendingForce.AddUnit<Fighter>();
            defendingForce.AddUnit<TacticalBomber>();
            defendingForce.AddUnit<TacticalBomber>();
            defendingForce.AddUnit<StrategicBomber>();
            defendingForce.AddUnit<StrategicBomber>();

            var battle = new Battle(attackingForce, defendingForce);

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