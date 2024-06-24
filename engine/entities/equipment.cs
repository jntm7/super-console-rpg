namespace SuperConsoleRPG.Engine.Entities
{
    public class Equipment : Item
    {
        public int AttackBonus { get; set; }
        public int DefenseBonus { get; set; }

        public Equipment(string name, string description, int attackBonus, int defenseBonus)
            : base(name, description)
        {
            AttackBonus = attackBonus;
            DefenseBonus = defenseBonus;
        }
    }
}