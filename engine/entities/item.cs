namespace SuperConsoleRPG.Engine.Entities
{
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ItemEffect Effect { get; set; }

        public Item(string name, string description, ItemEffect effect)
        {
            Name = name;
            Description = description;
            Effect = effect;
        }

        public void Use(Character character)
        {
            Effect.Apply(character);
        }
    }
}