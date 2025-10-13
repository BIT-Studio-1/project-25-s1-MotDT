using System.Diagnostics;
using System.Numerics;
using static Studio_1.Entity;

namespace Studio_1
{
    internal class Program
    {
        static void Main()
        {
            // Are we running in VS?
            if (System.IO.File.Exists("../../../Art Files/Title.txt"))
            {
                RenderFrame("../../../Art Files/Title.txt", 200, 12); //Titlecard
            }
            else
            {
                Console.WriteLine("Fallback address bruh");
                RenderFrame("Art Files/Title.txt", 200, 12); //Titlecard
            }
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
            Entrance(hero); // Call Entrance method
        }

        static void Entrance(Entity.Character hero)
        {
            string choice;
            do
            {
                Console.Clear();
                RenderFrame("../../../Art Files/Room1.txt", 25, 10); //Background 
                Console.WriteLine("You find yourself in the dark entrance way of the wizard's tower");
                Thread.Sleep(200);
                Console.WriteLine("It is a small limestone room. A single torch dimly illuminates the otherwise dark entrance");
                Thread.Sleep(200);
                Console.WriteLine("There is a wooden door with a broken lock to the north");
                Thread.Sleep(200);
                Console.WriteLine("Slumped up against the wall just under the torch is a small skeleton");
                Console.WriteLine("What would you like to do?");
                choice = Console.ReadLine().ToUpper();
                switch (choice)
                {
                    case "GO NORTH":
                        Room2(hero); //Call Room2 method
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
                            Console.WriteLine("GAME OVER");
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
                        hero.Status(); //Call Status method from Character class
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

        static void Room2(Entity.Character hero)
        {
            Entity.Monster ghoul = new Entity.Monster
            {
                health = Entity.EntityHealth.InitHealth(6),
                name = "Ghoul",
                damDice = 4,
                dodgeDiff = 14,
                hitDiff = 14,
                item1 = false
            };
            string choice;
            do
            {
                Console.Clear();
                RenderFrame("../../../Art Files/Room2Ghoul.txt", 25, 10); //Background with enemy
                Console.WriteLine("You are in Room 2");
                Thread.Sleep(200);
                Console.WriteLine("A Ghoul stands in your way");
                Thread.Sleep(200);
                Console.WriteLine("You must vanquish it before you leave");
                Thread.Sleep(200);
                Console.WriteLine("To the north there is a small hole in the wall");
                Thread.Sleep(200);
                Console.WriteLine("What would you like to do?");
                choice = Console.ReadLine().ToUpper();
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
                        if (ghoul.item1 == true)
                        {
                            //Stuff Goes here (now we can check based on monster item drops)
                        }
                        else
                        {
                            Console.WriteLine("\nYou find nothing of use");
                            Thread.Sleep(1000);
                        }
                        break;
                    case "STATUS":
                        hero.Status();
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

        static void Room3(Entity.Character hero)
        {
            Entity.Monster goblin = new Entity.Monster
            {
                health = Entity.EntityHealth.InitHealth(6),
                name = "Goblin",
                damDice = 4,
                dodgeDiff = 14,
                hitDiff = 14,
                item1 = true
            };
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
                choice = Console.ReadLine().ToUpper();
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

        // Prints the health bar of the character
        static void PrintHealthBar(Entity.Character character)
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
            Console.ResetColor();
        }

        //Art file renderer, call method with: directory of text file as a string, print delay between lines, console coulour int value 
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
        public static int Roll(int hitMod)
        {
            Random rnd = new Random();
            return rnd.Next(1, 21) + hitMod;
        }

        public static void Combat(ref Character hero, ref Monster monster)
        {
            do
            {
                Random random = new Random();
                int player_roll = Roll(hero.strength);
                if (player_roll >= monster.hitDiff)
                {
                    int dam = random.Next(1, hero.damDice + 1);
                    monster.health.curHP -= dam;
                    Console.WriteLine($"You strike the {monster.name} for {dam}");
                }
                else
                {
                    Console.WriteLine($"{hero.name} Strikes the {monster.name} and misses");
                }

                if (monster.health.curHP > 0)
                {
                    //Monster 'attacks'
                    player_roll = Roll(hero.finesse);
                    if (player_roll <= monster.dodgeDiff)
                    {
                        int dam = random.Next(1, monster.damDice + 1);
                        hero.health.curHP -= dam;
                        Console.WriteLine($"{monster.name} strikes you for {dam}");
                    }
                    else
                    {
                        Console.WriteLine($"{hero.name} dodges the {monster.name}'s attack just in time");
                    }
                }
            } while (monster.health.curHP > 0 || monster.health.curHP > 0);
        }

    }
}
