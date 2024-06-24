// SuperConsoleRPG.Game/Scripts/GameEngine.cs
using System;
using System.Linq;
using SuperConsoleRPG.Engine.Entities;
using SuperConsoleRPG.Engine.Systems;

namespace SuperConsoleRPG.Game.Scripts
{
    public class GameEngine
    {
        private Character player;
        private Enemy enemy;
        private CombatSystem combatSystem;
        private InventorySystem inventorySystem;

        public GameEngine()
        {
            Initialize();
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                DisplayStatus();
                DisplayMenu();
                HandleInput();
            }
        }

        private void Initialize()
        {
            player = new Character("Hero", 100, 20, 10);
            enemy = new Enemy("Goblin", 50, 15, 5, 50);
            combatSystem = new CombatSystem();
            inventorySystem = new InventorySystem(player);

            inventorySystem.AddItem(new Item("Healing Potion", "Restores 20 health.", new HealingEffect("Healing Potion", "Restores 20 health.", 20)));
            inventorySystem.AddItem(new Item("Attack Buff", "Increases attack by 5 for 3 turns.", new AttackBuffEffect("Attack Buff", "Increases attack by 5 for 3 turns.", 5, 3)));
            inventorySystem.AddItem(new Item("Defense Buff", "Increases defense by 5 for 3 turns.", new DefenseBuffEffect("Defense Buff", "Increases defense by 5 for 3 turns.", 5, 3)));
        }

        private void DisplayStatus()
        {
            Console.WriteLine("Player Status:");
            Console.WriteLine($"Name: {player.Name}");
            Console.WriteLine($"Health: {player.Health}/{player.MaxHealth}");
            Console.WriteLine($"Attack: {player.Attack}");
            Console.WriteLine($"Defense: {player.Defense}");
            Console.WriteLine($"Level: {player.Level}");
            Console.WriteLine($"Experience: {player.Experience}");
            Console.WriteLine();
            Console.WriteLine("Enemy Status:");
            Console.WriteLine($"Name: {enemy.Name}");
            Console.WriteLine($"Health: {enemy.Health}/{enemy.MaxHealth}");
            Console.WriteLine($"Attack: {enemy.Attack}");
            Console.WriteLine($"Defense: {enemy.Defense}");
            Console.WriteLine();
        }

        private void DisplayMenu()
        {
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Use Item");
            Console.WriteLine("3. Run");
            Console.WriteLine();
        }

        private void HandleInput()
        {
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Attack();
                    break;
                case "2":
                    UseItem();
                    break;
                case "3":
                    RunAway();
                    break;
                default:
                    Console.WriteLine("Invalid option. Press any key to try again...");
                    Console.ReadKey();
                    break;
            }
        }

        private void Attack()
        {
            var result = combatSystem.Fight(player, enemy);
            Console.WriteLine($"You dealt {result.DamageDealt} damage to {enemy.Name}!");

            player.TickEffects();

            if (result.Winner != null)
            {
                Console.WriteLine($"{result.Loser.Name} has been defeated!");
                player.GainExperience(enemy.ExperienceReward);
                Console.WriteLine($"You gained {enemy.ExperienceReward} experience points!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Initialize();
            }
            else
            {
                var enemyResult = combatSystem.Fight(enemy, player);
                Console.WriteLine($"{enemy.Name} dealt {enemyResult.DamageDealt} damage to you!");

                player.TickEffects();

                if (enemyResult.Winner != null)
                {
                    Console.WriteLine("You have been defeated!");
                    Console.WriteLine("Game Over. Press any key to exit...");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        private void UseItem()
        {
            var items = inventorySystem.GetItems();
            if (items.Count == 0)
            {
                Console.WriteLine("You have no items in your inventory.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Select an item to use:");
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {items[i].Name} - {items[i].Description}");
            }

            var input = Console.ReadLine();
            if (int.TryParse(input, out int itemIndex) && itemIndex > 0 && itemIndex <= items.Count)
            {
                var item = items[itemIndex - 1];
                inventorySystem.UseItem(item);
                player.AddEffect(item.Effect);
                Console.WriteLine($"You used {item.Name}.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Invalid selection. Press any key to continue...");
                Console.ReadKey();
            }
        }

        private void RunAway()
        {
            Console.WriteLine("You ran away from the battle.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Initialize();
        }
    }
}
