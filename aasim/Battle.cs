using Microsoft.Extensions.Logging;

namespace aasim
{
    internal class Battle : ICloneable
    {
        public Army Attackers { get; init; }
        public Army Defenders { get; init; }

        public Battle(Army attackers, Army defenders)
            => (Attackers, Defenders) = (attackers, defenders);

        public BattleResult Resolve()
        {
            BattleResult? result;
            do
            {
                result = Advance();
            } while (!result.HasValue);
            return result.Value;
        }

        public BattleResult? Advance()
        {
            var attackerHits = Attackers.SimulateAttack(this);
            var defenderHits = Defenders.SimulateDefense(this);

            Attackers.ApplyHits(defenderHits);
            Defenders.ApplyHits(attackerHits);

            if (Attackers.IsDestroyed() && Defenders.IsDestroyed())
            {
                return BattleResult.Draw;
            }
            if (Attackers.IsDestroyed())
            {
                return BattleResult.DefendersWin;
            }
            if (Defenders.IsDestroyed())
            {
                return BattleResult.AttackersWin;
            }
            return null;
        }

        public object Clone() 
            => new Battle((Army) Attackers.Clone(), (Army) Defenders.Clone());
    }

    enum BattleResult
    {
        AttackersWin, DefendersWin, Draw
    }

    record BattleSimulationSummary
    {
        public int AttackerWins { get; init; }
        public int DefenderWins { get; init; }
        public int Draws { get; init; }
    }
}
