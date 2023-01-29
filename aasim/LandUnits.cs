namespace aasim
{
    internal class Tank : Unit
    {
        public Tank() : base(3, 3, 1, 6) { }
    }

    internal class Artillery : Unit
    {
        public Artillery() : base(2, 2, 1, 4) { }
    }

    internal class Infantry : Unit
    {
        public Infantry() : base(1, 2, 1, 3) { }

        public override bool Attack(Battle context, int i)
        {
            var numArtillery = context.Attackers.Count<Artillery>();
            if (i < numArtillery)
            {
                return Roll() <= AttackingCombatScore + 1;
            }
            return base.Attack(context, i);
        }
    }
}
