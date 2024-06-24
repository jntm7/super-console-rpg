namespace SuperConsoleRPG.Engine.Systems
{
    public class InventorySystem
    {
        private List<Item> items;
        private Character character;

        public InventorySystem(Character character)
        {
            items = new List<Item>();
            this.character = character;
        }

        public void AddItem(Item item)
        {
            items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            items.Remove(item);
        }

        public void EquipItem(Equipment equipment)
        {
            // For simplicity, let's assume a character can only equip one item at a time
            character.Attack += equipment.AttackBonus;
            character.Defense += equipment.DefenseBonus;
        }

        public void UnequipItem(Equipment equipment)
        {
            character.Attack -= equipment.AttackBonus;
            character.Defense -= equipment.DefenseBonus;
        }

        public List<Item> GetItems()
        {
            return new List<Item>(items);
        }
    }
}