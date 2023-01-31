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
            result.AttackerWinRatio.Should().BeApproximately(.174, delta);
            result.DefenderWinRatio.Should().BeApproximately(.804, delta);
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
            result.AttackerWinRatio.Should().BeApproximately(.416, delta);
            result.DefenderWinRatio.Should().BeApproximately(.532, delta);
            result.DrawRatio.Should().BeApproximately(.052, delta);
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
            result.AttackerWinRatio.Should().BeApproximately(.314, delta);
            result.DefenderWinRatio.Should().BeApproximately(.599, delta);
            result.DrawRatio.Should().BeApproximately(.087, delta);
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
            result.AttackerWinRatio.Should().BeApproximately(.758, delta);
            result.DefenderWinRatio.Should().BeApproximately(.214, delta);
            result.DrawRatio.Should().BeApproximately(.028, delta);
        }

        record RatioBattleSimulationSummary
        {
            public double AttackerWinRatio { get; init; }
            public double DefenderWinRatio { get; init;  }
            public double DrawRatio { get; init;  }

            public RatioBattleSimulationSummary() { }

            public RatioBattleSimulationSummary(BattleSimulationSummary summary)
            {
                double rounds = summary.AttackerWins + summary.DefenderWins + summary.Draws;
                AttackerWinRatio = summary.AttackerWins / rounds;
                DefenderWinRatio = summary.DefenderWins / rounds;
                DrawRatio = summary.Draws / rounds;
            }
        }
    }
}