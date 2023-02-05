namespace tests
{
    public class LandUnitTests
    {
        public const int rounds = 10000;
        public const double delta = 0.02;

        [Fact]
        public void Infantry_Only()
        {
            var attackingForce = new Force(new SimpleLossPicker());
            attackingForce.AddUnit<Infantry>();
            attackingForce.AddUnit<Infantry>();
            attackingForce.AddUnit<Infantry>();

            var defendingForce = new Force(new SimpleLossPicker());
            defendingForce.AddUnit<Infantry>();
            defendingForce.AddUnit<Infantry>();
            defendingForce.AddUnit<Infantry>();

            var battle = new Battle(attackingForce, defendingForce);
            var result = new RatioBattleSimulationSummary(Analysis.Simulate(battle, rounds));
            result.AttackerWinRatio.Should().BeApproximately(.176, delta);
            result.DefenderWinRatio.Should().BeApproximately(.802, delta);
            result.DrawRatio.Should().BeApproximately(.022, delta);
        }

        [Fact]
        public void Infantry_Artillery()
        {
            var attackingForce = new Force(new SimpleLossPicker());
            attackingForce.AddUnit<Infantry>();
            attackingForce.AddUnit<Infantry>();
            attackingForce.AddUnit<Artillery>();

            var defendingForce = new Force(new SimpleLossPicker());
            defendingForce.AddUnit<Infantry>();
            defendingForce.AddUnit<Infantry>();
            defendingForce.AddUnit<Artillery>();

            var battle = new Battle(attackingForce, defendingForce);
            var result = new RatioBattleSimulationSummary(Analysis.Simulate(battle, rounds));
            result.AttackerWinRatio.Should().BeApproximately(.418, delta);
            result.DefenderWinRatio.Should().BeApproximately(.532, delta);
            result.DrawRatio.Should().BeApproximately(.050, delta);
        }

        [Fact]
        public void Infantry_Tank()
        {
            var attackingForce = new Force(new SimpleLossPicker());
            attackingForce.AddUnit<Infantry>();
            attackingForce.AddUnit<Infantry>();
            attackingForce.AddUnit<Tank>();

            var defendingForce = new Force(new SimpleLossPicker());
            defendingForce.AddUnit<Infantry>();
            defendingForce.AddUnit<Infantry>();
            defendingForce.AddUnit<Tank>();

            var battle = new Battle(attackingForce, defendingForce);
            var result = new RatioBattleSimulationSummary(Analysis.Simulate(battle, rounds));
            result.AttackerWinRatio.Should().BeApproximately(.316, delta);
            result.DefenderWinRatio.Should().BeApproximately(.597, delta);
            result.DrawRatio.Should().BeApproximately(.088, delta);
        }

        [Fact]
        public void LandBattle()
        {
            var attackingForce = new Force(new SimpleLossPicker());
            attackingForce.AddUnit<Infantry>();
            attackingForce.AddUnit<Infantry>();
            attackingForce.AddUnit<Infantry>();
            attackingForce.AddUnit<Artillery>();
            attackingForce.AddUnit<Artillery>();
            attackingForce.AddUnit<Tank>();
            attackingForce.AddUnit<Tank>();

            var defendingForce = new Force(new SimpleLossPicker());
            defendingForce.AddUnit<Infantry>();
            defendingForce.AddUnit<Infantry>();
            defendingForce.AddUnit<Infantry>();
            defendingForce.AddUnit<Infantry>();
            defendingForce.AddUnit<Artillery>();
            defendingForce.AddUnit<Tank>();

            var battle = new Battle(attackingForce, defendingForce);
            var result = new RatioBattleSimulationSummary(Analysis.Simulate(battle, rounds));
            result.AttackerWinRatio.Should().BeApproximately(.756, delta);
            result.DefenderWinRatio.Should().BeApproximately(.215, delta);
            result.DrawRatio.Should().BeApproximately(.029, delta);
        }
    }
}