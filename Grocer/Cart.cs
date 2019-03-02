using System;
using System.Collections.Generic;

namespace Grocer
{
    public class Cart
    {
        public Dictionary<InventoryItem, decimal> CartItems = new Dictionary<InventoryItem, decimal>();

        public void AddItem(string item, decimal units = 1)
        {
            InventoryItem itemToAdd = ClientInventory.InventoryDictionary[item];
            if (!CartItems.ContainsKey(itemToAdd))
            {
                CartItems.Add(itemToAdd, 0);
            }
            CartItems[itemToAdd] += units;
        }
    }
}
