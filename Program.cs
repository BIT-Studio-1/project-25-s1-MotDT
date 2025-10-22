git using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Xml;
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
            Console.OutputEncoding = System.Text.Encoding.UTF8;
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
            // string confirm;
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
                } while (menu < 1 || menu > 4 || parse == false);
                Entity.Character display = GetChar(menu);
                Console.WriteLine();
                display.Status();
            } while (!Selector.BoolSelectorMenu("Is this you?: \n"));

            Entity.Character hero = GetChar(menu);

            // Initialize the game's state.
            GameState initial_state = new GameState
            {
                hero = hero,
                monsters = new Monster[] {
                    new Entity.Monster
                    {
                        health = Entity.EntityHealth.InitHealth(6),
                        name = "Ghoul",
                        damDice = 3,
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
                        damDice = 5,                               // stronger damage changed from 10 to 5
                        dodgeDiff = 13,                             // harder to hit changed from 18 to 13
                        hitDiff = 11,                               // harder to dodge changed from 14 to 11
                        item1 = true                                // drops the special key
    }
                    },
                random_gen = new Random()
            };

            GC.Collect();
            F1Entrance(initial_state); // Call Entrance method
        }

        static void EndPrompts()
        {
            Console.WriteLine($"{GREEN}◆{RESET}");
            Console.ReadKey();
        }

        //Floor 1 entrance
        //-> North F1Hall
        static void F1Entrance(GameState state)
        {
            string choice;
            do
            {
                Console.Clear();
                RenderFrame(FindWorkingPath(new string[] { "../../../Art Files/F1Entrance.txt", "Art Files/F1Entrance.txt" }), 25, 10); //Background 
                PrintDelayed("You find yourself in the dark entrance way of the wizard's tower");
                PrintDelayed("It is a small limestone room. A single torch dimly illuminates the otherwise dark entrance");
                PrintDelayed($"There is a wooden door with a broken lock to the {YELLOW}{UNDERLINE}NORTH{RESET}{NOUNDERLINE}");
                PrintDelayed($"To your {YELLOW}{UNDERLINE}SOUTH{RESET}{NOUNDERLINE} lies the door back to civilisation perhaps you should abandon your quest?");
                PrintDelayed($"Slumped up against the wall just under the torch is a small {BLUE}SKELETON{RESET}");
                Console.WriteLine();
                PrintDelayed("What would you like to do?");
                // choice = Console.ReadLine().ToUpper();
                choice = Selector.DefaultSelectorMenu(["GO NORTH", "GO SOUTH", "INSPECT SKELETON", "STATUS", "HELP"], "");
                switch (choice)
                {
                    case "GO NORTH":
                        F1Hall(state); //Call Room2 method
                        break;
                    case "GO SOUTH":
                        PrintDelayed("\nDo you wish to run in fear of THE TOWER!!!");
                        if (Selector.BoolSelectorMenu(""))
                        {
                            PeacefulEnding();
                        }
                        else
                        {
                            PrintDelayed("\nAfter some deliberation you decide to continue in search of riches in the tower");
                            EndPrompts();
                        }
                        break;
                    case "INSPECT SKELETON":
                        if (!state.hero.bomb)
                        {
                            PrintDelayed("\nYou see something round alongside an angry looking rat inside the skeletons rib cage.");
                            PrintDelayed("Would you like to try and grab it?");
                            // string search = Console.ReadLine().ToUpper();
                            if (Selector.BoolSelectorMenu(""))
                            {
                                PrintDelayed("Testing your TOUGHNESS...");
                                Thread.Sleep(1000);
                                int check = Roll(state.hero.toughness, ref state.random_gen);
                                if (check > 12)
                                {
                                    PrintDelayed($"\nYou push past the giant rat as it claws at your arm and find a small {MAGENTA}BOMB{RESET} hidden inside the skeletons ribs!");
                                    PrintDelayed("You stash it for later.");
                                    state.hero.bomb = true;
                                    EndPrompts();
                                }
                                else
                                {
                                    PrintDelayed("\nYou recoil as you are bitten by a giant rat hiding inside the skeleton.");
                                    PrintDelayed($"{RED}You take 1 damage!{RESET}");
                                    state.hero.health.curHP -= 1;
                                    if (state.hero.health.curHP <= 0)
                                    {
                                        PrintDelayed("You fall to the ground in agony as the rat bites your ankle");
                                        PrintDelayed("More rats appear from the shadows and you are overwhelmed by vermin and succumb to the swarm");
                                        GameOver("a swarm of angry rats");
                                    }
                                    EndPrompts();
                                }
                            }
                        }
                        else
                        {
                            PrintDelayed("\nThere is nothing left on the skeleton, other than an angry rat.");
                            EndPrompts();
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
                if (state.hero.torch == true)
                {
                    RenderFrame(FindWorkingPath(new string[] { "../../../Art Files/F1HallNoTorch.txt", "Art Files/F1HallNoTorch.txt" }), 25, 10);
                }
                else
                {
                    RenderFrame(FindWorkingPath(new string[] { "../../../Art Files/F1Hall.txt", "Art Files/F1Hall.txt" }), 25, 10);
                }          
                PrintDelayed("You find yourself in a large damp Hallway");
                PrintDelayed($"To the {YELLOW}{UNDERLINE}NORTH{RESET}{NOUNDERLINE} lies a creaking wooden door. You hear shuffling behind it");
                PrintDelayed($"To the {YELLOW}{UNDERLINE}EAST{RESET}{NOUNDERLINE} is an iron gate with a small lock blocking the way to the stairs");
                PrintDelayed($"behind you to the {YELLOW}{UNDERLINE}SOUTH{RESET}{NOUNDERLINE} lies the path back to the entrance");
                if (state.hero.torch != true)
                {
                    PrintDelayed($"On the wall you see a spare {BLUE}TORCH{RESET}");
                }
                PrintDelayed("What would you like to do?");
                // choice = Console.ReadLine().ToUpper();
                choice = Selector.DefaultSelectorMenu(new[] { "GO NORTH", "GO SOUTH", "GO EAST", "INSPECT TORCH", "INVENTORY", "STATUS", "HELP" }, "");
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
                            PrintDelayed($"\nYou unlock the gate using the {MAGENTA}RUSTY KEY{RESET} and proceed up the stairs");
                            EndPrompts();
                            F2Main(state); //Call F2Main
                        }
                        else
                        {
                            PrintDelayed("\nYou fiddle with the lock but it refuses to budge");
                            EndPrompts();
                        }
                        break;
                    case "INSPECT TORCH":
                        if (!state.hero.torch)
                        {
                            PrintDelayed($"\nYou decide to take the {MAGENTA}TORCH{RESET} with you, never know when it might come in handy");
                            state.hero.torch = true;
                        }
                        else
                        {
                            PrintDelayed("\nYou have already taken the torch");
                        }
                        EndPrompts();
                        break;
                    case "INVENTORY":
                        Console.WriteLine("Inventory:");
                        if (state.hero.bomb) Console.WriteLine("- Bomb");
                        if (state.hero.HealthPotion) Console.WriteLine("- Health Potion");
                        if (state.hero.F1Key) Console.WriteLine("- Rusty Key");
                        if (state.hero.F2Key1 || state.hero.F2Key2) Console.WriteLine("- Glowing Key(s)");
                        if (state.hero.F2chestKey) Console.WriteLine("- Small Key");
                        if (state.hero.candle1 || state.hero.candle2 || state.hero.candle3) Console.WriteLine("- Candle(s)");
                        EndPrompt();
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
                    RenderFrame(FindWorkingPath(new string[] { "../../../Art Files/F1Room3Ghoul.txt", "Art Files/F1Room3Ghoul.txt" }), 25, 10); //Background with enemy
                    PrintDelayed($"Before you can act a {RED}GHOUL{RESET} ambushes you");
                    PrintDelayed("You must vanquish it before you can act freely");
                    PrintDelayed($"{RED}Prepare for combat...{RESET}");
                    EndPrompts();
                }
                if (state.monsters[0].health.IsAlive == true)
                {
                    Combat(ref state.hero, ref state.monsters[0], ref state.random_gen);
                }
                RenderFrame(FindWorkingPath(new string[] { "../../../Art Files/F1Room3GhoulDead.txt", "Art Files/F1Room3GhoulDead.txt" }), 25, 10); //Background with dead enemy
                PrintDelayed($"There is a small {BLUE}HOLE{RESET} in the wall");
                PrintDelayed($"The {BLUE}GHOUL{RESET} lays dead on the ground");
                PrintDelayed($"To your {YELLOW}{UNDERLINE}SOUTH{RESET}{NOUNDERLINE} is the door back to the hallway");
                Console.WriteLine("What would you like to do?");
                choice = Selector.DefaultSelectorMenu(new[] { "GO SOUTH", "INSPECT GHOUL", "INSPECT HOLE", "INVENTORY", "STATUS", "HELP" }, "");
                switch (choice)
                {
                    case "GO SOUTH":
                        F1Hall(state);
                        break;
                    case "INSPECT GHOUL":
                        if (state.monsters[0].item1 == true)
                        {
                            PrintDelayed($"\nYou find a {MAGENTA}RUSTY KEY{RESET} on the body of the ghoul");
                            PrintDelayed("You think this may be the key for the gate in front of the staircase.");
                            state.monsters[0].item1 = false;
                            state.hero.F1Key = true;
                        }
                        else
                        {
                            PrintDelayed("\nYou find nothing of use");
                        }
                        EndPrompts();
                        break;
                    case "INSPECT HOLE":
                        if (state.hero.torch)
                        {
                            if (state.hero.HealthPotion == false)
                            {
                                PrintDelayed($"\nYou shine the {MAGENTA}TORCH{RESET} inside the hole.");
                                PrintDelayed("On the floor there is a large stone pressure plate and in the far corner of the room a bright red vial lies on the floor.");
                                PrintDelayed($"Thankfully with the help of the torch avoiding the pressure plate is easy and you pick up the {MAGENTA}HEALTH POTION{RESET}.");
                                state.hero.HealthPotion = true;
                            }
                            else
                            {
                                PrintDelayed("\nNothing remains inside the dark room");
                            }
                        }
                        else
                        {
                            PrintDelayed("\nThe hole is pitch black");
                            PrintDelayed("Would you like to go through anyway?");
                            
                            if (Selector.BoolSelectorMenu(""))
                            {
                                PrintDelayed("\nYou stumble forward into the darkness.");
                                PrintDelayed("You feel shifting ground under your feet");
                                PrintDelayed("The last thing you hear is the sound of stone scraping on stone.");
                                GameOver("a hidden trap in the darkness");
                            }
                            else
                            {
                                PrintDelayed("\nYou decide its best to come back with some light.");
                            }
                        }
                        EndPrompts();
                        break;
                    case "INVENTORY":
                        Console.WriteLine("Inventory:");
                        if (state.hero.bomb) Console.WriteLine("- Bomb");
                        if (state.hero.HealthPotion) Console.WriteLine("- Health Potion");
                        if (state.hero.F1Key) Console.WriteLine("- Rusty Key");
                        if (state.hero.F2Key1 || state.hero.F2Key2) Console.WriteLine("- Glowing Key(s)");
                        if (state.hero.F2chestKey) Console.WriteLine("- Small Key");
                        if (state.hero.candle1 || state.hero.candle2 || state.hero.candle3) Console.WriteLine("- Candle(s)");
                        EndPrompts();
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
                PrintDelayed("You exit the staircase to find a large stone room");
                PrintDelayed($"To the {YELLOW}{UNDERLINE}NORTH{RESET}{NOUNDERLINE} is a large door flanked by two stone statues with keyholes in them");
                PrintDelayed($"To the {YELLOW}{UNDERLINE}SOUTH{RESET}{NOUNDERLINE} there is an open archway that seems to lead into a large room");
                PrintDelayed($"To the {YELLOW}{UNDERLINE}WEST{RESET}{NOUNDERLINE} is the stairs back down to the first floor");
                PrintDelayed($"To the {YELLOW}{UNDERLINE}EAST{RESET}{NOUNDERLINE} is a stone door with symbols carved into the frame");
                PrintDelayed($"On the floor under one of the statues is a {BLUE}CANDLE{RESET}");
                // choice = Console.ReadLine().ToUpper();
                choice = Selector.DefaultSelectorMenu(new[] { "GO NORTH", "GO SOUTH", "GO EAST", "GO WEST", "INSPECT CANDLE", "INVENTORY", "STATUS", "HELP" },
                switch (choice)
                {
                    case "GO NORTH":
                        if (state.hero.F2Key1 && state.hero.F2Key2)
                        {
                            PrintDelayed("You unlock the heavy door with the two keys.");
                            Console.Clear();
                            RenderFrame(FindWorkingPath(new string[] { "../../../Art Files/End screen.txt", "Art Files/End screen.txt" }), 25, 10);
                            Console.ReadKey();
                            Environment.Exit(0);
                        }
                        else if (state.hero.F2Key1 || state.hero.F2Key2)
                        {
                            PrintDelayed("You place a key into the lock, but another slot remains empty...");
                            Console.ReadKey();
                        }
                        else
                        {
                            PrintDelayed("The door won’t budge — it requires two keys.");
                            Console.ReadKey();
                        }
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
                        if (!state.hero.candle3)
                        {
                            PrintDelayed($"\nYou Decide to pick the small {MAGENTA}CANDLE{RESET} up from underneath the stature and store it for later.");
                            state.hero.candle3 = true;
                        }
                        else
                        {
                            PrintDelayed("\nNothing but a small puddle of wax residue remains at the statues feet.");
                        }
                        EndPrompts();
                        break;

                    case "INVENTORY":
                        Console.WriteLine("Inventory:");
                        if (state.hero.bomb) Console.WriteLine("- Bomb");
                        if (state.hero.HealthPotion) Console.WriteLine("- Health Potion");
                        if (state.hero.F1Key) Console.WriteLine("- Rusty Key");
                        if (state.hero.F2Key1 || state.hero.F2Key2) Console.WriteLine("- Glowing Key(s)");
                        if (state.hero.F2chestKey) Console.WriteLine("- Small Key");
                        if (state.hero.candle1 || state.hero.candle2 || state.hero.candle3) Console.WriteLine("- Candle(s)");
                        EndPrompts();
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
                PrintDelayed("You enter what appears to be a Study dimly lit by moonlight coming through the windows.");
                PrintDelayed($"To the {YELLOW}{UNDERLINE}EAST{RESET}{NOUNDERLINE} there is a hole in the wall which emanates an {RED}ominous presence...{RESET}");
                PrintDelayed($"To the {YELLOW}{UNDERLINE}WEST{RESET}{NOUNDERLINE} lies the door back to the main hall");
                PrintDelayed($"By the north wall is a {BLUE}DESK{RESET} with a large ornate {BLUE}WINDOW{RESET} behind it.");
                PrintDelayed($"{BLUE}BOOKSHELVES{RESET} filled with old parchments and scrolls line the walls.");
                // choice = Console.ReadLine().ToUpper();
                choice = Selector.DefaultSelectorMenu(["GO EAST", "GO WEST", "INSPECT DESK", "INSPECT WINDOW", "INSPECT BOOKSHELVES", "INVENTORY", "STATUS", "HELP"], "");
                switch (choice)
                {
                    case "GO EAST":
                        F2EastHall2(state);
                        break;
                    case "GO WEST":
                        F2Main(state);
                        break;
                    case "INSPECT DESK":
                        PrintDelayed("\nThe desk is covered in a mess of papers each covered with undecipherable scrawls. A dried up ink pot sits on the corner.");
                        if (!state.hero.candle1)
                        {
                            PrintDelayed($"Searching through the drawers you find a {MAGENTA}CANDLE{RESET} and stash it for later.");
                            state.hero.candle1 = true;
                        }
                        else
                        {
                            PrintDelayed("You find nothing else of use inside the desk drawers");
                        }
                        EndPrompts();
                        break;
                    case "INSPECT WINDOW":
                        PrintDelayed("\nYou look out the window into the darkness of the night. The full moon shines brightly in the sky.");
                        EndPrompts();
                        break;
                    case "INSPECT BOOKSHELVES":
                        PrintDelayed("\nYou spend some time rummaging through each bookshelf, however you cannot understand any of the writings and find nothing of use.");
                        EndPrompts();
                        break;
                    case "INVENTORY":
                        Console.WriteLine("Inventory:");
                        if (state.hero.bomb) Console.WriteLine("- Bomb");
                        if (state.hero.HealthPotion) Console.WriteLine("- Health Potion");
                        if (state.hero.F1Key) Console.WriteLine("- Rusty Key");
                        if (state.hero.F2Key1 || state.hero.F2Key2) Console.WriteLine("- Glowing Key(s)");
                        if (state.hero.F2chestKey) Console.WriteLine("- Small Key");
                        if (state.hero.candle1 || state.hero.candle2 || state.hero.candle3) Console.WriteLine("- Candle(s)");
                        EndPrompts();
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
            string choice = "";
            do
            {
                Console.Clear();
                // if the elite wraith is still alive, initiate combat
                if (state.monsters[3].health.IsAlive == true)
                {

                    RenderFrame(FindWorkingPath(new string[] { "../../../Art Files/F2EastHall2Wraith.txt", "Art Files/F2EastHall2Wraith.txt" }), 25, 10); //Background 
                    PrintDelayed("Crawling through the hole you enter a dank chamber with a runic circle engraved into the stone floor.");
                    PrintDelayed($"A moment later the runic circle begins to glow a vibrant purple and a large {RED}WRAITH{RESET} emerges!");
                    PrintDelayed($"{RED}Prepare for combat...{RESET}");
                    EndPrompts();
                    Combat(ref state.hero, ref state.monsters[3], ref state.random_gen);
                }
                // After combat, show the cleared room
                else
                {
                    RenderFrame(FindWorkingPath(new string[] { "../../../Art Files/F2EastHall2WraithDead.txt", "Art Files/F2EastHall2WraithDead.txt" }), 25, 10);
                    PrintDelayed("The chamber is filled with a eerie silence.");
                    PrintDelayed($"The {BLUE}WRAITH{RESET} has disintegrated, its faint miasma still lingering.");
                    PrintDelayed($"The {BLUE}MAGIC CIRCLE{RESET} that summoned the wraith is still faintly glowing on the ground");
                    PrintDelayed($"To the {YELLOW}{UNDERLINE}WEST{RESET}{NOUNDERLINE} is the hole back.");
                    choice = Selector.DefaultSelectorMenu(["GO WEST", "INSPECT WRAITH", "INSPECT MAGIC CIRCLE", "INVENTORY", "STATUS", "HELP"], "");
                    switch (choice)
                    {
                        case "GO WEST":
                            F2EastHall1(state);
                            break;
                        case "INSPECT WRAITH":
                            if (state.monsters[3].item1 == true)
                            {
                                PrintDelayed($"\nYou find a strange {MAGENTA}GLOWING KEY{RESET} on the floor where the wraith disintegrated.");
                                PrintDelayed("This must unlock something deeper in the tower...");
                                state.monsters[3].item1 = false;
                                state.hero.F2Key1 = true;
                            }
                            else
                            {
                                PrintDelayed("\nThe miasma left by the wraith chills your bones.");
                            }
                            EndPrompts();
                            break;
                        case "INSPECT MAGIC CIRCLE":
                            PrintDelayed("\nThe lines and runes of the circle pulse with a dull arcane purple.");
                            PrintDelayed("You hope that the circle won't summon anything else");
                            EndPrompts();
                            break;
                        case "INVENTORY":
                            Console.WriteLine("Inventory:");
                            if (state.hero.bomb) Console.WriteLine("- Bomb");
                            if (state.hero.HealthPotion) Console.WriteLine("- Health Potion");
                            if (state.hero.F1Key) Console.WriteLine("- Rusty Key");
                            if (state.hero.F2Key1 || state.hero.F2Key2) Console.WriteLine("- Glowing Key(s)");
                            if (state.hero.F2chestKey) Console.WriteLine("- Small Key");
                            if (state.hero.candle1 || state.hero.candle2 || state.hero.candle3) Console.WriteLine("- Candle(s)");
                            EndPrompts();
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
                if (state.hero.F2tomeInteract == true)
                {
                    RenderFrame(FindWorkingPath(new string[] { "../../../Art Files/F2SouthHall1NoTome.txt", "Art Files/F2SouthHall1NoTome.txt" }), 25, 10); //Background
                }
                else
                {
                    RenderFrame(FindWorkingPath(new string[] { "../../../Art Files/F2SouthHall1Tome.txt", "Art Files/F2SouthHall1Tome.txt" }), 25, 10); //Background
                }
                PrintDelayed($"You find yourself in a large stone room in the middle of it there is a large {BLUE}MAGIC CIRCLE{RESET} behind which there is a {BLUE}LECTERN{RESET}");
                PrintDelayed($"To the {YELLOW}{UNDERLINE}NORTH{RESET}{NOUNDERLINE} there is an archway that leads back into the floor 2 main hall");
                PrintDelayed($"To the {YELLOW}{UNDERLINE}SOUTH{RESET}{NOUNDERLINE} there is a small ornate door that seems to lead behind the {BLUE}LECTERN{RESET}");
                PrintDelayed($"on the wall adjacent to the entrance there is a {BLUE}CANDLE HOLDER{RESET} ");
                choice = Selector.DefaultSelectorMenu(["GO NORTH", "GO SOUTH", "INSPECT MAGIC CIRCLE", "INSPECT LECTERN", "INSPECT CANDLE HOLDER", "INVENTORY", "STATUS", "HELP"], "");
                switch (choice)
                {
                    case "GO NORTH":
                        F2Main(state);
                        break;
                    case "GO SOUTH":
                        F2SouthHall2(state);
                        break;
                    case "INSPECT MAGIC CIRCLE":
                        PrintDelayed("\nThe circle is engraved with arcane runes beyond your understanding.");
                        PrintDelayed("It appears to be dormant.");
                        EndPrompts();
                        break;
                    case "INSPECT LECTERN":
                        if (state.hero.F2tomeInteract == true)
                        {
                            PrintDelayed("\nThe lectern is empty");
                        }
                        else
                        {
                            PrintDelayed("\nThere is an aged tome bound by leather atop the lectern.");
                            PrintDelayed("The cover has runes that you cannot understand engraved into the leather.");
                            PrintDelayed("Do you want to open the tome?");
                            if (Selector.BoolSelectorMenu(""))
                            {
                                PrintDelayed("\nYou cautiously flip open the first page.");
                                PrintDelayed("The page is covered in seemingly innocuous runes, although you can't understand any of it.");
                                PrintDelayed("Just as you are about to put the tome down in disappointment, the runes on the page suddenly begin to glow and you feel mana begin to circulate within your body.");
                                PrintDelayed("Testing your TOUGHNESS...");
                                Thread.Sleep(1000);
                                int check = Roll(state.hero.toughness, ref state.random_gen);
                                if (check > 10)
                                {
                                    PrintDelayed($"\nAfter some struggle you feel the mana settle within your body.");
                                    PrintDelayed("Your senses feel sharper!.");
                                    PrintDelayed($"{GREEN}+1 Skill{RESET}");
                                    state.hero.skill++;
                                }
                                else
                                {
                                    PrintDelayed("The mana coursing through your body proves to be too much to handle.");
                                    PrintDelayed("Your senses feel a little duller");
                                    PrintDelayed($"{RED}-1 Skill{RESET}");
                                    state.hero.skill--;
                                }
                                PrintDelayed("The tome crumbles into dust in your hands.");
                                state.hero.F2tomeInteract = true;
                            }
                            else
                            {
                                PrintDelayed("\nYou decide reading a suspicious ancient tome may not be the best idea.");
                            }
                        }
                        EndPrompts();
                        break;
                    case "INSPECT CANDLE HOLDER":
                        if (!state.hero.candle2)
                        {
                            PrintDelayed($"\nYou pull the last intact {MAGENTA}CANDLE{RESET} from the wall holder and decide to store it for later.");
                            state.hero.candle2 = true;
                        }
                        else
                        {
                            PrintDelayed("\nThere is only the burned out remains of the other candles left.");
                        }
                        EndPrompts();
                        break;
                    case "INVENTORY":
                        Console.WriteLine("Inventory:");
                        if (state.hero.bomb) Console.WriteLine("- Bomb");
                        if (state.hero.HealthPotion) Console.WriteLine("- Health Potion");
                        if (state.hero.F1Key) Console.WriteLine("- Rusty Key");
                        if (state.hero.F2Key1 || state.hero.F2Key2) Console.WriteLine("- Glowing Key(s)");
                        if (state.hero.F2chestKey) Console.WriteLine("- Small Key");
                        if (state.hero.candle1 || state.hero.candle2 || state.hero.candle3) Console.WriteLine("- Candle(s)");
                        EndPrompt();
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
        static void F2SouthHall2(GameState state)
        {
            string choice;
            do
            {
                Console.Clear();
                if (state.hero.F2candelabraInteract == true)
                {
                    RenderFrame(FindWorkingPath(new string[] { "../../../Art Files/F2SouthHall2Candelabra.txt", "Art Files/F2SouthHall2Candelabra.txt" }), 25, 10);
                }
                else
                {
                    RenderFrame(FindWorkingPath(new string[] { "../../../Art Files/F2SouthHall2.txt", "Art Files/F2SouthHall2.txt" }), 25, 10); //Background 
                }
                PrintDelayed("You enter what appears to be a small treasury, although it has seemingly been pilfered by past adventurers.");
                PrintDelayed($"To the {YELLOW}{UNDERLINE}NORTH{RESET}{NOUNDERLINE} is the door you came in from.");
                PrintDelayed($"In the corner of the room is a small ornate {BLUE}CHEST{RESET} next to an odd {BLUE}CANDELABRA{RESET}");
                PrintDelayed($"In the centre of the room atop a pedestal is a small {BLUE}IDOL{RESET} of some kind");
                choice = Selector.DefaultSelectorMenu(["GO NORTH", "INSPECT CHEST", "INSPECT CANDELABRA", "INSPECT IDOL", "INVENTORY", "STATUS", "HELP"], "");
                switch (choice)
                {
                    case "GO NORTH":
                        F2SouthHall1(state);
                        break;
                    case "INSPECT CHEST":
                        if (state.hero.F2Key2 == true)
                        {
                            PrintDelayed("\nYou hope to find some chests with actual treasure in the future");
                        }
                        else if (state.hero.F2chestKey == true)
                        {
                            PrintDelayed($"\nThe {MAGENTA}SMALL KEY{RESET} fits into the lock as the chest pops open revealing...");
                            Thread.Sleep(1000);
                            PrintDelayed("... another key.");
                            Thread.Sleep(1000);
                            PrintDelayed($"You sigh and pocket the {MAGENTA}GLOWING KEY{RESET} for later.");
                            state.hero.F2Key2 = true;
                            state.hero.F2chestKey = false;
                        }
                        else
                        {
                            PrintDelayed("\nThe chest appears to be locked, a small keyhole sits on the front");
                            PrintDelayed("Engraved into the wood on top of the chest are the words \"LIGHT THE WAY\"");
                        }
                        EndPrompts();
                        break;
                    case "INSPECT CANDELABRA":
                        PrintDelayed("\nThe candelabra is surprisingly well maintained compared to everything else in the room.");
                        if (state.hero.F2candelabraInteract == true)
                        {
                            PrintDelayed("The candle flames flicker sporadically in the dark.");
                        }
                        else if (state.hero.candle1 == true && state.hero.candle2 == true && state.hero.candle3 == true)
                        {
                            PrintDelayed($"You place all 3 of your {MAGENTA}CANDLES{RESET} into the empty slots of the candelabra.");
                            PrintDelayed("After a few seconds the candles suddenly light on their own!");
                            PrintDelayed($"A brick in the wall behind the candelabra suddenly comes loose, revealing a {MAGENTA}SMALL KEY{RESET} behind it which you take.");
                            state.hero.F2chestKey = true;
                            state.hero.candle1 = false;
                            state.hero.candle2 = false;
                            state.hero.candle3 = false;
                            state.hero.F2candelabraInteract = true;
                        }
                        else if (state.hero.candle1 == true || state.hero.candle2 == true || state.hero.candle3 == true)
                        {
                            PrintDelayed("It seems like you could insert candles into the empty slots on the candelabra, however you don't have enough to fill all 3 slots.");
                        }
                        EndPrompts();
                        break;
                    case "INSPECT IDOL":
                        PrintDelayed("\nAn odd looking idol sits atop an ornate pedestal.");
                        PrintDelayed($"Something about it gives you a {RED}bad feeling...{RESET}");
                        PrintDelayed("Would you like to try and take it?");
                        bool idolChoice = Selector.BoolSelectorMenu("");
                        if (idolChoice == true)
                        {
                            PrintDelayed($"\nAs you wrap your hand around the idol it suddenly starts to glow a {RED}deep crimson{RESET}.");
                            PrintDelayed($"It feels as if your life is being {RED}drained{RESET}.");
                            PrintDelayed("Let go?");
                            idolChoice = Selector.BoolSelectorMenu("");
                            if (idolChoice == true)
                            {
                                PrintDelayed("\nThankfully the pain stops as soon as you let go.");
                            }
                            else
                            {
                                PrintDelayed("\nImages of unknowable beings flood your mind as searing pain courses through your body.");
                                PrintDelayed($"{RED}You don't think you can handle anymore...{RESET}");
                                PrintDelayed($"{RED}L3tT G0¿{RESET}");
                                idolChoice = Selector.BoolSelectorMenu("");
                                if (idolChoice == true)
                                {
                                    PrintDelayed("\nAs soon as you let go you feel completely fine as if nothing had ever happened.");
                                }
                                else
                                {
                                    for (int i = 0; i <= 5; i ++)
                                    {
                                        PrintDelayed($"{RED}KILL{RESET}");
                                        PrintDelayed($"{RED}KLSD2395HG54{RESET}");
                                        PrintDelayed($"{RED}DEATH{RESET}");
                                        PrintDelayed($"{RED}[]>&^&^$#&|!{RESET}");
                                        PrintDelayed($"{RED}BLOOD{RESET}");
                                        PrintDelayed($"{RED}SJSALK41985SDLFKJ{RESET}");
                                    }
                                    Thread.Sleep(1000);
                                    GameOver($"{RED}3Rr0R¿ =){RESET}");
                                }
                            }
                        }
                        else
                        {
                            PrintDelayed("\nBetter not...");
                        }
                        EndPrompts();
                        break;
                    case "INVENTORY":
                        Console.WriteLine("Inventory:");
                        if (state.hero.bomb) Console.WriteLine("- Bomb");
                        if (state.hero.HealthPotion) Console.WriteLine("- Health Potion");
                        if (state.hero.F1Key) Console.WriteLine("- Rusty Key");
                        if (state.hero.F2Key1 || state.hero.F2Key2) Console.WriteLine("- Glowing Key(s)");
                        if (state.hero.F2chestKey) Console.WriteLine("- Small Key");
                        if (state.hero.candle1 || state.hero.candle2 || state.hero.candle3) Console.WriteLine("- Candle(s)");
                        EndPrompts();
                        break;
                    case "STATUS":
                        state.hero.Status(); //Call Status method from Character class
                        break;
                    case "HELP":
                        Help(); //Call Help method
                        break;
                    default:
                        Console.WriteLine($"\n◆ Sorry I don't understand the command \"{choice}\"");
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
                    case "INVENTORY":
                        Console.WriteLine("Inventory:");
                        if (state.hero.bomb) Console.WriteLine("- Bomb");
                        if (state.hero.HealthPotion) Console.WriteLine("- Health Potion");
                        if (state.hero.F1Key) Console.WriteLine("- Rusty Key");
                        if (state.hero.F2Key1 || state.hero.F2Key2) Console.WriteLine("- Glowing Key(s)");
                        if (state.hero.F2chestKey) Console.WriteLine("- Small Key");
                        if (state.hero.candle1 || state.hero.candle2 || state.hero.candle3) Console.WriteLine("- Candle(s)");
                        EndPrompts();
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
            Thread.Sleep(100);
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
                            health = Entity.EntityHealth.InitHealth(16),
                            damDice = 4,
                            skill = 0,
                            finesse = -2,
                            toughness = 3,
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
                            skill = 2,
                            finesse = 0,
                            toughness = 1,
                            presence = -1
                        };
                    }
                case 3:
                    {
                        return new Entity.Character
                        {
                            name = "Dodgio",
                            health = Entity.EntityHealth.InitHealth(10),
                            damDice = 6,
                            skill = 1,
                            finesse = 2,
                            toughness = -1,
                            presence = 0
                        };
                    }
                case 4:
                    {
                        return new Entity.Character
                        {
                            name = "Joe Biden",
                            health = Entity.EntityHealth.InitHealth(4),
                            damDice = 10,
                            skill = 8,
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
                        skill = 0,
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
                using (StreamReader sr = new StreamReader(@$"{file}"))
                {
                    string? line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        PrintDelayed(line, printDelay);
                    }
                    sr.Close();
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
│INSPECT {BLUE}[OBJECT]{RESET}│ Inspect an object in the current room                                            │
│      HELP      │ Prints the help menu                                                             │
│     STATUS     │ Shows the player's character sheet                                               │
└────────────────┴──────────────────────────────────────────────────────────────────────────────────┘");
            Console.WriteLine($"{MAGENTA}ITEMS{RESET} will be used if you have the correct items when inspecting objects.");
            PrintDelayed("◆ Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        //For skill checks and combat so you pass it the skill you want to test and it simulates a dice roll and then returns the result 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Roll(int hitMod, ref Random rnd)
        {
            return rnd.Next(1, 21) + hitMod;
        }


        public static void GameOver(string causeOfDeath) 
        {
            Console.Clear();
            RenderFrame(FindWorkingPath(new string[] { "../../../Art Files/GameOver.txt", "Art Files/GameOver.txt" }), 200, 12);
            PrintDelayed($"\nYou were slain by {causeOfDeath}..."); // tell the player what killed their character
            Console.ReadKey(); 
            Environment.Exit(0);
        }

        public static void PeacefulEnding() // function for ending when the player exits the first room
        {
            PrintDelayed("\nYou decide that it may not be worth risking life and limb for treasure after all");
            PrintDelayed("You run back to your horse hitched outside and return to your life back home");
            Console.ReadKey();
            Console.Clear();
            RenderFrame(FindWorkingPath(new string[] { "../../../Art Files/GameOver.txt", "Art Files/GameOver.txt" }), 200, 12);
            Console.ReadKey();
            Environment.Exit(3000);
        }



        // Singular function for a single round of combat
        public static void Combat(ref Character hero, ref Monster monster, ref Random random)
        {
            do
            {
                Console.Clear();
                int player_roll = Roll(hero.skill, ref random);
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

                // If the player has any type of consumable.
                if (hero.bomb || hero.HealthPotion)
                {
                    PrintDelayed("\nWould you like to use an item Y/N ");
                    // string userResponse = Console.ReadLine().ToUpper();
                    // if (userResponse == "Y")
                    if (Selector.BoolSelectorMenu(""))
                    {
                        PrintDelayed("Do you want to use a BOMB or a POTION");
                        // string item = Console.ReadLine().ToUpper();
                        string item = Selector.DefaultSelectorMenu(["BOMB", "POTION", "CANCEL"], "");
                        switch (item)
                        {
                            case "BOMB":
                                if (hero.bomb == true)
                                {
                                    int dam = random.Next(4, 9);
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
                                    int heal = random.Next(4, 9);
                                    PrintDelayed($"You drink your health potion and heal yourself for {heal}");
                                    hero.health.curHP = Math.Min(hero.health.curHP + heal, hero.health.maxHP);
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
                    Console.Clear();
                    RenderFrame(FindWorkingPath(new string[] { "../../../Art Files/YouDied.txt", "Art Files/YouDied.txt" }), 200, 12); //Game over ASCII art
                    Thread.Sleep(1000);
                    GameOver($"the {RED}{monster.name}'s{RESET} deadly attack");
                }
                else
                {
                    hero.PrintHealthBar();
                    Thread.Sleep(1000);
                }
                Thread.Sleep(1000);
                
            } while (hero.health.curHP > 0 && monster.health.curHP > 0);
            Console.Clear();
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
