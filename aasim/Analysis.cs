using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aasim
{
    public class Analysis
    {
        public static BattleSimulationSummary Simulate(Battle battle, int rounds)
            => Enumerable.Range(0, rounds)
            .AsParallel()
            .Select(_ => ((Battle)battle.Clone()).Resolve())
            .Aggregate(new BattleSimulationSummary(), (summary, result) => summary + result);
    }
}
