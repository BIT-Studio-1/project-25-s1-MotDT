using System;
using System.Numerics;
using System.Threading;
using System.Xml.Linq;

namespace Studio_1
{
    internal class Program
    {
        static void Main()
        {
            // Main logic here            
            // Change the console text color
            Console.ForegroundColor = ConsoleColor.Red; // Set text colour to Red
            // ASCII art printed line-by-line with a 200ms pause after each line
            Console.WriteLine("███▄ ▄███▓ ▄▄▄      ▒███████▒▓█████     ▒█████    █████▒   ▄▄▄█████▓ ██░ ██ ▓█████  ");
            Thread.Sleep(200);
            Console.WriteLine("▓██▒▀█▀ ██▒▒████▄    ▒ ▒ ▒ ▄▀░▓█   ▀    ▒██▒  ██▒▓██   ▒    ▓  ██▒ ▓▒▓██░ ██▒▓█   ▀ ");
            Thread.Sleep(200);
            Console.WriteLine("▓██    ▓██░▒██  ▀█▄  ░ ▒ ▄▀▒░ ▒███      ▒██░  ██▒▒████ ░    ▒ ▓██░ ▒░▒██▀▀██░▒███   ");
            Thread.Sleep(200);
            Console.WriteLine("▒██    ▒██ ░██▄▄▄▄██   ▄▀▒   ░▒▓█  ▄    ▒██   ██░░▓█▒  ░    ░ ▓██▓ ░ ░▓█ ░██ ▒▓█  ▄ ");
            Thread.Sleep(200);
            Console.WriteLine("▒██▒   ░██▒ ▓█   ▓██▒▒███████▒░▒████▒   ░ ████▓▒░░▒█░         ▒██▒ ░ ░▓█▒░██▓░▒████▒");
            Thread.Sleep(200);
            Console.WriteLine("░ ▒░   ░  ░ ▒▒   ▓▒█░░▒▒ ▓░▒░▒░░ ▒░ ░   ░ ▒░▒░▒░  ▒ ░         ▒ ░░    ▒ ░░▒░▒░░ ▒░ ░");
            Thread.Sleep(200);
            Console.WriteLine("░  ░      ░  ▒   ▒▒ ░░░▒ ▒ ░ ▒ ░ ░  ░     ░ ▒ ▒░  ░                                 ");
            Thread.Sleep(200);
            Console.WriteLine("░  ░      ░  ▒   ▒▒ ░░░▒ ▒ ░ ▒ ░ ░  ░     ░ ▒ ▒░  ░             ░     ▒ ░▒░ ░ ░ ░  ░");
            Thread.Sleep(200);
            Console.WriteLine("░         ░  ░  ░ ░       ░  ░       ░ ░                       ░  ░  ░   ░  ░");
            Thread.Sleep(200);
            Console.WriteLine("");
            Thread.Sleep(200);
            Console.WriteLine("▓█████▄  ▄▄▄       ██▀███   ██ ▄█▀   ▄▄▄█████▓ ▒█████   █     █░▓█████  ██▀███      ");
            Thread.Sleep(200);
            Console.WriteLine("▒██▀ ██▌▒████▄    ▓██ ▒ ██▒ ██▄█▒    ▓  ██▒ ▓▒▒██▒  ██▒▓█░ █ ░█░▓█   ▀ ▓██ ▒ ██▒ ");
            Thread.Sleep(200);
            Console.WriteLine("░██   █▌▒██  ▀█▄  ▓██ ░▄█ ▒▓███▄░    ▒ ▓██░ ▒░▒██░  ██▒▒█░ █ ░█ ▒███   ▓██ ░▄█ ▒    ");
            Thread.Sleep(200);
            Console.WriteLine("░▓█▄   ▌░██▄▄▄▄██ ▒██▀▀█▄  ▓██ █▄    ░ ▓██▓ ░ ▒██   ██░░█░ █ ░█ ▒▓█  ▄ ▒██▀▀█▄      ");
            Thread.Sleep(200);
            Console.WriteLine("░▒████▓  ▓█   ▓██▒░██▓ ▒██▒▒██▒ █▄     ▒██▒ ░ ░ ████▓▒░░░██▒██▓ ░▒████▒░██▓ ▒██▒    ");
            Thread.Sleep(200);
            Console.WriteLine(" ▒▒▓  ▒  ▒▒   ▓▒█░░ ▒▓ ░▒▓░▒ ▒▒ ▓▒     ▒ ░░   ░ ▒░▒░▒░ ░ ▓░▒ ▒  ░░ ▒░ ░░ ▒▓ ░▒▓░    ");
            Thread.Sleep(200);
            Console.WriteLine(" ░ ▒  ▒   ▒   ▒▒ ░  ░▒ ░ ▒░░ ░▒ ▒░       ░      ░ ▒ ▒░   ▒ ░ ░   ░ ░  ░  ░▒ ░ ▒░    ");
            Thread.Sleep(200);
            Console.WriteLine(" ░ ░  ░   ░   ▒     ░░   ░ ░ ░░ ░      ░      ░ ░ ░ ▒    ░   ░     ░     ░░   ░     ");
            Thread.Sleep(200);
            Console.WriteLine("░          ░  ░   ░     ░  ░                   ░ ░      ░       ░  ░   ░         ");
            Thread.Sleep(200);
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Cold stone and stale air greet you; the corpse of your companion hangs chained to the wall."); // intro paragraph
            Console.WriteLine("A rusted door to the south promises danger and a chance at freedom — choose Beef, Stabbs, or Dodgio and prove your fate."); // intro paragraph
            Console.WriteLine("Menu Stuff goes here E.g. Play the game and exit and what not");
            Console.WriteLine("Press Enter to start");
            Console.ReadLine();
            Console.WriteLine("Press 1 if you want to play the tough BEEF");
            Console.WriteLine("Press 2 if you want to play the brutal Stabbs");
            Console.WriteLine("Press 3 if you want to play the Dexterous Dodgio");
            int menu = Convert.ToInt32(Console.ReadLine());
            Character hero = Getchar(menu);
            Console.WriteLine($"Your Character is {hero.name}");
            Console.WriteLine("Press ENTER to begin");
            Console.ReadLine();
            Room1(hero);
        }

        static void Room1(Character hero)
        { 
        string choice;
        bool item = false;
            do
            {
                Console.Clear();
                //Animations Go here!!!
                Console.WriteLine("You are in room 1");
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
                        Room2(hero);
                        break;
                    case "SEARCH":
                        if (item == true)
                        {
                            //Stuff Goes here
                        }
                        else
                        {
                            Console.WriteLine("\nYou find nothing of use");
                            Thread.Sleep(1000);
                        }
                        break;
                    case "STATUS":
                        hero.Status();
                        Thread.Sleep(2000);
                        break;
                    case "HELP":
                        //Print Commands with a method
                        Help();
                        break;
                    default:
                        Console.WriteLine("\nSorry I don't understand that command.");
                        Thread.Sleep(2000);
                        break;
                }
            }
            while (choice != "Go South");
        }

        static void Room2(Character hero)
        {
            string choice;
            bool item = false;
            do
            {
                Console.Clear();
                //Animations Go here!!!
                Console.WriteLine("You are in Room2");
                Thread.Sleep(200);
                Console.WriteLine("The room 2 Ghoul stands in your way");
                Thread.Sleep(200);
                Console.WriteLine("you must vanquish it before you leave");
                Thread.Sleep(200);
                Console.WriteLine("to the north there is a small hole in the wall");
                Thread.Sleep(200);
                Console.WriteLine("What would you like to do?");
                choice = Console.ReadLine();
                choice = choice.ToUpper();
                switch (choice)
                {
                    case "GO NORTH":
                        Room3(hero);
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
                        hero.Status();
                        Thread.Sleep(2000);
                        break;
                    case "HELP":
                        //Print Commands with a method
                        Help();
                        break;
                    default:
                        Console.WriteLine("\nSorry I don't understand that command.");
                        Thread.Sleep(2000);
                        break;
                }
            }
            while (choice != "Go South");
        }

        static void Room3(Character hero)
        {
            string choice;
            bool item = false;
            do
            {
                Console.Clear();
                //Animations Go here!!!
                Console.WriteLine("You are in Room2");
                Thread.Sleep(200);
                Console.WriteLine("Stuff");
                Thread.Sleep(200);
                Console.WriteLine("Wow");
                Thread.Sleep(200);
                Console.WriteLine("What would you like to do?");
                choice = Console.ReadLine();
                choice = choice.ToUpper();
                switch (choice)
                {
                    case "GO SOUTH":
                        Environment.Exit(0);
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
                        hero.Status();
                        Thread.Sleep(2000);
                        break;
                    case "HELP":
                        //Print Commands with a method
                        Help();
                        break;
                    default:
                        Console.WriteLine("\nSorry I don't understand that command.");
                        Thread.Sleep(2000);
                        break;
                }
            }
            while (choice != "Go South");
        }

        public static Character Getchar(int menu)
        {
            switch (menu)
            {
                case 1:
                    {
                        return new Character
                        {
                            name = "Beef",
                            health = EntityHealth.InitHealth(12),
                            damDice = 4,
                            strength = 0,
                            finesse = 0,
                            toughness = 1,
                            presence = 1
                        };
                    }
                case 2:
                    {
                        return new Character
                        {
                            name = "Stabbs",
                            health = EntityHealth.InitHealth(8),
                            damDice = 8,
                            strength = 1,
                            finesse = -1,
                            toughness = 0,
                            presence = 0
                        };
                    }
                case 3:
                    {
                        return new Character
                        {
                            name = "Dodgio",
                            health = EntityHealth.InitHealth(10),
                            damDice = 6,
                            strength = 2,
                            finesse = 1,
                            toughness = 0,
                            presence = 0
                        };
                    }
                default:
                    Console.WriteLine("Error Returning default");
                    return new Character
                    {
                        name = "Beef",
                        health = EntityHealth.InitHealth(12),
                        damDice = 4,
                        strength = 0,
                        finesse = 0,
                        toughness = 1,
                        presence = 1
                    };
            }
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

        static void Help()
        {
            Console.WriteLine("\nThe game commands are GO [DIRECTION], HELP, SEARCH and STATUS");
            Console.WriteLine("            The commands are not case sensitive");
            Thread.Sleep(500);
            Console.WriteLine("GO [DIRECTION] -- This command takes you to a different room based on its relative position to the current room");
            Thread.Sleep(500);
            Console.WriteLine("     HELP      -- This command prints the help menu");
            Thread.Sleep(500);
            Console.WriteLine("    SEARCH     -- This command searches the room the player is currently in");
            Thread.Sleep(500);
            Console.WriteLine("    STATUS     -- This command shows an abridged version of the players character sheet");
            Thread.Sleep(2000);
            Console.Clear();
        }

    }
    /// <summary>
    /// Character Data
    /// </summary>
    public class Character // This character is simpler; you test themselves against DC10+ monster attack
    {

        public EntityHealth health; // character's health component
        public string name; // character's name
        public int damDice;
        public int strength; // this is used as hit mod
        public int finesse;
        public int toughness;
        public int presence;
        bool itemname = false;
        bool roomItem;

        public void Status()
        {
            Console.WriteLine($@"Character Sheet:
{name}
{health.curHP}
{strength}
{finesse}
{toughness}
{presence}
            ");
            Thread.Sleep(1000);
        }
    }

    public class Monster
    {
        public EntityHealth health; // monster's health component 
        public string name; // monster's name
        int damDice;
        int dodgeDiff;
        int hitDiff;
        bool item1; // item the monster can have that the player can loot
    }

    /// <summary>
    /// Generic Health class used by both players and monsters
    /// </summary>
    public class EntityHealth
    {

        public int maxHP; // Max health of the entity
        public int curHP; // Current Health of the entity

        /// <summary>
        /// Constructor function that automatically sets max health.
        /// A new EntityHealth instance where maxHP == curHP == initHP
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
