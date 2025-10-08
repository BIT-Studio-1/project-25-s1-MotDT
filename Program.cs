using System;
using System.Numerics;

namespace Studio_1
{
    internal class Program
    {
        static void Main()
        {
            string name = " ";
            // Main logic here
            Console.WriteLine("Title Animation goes here very cool and epic adventure game");
            Console.WriteLine("Cool intro lore stuff goes here");
            Console.WriteLine("Menu Stuff goes here E.g. Play the game and exit and what not");
            Console.WriteLine("Press Enter to start");
            Console.ReadLine();
            Console.WriteLine("Press 1 if you want to play the tough BEEF");
            Console.WriteLine("Press 2 if you want to play the brutal Stabbs");
            Console.WriteLine("Press 3 if you want to play the Dexterous Dodgio");
            int menu = Convert.ToInt32(Console.ReadLine());
            switch (menu)
            {
                case 1:
                    {
                        Character hero = new Character
                        {
                            name = "Beef",
                            health = new EntityHealth { maxHP = 12, curHP = 12 },
                            damDice = 4,
                            strength = 0,
                            finesse = 0,
                            toughness = 1,
                            presence = 1
                        };
                        name = "Beef";
                        break;
                    }
                case 2:
                    {
                        Character hero = new Character
                        {
                            name = "Stabbs",
                            health = new EntityHealth { maxHP = 8, curHP = 8 },
                            damDice = 8,
                            strength = 1,
                            finesse = -1,
                            toughness = 0,
                            presence = 0
                        };
                        break;
                    }
                case 3:
                    {
                        Character hero = new Character
                        {
                            name = "Dodgeo",
                            health = new EntityHealth { maxHP = 10, curHP = 10 },
                            damDice = 6,
                            strength = 2,
                            finesse = 1,
                            toughness = 0,
                            presence = 0
                        };
                        break;
                    }
                default:
                    Console.WriteLine("Add something about an error possibly list vailid choices and what not");
                    break;
            }
            Console.WriteLine($"Your Character is {name}");
            Console.WriteLine("Press ENTER to begin");
            Console.ReadLine();

            //Basic Room Template
            string choice;
            bool item = false;
            do
            {
                Console.Clear();
                //Animations Go here!!!
                Console.WriteLine("You awake inside a dimly lit and damp cell");
                Thread.Sleep(200);
                Console.WriteLine("Chained to the wall is the corpse of your former companion");
                Thread.Sleep(200);
                Console.WriteLine("There is a rusted door to the South");
                Thread.Sleep(200);
                Console.WriteLine("What would you like to do?");
                choice = Console.ReadLine();
                choice = choice.ToUpper();
                switch (choice)
                {
                    case "GO SOUTH":
                        //Movement Goes here
                        break;
                    case "SEARCH":
                        if (item == true)
                        {
                            //Stuff Goeshere
                        }
                        else
                        {
                            Console.WriteLine("\nYou find nothing of use");
                            Thread.Sleep(1000);
                        }
                        break;
                    case "STATUS":
                        //Print player status with a method
                        Thread.Sleep(2000);
                        break;
                    case "HELP":
                        //Print Commands with a method
                        break;
                    default:
                        Console.WriteLine("\nSorry I don't understand that command.");
                        Thread.Sleep(2000);
                        break;
                }
            }
            while (choice != "Go South");

        }

        // Prints the health bar of the character
        static void PrintHealthBar(Character character)
        {
            // Set the console text color to green for the health bar display
            Console.ForegroundColor = ConsoleColor.Green;

            // Create a string of '█' characters representing the character's current health
            string remainingHealthBar = new string('█', character.health.curHP);

            // Create a string of '_' characters representing missing health (maxHP - curHP)
            string totalHealthBar = new string('_', character.health.maxHP - character.health.curHP);

            // Print the character's name, the visual health bar, and the numeric HP values (current/max)
            Console.WriteLine($"{character.name} HP: {remainingHealthBar}{totalHealthBar} ({character.health.curHP}/{character.health.maxHP})");

            // Reset the console text color to white
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    /// <summary>
    /// Character Data
    /// </summary>
    public class Character // This character is simpler; you test themself against DC10+ monster attack
    {
        /// Character's health component
        public EntityHealth health;
        public string name;
        public int damDice;
        public int strength; // this is used as hit mod
        public int finesse;
        public int toughness;
        public int presence;
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

    /// <summary>
    /// Generic Health class used by both players and monsters
    /// </summary>
    public class EntityHealth
    {
        /// Max health of the entity
        public int maxHP;
        /// Current Health of the entity
        public int curHP;

        /// <summary>
        /// Constructor function that automatically sets max health.
        /// </summary>
        public static EntityHealth InitHealth(int initHP)
        {
            return new EntityHealth
            {
                maxHP = initHP,
                curHP = initHP
            };
        }
    }
}
