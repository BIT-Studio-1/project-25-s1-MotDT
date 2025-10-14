using static Studio_1.Entity;
using System.Runtime.CompilerServices;

namespace Studio_1
{
    internal class Program
    {
        /// <summary>
        /// A struct that contains the data for  game state.
        /// </summary>
        struct GameState
        {
            public Entity.Character hero;
            public Monster[] monsters;
            public Random random_gen;
        }
        static void Main()
        {
            // Title Card
            RenderFrame(FindWorkingPath(new string[] { "../../../Art Files/Title.txt", "Art Files/Title.txt" }), 200, 12);

            Console.WriteLine();
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
            Entity.Character hero = GetChar(menu);
            Console.WriteLine($"Your Character is {hero.name}\n");
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
                        dodgeDiff = 14,
                        hitDiff = 14,
                        item1 = false
                    },
                    new Entity.Monster
                    {
                        health = Entity.EntityHealth.InitHealth(6),
                        name = "Goblin",
                        damDice = 4,
                        dodgeDiff = 14,
                        hitDiff = 14,
                        item1 = true
                    }
                },
                random_gen = new Random()
            };
            
            Entrance(initial_state); // Call Entrance method
        }

        static void Entrance(GameState state)
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
                Console.WriteLine("What would you like to do?");
                choice = Console.ReadLine().ToUpper();
                switch (choice)
                {
                    case "GO NORTH":
                        Room2(state); //Call Room2 method
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
                        Thread.Sleep(1000);
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

        static void Room2(GameState state)
        {
            string choice;
            do
            {
                Console.Clear();
                Console.WriteLine("You find yourself in a small damp room");
                if (state.monsters[0].health.IsAlive == true)
                {
                    RenderFrame(FindWorkingPath(new string[] {"../../../Art Files/Room2Ghoul.txt","Art Files/Room2Ghoul.txt"})  , 25, 10); //Background with enemy
                    Thread.Sleep(200);
                    Console.WriteLine("Before you can act a Ghoul ambushes you");
                    Thread.Sleep(200);
                    Console.WriteLine("You must vanquish it before you can act freely");
                    Thread.Sleep(400);
                }
                if (state.monsters[0].health.IsAlive == true)
                {
                    Combat(ref state.hero, ref state.monsters[0], ref state.random_gen);
                }
                RenderFrame(FindWorkingPath(new string[] {"../../../Art Files/Room2Ghoul.txt","Art Files/Room2Ghoul.txt"}), 25, 10); //Background with dead enemy
                Thread.Sleep(100);
                Console.WriteLine("To the north there is a small hole in the wall");
                Thread.Sleep(100);
                Console.WriteLine("To your south is the door back to the entrance of the tower");
                Thread.Sleep(200);
                Console.WriteLine("What would you like to do?");
                choice = Console.ReadLine().ToUpper();
                switch (choice)
                {
                    case "GO NORTH":
                        Room3(state); //Call Room3 method
                        break;
                    case "GO SOUTH":
                        Entrance(state); //Call Entrance method
                        break;
                    case "GO EAST":
                        Console.WriteLine("Placeholder text room to be added currently goes to entrance");
                        Entrance(state); //Call Entrance method
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

        static void Room3(GameState state)
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
                Console.WriteLine("To the north lies the way up");
                Thread.Sleep(200);
                Console.WriteLine("What would you like to do?");
                choice = Console.ReadLine().ToUpper();
                switch (choice)
                {
                    case "GO SOUTH":
                        Room2(state);
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

        // Potential helper function for repeated uses of Console.WriteLine(a) and Thread.Sleep(b)
        // Takes an array of (string a,int b)
        // No, I could not make the name shorter.
        static void PrintMultiDelayString((string, int)[] data)
        {
            // Iterate through each pair
            foreach ((string, int) line in data)
            {
                Console.WriteLine(line.Item1);
                Thread.Sleep(line.Item2);
            }
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
            Console.WriteLine("\nThe game commands are GO [DIRECTION], HELP, SEARCH and STATUS");
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

        public static void GameOver() //placeholder function for an animation and possible conditonal like what killed you 
        {
            Console.WriteLine("You loose");
            Thread.Sleep(200);
            Console.WriteLine("GAME OVER");
            Thread.Sleep(200);
            Environment.Exit(2000);
        }

        /// <summary>
        /// Singular function for a single round of combat
        /// </summary>
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
                    Thread.Sleep(1000);
                }
                else
                {
                    Console.WriteLine($"{hero.name} Strikes the {monster.name} and misses");
                    Thread.Sleep(1000);
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
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Console.WriteLine($"{hero.name} dodges the {monster.name}'s attack just in time");
                        Thread.Sleep(1000);
                    }
                }
                if (hero.health.curHP >= 0)
                {
                    GameOver();
                }
                else
                {
                    hero.PrintHealthBar();
                    Thread.Sleep(1000);
                }
            } while (monster.health.curHP! > 0 || monster.health.curHP! > 0);
            Console.WriteLine($"Combat over");
        }

        /// <summary>
        /// Function that scans through a list of paths and returns the first valid one. Returns null if none found.
        /// </summary>
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
