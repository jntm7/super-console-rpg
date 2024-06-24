namespace SuperConsoleRPG.Engine.Entities
{
    public abstract class ItemEffect
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ItemEffect(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public abstract void Apply(Character character);
    }
}