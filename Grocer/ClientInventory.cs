using System;
using System.Collections.Generic;
using System.Text;

namespace Grocer
{
    public static class ClientInventory
    {
        
        

        public static Dictionary<string, InventoryItem> InventoryDictionary = new Dictionary<string, InventoryItem>
        {
            {InventoryVariables.HAMBURGER_ID, InventoryVariables.HAMBURGER }
        };

    }

    public static class InventoryVariables
    {
        public static string HAMBURGER_ID = "hamburger";
        public static decimal HAMBURGER_PRICE = 4.99m;
        public static decimal HAMBURGER_MARKDOWN = 0;

        public static InventoryItem HAMBURGER = new InventoryItem
        {
            Name = InventoryVariables.HAMBURGER_ID,
            Price = InventoryVariables.HAMBURGER_PRICE,
            MarkDown = InventoryVariables.HAMBURGER_MARKDOWN
        };
    }
}
