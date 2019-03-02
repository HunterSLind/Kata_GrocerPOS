using System;
using System.Collections.Generic;
using System.Text;

namespace Grocer
{
    public static class InventoryVariables
    {
        public static string HAMBURGER_ID = "hamburger";
        public static decimal HAMBURGER_PRICE = 4.99m;
        public static decimal HAMBURGER_MARKDOWN = 0;

        public static InventoryItem HAMBURGER = new InventoryItem
        {
            Name = HAMBURGER_ID,
            Price = HAMBURGER_PRICE,
            MarkDown = HAMBURGER_MARKDOWN
        };

        public static void ResetInventory()
        {
            ClientInventory.InventoryDictionary = new Dictionary<string, InventoryItem>
            {
                {InventoryVariables.HAMBURGER_ID, InventoryVariables.HAMBURGER }
            };
        }
    }
}
