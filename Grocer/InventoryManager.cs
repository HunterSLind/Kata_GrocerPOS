using System;
using System.Collections.Generic;
using System.Text;

namespace Grocer
{
    public static class InventoryManager
    {
        public static void UpdateItemPrice(string item, decimal newPrice)
        {
            ClientInventory.InventoryDictionary[item].Price = newPrice;
        }
        public static void UpdateItemMarkdown(string item, decimal newMarkdown)
        {

        }
    }
}
