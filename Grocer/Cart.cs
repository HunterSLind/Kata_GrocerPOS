using System;
using System.Collections.Generic;

namespace Grocer
{
    public class Cart
    {
        public Dictionary<InventoryItem, decimal> cartItems = new Dictionary<InventoryItem, decimal>();

        public void AddItem(string item)
        {
            cartItems.Add(ClientInventory.InventoryDictionary[item], 1);
        }
    }
}
