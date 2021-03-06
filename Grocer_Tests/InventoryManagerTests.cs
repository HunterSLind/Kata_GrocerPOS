﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Grocer;

namespace Grocer_Tests
{
    [TestClass]
    public class InventoryManagerTests
    {
        [TestInitialize]
        public void Setup()
        {
            ClientInventory.InventoryDictionary = new System.Collections.Generic.Dictionary<string, InventoryItem>() {
                { InventoryVariables.HAMBURGER_ID, InventoryVariables.HAMBURGER },
                { InventoryVariables.APPLE_ID, InventoryVariables.APPLE },
                { InventoryVariables.BANANA_ID, InventoryVariables.BANANA },
                { InventoryVariables.CLEMENTINE_ID, InventoryVariables.CLEMENTINE },
                { InventoryVariables.DURIAN_ID, InventoryVariables.DURIAN },
                { InventoryVariables.EGGPLANT_ID, InventoryVariables.EGGPLANT },
                { InventoryVariables.FRENCHDIP_ID, InventoryVariables.FRENCHDIP }
            };
        }

        [TestMethod]
        public void ItemPrice_Update()
        {
            decimal newPrice = InventoryVariables.HAMBURGER_PRICE + 0.25m;
            InventoryManager.UpdateItemPrice(InventoryVariables.HAMBURGER_ID, newPrice);

            Assert.AreEqual(newPrice, ClientInventory.InventoryDictionary[InventoryVariables.HAMBURGER_ID].Price);
        }

        [TestMethod]
        public void ItemMarkdown_Update()
        {
            decimal newMarkdown = InventoryVariables.HAMBURGER_MARKDOWN + 0.42m;
            InventoryManager.UpdateItemMarkdown(InventoryVariables.HAMBURGER_ID, newMarkdown);
            Assert.AreEqual(newMarkdown, ClientInventory.InventoryDictionary[InventoryVariables.HAMBURGER_ID].MarkDown);
        }

        [TestMethod]
        public void SetItemBundleDiscount()
        {
            InventoryManager.AddBundleDiscountToItem(InventoryVariables.BANANA_ID, 3, 3); // Buy 3 for bundle price
            var clientItem = ClientInventory.InventoryDictionary[InventoryVariables.BANANA_ID];
            var discountedPrice = clientItem.Discount.GetDiscountedPrice(clientItem, 3);

            Assert.AreEqual(clientItem.BundlePrice, discountedPrice);

        }

        [TestMethod]
        public void SetItemDealDiscount()
        {
            InventoryManager.AddDealDiscountToItem(InventoryVariables.DURIAN_ID, 1.0m, 1, 1, 2); // Buy one get one
            var clientItem = ClientInventory.InventoryDictionary[InventoryVariables.DURIAN_ID];
            var discountedPrice = clientItem.Discount.GetDiscountedPrice(clientItem, 2);
            decimal expected = InventoryVariables.DURIAN_PRICE;
            Assert.AreEqual(expected, discountedPrice);
        }
    }
}
