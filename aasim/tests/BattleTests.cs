using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace aasim.tests
{
    internal class BattleTests
    {
        [Fact]
        public async void Infantry_Only_Basic()
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


        }
    }
}
