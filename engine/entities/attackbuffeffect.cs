namespace SuperConsoleRPG.Engine.Entities
{
    public class AttackBuffEffect : ItemEffect
    {
        public int AttackIncrease { get; set; }
        public int Duration { get; set; }
        private int turnsRemaining;

        public AttackBuffEffect(string name, string description, int attackIncrease, int duration)
            : base(name, description)
        {
            AttackIncrease = attackIncrease;
            Duration = duration;
            turnsRemaining = duration;
        }

        public override void Apply(Character character)
        {
            if (turnsRemaining > 0)
            {
                character.Attack += AttackIncrease;
                Console.WriteLine($"{character.Name}'s attack increased by {AttackIncrease} for {Duration} turns.");
            }
        }

        public void Tick(Character character)
        {
            if (turnsRemaining > 0)
            {
                turnsRemaining--;
                if (turnsRemaining == 0)
                {
                    character.Attack -= AttackIncrease;
                    Console.WriteLine($"{character.Name}'s attack buff has worn off.");
                }
            }
        }
    }
}