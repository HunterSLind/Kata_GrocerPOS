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
            Assert.AreEqual(1, cart.cartItems[ClientInventory.HAMBURGER]);
        }

        [TestMethod]
        public void AddItems()
        {
            cart.AddItem(InventoryVariables.HAMBURGER_ID);
            cart.AddItem(InventoryVariables.HAMBURGER_ID);
            Assert.AreEqual(2, cart.cartItems[ClientInventory.HAMBURGER]);
        }
    }
}
