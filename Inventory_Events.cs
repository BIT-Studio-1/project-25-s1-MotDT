using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio_1
{
    internal class Inventory_Events
    {
        public class InventoryAndEvents
        {
            public Dictionary<string, int> inventory = new Dictionary<string, int>();
            public Dictionary<string, bool> events = new Dictionary<string, bool>();

            public Dictionary<string, int> AddItem(string itemName, int amount)
            {
                if (inventory.ContainsKey(itemName))
                {
                    inventory[itemName] += amount;
                }
                else
                {
                    inventory.Add(itemName, amount);
                }
                return inventory;
            }

            public Dictionary<string, int> UseItem(string itemName, int amount)
            {
                if (inventory.ContainsKey(itemName) && inventory[itemName] - amount !< 0)
                {
                    inventory[itemName] -= amount;
                    Console.WriteLine($"Used {amount} {itemName}(s)");
                }
                else
                {
                    Console.WriteLine("Cannot use item");
                }
                return inventory;
            }
        }
    }
}
