namespace tests
{
    public class AirUnitTests
    {
        public const int rounds = 10000;
        public const double delta = 0.02;

        [Fact]
        public void Fighters_Only()
        {
            var attackingForce = new Force(new SimpleLossPicker());
            attackingForce.AddUnit<Fighter>();
            attackingForce.AddUnit<Fighter>();
            attackingForce.AddUnit<Fighter>();

            var defendingForce = new Force(new SimpleLossPicker());
            defendingForce.AddUnit<Fighter>();
            defendingForce.AddUnit<Fighter>();

            var battle = new Battle(attackingForce, defendingForce);
            var result = new RatioBattleSimulationSummary(Analysis.Simulate(battle, rounds));
            result.AttackerWinRatio.Should().BeApproximately(.743, delta);
            result.DefenderWinRatio.Should().BeApproximately(.164, delta);
            result.DrawRatio.Should().BeApproximately(.092, delta);
        }

        [Fact]
        public void TacticalBomber_Tank()
        {
            var attackingForce = new Force(new SimpleLossPicker());
            attackingForce.AddUnit<Tank>();
            attackingForce.AddUnit<Tank>();
            attackingForce.AddUnit<TacticalBomber>();
            attackingForce.AddUnit<TacticalBomber>();

            var defendingForce = new Force(new SimpleLossPicker());
            defendingForce.AddUnit<Infantry>();
            defendingForce.AddUnit<Infantry>();
            defendingForce.AddUnit<Infantry>();

            var battle = new Battle(attackingForce, defendingForce);
            var result = new RatioBattleSimulationSummary(Analysis.Simulate(battle, rounds));
            result.AttackerWinRatio.Should().BeApproximately(.957, delta);
            result.DefenderWinRatio.Should().BeApproximately(.030, delta);
            result.DrawRatio.Should().BeApproximately(.013, delta);
        }

        [Fact]
        public void TacticalBomber_Fighter()
        {
            var attackingForce = new Force(new SimpleLossPicker());
            attackingForce.AddUnit<TacticalBomber>();
            attackingForce.AddUnit<Fighter>();

            var defendingForce = new Force(new SimpleLossPicker());
            defendingForce.AddUnit<Infantry>();
            defendingForce.AddUnit<Infantry>();
            defendingForce.AddUnit<TacticalBomber>();

            var battle = new Battle(attackingForce, defendingForce);
            var result = new RatioBattleSimulationSummary(Analysis.Simulate(battle, rounds));
            result.AttackerWinRatio.Should().BeApproximately(.201, delta);
            result.DefenderWinRatio.Should().BeApproximately(.711, delta);
            result.DrawRatio.Should().BeApproximately(.088, delta);
        }

        [Fact]
        public void StrategicBomber_Fighter()
        {
            var attackingForce = new Force(new SimpleLossPicker());
            attackingForce.AddUnit<StrategicBomber>();
            attackingForce.AddUnit<Fighter>();

            var defendingForce = new Force(new SimpleLossPicker());
            defendingForce.AddUnit<Infantry>();
            defendingForce.AddUnit<Infantry>();
            defendingForce.AddUnit<TacticalBomber>();

            var battle = new Battle(attackingForce, defendingForce);
            var result = new RatioBattleSimulationSummary(Analysis.Simulate(battle, rounds));
            result.AttackerWinRatio.Should().BeApproximately(.167, delta);
            result.DefenderWinRatio.Should().BeApproximately(.757, delta);
            result.DrawRatio.Should().BeApproximately(.076, delta);
        }

        [Fact]
        public void AirBattle()
        {
            var attackingForce = new Force(new SimpleLossPicker());
            attackingForce.AddUnit<Fighter>();
            attackingForce.AddUnit<Fighter>();
            attackingForce.AddUnit<TacticalBomber>();
            attackingForce.AddUnit<StrategicBomber>();

            var defendingForce = new Force(new SimpleLossPicker());
            defendingForce.AddUnit<Fighter>();
            defendingForce.AddUnit<TacticalBomber>();
            defendingForce.AddUnit<TacticalBomber>();
            defendingForce.AddUnit<StrategicBomber>();
            defendingForce.AddUnit<StrategicBomber>();

            var battle = new Battle(attackingForce, defendingForce);
            var result = new RatioBattleSimulationSummary(Analysis.Simulate(battle, rounds));
            result.AttackerWinRatio.Should().BeApproximately(.170, delta);
            result.DefenderWinRatio.Should().BeApproximately(.784, delta);
            result.DrawRatio.Should().BeApproximately(.045, delta);
        }
    }
}
