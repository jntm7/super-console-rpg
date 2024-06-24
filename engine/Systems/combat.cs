namespace SuperConsoleRPG.Engine.Systems
{
    public class CombatSystem
    {
        public CombatResult Fight(Character attacker, Character defender)
        {
            // Calculate damage
            int damage = attacker.Attack - defender.Defense;
            if (damage < 0) damage = 0;

            // Apply damage to defender
            defender.TakeDamage(damage);

            // Check if defender is still alive
            if (!defender.IsAlive())
            {
                return new CombatResult
                {
                    Winner = attacker,
                    Loser = defender,
                    DamageDealt = damage
                };
            }

            // Return the result of the attack
            return new CombatResult
            {
                Winner = null,
                Loser = null,
                DamageDealt = damage
            };
        }
    }

    public class CombatResult
    {
        public Character Winner { get; set; }
        public Character Loser { get; set; }
        public int DamageDealt { get; set; }
    }
}