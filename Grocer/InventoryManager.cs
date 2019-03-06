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
            ClientInventory.InventoryDictionary[item].MarkDown = newMarkdown;
        }

        public static void AddBundleDiscountToItem(string itemName, decimal amountInBundle, int limit)
        {
            ClientInventory.InventoryDictionary[itemName].Discount = new Bundle(amountInBundle, limit);
        }

        public static void AddDealDiscountToItem(string itemName, decimal dealMod, decimal required, decimal acquired, int limit)
        {
            ClientInventory.InventoryDictionary[itemName].Discount = new Deal(dealMod, required, acquired, limit);
        }
    }
}
