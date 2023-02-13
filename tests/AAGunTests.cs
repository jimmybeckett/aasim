namespace tests
{
    public class AAGunTests
    {
        public const int rounds = 10000;
        public const double delta = 0.02;

        [Fact]
        public void AAGun_UnderutilizedAA()
        {
            var attackingForce = new Force(new SimpleLossPicker());
            attackingForce.AddUnit<Fighter>(1);
            attackingForce.AddUnit<TacticalBomber>(1);

            var defendingForce = new Force(new SimpleLossPicker());
            defendingForce.AddUnit<AAGun>();
            defendingForce.AddUnit<Fighter>();

            var battle = new Battle(attackingForce, defendingForce);
            var result = new RatioBattleSimulationSummary(Analysis.Simulate(battle, rounds));
            result.AttackerWinRatio.Should().BeApproximately(.423, delta);
            result.DefenderWinRatio.Should().BeApproximately(.443, delta);
            result.DrawRatio.Should().BeApproximately(.133, delta);
        }

        [Fact]
        public void AAGun_OverUtilizedAA()
        {
            var attackingForce = new Force(new SimpleLossPicker());
            attackingForce.AddUnit<TacticalBomber>(4);

            var defendingForce = new Force(new SimpleLossPicker());
            defendingForce.AddUnit<AAGun>(2);
            defendingForce.AddUnit<Fighter>(3);

            var battle = new Battle(attackingForce, defendingForce);
            var result = new RatioBattleSimulationSummary(Analysis.Simulate(battle, rounds));
            result.AttackerWinRatio.Should().BeApproximately(.089, delta);
            result.DefenderWinRatio.Should().BeApproximately(.875, delta);
            result.DrawRatio.Should().BeApproximately(.036, delta);
        }

        [Fact]
        public void AAGun_AAvsFighter()
        {
            var attackingForce = new Force(new SimpleLossPicker());
            attackingForce.AddUnit<Fighter>();

            var defendingForce = new Force(new SimpleLossPicker());
            defendingForce.AddUnit<AAGun>();

            var battle = new Battle(attackingForce, defendingForce);
            var result = new RatioBattleSimulationSummary(Analysis.Simulate(battle, rounds));
            result.DefenderWinRatio.Should().BeApproximately(0.167, delta);
            result.AttackerWinRatio.Should().BeApproximately(0.833, delta);
            result.DrawRatio.Should().BeApproximately(0, delta);
        }

        [Fact]
        public void AAGun_AAvs2Fighters()
        {
            var attackingForce = new Force(new SimpleLossPicker());
            attackingForce.AddUnit<Fighter>(2);

            var defendingForce = new Force(new SimpleLossPicker());
            defendingForce.AddUnit<AAGun>();

            var battle = new Battle(attackingForce, defendingForce);
            var result = new RatioBattleSimulationSummary(Analysis.Simulate(battle, rounds));
            result.DefenderWinRatio.Should().BeApproximately(0.028, delta);
            result.AttackerWinRatio.Should().BeApproximately(0.972, delta);
            result.DrawRatio.Should().BeApproximately(0, delta);
        }
    }
}
