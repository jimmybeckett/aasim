using aasim;

namespace tests
{
    public class UnitTest1
    {
        public const int rounds = 10000;
        public const double delta = 0.02;

        [Fact]
        public void Infantry_Only()
        {
            var attackingArmy = new Army(new SimpleLossPicker());
            attackingArmy.AddUnit<Infantry>();
            attackingArmy.AddUnit<Infantry>();
            attackingArmy.AddUnit<Infantry>();

            var defendingArmy = new Army(new SimpleLossPicker());
            defendingArmy.AddUnit<Infantry>();
            defendingArmy.AddUnit<Infantry>();
            defendingArmy.AddUnit<Infantry>();

            var battle = new Battle(attackingArmy, defendingArmy);
            var result = new RatioBattleSimulationSummary(Analysis.Simulate(battle, rounds));
            result.AttackerWinRatio.Should().BeApproximately(.176, delta);
            result.DefenderWinRatio.Should().BeApproximately(.802, delta);
            result.DrawRatio.Should().BeApproximately(.022, delta);
        }

        [Fact]
        public void Infantry_Artillery()
        {
            var attackingArmy = new Army(new SimpleLossPicker());
            attackingArmy.AddUnit<Infantry>();
            attackingArmy.AddUnit<Infantry>();
            attackingArmy.AddUnit<Artillery>();

            var defendingArmy = new Army(new SimpleLossPicker());
            defendingArmy.AddUnit<Infantry>();
            defendingArmy.AddUnit<Infantry>();
            defendingArmy.AddUnit<Artillery>();

            var battle = new Battle(attackingArmy, defendingArmy);
            var result = new RatioBattleSimulationSummary(Analysis.Simulate(battle, rounds));
            result.AttackerWinRatio.Should().BeApproximately(.418, delta);
            result.DefenderWinRatio.Should().BeApproximately(.532, delta);
            result.DrawRatio.Should().BeApproximately(.050, delta);
        }

        [Fact]
        public void Infantry_Tank()
        {
            var attackingArmy = new Army(new SimpleLossPicker());
            attackingArmy.AddUnit<Infantry>();
            attackingArmy.AddUnit<Infantry>();
            attackingArmy.AddUnit<Tank>();

            var defendingArmy = new Army(new SimpleLossPicker());
            defendingArmy.AddUnit<Infantry>();
            defendingArmy.AddUnit<Infantry>();
            defendingArmy.AddUnit<Tank>();

            var battle = new Battle(attackingArmy, defendingArmy);
            var result = new RatioBattleSimulationSummary(Analysis.Simulate(battle, rounds));
            result.AttackerWinRatio.Should().BeApproximately(.316, delta);
            result.DefenderWinRatio.Should().BeApproximately(.597, delta);
            result.DrawRatio.Should().BeApproximately(.088, delta);
        }

        [Fact]
        public void Infantry_Artillery_Tank()
        {
            var attackingArmy = new Army(new SimpleLossPicker());
            attackingArmy.AddUnit<Infantry>();
            attackingArmy.AddUnit<Infantry>();
            attackingArmy.AddUnit<Infantry>();
            attackingArmy.AddUnit<Artillery>();
            attackingArmy.AddUnit<Artillery>();
            attackingArmy.AddUnit<Tank>();
            attackingArmy.AddUnit<Tank>();

            var defendingArmy = new Army(new SimpleLossPicker());
            defendingArmy.AddUnit<Infantry>();
            defendingArmy.AddUnit<Infantry>();
            defendingArmy.AddUnit<Infantry>();
            defendingArmy.AddUnit<Infantry>();
            defendingArmy.AddUnit<Artillery>();
            defendingArmy.AddUnit<Tank>();

            var battle = new Battle(attackingArmy, defendingArmy);
            var result = new RatioBattleSimulationSummary(Analysis.Simulate(battle, rounds));
            result.AttackerWinRatio.Should().BeApproximately(.756, delta);
            result.DefenderWinRatio.Should().BeApproximately(.215, delta);
            result.DrawRatio.Should().BeApproximately(.029, delta);
        }
    }
}