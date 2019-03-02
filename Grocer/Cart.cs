using System;
using System.Collections.Generic;

namespace Grocer
{
    public class Cart
    {
        public Dictionary<InventoryItem, decimal> CartItems = new Dictionary<InventoryItem, decimal>();

        public void AddItem(string item)
        {
            if (!CartItems.ContainsKey(ClientInventory.InventoryDictionary[item]))
            {
                CartItems.Add(ClientInventory.InventoryDictionary[item], 0);
            }
            CartItems[ClientInventory.InventoryDictionary[item]] += 1;
        }
    }
}
