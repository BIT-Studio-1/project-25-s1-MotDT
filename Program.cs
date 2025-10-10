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
            // Change the console text colour
            Console.ForegroundColor = ConsoleColor.Red; // Set console text colour to red
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
            Thread.Sleep(200);
            Console.ForegroundColor = ConsoleColor.White; // Reset console text colour to white
            Console.WriteLine("Cold stone and stale air greet you; the corpse of your companion hangs chained to the wall."); // intro paragraph
            Thread.Sleep(200);
            Console.WriteLine("A rusted door to the south promises danger and a chance at freedom — choose Beef, Stabbs, or Dodgio and prove your fate."); // intro paragraph
            Thread.Sleep(200);
            Console.WriteLine("Choose a character! ");
            Thread.Sleep(200);
            Console.WriteLine("=+=+=+=+=+=+=+=+=+=+=+=+=+=+=");
            Thread.Sleep(200);
            Console.WriteLine("[1] BEEF the TANKY warrior");
            Thread.Sleep(200);
            Console.WriteLine("[2] Stabbs the DAMAGING rouge");
            Thread.Sleep(200);
            Console.WriteLine("[3] Dodgio the EVASIVE acrobat");
            Thread.Sleep(200);
            Console.WriteLine("=+=+=+=+=+=+=+=+=+=+=+=+=+=+=\n");
            Console.Write("Enter your choice ");
            int menu = Convert.ToInt32(Console.ReadLine());
            Character hero = GetChar(menu);
            Console.WriteLine($"Your Character is {hero.name}");
            Console.WriteLine("Press ENTER to begin");
            Console.ReadLine();
            Entrance(hero); // Call Entrance method
        }

        static void Entrance(Character hero)
        {
            string choice;
            bool item = false;
            do
            {
                Console.Clear();
                //Animations Go here!!!
                Console.WriteLine("You find yourself in the dark entrance way of the wizard's tower");
                Thread.Sleep(200);
                Console.WriteLine("It is a small limestone room. A single torch dimly illuminates the otherwise dark entrance");
                Thread.Sleep(200);
                Console.WriteLine("There is a wooden door with a broken lock to the north");
                Thread.Sleep(200);
                Console.WriteLine("Slumped up against the wall just under the torch is a small skeleton");
                Console.WriteLine("What would you like to do?");
                choice = Console.ReadLine();
                choice = choice.ToUpper();
                switch (choice)
                {
                    case "GO NORTH":
                        Room2(hero); //Call Room2 method
                        break;
                    case "GO SOUTH":
                        Console.WriteLine("Do you wish to run in fear of THE TOWER!!!");
                        Console.WriteLine("Y/N");
                        char Choice = Convert.ToChar(Console.ReadLine());
                        Choice = Char.ToUpper(Choice);
                        if (Choice == 'Y')
                        {
                            Console.WriteLine("You decide that it may not be worth risking life and limb for treasure after all");
                            Console.WriteLine("You run back to your horse hitched outside and return to your life back home");
                            Console.WriteLine("GAME OVER");
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine("After some deliberation you decide to continue in search of riches in the tower");
                        }
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
                        hero.Status(); //Call Status method from Character class
                        Thread.Sleep(2000);
                        break;
                    case "HELP":
                        Help();//Call Help method
                        break;
                    default:
                        Console.WriteLine("\nSorry I don't understand that command.");
                        Thread.Sleep(2000);
                        break;
                }
            }
            while (choice != "GO NORTH");
        }

        static void Room2(Character hero)
        {
            string choice;
            bool item = false;
            do
            {
                Console.Clear(); // Clear the console
                //Animations Go here!!!
                Console.WriteLine("You are in Room 2");
                Thread.Sleep(200);
                Console.WriteLine("A Ghoul stands in your way");
                Thread.Sleep(200);
                Console.WriteLine("You must vanquish it before you leave");
                Thread.Sleep(200);
                Console.WriteLine("To the north there is a small hole in the wall");
                Thread.Sleep(200);
                Console.WriteLine("What would you like to do?");
                choice = Console.ReadLine();
                choice = choice.ToUpper();
                switch (choice)
                {
                    case "GO NORTH":
                        Room3(hero); //Call Room3 method
                        break;
                    case "GO SOUTH":
                        Entrance(hero); //Call Entrance method
                        break;
                    case "GO EAST":
                        Console.WriteLine("Placeholder text room to be added");
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
                        Help();
                        break;
                    default:
                        Console.WriteLine("\nSorry I don't understand that command.");
                        Thread.Sleep(2000);
                        break;
                }
            }
            while ((choice != "GO SOUTH") || (choice != "GO NORTH") || (choice != "GO East"));
        }

        static void Room3(Character hero)
        {
            string choice;
            bool item = false;
            do
            {
                Console.Clear();
                //Animations Go here!!!
                Console.WriteLine("You are in Room 3");
                Thread.Sleep(200);
                Console.WriteLine("A lone goblin crouches in the far corner, its eyes glinting in the torchlight");
                Thread.Sleep(200);
                Console.WriteLine("It brandishes a rusty dagger and hisses, clearly ready to fight");
                Thread.Sleep(200);
                Console.WriteLine("It is also clutching scraps of something that might have belonged to your companion");
                Thread.Sleep(200);
                Console.WriteLine("You must defeat the goblin before you can proceed");
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
                        Help(); //Call Help method
                        break;
                    default:
                        Console.WriteLine("\nSorry I don't understand that command.");
                        Thread.Sleep(2000);
                        break;
                }
            }
            while (choice != "Go South");
        }

        /// <summary>
        /// Potential helper function for repeated uses of Console.WriteLine(a) and Thread.Sleep(b)
        /// Takes an array of (string a,int b)
        /// No, I could not make the name shorter.
        /// </summary>
        static void PrintMultiDelayString((string, int)[] data)
        {
            // Iterate through each pair
            foreach ((string, int) line in data)
            {
                Console.WriteLine(line.Item1);
                Thread.Sleep(line.Item2);
            }
        }

        public static Character GetChar(int menu)
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
            Console.Clear(); // Clear the console
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
        bool F1Key = false;
        bool roomItem;

        public void Status()
        {
            Console.WriteLine($@"Character Sheet:
Character name:     {name}
Current hp:         {health.curHP}
Strength bonus:     {strength}
Finesse Bonus:      {finesse}
Toughness Bonus:    {toughness}
Presence Bonus:     {presence}
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
