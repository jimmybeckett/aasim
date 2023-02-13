using System.Diagnostics;

namespace aasim
{
    class TestClass
    {
        static void Main(string[] args)
        {
            var attackingForce = new Force(new SimpleLossPicker());
            attackingForce.AddUnit<TacticalBomber>(4);

            var defendingForce = new Force(new SimpleLossPicker());
            defendingForce.AddUnit<AAGun>(2);
            defendingForce.AddUnit<Fighter>(3);

            var battle = new Battle(attackingForce, defendingForce);

            var stopwatch = Stopwatch.StartNew();

            PrintSummary(new RatioBattleSimulationSummary(Analysis.Simulate(battle, 1000000)));

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