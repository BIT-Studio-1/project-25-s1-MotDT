using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using static Studio_1.Entity;
using static System.Net.Mime.MediaTypeNames;

namespace Studio_1
{
    internal class Program
    {
        // A struct that contains the data for  game state.
        struct GameState
        {
            public Entity.Character hero;
            public Monster[] monsters;
            public Random random_gen;
        }

        //Global constants for changing colour of text, remember to always RESET!
        public const string RESET = "\x1b[0m";
        public const string RED = "\x1b[91m";
        public const string GREEN = "\x1b[92m";
        public const string YELLOW = "\x1b[93m";
        public const string BLUE = "\x1b[94m";
        public const string MAGENTA = "\x1b[95m";
        public const string CYAN = "\x1b[96m";
        public const string GREY = "\x1b[97m";

        //Global constants for changing formatting of text, remember to cancel the formatting after!
        public const string BOLD = "\x1b[1m";
        public const string NOBOLD = "\x1b[22m";
        public const string UNDERLINE = "\x1b[4m";
        public const string NOUNDERLINE = "\x1b[24m";
        public const string REVERSE = "\x1b[7m";
        public const string NOREVERSE = "\x1b[27m";

        static void Main()
        {
            // Title Card
            RenderFrame(FindWorkingPath(new string[] { "../../../Art Files/Title.txt", "Art Files/Title.txt" }), 200, 12);

            Console.WriteLine();
            PrintMultiDelayString("Cold stone and stale air greet you.");
            Console.WriteLine("To the south a rusted door that promises danger and a chance at freedom — choose Beef, Stabbs, or Dodgio and prove your fate."); // intro paragraph
            Thread.Sleep(200);
            Console.WriteLine("Choose a character! \n");
            Thread.Sleep(200);
            Console.WriteLine("=+=+=+=+=+=+=+=+=+=+=+=+=+=+=");
            Thread.Sleep(200);
            Console.WriteLine($"[1] BEEF the {GREEN}TANKY{RESET} warrior");
            Thread.Sleep(200);
            Console.WriteLine($"[2] Stabbs the {RED}DAMAGING{RESET} rouge");
            Thread.Sleep(200);
            Console.WriteLine($"[3] Dodgio the {BLUE}EVASIVE{RESET} acrobat");
            Thread.Sleep(200);
            Console.WriteLine("=+=+=+=+=+=+=+=+=+=+=+=+=+=+=");
            string confirm;
            int menu;
            do
            {
                bool parse;
                do
                {
                    string tmp;
                    Console.Write("\nEnter your choice: ");
                    tmp = Console.ReadLine();
                    parse = int.TryParse(tmp, out menu);
                } while (menu < 1 || menu > 3 || parse == false);
                Entity.Character display = GetChar(menu);
                Console.WriteLine();
                display.Status();
                Console.Write("Is this you? [y/n]: ");
                confirm = Console.ReadLine();
            } while (confirm.ToLower() != "y");
            Entity.Character hero = GetChar(menu);
            Console.WriteLine("Press ENTER to begin");
            Console.ReadLine();

            // Initialize the game's state.
            GameState initial_state = new GameState
            {
                hero = hero,
                monsters = new Monster[] {
                    new Entity.Monster
                    {
                        health = Entity.EntityHealth.InitHealth(6),
                        name = "Ghoul",
                        damDice = 4,
                        dodgeDiff = 10,
                        hitDiff = 10,
                        item1 = true
                    },
                    new Entity.Monster
                    {
                        health = Entity.EntityHealth.InitHealth(6),
                        name = "Goblin",
                        damDice = 4,
                        dodgeDiff = 15,
                        hitDiff = 12,
                        item1 = false
                    },
                    new Entity.Monster
                    {
                        health = Entity.EntityHealth.InitHealth(6),
                        name = "Dire Hound",
                        damDice = 6,
                        dodgeDiff = 13,
                        hitDiff = 15,
                        item1 = false
                    }
                },
                random_gen = new Random()
            };
            
            F1Entrance(initial_state); // Call Entrance method
        }

        //Floor 1 entrance
        //-> North F1Hall
        static void F1Entrance(GameState state)
        {
            string choice;
            do
            {
                Console.Clear();
                RenderFrame(FindWorkingPath(new string[] {"../../../Art Files/Room1.txt","Art Files/Room1.txt"}), 25, 10); //Background 
                Console.WriteLine("You find yourself in the dark entrance way of the wizard's tower");
                Thread.Sleep(200);
                Console.WriteLine("It is a small limestone room. A single torch dimly illuminates the otherwise dark entrance");
                Thread.Sleep(200);
                Console.WriteLine("There is a wooden door with a broken lock to the NORTH");
                Thread.Sleep(200);
                Console.WriteLine("To your SOUTH lies the door back to civilisation perhaps you should abandon your quest?");
                Thread.Sleep(200);
                Console.WriteLine("Slumped up against the wall just under the torch is a small skeleton");
                Thread.Sleep(200);
                Console.WriteLine();
                Console.WriteLine("What would you like to do?");
                choice = Console.ReadLine().ToUpper();
                switch (choice)
                {
                    case "GO NORTH":
                        F1Hall(state); //Call Room2 method
                        break;
                    case "GO SOUTH":
                        Console.WriteLine("Do you wish to run in fear of THE TOWER!!!");
                        Console.WriteLine("Y/N");
                        char leave = Convert.ToChar(Console.ReadLine());
                        leave = char.ToUpper(leave);
                        if (leave == 'Y')
                        {
                            Console.WriteLine("You decide that it may not be worth risking life and limb for treasure after all");
                            Thread.Sleep(200);
                            Console.WriteLine("You run back to your horse hitched outside and return to your life back home");
                            Thread.Sleep(200);
                            GameOver();
                            Thread.Sleep(200);
                            Environment.Exit(1000);
                        }
                        else
                        {
                            Console.WriteLine("After some deliberation you decide to continue in search of riches in the tower");
                        }
                        break;
                    case "SEARCH":
                        Console.WriteLine("\nYou find nothing of use on the crumpled remains of the skeleton");
                        Thread.Sleep(2000);
                        break;
                    case "STATUS":
                        state.hero.Status(); //Call Status method from Character class
                        break;
                    case "HELP":
                        Help(); //Call Help method
                        break;
                    default:
                        Console.WriteLine($"\nSorry I don't understand that command.\"{choice}\"");
                        Thread.Sleep(2000);
                        break;
                }
            }
            while (choice != "GO NORTH" || choice != "GO SOUTH");
        }

        //Floor 1 Hall
        //-> South F1Entrance, North F1Room3, East F2Main
        static void F1Hall(GameState state)
        {
            string choice;
            do
            {
                Console.Clear();
                RenderFrame(FindWorkingPath(new string[] { "../../../Art Files/RoomP.txt", "Art Files/RoomP.txt" }), 25, 10);
                Console.WriteLine("You find yourself in a large damp Hallway");
                Thread.Sleep(200);
                Console.WriteLine("To the north lies a creaking wooden door. You hear shuffling behind it");
                Thread.Sleep(200);
                Console.WriteLine("To the east is a set of iron bars with a small lock blocking the way to the stairs");
                Thread.Sleep(200);
                Console.WriteLine("behind you to the SOUTH lies the path back to the entrance");
                Thread.Sleep(200);
                Console.WriteLine("What would you like to do?");
                choice = Console.ReadLine().ToUpper();
                switch (choice)
                {
                    case "GO NORTH":
                        F1Room3(state); //Call Room3 method
                        break;
                    case "GO SOUTH":
                        F1Entrance(state); //Call Entrance method
                        break;
                    case "GO EAST":
                        if (state.hero.F1Key == true)
                        {
                            Console.WriteLine("Placeholder text room to be added currently goes to entrance");
                            Thread.Sleep(200);
                            F1Entrance(state); //Call Entrance method
                        }
                        else
                        {
                            Console.WriteLine("You must find they key to the gate lock before progressing");
                            Thread.Sleep(1000);
                        }
                        break;
                    case "SEARCH":
                        break;
                    case "STATUS":
                        state.hero.Status();
                        break;
                    case "HELP":
                        Help();
                        break;
                    default:
                        Console.WriteLine($"\nSorry I don't understand that command.\"{choice}\"");
                        Thread.Sleep(2000);
                        break;
                }
            }
            while ((choice != "GO SOUTH") || (choice != "GO NORTH") || (choice != "GO East"));
        }

        //Floor 1 Room 3
        //-> South F1Hall
        static void F1Room3(GameState state)
        {
            string choice;
            do
            {
                Console.Clear();
                if (state.monsters[0].health.IsAlive == true)
                {
                    RenderFrame(FindWorkingPath(new string[] { "../../../Art Files/Room3Ghoul.txt", "Art Files/Room2Ghoul.txt" }), 25, 10); //Background with enemy
                    Thread.Sleep(200);
                    Console.WriteLine("Before you can act a Ghoul ambushes you");
                    Thread.Sleep(200);
                    Console.WriteLine("You must vanquish it before you can act freely");
                    Thread.Sleep(2000);
                }
                if (state.monsters[0].health.IsAlive == true)
                {
                    Combat(ref state.hero, ref state.monsters[0], ref state.random_gen);
                }
                RenderFrame(FindWorkingPath(new string[] { "../../../Art Files/Room3GhoulDead.txt", "Art Files/Room2GhoulDead.txt" }), 25, 10); //Background with dead enemy
                Thread.Sleep(100);
                Console.WriteLine("To the north there is a small hole in the wall");
                Thread.Sleep(100);
                Console.WriteLine("To your south is the door back to the hallway");
                Thread.Sleep(200);
                Console.WriteLine("What would you like to do?");
                choice = Console.ReadLine().ToUpper();
                
                switch (choice)
                {
                    case "GO SOUTH":
                        F1Hall(state);
                        break;
                    case "SEARCH":
                        if (state.monsters[0].item1 == true)
                        {
                            Console.WriteLine("\nYou find a key on the body of the ghoul");
                            Thread.Sleep(200);
                            Console.WriteLine("You think this may be the key to the stair case to ascend the tower");
                            Thread.Sleep(800);
                            state.monsters[0].item1 = false;
                            state.hero.F1Key = true;
                        }
                        else
                        {
                            Console.WriteLine("\nYou find nothing of use");
                            Thread.Sleep(1000);
                        }
                        break;
                    case "STATUS":
                        state.hero.Status();
                        break;
                    case "HELP":
                        Help(); //Call Help method
                        break;
                    default:
                        Console.WriteLine($"\nSorry I don't understand that command.\"{choice}\"");
                        Thread.Sleep(2000);
                        break;
                }
            }
            while (choice != "Go South");
        }

        //Floor 2 Main
        //-> West F1Hall, North End, West F2EastHall1, South F2SouthHall1
        static void F2Main(GameState state)
        {
            string choice;
            do
            {
                Console.Clear();
                RenderFrame(FindWorkingPath(new string[] { "../../../Art Files/F2Main.txt", "Art Files/F2Main.txt" }), 25, 10); //Background 
                //Text goes here
                choice = Console.ReadLine().ToUpper();
                switch (choice)
                {
                    case "GO NORTH":
                        break;
                    case "GO EAST":
                        break;
                    case "GO SOUTH":
                        break;
                    case "GO WEST":
                        break;
                    case "SEARCH":
                        Console.ReadKey();
                        break;
                    case "STATUS":
                        state.hero.Status(); //Call Status method from Character class
                        break;
                    case "HELP":
                        Help(); //Call Help method
                        break;
                    default:
                        Console.WriteLine($"\nSorry I don't understand that command.\"{choice}\"");
                        Console.ReadKey();
                        break;
                }
            }
            while (choice != "GO NORTH" || choice != "GO EAST" || choice != "GO SOUTH" || choice != "GO WEST");
        }

        //Floor 2 East Hall 1
        //-> West F2Main, East F2EastHall2
        static void F2EastHall1(GameState state)
        {
            string choice;
            do
            {
                Console.Clear();
                RenderFrame(FindWorkingPath(new string[] { "../../../Art Files/F2EastHall1.txt", "Art Files/F2EastHall1.txt" }), 25, 10); //Background 
                //Text goes here
                choice = Console.ReadLine().ToUpper();
                switch (choice)
                {
                    case "GO EAST":
                        break;
                    case "GO WEST":
                        break;
                    case "SEARCH":
                        Console.ReadKey();
                        break;
                    case "STATUS":
                        state.hero.Status(); //Call Status method from Character class
                        break;
                    case "HELP":
                        Help(); //Call Help method
                        break;
                    default:
                        Console.WriteLine($"\nSorry I don't understand that command.\"{choice}\"");
                        Console.ReadKey();
                        break;
                }
            }
            while (choice != "GO EAST" || choice != "GO WEST");
        }

        //Floor 2 East Hall 2
        //-> West F2EastHall 1
        static void F2EastHall2(GameState state)
        {
            string choice;
            do
            {
                Console.Clear();
                RenderFrame(FindWorkingPath(new string[] { "../../../Art Files/F2EastHall2.txt", "Art Files/F2EastHall2.txt" }), 25, 10); //Background 
                //Text goes here
                choice = Console.ReadLine().ToUpper();
                switch (choice)
                {
                    case "GO WEST":
                        break;
                    case "SEARCH":
                        Console.ReadKey();
                        break;
                    case "STATUS":
                        state.hero.Status(); //Call Status method from Character class
                        break;
                    case "HELP":
                        Help(); //Call Help method
                        break;
                    default:
                        Console.WriteLine($"\nSorry I don't understand that command.\"{choice}\"");
                        Console.ReadKey();
                        break;
                }
            }
            while (choice != "GO WEST");
        }

        //Floor 2 South Hall 1
        //-> North F2Main, South F2SouthHall2
        static void F2SouthHall1(GameState state)
        {
            string choice;
            do
            {
                Console.Clear();
                RenderFrame(FindWorkingPath(new string[] { "../../../Art Files/F2SouthHall1.txt", "Art Files/F2SouthHall1.txt" }), 25, 10); //Background 
                //Text goes here
                choice = Console.ReadLine().ToUpper();
                switch (choice)
                {
                    case "GO NORTH":
                        break;
                    case "GO SOUTH":
                        break;
                    case "SEARCH":
                        Console.ReadKey();
                        break;
                    case "STATUS":
                        state.hero.Status(); //Call Status method from Character class
                        break;
                    case "HELP":
                        Help(); //Call Help method
                        break;
                    default:
                        Console.WriteLine($"\nSorry I don't understand that command.\"{choice}\"");
                        Console.ReadKey();
                        break;
                }
            }
            while (choice != "GO NORTH" || choice != "GO SOUTH");
        }
        //Floor 2 South Hall 2
        //-> North F2SouthHall1
        static void F2SouthHall2(GameState state)
        {
            string choice;
            do
            {
                Console.Clear();
                RenderFrame(FindWorkingPath(new string[] { "../../../Art Files/F2SouthHall2.txt", "Art Files/F2SouthHall2.txt" }), 25, 10); //Background 
                //Text goes here
                choice = Console.ReadLine().ToUpper();
                switch (choice)
                {
                    case "GO NORTH":
                        break;
                    case "SEARCH":
                        Console.ReadKey();
                        break;
                    case "STATUS":
                        state.hero.Status(); //Call Status method from Character class
                        break;
                    case "HELP":
                        Help(); //Call Help method
                        break;
                    default:
                        Console.WriteLine($"\nSorry I don't understand that command.\"{choice}\"");
                        Console.ReadKey();
                        break;
                }
            }
            while (choice != "GO NORTH");
        }


        static void RoomBlueprint(GameState state)
        {
            string choice;
            do
            {
                Console.Clear();
                RenderFrame(FindWorkingPath(new string[] { "../../../Art Files/.txt", "Art Files/.txt" }), 25, 10); //Background 
                //Text goes here
                choice = Console.ReadLine().ToUpper();
                switch (choice)
                {
                    case "GO NORTH":
                        break;
                    case "GO EAST":
                        break;
                    case "GO SOUTH":
                        break;
                    case "GO WEST":
                        break;
                    case "SEARCH":
                        Console.ReadKey();
                        break;
                    case "STATUS":
                        state.hero.Status(); //Call Status method from Character class
                        break;
                    case "HELP":
                        Help(); //Call Help method
                        break;
                    default:
                        Console.WriteLine($"\nSorry I don't understand that command.\"{choice}\"");
                        Console.ReadKey();
                        break;
                }
            }
            while (choice != "GO NORTH" || choice != "GO EAST" || choice != "GO SOUTH" || choice != "GO WEST");
        }

        // Potential helper function for repeated uses of Console.WriteLine(a) and Thread.Sleep(b)
        // Takes an array of (string a,int b)
        // No, I could not make the name shorter.
        static void PrintMultiDelayString(string text)
        {

                Console.WriteLine(text);
                Thread.Sleep(200);
        }

        public static Entity.Character GetChar(int menu)
        {
            switch (menu)
            {
                case 1:
                    {
                        return new Entity.Character
                        {
                            name = "Beef",
                            health = Entity.EntityHealth.InitHealth(12),
                            damDice = 4,
                            strength = 0,
                            finesse = 0,
                            toughness = 1,
                            presence = 1
                        };
                    }
                case 2:
                    {
                        return new Entity.Character
                        {
                            name = "Stabbs",
                            health = Entity.EntityHealth.InitHealth(8),
                            damDice = 8,
                            strength = 1,
                            finesse = -1,
                            toughness = 0,
                            presence = 0
                        };
                    }
                case 3:
                    {
                        return new Entity.Character
                        {
                            name = "Dodgio",
                            health = Entity.EntityHealth.InitHealth(10),
                            damDice = 6,
                            strength = 2,
                            finesse = 1,
                            toughness = 0,
                            presence = 0
                        };
                    }
                default:
                    Console.WriteLine("Error Returning default");
                    return new Entity.Character
                    {
                        name = "Beef",
                        health = Entity.EntityHealth.InitHealth(12),
                        damDice = 4,
                        strength = 0,
                        finesse = 0,
                        toughness = 1,
                        presence = 1
                    };
            }
        }


        //Art file renderer, call method with: directory of text file as a string, print delay between lines, console colour int value 
        //Use directory "../../../Art Files/{file}.txt/"
        static void RenderFrame(string file, int printDelay, int colour)
        {
            Console.ForegroundColor = (ConsoleColor)colour;
            try
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    string? line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                        Thread.Sleep(printDelay);
                    }
                }
            }
            //If file could not be found in expected directory
            catch (Exception ex)
            {
                //Will report expected directory
                Console.WriteLine($"File could not be read : {ex.Message}");
            }
            Console.ResetColor();
        }

        static void Help() //Help function to display commonly used commands in game
        {
            Console.WriteLine("\nThe game commands are GO [COMPASS DIRECTION], HELP, SEARCH and STATUS");
            Console.WriteLine("            The commands are not case sensitive");
            Thread.Sleep(200);
            Console.WriteLine("GO [DIRECTION] -- This command takes you to a different room based on its relative position to the current room");
            Thread.Sleep(200);
            Console.WriteLine("     HELP      -- This command prints the help menu");
            Thread.Sleep(200);
            Console.WriteLine("    SEARCH     -- This command searches the room the player is currently in");
            Thread.Sleep(200);
            Console.WriteLine("    STATUS     -- This command shows the players character sheet");
            Thread.Sleep(200);
            Console.WriteLine("Press Enter to close");
            Console.ReadLine();
            Console.Clear();
        }

        //For skill checks and combat so you pass it the skill you want to test and it simulates a dice roll and then returns the result 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Roll(int hitMod, ref Random rnd)
        {
            return rnd.Next(1, 21) + hitMod;
        }

        public static void GameOver() //placeholder function for an animation and possible conditional like what killed you 
        {
            Console.WriteLine("You loose");
            Thread.Sleep(200);
            Console.WriteLine("GAME OVER");
            Thread.Sleep(200);
            Environment.Exit(2000);
        }

        // Singular function for a single round of combat
        public static void Combat(ref Character hero, ref Monster monster,ref Random random)
        {
            do
            {
                Console.Clear();
                int player_roll = Roll(hero.strength,ref random);
                if (player_roll >= monster.hitDiff)
                {
                    int dam = random.Next(1, hero.damDice + 1);
                    monster.health.curHP -= dam;
                    Console.WriteLine($"You strike the {monster.name} for {dam} damage");
                    Thread.Sleep(200);
                }
                else
                {
                    Console.WriteLine($"{hero.name} Strikes the {monster.name} and misses");
                    Thread.Sleep(200);
                }
                if (monster.health.curHP > 0)
                {
                    monster.PrintHealthBar();
                }
                else
                {
                    Console.WriteLine($"{monster.name} has been defeated");
                }
                if (monster.health.curHP > 0)
                {
                    //Monster 'attacks'
                    player_roll = Roll(hero.finesse, ref random);
                    if (player_roll <= monster.dodgeDiff)
                    {
                        int dam = random.Next(1, monster.damDice + 1);
                        hero.health.curHP -= dam;
                        Console.WriteLine($"{monster.name} strikes you for {dam} damage");
                        Thread.Sleep(200);
                    }
                    else
                    {
                        Console.WriteLine($"{hero.name} dodges the {monster.name}'s attack just in time");
                        Thread.Sleep(200);
                    }
                }
                if (hero.health.curHP <= 0)
                {
                    GameOver();
                }
                else
                {
                    hero.PrintHealthBar();
                    Thread.Sleep(1000);
                }
                Thread.Sleep(1000);
            } while (monster.health.curHP! > 0 || monster.health.curHP! > 0);
            Console.Clear();
        }

        // Function that scans through a list of paths and returns the first valid one. Returns null if none found.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string? FindWorkingPath(string[] paths)
        {
            // Look through all possible paths
            foreach (string? path in paths)
            {
                if (System.IO.File.Exists(path))
                {
                    return path;
                }
            }
            // We found nothing and all paths are exhausted
            return null;
        }

    }
}
