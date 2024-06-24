namespace SuperConsoleRPG.Engine.Entities
{
    public class DefenseBuffEffect : ItemEffect
    {
        public int DefenseIncrease { get; set; }
        public int Duration { get; set; }
        private int turnsRemaining;

        public DefenseBuffEffect(string name, string description, int defenseIncrease, int duration)
            : base(name, description)
        {
            DefenseIncrease = defenseIncrease;
            Duration = duration;
            turnsRemaining = duration;
        }

        public override void Apply(Character character)
        {
            if (turnsRemaining > 0)
            {
                character.Defense += DefenseIncrease;
                Console.WriteLine($"{character.Name}'s defense increased by {DefenseIncrease} for {Duration} turns.");
            }
        }

        public void Tick(Character character)
        {
            if (turnsRemaining > 0)
            {
                turnsRemaining--;
                if (turnsRemaining == 0)
                {
                    character.Defense -= DefenseIncrease;
                    Console.WriteLine($"{character.Name}'s defense buff has worn off.");
                }
            }
        }
    }
}