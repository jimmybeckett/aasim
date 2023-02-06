namespace aasim
{
    public abstract class Unit
    {
        private static readonly Random _random = new();

        protected Unit(int attack, int defense, int health, int cost) =>
            (AttackingCombatScore, DefendingCombatScore, Health, Cost) = (attack, defense, health, cost);

        public int AttackingCombatScore { get; init; }
        public int DefendingCombatScore { get; init; }
        public int Health { get; init; }
        public int Cost { get; init; }

        public virtual bool Attack(Battle context, int i) 
            => SimulateD6Lte(AttackingCombatScore);

        public virtual bool Defend(Battle context, int i)
            => SimulateD6Lte(DefendingCombatScore);

        public virtual bool CanRetreat(bool isAggressor) => isAggressor;

        public override string ToString() => GetType().Name;
        
        protected static bool SimulateD6Lte(int n) => 1 + _random.Next(6) <= n;
    }
}
