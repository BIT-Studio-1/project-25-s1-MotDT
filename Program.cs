using System;

namespace Studio_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Main logic here
            Console.WriteLine("Title Animation goes here very cool and epic adventure game");
            Console.WriteLine("Cool intro lore stuff goes here");
            Console.WriteLine("Menu Stuff goes here E.g. Play the game and exit and what not");
            Console.WriteLine("Press Enter to start");
            Console.ReadLine();
            Console.WriteLine("Press 1 if you want to play the tough BEEF");
            Console.WriteLine("Press 2 if you want to play the brutal Stabbs");
            Console.WriteLine("Press 2 if you want to play the brutal Stabbs");
            int menu = Convert.ToInt32(Console.ReadLine);
            if menu = 1
                {
                Character character = new Character
                {
                    name = "Beef (Tough)",
                    health = new EntityHealth { maxHP = 12, curHP = 12 },
                    damDice = 4,
                    strength = 0,
                    finesse = 0,
                    toughness = 1,
                    presence = 1
                }
                }
            else if menu = 2
                {
                Character character = new Character
                {
                    name = "Stabbs",
                    health = new EntityHealth { maxHP = 8, curHP = 8 },
                    damDice = 8,
                    strength = 1,
                    finesse = -1,
                    toughness = 0,
                    presence = 0
                }
            }

            else
            {
                Character character = new Character
                {
                    name = "Dodgeo",
                    health = new EntityHealth { maxHP = 10, curHP = 10 },
                    damDice = 6,
                    strength = 2,
                    finesse = 1,
                    toughness = 0,
                    presence = 0
                }
            }
        }

        static void PrintHealthBar(Character character)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string remainingHealthBar = new string('█', character.health.curHP);
            string totalHealthBar = new string('_', character.health.maxHP - character.health.curHP);
            Console.WriteLine($"{character.name} HP: {remainingHealthBar}{totalHealthBar} ({character.health.curHP}/{character.health.maxHP})");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    public class Character // This character is simpler; you test themself against DC10+ monster attack
    {
        /// Character's health component
        public EntityHealth health;
        public string name;
        int damDice;
        int strength; // this is used as hit mod
        int finesse;
        int toughness;
        int presence;
    }

    public class Monster
    {
        /// Monster's health component
        public EntityHealth health;
        public string name;
        int damDice;
        int dodgeDiff;
        int hitDiff;
        bool item1;
    }

    /// Health class used by both players and monsters
    public class EntityHealth {
        /// Max health of the entity
        public int maxHP;
        /// Current Health of the entity
        public int curHP;
    }
}
