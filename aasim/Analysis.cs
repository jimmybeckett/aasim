using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aasim
{
    internal class Analysis
    {
        public static BattleSimulationSummary Simulate(Battle battle, int rounds)
        {
            var attackerWins = 0;
            var defenderWins = 0;
            var draws = 0;
            for (int i = 0; i < rounds; i++)
            {
                switch (((Battle) battle.Clone()).Resolve())
                {
                    case BattleResult.AttackersWin:
                        attackerWins++;
                        break;
                    case BattleResult.DefendersWin:
                        defenderWins++;
                        break;
                    case BattleResult.Draw:
                        draws++;
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }
            return new BattleSimulationSummary()
            {
                AttackerWins = attackerWins,
                DefenderWins = defenderWins,
                Draws = draws
            };
        }
    }
}
