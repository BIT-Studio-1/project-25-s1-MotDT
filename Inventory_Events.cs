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

            public Dictionary<string, int> AddItem(string itemName, int amount) // This function adds an item to the inventory. If the item already exists, it increases the amount.
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

            public Dictionary<string, int> UseItem(string itemName, int amount) //This function uses an item from the inventory. If the item exists and there is enough amount, it decreases the amount. Otherwise, it does nothing.
            {
                if (inventory.ContainsKey(itemName) && inventory[itemName] - amount! < 0)
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

            public Dictionary<string, bool> TriggerEvent(string eventName) 
            {
                if (!events.ContainsKey(eventName))
                {
                    events.Add(eventName, true);
                    Console.WriteLine($"Event {eventName} triggered"); //Debugging line, can be removed later
                }
                else if (events.ContainsKey(eventName) && events[eventName] == false) //This condition is for events that can be retriggered. If the event exists and is currently false, it can be retriggered by setting it to true again.
                {
                    events[eventName] = true;
                    Console.WriteLine($"Event {eventName} retriggered"); //Debugging line, can be removed later
                } 
                else
                {
                    Console.WriteLine("Event already triggered"); //Debugging line, can be removed later
                }
                return events;
            }
        }
    }
}
