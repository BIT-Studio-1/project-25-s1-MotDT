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
        }
    }
}
