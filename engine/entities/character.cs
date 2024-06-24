namespace SuperConsoleRPG.Engine.Entities
{
    public class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        private const int ExperiencePerLevel = 100;
        public Character(string name, int maxHealth, int attack, int defense, int level = 1)
        {
            Name = name;
            MaxHealth = maxHealth;
            Health = maxHealth;
            Attack = attack;
            Defense = defense;
            Level = level;
            Experience = 0;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
        }

        public void Heal(int amount)
        {
            Health += amount;
            if (Health > MaxHealth) Health = MaxHealth;
        }

        public bool IsAlive()
        {
            return Health > 0;
        }

        public void GainExperience(int exp)
        {
            Experience += exp;
            while (Experience >= ExperienceRequiredForNextLevel())
            {
                LevelUp();
            }
        }

        private void LevelUp()
        {
            Experience -= ExperienceRequiredForNextLevel();
            Level++;
            MaxHealth += 10;
            Health = MaxHealth;
            Attack += 5;
            Defense += 5;
        }

        private int ExperienceRequiredForNextLevel()
        {
            return Level * ExperiencePerLevel;
        }

        private List<ItemEffect> activeEffects = new List<ItemEffect>();

        public void AddEffect(ItemEffect effect)
        {
            effect.Apply(this);
            activeEffects.Add(effect);
        }

        public void TickEffects()
        {
            foreach (var effect in activeEffects)
            {
                if (effect is AttackBuffEffect attackBuff)
                {
                    attackBuff.Tick(this);
                }
                else if (effect is DefenseBuffEffect defenseBuff)
                {
                    defenseBuff.Tick(this);
                }
            }
            activeEffects.RemoveAll(effect => 
                (effect is AttackBuffEffect attackBuff && attackBuff.Duration == 0) ||
                (effect is DefenseBuffEffect defenseBuff && defenseBuff.Duration == 0));
        }
    }
}
