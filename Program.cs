using System;

namespace Studio_1
{
    internal class Program
    {
        static void Main(string[] args)
        {

        
        static void PrintHealthBar(Character character)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string remainingHealthBar = new string('█', character.health.maxHP);
            string totalHealthBar = new string('_',character.health.maxHP - character.health.curHP);
            Console.WriteLine($"{character.name} HP: {remainingHealthBar}{totalHealthBar} ({character.health.curHP}/{character.health.maxHP})");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
        public class Character //idea with this character is way more simple  you test him self against dc10+monster attack
        {
            /// Character's health component
            public EntityHealth health;
            public string name;
            int damDice;
            int strength; // this is used at hit mod i am stupid -Rory
            int fineese;
            int toughness;
            int presnase;
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
}
