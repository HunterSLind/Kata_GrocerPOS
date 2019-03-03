﻿using System;
using System.Collections.Generic;

namespace Grocer
{
    public class Cart
    {
        public Dictionary<InventoryItem, decimal> CartItems = new Dictionary<InventoryItem, decimal>();

        public void AddItem(string item, decimal amount = 1)
        {
            InventoryItem itemToAdd = ClientInventory.InventoryDictionary[item];
            if (!CartItems.ContainsKey(itemToAdd))
            {
                CartItems.Add(itemToAdd, 0);
            }
            CartItems[itemToAdd] += amount;
        }

        public void RemoveItem(string item, decimal amount = 1)
        {
            InventoryItem itemToRemove = ClientInventory.InventoryDictionary[item];
            CartItems[itemToRemove] -= amount;
        }

        public decimal GetCartTotal()
        {
            decimal price = 0;
            foreach (var item in CartItems)
            {
                price += item.Key.Price * item.Value;
            }
            return Math.Round(price, 2, MidpointRounding.AwayFromZero);
        }
    }
}
