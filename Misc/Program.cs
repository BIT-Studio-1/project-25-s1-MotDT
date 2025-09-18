using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Text.Json;
using System.Threading;
using System.Xml.Linq;


namespace TextAdventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.White;
            char play = '\0';
            string jsonString = File.ReadAllText("Monsters.json");
            List<Character> monsters = JsonSerializer.Deserialize<List<Character>>(jsonString);
            Character Player = new Character
            {
                Name = "Grognak",
                MaxHP = 13,
                HP = 13,
                Thac0 = 19,
                AC = 4,
                HitBonus = 1,
                AttackDice = 4,
                Key = false
            };
            do
            {
                Animation.title();
                Intro();
                Cell(Player, monsters);
                Console.WriteLine("Would you like to play again Y/N");
                play = Convert.ToChar(Console.ReadLine());
            } while (play == 'y');
        }
        static void Intro()
        {
            Console.WriteLine("Traveling trough the woods you were ambushed by monsters and captured");
            Thread.Sleep(200);
            Console.WriteLine("You awake inside of a dark prison cell");
            Thread.Sleep(200);
            Console.WriteLine("You manage to free yourself from your makeshift bindings and acquire a improvised weapon");
            Thread.Sleep(200);
            Console.WriteLine("You must find your equipment and escape the dungeon");
            Console.WriteLine("The game commands are GO [DIRECTION], HELP, SEARCH and STATUS");
            Thread.Sleep(1000);
            Console.WriteLine("Press ENTER to continue");
            Console.ReadLine();
            Console.Clear();
        }

        static void Cell(Character Player, List<Character> monsters)
        {
            string choice;
            bool sheild = false;
            if (Player.AC == 4)
            {
                sheild = true;
            }
            do
            {
                Console.Clear();
                Animation.Start();
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
                        Hall(Player, monsters);
                        break;
                    case "SEARCH":
                        if (sheild == true)
                        {
                            Console.WriteLine("\nYou find a small buckler behind the skeleton");
                            Thread.Sleep(1000);
                            Player.AC -= 1;
                            sheild = false;
                        }
                        else
                        {
                            Console.WriteLine("\nYou find nothing of use");
                            Thread.Sleep(1000);
                        }
                        break;
                    case "STATUS":
                        Player.PrintInfo();
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
            while (choice != "Go South");
        }

        static void StoreRoom(Character Player, List<Character> monsters)
        {
            string choice;
            do
            {
                Console.Clear();
                Animation.StoreRoom();
                Console.WriteLine("You Find yourself inside of a make shift store room");
                Thread.Sleep(200);
                Console.WriteLine("The Orkish raiders loot covers the room");
                Thread.Sleep(200);
                Console.WriteLine("There is a door back to the hallway to the north");
                Thread.Sleep(200);
                Console.WriteLine("What would you like to do?");
                choice = Console.ReadLine();
                choice = choice.ToUpper();
                switch (choice)
                {
                    case "GO NORTH":
                        Hall(Player, monsters);
                        break;
                    case "SEARCH":
                        Console.WriteLine("\nYou find a stockpile of strong healing potions amoung the spoils");
                        Thread.Sleep(200);
                        Console.WriteLine($"Your Current Health is {Player.HP} / {Player.MaxHP}");
                        Thread.Sleep(200);
                        Console.WriteLine("Would you like to drink the potion?");
                        Thread.Sleep(200);
                        choice = Console.ReadLine();
                        choice = choice.ToUpper();
                        Console.WriteLine("\nYou drink the potion and feel rejuvenated");
                        Player.HP = Player.MaxHP;
                        Thread.Sleep(200);
                        Console.WriteLine($"Your Current Health is { Player.HP } / { Player.MaxHP}");
                        Thread.Sleep(1000);
                        break;
                    case "HELP":
                        Help();
                        break;
                    case "STATUS":
                        Player.PrintInfo();
                        Thread.Sleep(2000);
                        break;
                    default:
                        Console.WriteLine("\nSorry I don't understand that command.");
                        Thread.Sleep(2000);
                        break;
                }   
            } while (choice != "GO NORTH");
        }

        static void Hall(Character Player, List<Character> monsters)
        {
            string choice;
            bool Mush = false;
            if (Player.MaxHP == 13)
            {
                Mush = true;
            }
            do
            {
                Console.Clear();
                Animation.Hall();
                Thread.Sleep(200);
                Console.WriteLine("You Find yourself in a large dimly lit hallway");
                Thread.Sleep(500);
                Console.WriteLine("To your NORTH WEST is a small prison cell");
                Thread.Sleep(500);
                Console.WriteLine("To your SOUTH WEST is a make shift store room");
                Thread.Sleep(500);
                Console.WriteLine("To your NORTH EAST is a small closed off room with a faint light emanating from it");
                Thread.Sleep(500);
                Console.WriteLine("To your SOUTH EAST is open wooden door with barrels propped against the wall");
                Thread.Sleep(500);
                Console.WriteLine("What will you do?");
                choice = Console.ReadLine();
                choice = choice.ToUpper();
                switch (choice)
                {
                    case "SEARCH":
                        if (Mush == true)
                        {
                            Console.WriteLine("\nYou find a strange mushroom and consume it");
                            Thread.Sleep(200);
                            Console.WriteLine("You feel invigorated!");
                            Thread.Sleep(500);
                            Player.MaxHP += 2;
                            Player.HP += 2;
                            Mush = false;
                        }
                        else
                        {
                            Console.WriteLine("\nYou have consumed all of the edible fungus");
                            Thread.Sleep(500);
                        }
                        break;
                    case "STATUS":
                        Player.PrintInfo();
                        Thread.Sleep(2000);
                        break;

                    case "HELP":
                        Help();
                        break;

                    case "GO SOUTH WEST":
                        StoreRoom(Player, monsters);
                        break;

                    case "GO NORTH WEST":
                        Cell(Player, monsters);
                        break;

                    case "GO NORTH EAST":
                        GuardRoom(Player, monsters);
                        break;

                    case "GO SOUTH EAST":
                        TreasureRoom(Player, monsters);
                        break;

                    case "GO EXIT":
                        Escape(Player, monsters);
                        break;

                    default:
                        Console.WriteLine("Sorry I don't understand that command.");
                        Thread.Sleep(2000);
                        break;
                }
            } while ((choice != "GO SOUTH EAST") || (choice != "GO NORTH EAST") || (choice != "GO NORTH WEST") || (choice != "GO SOUTH EAST") || (choice != "GO EXIT"));
        }

        static void GuardRoom(Character Player, List<Character> monsters)
        {
            Character Orc = monsters.Find(c => c.Name.Equals("Orc"));
            string choice;
            if (Orc.IsAlive)
            {
                Console.Clear();
                Animation.GuardRoom();
                Thread.Sleep(200);
                Console.WriteLine("You find yourself in a small guard room");
                Thread.Sleep(200);
                Console.WriteLine("There is a large Orc warrior standing in the center of the room");
                Thread.Sleep(200);
                Console.WriteLine("You must defeat him to continue your escape");
                Thread.Sleep(500);
                Animation.Combat();
                Thread.Sleep(500);
            }
            else
            {
                Console.Clear();
                Animation.GuardRoom();
                Thread.Sleep(200);
                Console.WriteLine("You find yourself in a small guard room");
                Thread.Sleep(200);
                Console.WriteLine("The Orc warrior has been defeated");
                Thread.Sleep(200);
            }
            while (Player.IsAlive && Orc.IsAlive)
            {
                Console.WriteLine("\n-- Player Turn --");
                Player.Attack(Orc);
                if (Orc.IsAlive)
                {
                    PrintHealthBar(Orc);
                }
                // only run the monster turn if the orc survived
                if (Orc.IsAlive)
                {
                    Console.WriteLine("\n-- Monster Turn --");
                    Orc.Attack(Player);
                    if (Player.IsAlive)
                    {
                        PrintHealthBar(Player);
                    }
                    Thread.Sleep(1500);
                    Console.Clear();
                }
            }
            if (Orc.IsAlive)
                Console.WriteLine("You have been defeated!");
            else
                Console.WriteLine($"{Orc.Name} has been defeated!");
            Console.WriteLine("\nCombat Ended!");
            if (!Player.IsAlive)
            {
                Animation.GameOver();
                Environment.Exit(0); //THIS CLOSES THE APPLICATION
            }
            Thread.Sleep(200);
            do
            {
                Animation.GuardRoom();
                Console.WriteLine("You have disposed of the foul Orc warrior");
                Thread.Sleep(500);
                Console.WriteLine("You find yourself inside of a make shift guard quarters rusted equipment and looted misshapen Armour lines the walls");
                choice = Console.ReadLine();
                choice = choice.ToUpper();
                switch (choice)
                {
                    case "GO SOUTH":
                    Hall(Player, monsters);
                    break;
                    
                    case "SEARCH":
                        if (Orc.Key == true)
                        {
                            Console.WriteLine("\nYou find a small key on the Orc's body");
                            Player.Key = true;
                            Thread.Sleep(500);
                            Console.WriteLine("You can now escape the dungeon");
                            Thread.Sleep(500);
                            Orc.Key = false;
                        }
                        else
                        {
                            Console.WriteLine("\n" +
                                "You search the room and find nothing of use");
                            Thread.Sleep(500);
                        }
                    break; 
                    
                    case "HELP":
                    Help();
                    break;
                        
                    case "STATUS":
                    Player.PrintInfo();
                    Thread.Sleep(2000);
                    break;
                        
                    default:
                    Console.WriteLine("Sorry I don't understand that command.");
                    Thread.Sleep(2000);
                    break;
                }
            } while (choice != "GO SOUTH");
        }

        static void TreasureRoom(Character Player, List<Character> monsters)
        {
            string choice;
            bool sword = false;
            Character Goblin = monsters.Find(c => c.Name.Equals("Goblin"));
            if (Goblin.IsAlive)
            {
                Console.Clear();
                Animation.TesasureRoom();
                Thread.Sleep(200);
                Console.WriteLine("You find yourself in a small guard room");
                Thread.Sleep(200);
                Console.WriteLine("There is a Small and rabbid goblin waiting in ambush");
                Thread.Sleep(200);
                Console.WriteLine("You must defeat the creature to continue your escape");
                Thread.Sleep(500);
                Animation.Combat();
                Thread.Sleep(500);
            }
            while (Player.IsAlive && Goblin.IsAlive)
            {
                Console.WriteLine("\n-- Player Turn --");
                Player.Attack(Goblin);
                if (Goblin.IsAlive)
                {
                    PrintHealthBar(Goblin);
                }
                // only run the monster turn if the orc survived
                if (Goblin.IsAlive)
                {
                    Console.WriteLine("\n-- Monster Turn --");
                    Goblin.Attack(Player);
                    if (Player.IsAlive)
                    {
                        PrintHealthBar(Player);
                    }
                    Thread.Sleep(1500);
                    Console.Clear();
                }
            }
            if (Goblin.IsAlive)
                Console.WriteLine("You have been defeated!");
            else
                Console.WriteLine($"{Goblin.Name} has been defeated!");
            Console.WriteLine("\nCombat Ended!");
            if (!Player.IsAlive)
            {
                Animation.GameOver();
                Environment.Exit(0); //THIS CLOSES THE APPLICATION
            }
            Thread.Sleep(200);
            if ((!Goblin.IsAlive) && (Player.AttackDice != 6))
            {
                sword = true;
            }
            do
            {
                Console.Clear();
                Animation.TesasureRoom();
                Console.WriteLine("You find yourself in a small guard room");
                Thread.Sleep(200);
                Console.WriteLine("The Savage Goblin has been defeated");
                Thread.Sleep(200);
                Console.WriteLine("What would you like to do?");
                choice = Console.ReadLine();
                choice = choice.ToUpper();
                switch (choice)
                {
                    case "GO NORTH":
                        Hall(Player, monsters);
                        break;
                    case "SEARCH":
                        if (sword==true)
                        {
                            Console.WriteLine("You find a sword in the lair of the feral goblin");
                            Thread.Sleep(200);
                            Player.AttackDice = 6;
                            Console.WriteLine("Your attack power has improved!");
                            Thread.Sleep(100);
                            sword = false;
                        }
                        else
                        {
                            Console.WriteLine("You Scramble in the dark and find nothing");
                        }
                        break;
                    case "HELP":
                        Help();
                        break;
                    case "STATUS":
                        Player.PrintInfo();
                        Thread.Sleep(2000);
                        break;
                    default:
                        Console.WriteLine("Sorry I don't understand that command.");
                        Thread.Sleep(2000);
                        break;
                }
            } while (choice != "GO NORTH");
        }

        static void Escape(Character Player, List<Character> monsters)
        {
            if (Player.Key == false)
            {
                Console.WriteLine("The gate is locked and you must find the key to escape");
                Thread.Sleep(1000);
                Hall(Player , monsters);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You unbolt the door and rush out into the woods");
                Thread.Sleep(500);
                Console.WriteLine("after running through the woods for days you manage to make it to the nearest town");
                Thread.Sleep(500);
                Console.WriteLine("Where you are rewarded handsomely for slaying the Greekskin Raiders");
                Animation.Victory();
                Thread.Sleep(2000);
                Environment.Exit(0);
            }
        }
        static void PrintHealthBar(Character character)
        {
                Console.ForegroundColor = ConsoleColor.Green;
                string remainingHealthBar = new string('█', character.HP);
                string totalHealthBar = new string('_', character.MaxHP - character.HP);
                Console.WriteLine($"{character.Name} HP: {remainingHealthBar}{totalHealthBar} ({character.HP}/{character.MaxHP})");
                Console.ForegroundColor = ConsoleColor.White;
        }
        static void Help()
        {
            Console.WriteLine("\nThe game commands are GO [DIRECTION], HELP, SEARCH and STATUS");
            Console.WriteLine("            The commands are not case sensitive");
            Thread.Sleep(500);
            Console.WriteLine("GO [DIRECTION] -- This command takes you to a different room based on its relitive position to the current room");
            Thread.Sleep(500);
            Console.WriteLine("     HELP      -- This command prints the help menu");
            Thread.Sleep(500);
            Console.WriteLine("    SEARCH     -- This command searches the room the player is currently in");
            Thread.Sleep(500);
            Console.WriteLine("    STATUS     -- This command shows an abridjed version of the players character sheet");
            Thread.Sleep(2000);
            Console.Clear();
        }
    }
}

