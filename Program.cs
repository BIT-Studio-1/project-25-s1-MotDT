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
            string remainingHealthBar = new string('█', Character.maxHP);
            string totalHealthBar = new string('_', Character.maxHP - Character.curHP);
            Console.WriteLine($"{character.Name} HP: {remainingHealthBar}{totalHealthBar} ({character.HP}/{character.MaxHP})");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
        public class Character //idea with this character is way more simple  you test him self against dc10+monster attack
        {
            string name;
            int maxHP;
            int curHP;
            int hitMod;
            int damDice;
            int strength;
            int fineese;
            int toughness;
            int presnase;
        }

        public class monster
        {
            string name;
            int maxHP;
            string curHP;
            int damDice;
            int attackBonus;
            bool item1;
        }
    }
}
