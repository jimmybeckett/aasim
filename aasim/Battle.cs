using Microsoft.Extensions.Logging;

namespace aasim
{
    public class Battle
    {
        public Force Attackers { get; init; }
        public Force Defenders { get; init; }

        public Battle(Force attackers, Force defenders)
            => (Attackers, Defenders) = (attackers, defenders);

        public Battle(Battle other)
            => (Attackers, Defenders) = (new Force(other.Attackers), new Force(other.Defenders));

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
