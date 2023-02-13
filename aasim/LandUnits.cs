namespace aasim
{
    public class Tank : Unit
    {
        public Tank() : base(3, 3, 1, 6) { }
    }

    public class Artillery : Unit
    {
        public Artillery() : base(2, 2, 1, 4) { }
    }

    public class Infantry : Unit
    {
        public Infantry() : base(1, 2, 1, 3) { }

        public override int Attack(Battle context, int i)
        {
            if (i < context.Attackers.Count<Artillery>())
            {
                return SimulateD6Lte(AttackingCombatScore + 1);
            }
            return base.Attack(context, i);
        }
    }

    public class MechInfantry : Unit
    {
        public MechInfantry() : base(1, 2, 1, 4) { }

        public override int Attack(Battle context, int i)
        {
            if (i < context.Attackers.Count<Artillery>())
            {
                return SimulateD6Lte(AttackingCombatScore + 1);
            }
            return base.Attack(context, i);
        }
    }

    public class AAGun : Unit
    {
        public AAGun() : base(0, 0, 1, 5) { }

        private const int _maxTargets = 3;

        private const int CombatScore = 1;

        public override int PreBattleDefense(Battle context, int i)
        {
            var numEnemyPlanes = context.Attackers.Count<Fighter>()
                + context.Attackers.Count<TacticalBomber>()
                + context.Attackers.Count<StrategicBomber>();
            var numViableTargets = Math.Max(numEnemyPlanes - _maxTargets * i, 0);
            return Enumerable.Range(0, Math.Min(numViableTargets, _maxTargets))
                .Select(_ => SimulateD6Lte(CombatScore))
                .Sum();
        }
    }
}
