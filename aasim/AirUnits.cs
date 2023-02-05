namespace aasim
{
    public class Fighter : Unit
    {
        public Fighter() : base(3, 4, 1, 10) { }
    }

    public class TacticalBomber : Unit
    {
        public TacticalBomber() : base(3, 3, 1, 11) { }

        public override bool Attack(Battle context, int i)
        {
            var numFighters = context.Attackers.Count<Fighter>();
            var numTanks = context.Attackers.Count<Tank>();
            if (i < numFighters + numTanks)
            {
                return Roll() <= AttackingCombatScore + 1;
            }
            return base.Attack(context, i);
        }
    }

    public class StrategicBomber : Unit
    {
        public StrategicBomber() : base(3, 3, 1, 10) { }
    }
}
