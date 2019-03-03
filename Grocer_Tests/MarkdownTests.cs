using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Grocer;
namespace Grocer_Tests
{
    [TestClass]
    public class MarkdownTests
    {
        [TestMethod]
        public void MarkdownPricingTest()
        {
            Markdown mkdown = new Markdown();
            decimal actual = mkdown.GetDiscountedPrice(InventoryVariables.APPLE, 1);
            decimal expected = InventoryVariables.APPLE.Price - InventoryVariables.APPLE.MarkDown;
            Assert.AreEqual(expected, actual);
        }
    }
}
