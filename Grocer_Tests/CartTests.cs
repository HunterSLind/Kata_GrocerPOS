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
        }

        [TestMethod]
        public void AddItem()
        {
            cart.AddItem(InventoryVariables.HAMBURGER_ID);
            Assert.AreEqual(1, cart.CartItems[ClientInventory.HAMBURGER]);
        }

        [TestMethod]
        public void AddItems()
        {
            cart.AddItem(InventoryVariables.HAMBURGER_ID);
            cart.AddItem(InventoryVariables.HAMBURGER_ID);
            Assert.AreEqual(2, cart.CartItems[ClientInventory.HAMBURGER]);
        }

        [TestMethod]
        public void AddItemWithWeight()
        {
            decimal units = 1.29m;
            cart.AddItem(InventoryVariables.HAMBURGER_ID, units);
            Assert.AreEqual(units, cart.CartItems[ClientInventory.HAMBURGER]);
        }
    }
}
