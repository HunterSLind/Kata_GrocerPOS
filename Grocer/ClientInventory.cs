using System;
using System.Collections.Generic;
using System.Text;

namespace Grocer
{
    public static class ClientInventory
    {
        public static Dictionary<string, InventoryItem> InventoryDictionary = new Dictionary<string, InventoryItem>
        {
            {InventoryVariables.HAMBURGER_ID, InventoryVariables.HAMBURGER },
            {InventoryVariables.APPLE_ID, InventoryVariables.APPLE }
        };
    }
}
