using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Grocer;

namespace Grocer_Tests
{
    [TestClass]
    public class CartTests
    {
        Cart cart;
        [TestInitialize]
        public void Setup()
        {
            cart = new Cart();
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
        public void AddItem()
        {
            cart.AddItem(InventoryVariables.HAMBURGER_ID);
            Assert.AreEqual(1, cart.CartItems[InventoryVariables.HAMBURGER]);
        }

        [TestMethod]
        public void AddItem_Multiple()
        {
            cart.AddItem(InventoryVariables.HAMBURGER_ID);
            cart.AddItem(InventoryVariables.HAMBURGER_ID);
            Assert.AreEqual(2, cart.CartItems[InventoryVariables.HAMBURGER]);
        }

        [TestMethod]
        public void AddItem_WithWeight()
        {
            decimal units = 1.29m;
            cart.AddItem(InventoryVariables.HAMBURGER_ID, units);
            Assert.AreEqual(units, cart.CartItems[InventoryVariables.HAMBURGER]);
        }

        [TestMethod]
        public void AddItem_MultipleWithWeight()
        {
            decimal units1 = 1.43m;
            decimal units2 = 2.73m;
            cart.AddItem(InventoryVariables.HAMBURGER_ID, units1);
            cart.AddItem(InventoryVariables.HAMBURGER_ID, units2);
            decimal expected = units1 + units2;
            Assert.AreEqual(expected, cart.CartItems[InventoryVariables.HAMBURGER]);
        }

        [TestMethod]
        public void RemoveItem()
        {
            cart.AddItem(InventoryVariables.HAMBURGER_ID);
            cart.RemoveItem(InventoryVariables.HAMBURGER_ID);
            decimal expected = 0;
            Assert.AreEqual(expected, cart.CartItems[InventoryVariables.HAMBURGER]);
        }

        [TestMethod]
        public void RemoveItem_UsingWeight()
        {
            decimal unit1 = 1.23m;
            decimal unit2 = 1.50m;
            cart.AddItem(InventoryVariables.HAMBURGER_ID, unit1);
            cart.AddItem(InventoryVariables.HAMBURGER_ID, unit2);
            cart.RemoveItem(InventoryVariables.HAMBURGER_ID, unit1);
            Assert.AreEqual(unit2, cart.CartItems[InventoryVariables.HAMBURGER]);
        }


        [TestMethod]
        public void GetCartTotal_IncludingWeightedItem()
        {
            decimal unit = 1.49m;
            cart.AddItem(InventoryVariables.HAMBURGER_ID, unit);
            decimal expected = Math.Round(unit * InventoryVariables.HAMBURGER_PRICE, 2, MidpointRounding.AwayFromZero);
            Assert.AreEqual(expected, cart.GetCartTotal());
        }

        [TestMethod]
        public void GetCartTotal_WithMarkdownItem()
        {
            cart.AddItem(InventoryVariables.APPLE_ID);
            decimal expected = InventoryVariables.APPLE_PRICE - InventoryVariables.APPLE_MARKDOWN;
            Assert.AreEqual(expected, cart.GetCartTotal());
        }
    }
}
