namespace SuperConsoleRPG.Engine.Entities
{
    public class HealingEffect : ItemEffect
    {
        public int HealAmount { get; set; }

        public HealingEffect(string name, string description, int healAmount)
            : base(name, description)
        {
            HealAmount = healAmount;
        }

        public override void Apply(Character character)
        {
            int healingAmount = HealAmount;

            if (character.Health + HealAmount > character.MaxHealth)
            {
                healingAmount = character.MaxHealth - character.Health;
            }

            character.Heal(healingAmount);
            Console.WriteLine($"{character.Name} healed for {healingAmount} health points.");
        }
    }
}