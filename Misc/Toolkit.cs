using TextAdventure;

namespace Game_build_tool_kit
{
    internal class Toolkit
    {
        // static void Main(string[] args)
        // {
        // }

        Character Player = new Character //this is the current character structure it will probibly be changed latter but currently all characters including monsters use this structure
        {
            string name = "Bob";
            int maxHP = ;
            int curHP;
            int hitMod;
            int damDice;
            int strength;
            int fineese;
            int toughness;
            int presnase;
        };

        /// This is the generic skeleton for a room it can be edited down 
        static void INSERTROOM(Character Player) //This is the same as defining a function in python at the top we pass the player object into the room so that it can be effected
        {
            string choice; //This is the variable that will store the players input
            do
            {
                Console.Clear(); //This clears the console so that it is not cluttered

                // NOTE: What is this meant to reference? It does not seem to exist?
                // Animation.ROOM-ANIMATION(); //This plays an animation for the room

                Thread.Sleep(200);
                Console.WriteLine("ROOM TEXT");
                Thread.Sleep(500);
                Console.WriteLine("ROOM TEXT");
                Thread.Sleep(500);
                Console.WriteLine("ROOM TEXT");
                Thread.Sleep(500);
                Console.WriteLine("ROOM TEXT");
                Thread.Sleep(500);
                Console.WriteLine("ROOM TEXT");
                Thread.Sleep(500);
                Console.WriteLine("What will you do?");
                choice = Console.ReadLine(); //This gets the players input and stores it in the choice variable
                choice = choice.ToUpper(); //This converts the players input to uppercase so that it is easier to compare

                // PLACEHOLDER: This is to prevent errors due to var "MUSH" not existing.
                bool Mush = false;

                switch (choice)
                {
                    case "SEARCH":
                        if (Mush == true)
                        {
                            // do stuff if there is a thing to find
                        }
                        else
                        {
                            Console.WriteLine("\nYou have consumed all of the edible fungus");
                            Thread.Sleep(500);
                        }
                        break;
                    case "STATUS":
                        Player.PrintInfo(); // calls the PrintInfo function from the Character class to print the players stats
                        Thread.Sleep(2000);
                        break;

                    case "HELP":
                        Help(); // calls the Help function to print the help menu
                        break;

                    case "GO SOUTH":
                        break;

                    case "GO NORTH":
                        break;

                    case "GO EAST":
                        break;

                    case "GO WEST":
                        break;

                    case "GO UP":
                        break;

                    default:
                        Console.WriteLine("Sorry I don't understand that command.");
                        Thread.Sleep(2000);
                        break;
                }
            } while ((choice != "GO SOUTH EAST") || (choice != "GO NORTH EAST") || (choice != "GO NORTH WEST") || (choice != "GO SOUTH EAST") || (choice != "GO EXIT"));
            // basicly you just make the stuff that breaks out of the loop possible exits from the room
        }

        static void PrintHealthBar(Character character) // This function prints a health bar for the character
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string remainingHealthBar = new string('█', character.HP);
            string totalHealthBar = new string('_', character.MaxHP - character.HP);
            Console.WriteLine($"{character.Name} HP: {remainingHealthBar}{totalHealthBar} ({character.HP}/{character.MaxHP})");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void Help() // This is the help function that prints the help menu
        {
            MultiPrintDelay(new (string, int)[]{
            ("GO [DIRECTION] -- This command takes you to a different room based on its relitive position to the current room",500),
            ("     HELP      -- This command prints the help menu",500),
            ("    SEARCH     -- This command searches the room the player is currently in",500),
            ("    STATUS     -- This command shows an abridjed version of the players character sheet",2000)});

            // Console.WriteLine("\nThe game commands are GO [DIRECTION], HELP, SEARCH and STATUS");
            // Console.WriteLine("            The commands are not case sensitive");
            // Thread.Sleep(500);
            // Console.WriteLine("GO [DIRECTION] -- This command takes you to a different room based on its relitive position to the current room");
            // Thread.Sleep(500);
            // Console.WriteLine("     HELP      -- This command prints the help menu");
            // Thread.Sleep(500);
            // Console.WriteLine("    SEARCH     -- This command searches the room the player is currently in");
            // Thread.Sleep(500);
            // Console.WriteLine("    STATUS     -- This command shows an abridjed version of the players character sheet");
            // Thread.Sleep(2000);
            // Console.Clear();
        }

        public static void MultiPrintDelay((string, int)[] data)
        {
            foreach (var entry in data)
            {
                Thread.Sleep(entry.Item2);
                Console.WriteLine(entry.Item1);
            }
        }
    }
}
