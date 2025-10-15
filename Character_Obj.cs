using System;
using System.Numerics;
using System.Threading;
using System.Xml.Linq;

namespace Studio_1
{
    internal class Entity
    {
        // Character Data
        public class Character // This character is simpler; you test themselves against DC10+ monster attack
        {

            public EntityHealth health; // character's health component
            public string name; // character's name
            public int damDice;
            public int strength; // this is used as hit mod
            public int finesse;  // Used for dodging attacks
            public int toughness; // Can be used for room Events and such
            public int presence;  // Can be used for room Events and such
            public bool F1Key = false; // Exit condition for the demo
            public bool roomItem;   // Placeholder item

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
                Console.WriteLine("Press Enter to close");
                Console.ReadLine();
            }
            // Prints the Hero's health bar.
            public void PrintHealthBar() {
                health.PrintHealthBar(name,ConsoleColor.Green);
            }
        }

        public class Monster
        {
            public EntityHealth health; // monster's health component 
            public string name; // monster's name
            public int damDice;
            public int dodgeDiff;
            public int hitDiff;
            public bool item1; // item the monster can have that the player can loot

            // Prints the Monster's health bar.
            public void PrintHealthBar() {
                health.PrintHealthBar(name,ConsoleColor.Red);
            }
        }

        // Generic Health class used by both players and monsters
        public class EntityHealth
        {

            public int maxHP; // Max health of the entity
            public int curHP; // Current Health of the entity

            // Constructor function that automatically sets max health.
            // A new EntityHealth instance where maxHP == curHP == initHP
            public static EntityHealth InitHealth(int initHP)
            {
                return new EntityHealth
                {
                    maxHP = initHP,
                    curHP = initHP
                };
            }
            public bool IsAlive => curHP > 0; // checks to see if the player is alive i think this works with the entity health class thing????

            
            // Prints the health bar for a generic EntityHealth component.
            public void PrintHealthBar(string name, ConsoleColor barColour)
            {
                // Set the console text color to green for the health bar display
                Console.ForegroundColor = barColour;

                // Create a string of '█' characters representing the character's current health
                string remainingHealthBar = new string('█', curHP);

                // Create a string of '_' characters representing missing health (maxHP - curHP)
                string totalHealthBar = new string('_', maxHP - curHP);

                // Print the character's name, the visual health bar, and the numeric HP values (current/max)
                Console.WriteLine($"{name.PadRight(6)}HP: {remainingHealthBar}{totalHealthBar} ({curHP}/{maxHP})");

                // Reset the console text color to white
                Console.ResetColor();
            }
        }

    }
}
