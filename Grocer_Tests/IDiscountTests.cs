using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Grocer;
namespace Grocer_Tests
{
    [TestClass]
    public class IDiscountTests
    {
        [TestMethod]
        public void MarkdownPricingTest()
        {
            Markdown mkdown = new Markdown();
            decimal actual = mkdown.GetDiscountedPrice(InventoryVariables.APPLE, 1);
            decimal expected = InventoryVariables.APPLE.Price - InventoryVariables.APPLE.MarkDown;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void BundlePricingTest()
        {
            Bundle bundle = new Bundle(2, 2);
            decimal actual = bundle.GetDiscountedPrice(InventoryVariables.BANANA, 2);
            decimal expected = InventoryVariables.BANANA_BUNDLE_PRICE;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultipleBundlePricingTest()
        {
            Bundle bundle = new Bundle(2, 4);
            decimal actual = bundle.GetDiscountedPrice(InventoryVariables.BANANA, 4);
            decimal expected = InventoryVariables.BANANA_BUNDLE_PRICE * 2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PartialBundlePricingTest()
        {
            Bundle bundle = new Bundle(2, 4);
            decimal actual = bundle.GetDiscountedPrice(InventoryVariables.BANANA, 3);
            decimal expected = InventoryVariables.BANANA_BUNDLE_PRICE + InventoryVariables.BANANA_PRICE;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BundleWithLimitPricingTest()
        {
            Bundle bundle = new Bundle(2, 4);
            decimal actual = bundle.GetDiscountedPrice(InventoryVariables.BANANA, 7);
            decimal expected = (InventoryVariables.BANANA_BUNDLE_PRICE * 2) + (InventoryVariables.BANANA_PRICE * 3);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DealPriceTest()
        {
            Deal deal = new Deal(InventoryVariables.CLEMENTINE_DEAL_MOD, 1, 1, 2);
            decimal actual = deal.GetDiscountedPrice(InventoryVariables.CLEMENTINE, 2); // 2 clementines
            decimal expected = InventoryVariables.CLEMENTINE_PRICE; // for the price of 1
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DealPriceTestWithExtra()
        {
            Deal deal = new Deal(InventoryVariables.CLEMENTINE_DEAL_MOD, 1, 1, 2);
            decimal actual = deal.GetDiscountedPrice(InventoryVariables.CLEMENTINE, 3); // 3 clementines
            decimal expected = InventoryVariables.CLEMENTINE_PRICE * 2; // for the price of 2
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DealPriceTestWithLimit()
        {
            Deal deal = new Deal(InventoryVariables.CLEMENTINE_DEAL_MOD, 1, 1, 2);
            decimal actual = deal.GetDiscountedPrice(InventoryVariables.CLEMENTINE, 4); // 4 clementines
            decimal expected = InventoryVariables.CLEMENTINE_PRICE * 3; // for the price of 3
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DealPriceTestWith2Required()
        {
            Deal deal = new Deal(InventoryVariables.CLEMENTINE_DEAL_MOD, 2, 1, 3);
            decimal actual = deal.GetDiscountedPrice(InventoryVariables.CLEMENTINE, 3); // 3 clementines
            decimal expected = InventoryVariables.CLEMENTINE_PRICE * 2; // for the price of 2
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DealPriceTestWith2Acquired()
        {
            Deal deal = new Deal(InventoryVariables.CLEMENTINE_DEAL_MOD, 2, 2, 4);
            decimal actual = deal.GetDiscountedPrice(InventoryVariables.CLEMENTINE, 5); // 5 clementines
            decimal expected = InventoryVariables.CLEMENTINE_PRICE * 3; // for the price of 3
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DealPriceTestWithFiftyPercentOff()
        {
            Deal deal = new Deal(InventoryVariables.DURIAN_DEAL_MOD, 1, 1, 2);
            decimal actual = deal.GetDiscountedPrice(InventoryVariables.DURIAN, 2); // 2 durians
            decimal expected = InventoryVariables.DURIAN_PRICE * 1.5m; // for the price of 1.5 durians
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DealPriceTestWithMultipleDeals()
        {
            Deal deal = new Deal(InventoryVariables.DURIAN_DEAL_MOD, 2, 2, 8);
            decimal actual = deal.GetDiscountedPrice(InventoryVariables.DURIAN, 10); // 10 durians
            decimal expected = InventoryVariables.DURIAN_PRICE * 8; // for the price of 6 durians
            Assert.AreEqual(expected, actual);
        }
    }
}
