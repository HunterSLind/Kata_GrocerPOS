using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Grocer;

namespace Grocer_Tests
{
    [TestClass]
    public class InventoryManagerTests
    {
        [TestMethod]
        public void UpdateItemPrice()
        {
            decimal newPrice = InventoryVariables.HAMBURGER_PRICE + 0.25m;
            InventoryManager.UpdateItemPrice(InventoryVariables.HAMBURGER_ID, newPrice);

            Assert.AreEqual(newPrice, ClientInventory.InventoryDictionary[InventoryVariables.HAMBURGER_ID].Price);
        }

        [TestMethod]
        public void UpdateItemMarkdown()
        {
            decimal newMarkdown = InventoryVariables.HAMBURGER_MARKDOWN + 0.42m;
            InventoryManager.UpdateItemMarkdown(InventoryVariables.HAMBURGER_ID, newMarkdown);
            Assert.AreEqual(newMarkdown, ClientInventory.InventoryDictionary[InventoryVariables.HAMBURGER_ID].MarkDown);
        }
        
        [TestCleanup]
        public void Cleanup()
        {
            InventoryVariables.ResetInventory();
        }
    }
}
