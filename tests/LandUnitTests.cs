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
            attackingForce.AddUnit<Infantry>(3);

            var defendingForce = new Force(new SimpleLossPicker());
            defendingForce.AddUnit<Infantry>(3);

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
            attackingForce.AddUnit<Infantry>(2);
            attackingForce.AddUnit<Artillery>();

            var defendingForce = new Force(new SimpleLossPicker());
            defendingForce.AddUnit<Infantry>(2);
            defendingForce.AddUnit<Artillery>();

            var battle = new Battle(attackingForce, defendingForce);
            var result = new RatioBattleSimulationSummary(Analysis.Simulate(battle, rounds));
            result.AttackerWinRatio.Should().BeApproximately(.418, delta);
            result.DefenderWinRatio.Should().BeApproximately(.532, delta);
            result.DrawRatio.Should().BeApproximately(.050, delta);
        }

        [Fact]
        public void Infantry_MechInfantry()
        {
            var attackingForce = new Force(new SimpleLossPicker());
            attackingForce.AddUnit<Infantry>();
            attackingForce.AddUnit<MechInfantry>(2);

            var defendingForce = new Force(new SimpleLossPicker());
            defendingForce.AddUnit<Infantry>(2);
            defendingForce.AddUnit<MechInfantry>();

            var battle = new Battle(attackingForce, defendingForce);
            var result = new RatioBattleSimulationSummary(Analysis.Simulate(battle, rounds));
            result.AttackerWinRatio.Should().BeApproximately(.176, delta);
            result.DefenderWinRatio.Should().BeApproximately(.802, delta);
            result.DrawRatio.Should().BeApproximately(.022, delta);
        }

        [Fact]
        public void MechInfantry_Artillery()
        {
            var attackingForce = new Force(new SimpleLossPicker());
            attackingForce.AddUnit<MechInfantry>(2);
            attackingForce.AddUnit<Artillery>();

            var defendingForce = new Force(new SimpleLossPicker());
            defendingForce.AddUnit<MechInfantry>(2);
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
            attackingForce.AddUnit<Infantry>(2);
            attackingForce.AddUnit<Tank>();

            var defendingForce = new Force(new SimpleLossPicker());
            defendingForce.AddUnit<Infantry>(2);
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
            var result = new RatioBattleSimulationSummary(Analysis.Simulate(battle, rounds));
            result.AttackerWinRatio.Should().BeApproximately(.775, delta);
            result.DefenderWinRatio.Should().BeApproximately(.197, delta);
            result.DrawRatio.Should().BeApproximately(.028, delta);
        }
    }
}