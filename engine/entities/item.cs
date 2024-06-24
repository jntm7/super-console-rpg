namespace SuperConsoleRPG.Engine.Entities
{
    public enum ItemEffect
    {
        Heal,
        AttackBuff,
        DefenseBuff
    }

    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ItemEffect Effect { get; set; }
        public int EffectValue { get; set; }

        public Item(string name, string description, ItemEffect effect, int effectValue)
        {
            Name = name;
            Description = description;
            Effect = effect;
            EffectValue = effectValue;
        }
    }
}