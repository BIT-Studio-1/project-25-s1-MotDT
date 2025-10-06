using System;

namespace Studio_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Main logic here
        }

        static void PrintHealthBar(Character character)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string remainingHealthBar = new string('█', character.health.curHP);
            string totalHealthBar = new string('_', character.health.maxHP - character.health.curHP);
            Console.WriteLine($"{character.name} HP: {remainingHealthBar}{totalHealthBar} ({character.health.curHP}/{character.health.maxHP})");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    public class Character // This character is simpler; you test themself against DC10+ monster attack
    {
        /// Character's health component
        public EntityHealth health;
        public string name;
        int damDice;
        int strength; // this is used as hit mod
        int finesse;
        int toughness;
        int presence;
    }

    public class Monster
    {
        /// Monster's health component
        public EntityHealth health;
        public string name;
        int damDice;
        int dodgeDiff;
        int hitDiff;
        bool item1;
    }

    /// Health class used by both players and monsters
    public class EntityHealth {
        /// Max health of the entity
        public int maxHP;
        /// Current Health of the entity
        public int curHP;
    }
}
