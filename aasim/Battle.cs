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

        public BattleResult Resolve(bool conductPreBattleCombat = true)
        {
            BattleResult? result = null;
            if (conductPreBattleCombat)
            {
                result = ConductPreBattleCombat();
            }
            while (!result.HasValue)
            {
                result = Advance();
            }
            return result.Value;
        }

        public BattleResult? ConductPreBattleCombat()
        {
            var attackerHits = Attackers.SimulatePreBattleAttack(this);
            var defenderHits = Defenders.SimulatePreBattleDefense(this);
            Attackers.ApplyHits(defenderHits);
            Defenders.ApplyHits(attackerHits);
            return Result();
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
