namespace tests
{
    public class AirUnitTests
    {
        public const int rounds = 10000;
        public const double delta = 0.02;

        [Fact]
        public void Fighters_Only()
        {
            var attackingArmy = new Army(new SimpleLossPicker());
            attackingArmy.AddUnit<Fighter>();
            attackingArmy.AddUnit<Fighter>();
            attackingArmy.AddUnit<Fighter>();

            var defendingArmy = new Army(new SimpleLossPicker());
            defendingArmy.AddUnit<Fighter>();
            defendingArmy.AddUnit<Fighter>();

            var battle = new Battle(attackingArmy, defendingArmy);
            var result = new RatioBattleSimulationSummary(Analysis.Simulate(battle, rounds));
            result.AttackerWinRatio.Should().BeApproximately(.743, delta);
            result.DefenderWinRatio.Should().BeApproximately(.164, delta);
            result.DrawRatio.Should().BeApproximately(.092, delta);
        }

        [Fact]
        public void TacticalBomber_Tank()
        {
            var attackingArmy = new Army(new SimpleLossPicker());
            attackingArmy.AddUnit<Tank>();
            attackingArmy.AddUnit<Tank>();
            attackingArmy.AddUnit<TacticalBomber>();
            attackingArmy.AddUnit<TacticalBomber>();

            var defendingArmy = new Army(new SimpleLossPicker());
            defendingArmy.AddUnit<Infantry>();
            defendingArmy.AddUnit<Infantry>();
            defendingArmy.AddUnit<Infantry>();

            var battle = new Battle(attackingArmy, defendingArmy);
            var result = new RatioBattleSimulationSummary(Analysis.Simulate(battle, rounds));
            result.AttackerWinRatio.Should().BeApproximately(.957, delta);
            result.DefenderWinRatio.Should().BeApproximately(.030, delta);
            result.DrawRatio.Should().BeApproximately(.013, delta);
        }

        [Fact]
        public void TacticalBomber_Fighter()
        {
            var attackingArmy = new Army(new SimpleLossPicker());
            attackingArmy.AddUnit<TacticalBomber>();
            attackingArmy.AddUnit<Fighter>();

            var defendingArmy = new Army(new SimpleLossPicker());
            defendingArmy.AddUnit<Infantry>();
            defendingArmy.AddUnit<Infantry>();
            defendingArmy.AddUnit<TacticalBomber>();

            var battle = new Battle(attackingArmy, defendingArmy);
            var result = new RatioBattleSimulationSummary(Analysis.Simulate(battle, rounds));
            result.AttackerWinRatio.Should().BeApproximately(.201, delta);
            result.DefenderWinRatio.Should().BeApproximately(.711, delta);
            result.DrawRatio.Should().BeApproximately(.088, delta);
        }

        [Fact]
        public void StrategicBomber_Fighter()
        {
            var attackingArmy = new Army(new SimpleLossPicker());
            attackingArmy.AddUnit<StrategicBomber>();
            attackingArmy.AddUnit<Fighter>();

            var defendingArmy = new Army(new SimpleLossPicker());
            defendingArmy.AddUnit<Infantry>();
            defendingArmy.AddUnit<Infantry>();
            defendingArmy.AddUnit<TacticalBomber>();

            var battle = new Battle(attackingArmy, defendingArmy);
            var result = new RatioBattleSimulationSummary(Analysis.Simulate(battle, rounds));
            result.AttackerWinRatio.Should().BeApproximately(.167, delta);
            result.DefenderWinRatio.Should().BeApproximately(.757, delta);
            result.DrawRatio.Should().BeApproximately(.076, delta);
        }

        [Fact]
        public void AirBattle()
        {
            var attackingArmy = new Army(new SimpleLossPicker());
            attackingArmy.AddUnit<Fighter>();
            attackingArmy.AddUnit<Fighter>();
            attackingArmy.AddUnit<TacticalBomber>();
            attackingArmy.AddUnit<StrategicBomber>();

            var defendingArmy = new Army(new SimpleLossPicker());
            defendingArmy.AddUnit<Fighter>();
            defendingArmy.AddUnit<TacticalBomber>();
            defendingArmy.AddUnit<TacticalBomber>();
            defendingArmy.AddUnit<StrategicBomber>();
            defendingArmy.AddUnit<StrategicBomber>();

            var battle = new Battle(attackingArmy, defendingArmy);
            var result = new RatioBattleSimulationSummary(Analysis.Simulate(battle, rounds));
            result.AttackerWinRatio.Should().BeApproximately(.170, delta);
            result.DefenderWinRatio.Should().BeApproximately(.784, delta);
            result.DrawRatio.Should().BeApproximately(.045, delta);
        }
    }
}
