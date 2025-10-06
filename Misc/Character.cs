namespace TextAdventure
{
    public class Character
    {
        public string Name {get; set;}
        public int MaxHP { get; set; }
        public int HP { get; set; }
        public int Thac0 { get; set; }
        public int AC { get; set; }
        public int HitBonus { get; set; }
        public int AttackDice { get; set; }
        public bool Key {  get; set; }
        private Random rng = new Random();
        //These need to be set get to actuly utilize the data from the jason files


        public bool IsAlive => HP > 0;      //if the character gets to 0 or less hp they fucking die wew

        public void Attack(Character target) //this is how attacking works
        {
            int roll = rng.Next(1, 21); // d20 roll remeber this starts at teh first and stops at the second hence the 21 
            int total = roll + HitBonus; //character rolls a d20 and add there hit bonus to get a result

            Console.WriteLine($"{Name} rolls a d20: {roll} + {HitBonus} = {total}");

            if (roll == 20)
            {
                Console.WriteLine("Critical hit!");
                int damage = RollDamage() + RollDamage();                                     // double damage 
                target.TakeDamage(damage);
            }
            else if (total >= Thac0 - target.AC)
            {
                int damage = RollDamage();                                                    //Generates the damgae of the attack by calling the function then returning  a number it genreates using the characters damasge dice
                target.TakeDamage(damage);                                                    //Basicly this goes hey call the take damage function and inserts the damage that we previouslty generated and set 
            }
            else
            {
                Console.WriteLine($"{Name} misses {target.Name}!");
            }
        }
        
        private int RollDamage()                                                                  //function for rolling damage
        {
            int damage = rng.Next(1, AttackDice + 1);                                             //makes a random function that generates a numbert between 1 and the damage dice (num+1 to its not under)
            Console.WriteLine($"{Name} deals {damage} damage!");                                  //This character deals this much damage to the other one wew
            return damage; 
        }

        public void TakeDamage(int amount)
        {
            HP -= amount;
            Console.WriteLine($"{Name} takes {amount} damage. Remaining HP: {Math.Max(HP, 0)}"); //Says the class taking the damage's name , the amount of damage and if the targer has hp left by comparing there htpoints to 0 to see what is greater
            if (HP <= 0)                                                                         //When the characters hitpoints are 0 or less they are dead and run this
            Console.WriteLine($"{Name} has fallen!");
        }

        public void PrintInfo()                                                                 //This is for a menu function later on in the program
        {
            Console.WriteLine($"\n{nameof(Name)}: {Name}");
            Console.WriteLine($"{nameof(HP)}: {HP}");
            Console.WriteLine($"{nameof(Thac0)}: {Thac0}");
            Console.WriteLine($"{nameof(AC)}: {AC}");
            Console.WriteLine($"{nameof(HitBonus)}: {HitBonus}");
            Console.WriteLine($"{nameof(AttackDice)}: 1d{AttackDice}");
        }
    }
}
