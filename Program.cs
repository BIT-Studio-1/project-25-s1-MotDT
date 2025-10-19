using System.Runtime.CompilerServices;
using static Studio_1.Entity;

namespace Studio_1
{
    internal class Program
    {
        /// <summary> A struct that contains the data for game state. </summary>
        struct GameState
        {
            public Entity.Character hero;
            public Monster[] monsters;
            public Random random_gen;
        }

        //Global constants for changing colour of text, remember to always RESET!
        public const string RESET = "\x1b[0m";
        public const string RED = "\x1b[91m"; //Monster names
        public const string GREEN = "\x1b[92m";
        public const string YELLOW = "\x1b[93m"; //Navigation directions
        public const string BLUE = "\x1b[94m"; //Interactable objects
        public const string MAGENTA = "\x1b[95m"; //Collectable items
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

            //intro paragraph
            Console.WriteLine();
            PrintDelayed("Cold stone and stale air greet you.");
            PrintDelayed("To the south a rusted door that promises danger and a chance at freedom.");
            Console.WriteLine("Choose Beef, Stabbs, or Dodgio and prove your fate.\n");

            // Character Selection dialog
            PrintDelayed("Choose a character! \n");
            PrintDelayed("=+=+=+=+=+=+=+=+=+=+=+=+=+=+=");
            PrintDelayed($"[1] BEEF   the {GREEN}TANKY{RESET} warrior");
            PrintDelayed($"[2] Stabbs the {RED}DAMAGING{RESET} rouge");
            PrintDelayed($"[3] Dodgio the {BLUE}EVASIVE{RESET} acrobat");
            PrintDelayed("=+=+=+=+=+=+=+=+=+=+=+=+=+=+=");
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
                    },
                    new Entity.Monster
                    {
                        health = Entity.EntityHealth.InitHealth(20), // tougher HP
                        name = "Elite Wraith",                      // elite boss name
                        damDice = 10,                               // stronger damage
                        dodgeDiff = 18,                             // harder to hit
                        hitDiff = 14,                               // harder to dodge
                        item1 = true                                // drops the special key
    }
                    },
                random_gen = new Random()
            };

            GC.Collect();
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
                RenderFrame(FindWorkingPath(new string[] { "../../../Art Files/Room1.txt", "Art Files/Room1.txt" }), 25, 10); //Background 
                PrintDelayed("You find yourself in the dark entrance way of the wizard's tower");
                PrintDelayed("It is a small limestone room. A single torch dimly illuminates the otherwise dark entrance");
                PrintDelayed($"There is a wooden door with a broken lock to the {YELLOW}{UNDERLINE}NORTH{RESET}{NOUNDERLINE}");
                PrintDelayed($"To your {YELLOW}{UNDERLINE}SOUTH{RESET}{NOUNDERLINE} lies the door back to civilisation perhaps you should abandon your quest?");
                PrintDelayed($"Slumped up against the wall just under the torch is a small {BLUE}SKELETON{RESET}");
                Console.WriteLine();
                PrintDelayed("What would you like to do?");
                // choice = Console.ReadLine().ToUpper();
                choice = Selector.DefaultSelectorMenu(["GO NORTH","GO SOUTH","INSPECT SKELETON","STATUS","HELP"],"");
                switch (choice)
                {
                    case "GO NORTH":
                        F1Hall(state); //Call Room2 method
                        break;
                    case "GO SOUTH":
                        PrintDelayed("Do you wish to run in fear of THE TOWER!!!");
                        Console.WriteLine("Y/N");
                        char leave = char.ToUpper(Convert.ToChar(Console.ReadLine()));
                        if (leave == 'Y')
                        {
                            PrintDelayed("You decide that it may not be worth risking life and limb for treasure after all");
                            PrintDelayed("You run back to your horse hitched outside and return to your life back home");
                            GameOver();
                        }
                        else
                        {
                            PrintDelayed("After some deliberation you decide to continue in search of riches in the tower");
                        }
                        break;
                    case "INSPECT SKELETON":
                        if (!state.hero.bomb)
                        {
                            PrintDelayed($"\nYou see something inside the Skeletons rib cage would you like to grab it Y/N");
                            string search = Console.ReadLine().ToUpper();
                            if (search == "Y")
                            {
                                int check = Roll(state.hero.toughness, ref state.random_gen);
                                if (check > 12)
                                {
                                    PrintDelayed("\nYou push past a giant rat as it claws at your arm");
                                    PrintDelayed("and Find a small bomb hidden inside the skeletons ribs and decide to take it");
                                    state.hero.bomb = true;
                                    Console.ReadKey();
                                }
                                else
                                {
                                    PrintDelayed("\nYou recoil as you are bitten by a giant rat hiding inside the skeleton and take 1 damgae");
                                    state.hero.health.curHP -= 1;
                                    if (state.hero.health.curHP <= 0)
                                    {
                                        PrintDelayed("You fall to the ground in agony as another rat bites your ancle");
                                        PrintDelayed("Soon you are overwelmed by vermin and sucm to the swarm");
                                        GameOver();
                                    }
                                    Console.ReadKey();
                                }
                            }
                        }
                        else
                        {
                            PrintDelayed("You find nothing of use on the crumpled remains of the skeleton");
                            Console.ReadKey();
                        }
                        break;
                    case "STATUS":
                        state.hero.Status(); //Call Status method from Character class
                        break;
                    case "HELP":
                        Help(); //Call Help method
                        break;
                    default:
                        Console.WriteLine($"\nSorry I don't understand the command \"{choice}\"");
                        Console.ReadKey();
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
                PrintDelayed("You find yourself in a large damp Hallway");
                PrintDelayed($"To the {YELLOW}{UNDERLINE}NORTH{RESET}{NOUNDERLINE} lies a creaking wooden door. You hear shuffling behind it");
                PrintDelayed($"To the {YELLOW}{UNDERLINE}EAST{RESET}{NOUNDERLINE} is an iron gate with a small lock blocking the way to the stairs");
                PrintDelayed($"behind you to the {YELLOW}{UNDERLINE}SOUTH{RESET}{NOUNDERLINE} lies the path back to the entrance");
                PrintDelayed($"On the wall you see a spare {BLUE}TORCH{RESET}");
                PrintDelayed("What would you like to do?");
                // choice = Console.ReadLine().ToUpper();
                choice = Selector.DefaultSelectorMenu(["GO NORTH","GO SOUTH","GO EAST","INSPECT TORCH","STATUS","HELP"],"");
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
                            PrintDelayed("You unlock the gate and proceed up the stairs");
                            Console.ReadKey();
                            F2Main(state); //Call F2Main
                        }
                        else
                        {
                            PrintDelayed("You fiddle with the lock but it refuses to budge");
                            Console.ReadKey();
                        }
                        break;
                    case "INSPECT TORCH":
                        if (!state.hero.torch)
                        {
                            PrintDelayed($"\nYou decide to take the extra torch with you\nnever know when it might come in handy");
                            state.hero.torch = true;
                            Console.ReadKey();
                        }
                        else
                        {
                            PrintDelayed("\nYou have already taken the spare torch");
                            Console.ReadKey();
                        }
                        break;
                    case "STATUS":
                        state.hero.Status();
                        break;
                    case "HELP":
                        Help();
                        break;
                    default:
                        Console.WriteLine($"\nSorry I don't understand the command \"{choice}\"");
                        Console.ReadKey();
                        break;
                }
            }
            while ((choice != "GO SOUTH") || (choice != "GO NORTH") || (choice != "GO EAST"));
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
                    RenderFrame(FindWorkingPath(new string[] { "../../../Art Files/Room3Ghoul.txt", "Art Files/Room3Ghoul.txt" }), 25, 10); //Background with enemy
                    PrintDelayed("Before you can act a Ghoul ambushes you");
                    PrintDelayed("You must vanquish it before you can act freely");
                    Console.ReadKey();
                }
                if (state.monsters[0].health.IsAlive == true)
                {
                    Combat(ref state.hero, ref state.monsters[0], ref state.random_gen);
                }
                RenderFrame(FindWorkingPath(new string[] { "../../../Art Files/Room3GhoulDead.txt", "Art Files/Room3GhoulDead.txt" }), 25, 10); //Background with dead enemy
                Thread.Sleep(100);
                PrintDelayed($"There is a small {BLUE}HOLE{RESET} in the wall");
                PrintDelayed($"The {BLUE}GHOUL{RESET} lays dead on the ground");
                PrintDelayed($"To your {YELLOW}{UNDERLINE}SOUTH{RESET}{NOUNDERLINE} is the door back to the hallway");
                Console.WriteLine("What would you like to do?");
                // choice = Console.ReadLine().ToUpper();
                choice = Selector.DefaultSelectorMenu(["GO SOUTH","INSPECT GHOUL","INSPECT HOLE","STATUS","HELP"],"");
                switch (choice)
                {
                    case "GO SOUTH":
                        F1Hall(state);
                        break;
                    case "INSPECT GHOUL":
                        if (state.monsters[0].item1 == true)
                        {
                            PrintDelayed("\nYou find a key on the body of the ghoul");
                            PrintDelayed("You think this may be the key to the stair case to ascend the tower");
                            Console.ReadKey();
                            state.monsters[0].item1 = false;
                            state.hero.F1Key = true;
                        }
                        else
                        {
                            PrintDelayed("\nYou find nothing of use");
                            Console.ReadKey();
                        }
                        break;
                    case "INSPECT HOLE":
                        if (state.hero.torch)
                        {
                            PrintDelayed("\nYou shine the torch inside the hole");
                            PrintDelayed("on the floor there is a large stone pressure plate and \nin the far corner of the room a bright red vial lies on the floor");
                            PrintDelayed("thankfully with the help of the torch avoiding the pressure plate is easy and you pick up the health potion");
                            state.hero.HealthPotion = true;
                        }
                        else
                        {
                            PrintDelayed("\nThe hole is pitch black");
                            PrintDelayed("Would you like to go through anyway Y/N");
                            choice = Console.ReadLine().ToUpper();
                            if (choice == "Y")
                            {
                                PrintDelayed("\nYou stumble foward into the darkness");
                                PrintDelayed("you feel shifting ground under your feet");
                                PrintDelayed("the last thing you hear is the sound of stone scraping on stone");
                                GameOver();
                            }
                            else
                            {
                                PrintDelayed("\nYou decide its best to come back with some light");
                            }
                        }
                        Console.ReadKey();
                        break;
                    case "STATUS":
                        state.hero.Status();
                        break;
                    case "HELP":
                        Help(); //Call Help method
                        break;
                    default:
                        Console.WriteLine($"\nSorry I don't understand the command \"{choice}\"");
                        Console.ReadKey();
                        break;
                }
            }
            while (choice != "Go South");
        }

        //Floor 2 Main
        //-> West F1Hall, North End, West F2EastHall1, South F2SouthHall1
        //Candle on an interactable somewhere
        static void F2Main(GameState state)
        {
            string choice;
            do
            {
                Console.Clear();
                RenderFrame(FindWorkingPath(new string[] { "../../../Art Files/F2Main.txt", "Art Files/F2Main.txt" }), 25, 10); //Background 
                PrintDelayed("You exit the stair case to find a large stone room");
                PrintDelayed($"To the {YELLOW}{UNDERLINE}NORTH{RESET}{NOUNDERLINE} is a large door flanked by two stone statues with keyholes in them");
                PrintDelayed($"To the {YELLOW}{UNDERLINE}SOUTH{RESET}{NOUNDERLINE} there is an open archway that seems to lead into a large room");
                PrintDelayed($"To the {YELLOW}{UNDERLINE}WEST{RESET}{NOUNDERLINE} is the stairs back down to the first floor");
                PrintDelayed($"To the {YELLOW}{UNDERLINE}EAST{RESET}{NOUNDERLINE} is a stone door with symbols carved into the frame");
                PrintDelayed($"On the floor under one of the statues is a {BLUE}CANDLE{RESET}");
                // choice = Console.ReadLine().ToUpper();
                choice = Selector.DefaultSelectorMenu(["GO NORTH","GO SOUTH","GO EAST","GO WEST","INSPECT CANDLE","STATUS","HELP"],"");
                switch (choice)
                {
                    case "GO NORTH":
                        choice = "";
                        Console.WriteLine("WIP");
                        break;
                    case "GO EAST":
                        F2EastHall1(state);
                        break;
                    case "GO SOUTH":
                        F2SouthHall1(state);
                        break;
                    case "GO WEST":
                        F1Hall(state);
                        break;
                    case "INSPECT CANDLE":
                        Console.ReadKey();
                        break;
                    case "STATUS":
                        state.hero.Status(); //Call Status method from Character class
                        break;
                    case "HELP":
                        Help(); //Call Help method
                        break;
                    default:
                        Console.WriteLine($"\nSorry I don't understand the command \"{choice}\"");
                        Console.ReadKey();
                        break;
                }
            }
            while (choice != "GO NORTH" || choice != "GO EAST" || choice != "GO SOUTH" || choice != "GO WEST");
        }

        //Floor 2 East Hall 1
        //-> West F2Main, East F2EastHall2
        //Room has candle on an interactable somewhere
        static void F2EastHall1(GameState state)
        {
            string choice;
            do
            {
                Console.Clear();
                RenderFrame(FindWorkingPath(new string[] { "../../../Art Files/F2EastHall1.txt", "Art Files/F2EastHall1.txt" }), 25, 10); //Background 
                PrintDelayed($"To the {YELLOW}{UNDERLINE}EAST{RESET}{NOUNDERLINE} there is a hole in the wall wich eminates a ominus presance");
                PrintDelayed($"To the {YELLOW}{UNDERLINE}WEST{RESET}{NOUNDERLINE} lies the door back to the main hall");
                // choice = Console.ReadLine().ToUpper();
                choice = Selector.DefaultSelectorMenu(["GO EAST","GO WEST","INSPECT","STATUS","HELP"],"");
                switch (choice)
                {
                    case "GO EAST":
                        F2EastHall2(state);
                        break;
                    case "GO WEST":
                        F2Main(state);
                        break;
                    case "INSPECT":
                        Console.ReadKey();
                        break;
                    case "STATUS":
                        state.hero.Status(); //Call Status method from Character class
                        break;
                    case "HELP":
                        Help(); //Call Help method
                        break;
                    default:
                        Console.WriteLine($"\nSorry I don't understand the command \"{choice}\"");
                        Console.ReadKey();
                        break;
                }
            }
            while (choice != "GO EAST" || choice != "GO WEST");
        }

        //Floor 2 East Hall 2
        //-> West F2EastHall 1
        //Room with elite monster that drops key
        static void F2EastHall2(GameState state)
        {
            string choice;
            do
            {
                Console.Clear();
                // if the elite wraith is still alive, initiate combat
                if (state.monsters[3].health.IsAlive == true)
                {

                    RenderFrame(FindWorkingPath(new string[] { "../../../Art Files/F2EastHall2.txt", "Art Files/F2EastHall2.txt" }), 25, 10); //Background 

                    // art file for the monster needed

                    //text for the room before combat
                    PrintDelayed("A chilling presence fills the hall...");
                    PrintDelayed("The Elite Wraith emerges from the shadows!");
                    choice = Console.ReadLine().ToUpper();

                    Combat(ref state.hero, ref state.monsters[3], ref state.random_gen);
                }

                // After combat, show the cleared room
                RenderFrame(FindWorkingPath(new string[] { "../../../Art Files/F2EastHall2.txt", "Art Files/F2EastHall2.txt" }), 25, 10);
                PrintDelayed("The room is eerily quiet now.");
                PrintDelayed("The Elite Wraith lies defeated, its essence fading.");
                PrintDelayed("To the WEST is the way back.");
                // choice = Console.ReadLine().ToUpper();
                choice = Selector.DefaultSelectorMenu(["GO WEST","INSPECT WRAITH","STATUS","HELP"],"");

                switch (choice)
                {
                    case "GO WEST":
                        F2EastHall1(state);
                        break;
                    case "INSPECT WRAITH":
                        if (state.monsters[3].item1 == true)
                        {
                            PrintDelayed("\nYou find a strange glowing key among the Wraith’s remains.");
                            PrintDelayed("This must unlock something deeper in the tower...");
                            Console.ReadKey();
                            state.monsters[3].item1 = false;
                            state.hero.F2Key1 = true;
                        }
                        else
                        {
                            PrintDelayed("\nThere is nothing of use.");
                            Console.ReadKey();
                        }
                        break;
                    case "STATUS":
                        state.hero.Status(); //Call Status method from Character class
                        break;
                    case "HELP":
                        Help(); //Call Help method
                        break;
                    default:
                        Console.WriteLine($"\nSorry I don't understand the command \"{choice}\"");
                        Console.ReadKey();
                        break;
                }
            }
            while (choice != "GO WEST");
        }

        //Floor 2 South Hall 1
        //-> North F2Main, South F2SouthHall2
        //Room with candelabra that needs 3 candles for code for the locked chest
        static void F2SouthHall1(GameState state)
        {
            string choice;
            do
            {
                Console.Clear();
                RenderFrame(FindWorkingPath(new string[] { "../../../Art Files/F2SouthHall1.txt", "Art Files/F2SouthHall1.txt" }), 25, 10); //Background 
                //Text goes here
                // choice = Console.ReadLine().ToUpper();
                choice = Selector.DefaultSelectorMenu(["GO NORTH","GO SOUTH","INSPECT","STATUS","HELP"],"");
                switch (choice)
                {
                    case "GO NORTH":
                        F2Main(state);
                        break;
                    case "GO SOUTH":
                        F2SouthHall2(state);
                        break;
                    case "INSPECT":
                        Console.ReadKey();
                        break;
                    case "STATUS":
                        state.hero.Status(); //Call Status method from Character class
                        break;
                    case "HELP":
                        Help(); //Call Help method
                        break;
                    default:
                        Console.WriteLine($"\nSorry I don't understand the command \"{choice}\"");
                        Console.ReadKey();
                        break;
                }
            }
            while (choice != "GO NORTH" || choice != "GO SOUTH");
        }
        //Floor 2 South Hall 2
        //-> North F2SouthHall1
        //Room with locked chest containing key that needs a code
        //Enemy in room you have to approach, has candle on body
        static void F2SouthHall2(GameState state)
        {
            string choice;
            do
            {
                Console.Clear();
                RenderFrame(FindWorkingPath(new string[] { "../../../Art Files/F2SouthHall2.txt", "Art Files/F2SouthHall2.txt" }), 25, 10); //Background 
                //Text goes here
                // choice = Console.ReadLine().ToUpper();
                choice = Selector.DefaultSelectorMenu(["GO NORTH","INSPECT","STATUS","HELP"],"");
                switch (choice)
                {
                    case "GO NORTH":
                        F2SouthHall1(state);
                        break;
                    case "INSPECT":
                        Console.ReadKey();
                        break;
                    case "STATUS":
                        state.hero.Status(); //Call Status method from Character class
                        break;
                    case "HELP":
                        Help(); //Call Help method
                        break;
                    default:
                        Console.WriteLine($"\nSorry I don't understand the command \"{choice}\"");
                        Console.ReadKey();
                        break;
                }
            }
            while (choice != "GO NORTH");
        }

        /// <summary> Blueprint for making new rooms. Do not call this method!</summary>
        static void RoomBlueprint(GameState state)
        {
            string choice;
            do
            {
                Console.Clear();
                RenderFrame(FindWorkingPath(new string[] { "../../../Art Files/.txt", "Art Files/.txt" }), 25, 10); //Background 
                //Text goes here
                choice = Console.ReadLine().ToUpper();
                // choice = Selector.DefaultSelectorMenu(["GO NORTH","GO SOUTH","INSPECT","STATUS","HELP"],"");
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
                    case "INSPECT":
                        Console.ReadKey();
                        break;
                    case "STATUS":
                        state.hero.Status(); //Call Status method from Character class
                        break;
                    case "HELP":
                        Help(); //Call Help method
                        break;
                    default:
                        Console.WriteLine($"\nSorry I don't understand the command \"{choice}\"");
                        Console.ReadKey();
                        break;
                }
            }
            while (choice != "GO NORTH" || choice != "GO EAST" || choice != "GO SOUTH" || choice != "GO WEST");
        }



        /// <summary>Print merged with sleep(200)</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static void PrintDelayed(string text)
        {
            Console.WriteLine(text);
            Thread.Sleep(200);
        }

        /// <summary>Print merged with sleep(), with custom time</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static void PrintDelayed(string text, int duration)
        {
            Console.WriteLine(text);
            Thread.Sleep(duration);
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
        static void RenderFrame(string? file, int printDelay, int colour)
        {
            Console.ForegroundColor = (ConsoleColor)colour;
            try
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    string? line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        PrintDelayed(line, printDelay);
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

        /// <summary>Help function to display commonly used commands in game</summary>
        static void Help()
        {
            Console.WriteLine(@$"┌────────────────┬──────────────────────────────────────────────────────────────────────────────────┐
│ GO {YELLOW}{UNDERLINE}[DIRECTION]{RESET}{NOUNDERLINE} │ Takes you to a different room based on its relative position to the current room │
│      HELP      │ Prints the help menu                                                             │
│INSPECT {BLUE}[OBJECT]{RESET}│ Inspect an object in the current room                                            │
│   USE {MAGENTA}[ITEM]{RESET}   │ Use an item in your inventory                                                    │
│     STATUS     │ Shows the players character sheet                                                │
└────────────────┴──────────────────────────────────────────────────────────────────────────────────┘");
            PrintDelayed($"Note: Commands are not case sensitive.");
            PrintDelayed("Press any key to continue");
            Console.ReadKey();
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
            PrintDelayed("You lose");
            PrintDelayed("GAME OVER");
            Environment.Exit(2000);
        }

        // Singular function for a single round of combat
        public static void Combat(ref Character hero, ref Monster monster, ref Random random)
        {
            do
            {
                Console.Clear();
                int player_roll = Roll(hero.strength, ref random);
                if (player_roll >= monster.hitDiff)
                {
                    int dam = random.Next(1, hero.damDice + 1);
                    monster.health.curHP -= dam;
                    PrintDelayed($"You strike the {monster.name} for {dam} damage");
                }
                else
                {
                    PrintDelayed($"{hero.name} Strikes the {monster.name} and misses");
                }
                if (hero.bomb || hero.HealthPotion)
                {
                    PrintDelayed("\nWould you like to use an item Y/N ");
                    string userResponse = Console.ReadLine().ToUpper();
                    if (userResponse == "Y")
                    {
                        PrintDelayed("Do you want to use a BOMB or a POTION");
                        // string item = Console.ReadLine().ToUpper();
                        string item = Selector.DefaultSelectorMenu(["BOMB","POTION","CANCEL"],"");
                        switch (item)
                        {
                            case "BOMB":
                                if (hero.bomb == true)
                                {
                                    int dam = random.Next(1, 9);
                                    PrintDelayed($"You throw your bomb at the {monster.name} and it explodes dealing {dam} damage");
                                    monster.health.curHP -= dam;
                                    hero.bomb = false;
                                }
                                else
                                {
                                    PrintDelayed($"You do not currently have a BOMB");
                                }
                                break;
                            case "POTION":
                                if (hero.HealthPotion == true)
                                {
                                    int heal = random.Next(1, 9);
                                    PrintDelayed($"You drink your health potion and heal yourself for {heal}");
                                    hero.health.curHP += heal;
                                    hero.HealthPotion = false;
                                }
                                else
                                {
                                    PrintDelayed($"You do not currently have a POTION");
                                }
                                break;
                            case "CANCEL":
                                break;
                        }
                    }

                    // The united lines of monster health checking
                    if (monster.health.curHP > 0)
                    {
                        // IT DOES WHAT IT DOES
                        monster.PrintHealthBar();
                        //Monster 'attacks'
                        player_roll = Roll(hero.finesse, ref random);
                        if (player_roll <= monster.dodgeDiff)
                        {
                            int dam = random.Next(1, monster.damDice + 1);
                            hero.health.curHP -= dam;
                            PrintDelayed($"{monster.name} strikes you for {dam} damage");
                        }
                        else
                        {
                            PrintDelayed($"{hero.name} dodges the {monster.name}'s attack just in time");
                        }
                    }
                    else
                    {
                        PrintDelayed($"{monster.name} has been defeated");
                    }

                    // Check on the hero
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
                }
            } while (monster.health.curHP! > 0 || monster.health.curHP! > 0);
        }

        /// <summary>Function that scans through a list of paths and returns the first valid one. Returns null if none found.</summary>
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
