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
                if (inventory.ContainsKey(itemName) && inventory[itemName] >= amount)
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
                else if (events.ContainsKey(eventName) && events[eventName] == false) //This condition is for events that can be retriggered. Reset events using the ResetEvent function to allow retriggering.
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

            public Dictionary<string, bool> ResetEvent(string eventName) //This function resets an event, allowing it to be triggered again.
            {
                if (events.ContainsKey(eventName))
                {
                    events[eventName] = false;
                    Console.WriteLine($"Event {eventName} reset"); //Debugging line, can be removed later
                }
                else
                {
                    Console.WriteLine($"Could not reset event {eventName}"); //Debugging line, can be removed later
                }
                return events;
            }

            public void PrintInventory()
            {
                Console.WriteLine("Inventory:");
                foreach (var item in inventory)
                {
                    if (item.Value > 0)  // Only print items that have a quantity greater than 0
                    { 
                        Console.WriteLine($"{item.Key}: {item.Value}");
                    }
                }
                Console.ReadKey();
            }

            public void DebugPrintEvents() //Debugging function to show the current state of events, can be removed later
            {
                foreach (var ev in events)
                {
                    Console.WriteLine($"{ev.Key}: {ev.Value}");
                }
                Console.ReadKey();
            }
        }
    }
}
