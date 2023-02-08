using System.Diagnostics;

namespace aasim
{
    class TestClass
    {
        static void Main(string[] args)
        {
            var attackingForce = new Force(new SimpleLossPicker());
            attackingForce.AddUnit<Infantry>(2);
            attackingForce.AddUnit<MechInfantry>();
            attackingForce.AddUnit<Artillery>(2);
            attackingForce.AddUnit<Tank>(2);

            var defendingForce = new Force(new SimpleLossPicker());
            defendingForce.AddUnit<Infantry>(2);
            defendingForce.AddUnit<MechInfantry>(2);
            defendingForce.AddUnit<Artillery>();
            defendingForce.AddUnit<Tank>();

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