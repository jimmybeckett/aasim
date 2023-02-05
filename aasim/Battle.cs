using Microsoft.Extensions.Logging;

namespace aasim
{
    public class Battle
    {
        public Army Attackers { get; init; }
        public Army Defenders { get; init; }

        public Battle(Army attackers, Army defenders)
            => (Attackers, Defenders) = (attackers, defenders);

        public Battle(Battle other)
            => (Attackers, Defenders) = (new Army(other.Attackers), new Army(other.Defenders));

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
    }

    public enum BattleResult
    {
        AttackersWin, DefendersWin, Draw
    }
}
