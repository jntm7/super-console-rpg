namespace SuperConsoleRPG.Engine.Entities
{
    public class Enemy : Character
    {
        public int ExperienceReward { get; set; }

        public Enemy(string name, int maxHealth, int attack, int defense, int experienceReward)
            : base(name, maxHealth, attack, defense)
        {
            ExperienceReward = experienceReward;
        }
    }
}
