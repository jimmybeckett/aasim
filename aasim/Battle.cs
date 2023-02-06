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
            return Result();
        }

        public BattleResult? Result()
        {
            if (Attackers.IsDefeated() && Defenders.IsDefeated())
            {
                return BattleResult.Draw;
            }
            if (Attackers.IsDefeated())
            {
                return BattleResult.DefendersWin;
            }
            if (Defenders.IsDefeated())
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
