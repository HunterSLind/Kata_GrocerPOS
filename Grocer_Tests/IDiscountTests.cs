using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Grocer;
namespace Grocer_Tests
{
    [TestClass]
    public class IDiscountTests
    {
        [TestMethod]
        public void Markdown_Price()
        {
            Markdown mkdown = new Markdown();
            decimal actual = mkdown.GetDiscountedPrice(InventoryVariables.APPLE, 1);
            decimal expected = InventoryVariables.APPLE.Price - InventoryVariables.APPLE.MarkDown;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Bundle_Price()
        {
            Bundle bundle = new Bundle(2, 2);
            decimal actual = bundle.GetDiscountedPrice(InventoryVariables.BANANA, 2);
            decimal expected = InventoryVariables.BANANA_BUNDLE_PRICE;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Bundle_MultiplePrice()
        {
            Bundle bundle = new Bundle(2, 4);
            decimal actual = bundle.GetDiscountedPrice(InventoryVariables.BANANA, 4);
            decimal expected = InventoryVariables.BANANA_BUNDLE_PRICE * 2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Bundle_PartialPrice()
        {
            Bundle bundle = new Bundle(2, 4);
            decimal actual = bundle.GetDiscountedPrice(InventoryVariables.BANANA, 3);
            decimal expected = InventoryVariables.BANANA_BUNDLE_PRICE + InventoryVariables.BANANA_PRICE;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Bundle_Limit()
        {
            Bundle bundle = new Bundle(2, 4);
            decimal actual = bundle.GetDiscountedPrice(InventoryVariables.BANANA, 7);
            decimal expected = (InventoryVariables.BANANA_BUNDLE_PRICE * 2) + (InventoryVariables.BANANA_PRICE * 3);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Deal_Price()
        {
            Deal deal = new Deal(InventoryVariables.CLEMENTINE_DEAL_MOD, 1, 1, 2);
            decimal actual = deal.GetDiscountedPrice(InventoryVariables.CLEMENTINE, 2); // 2 clementines
            decimal expected = InventoryVariables.CLEMENTINE_PRICE; // for the price of 1
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Deal_ExtraItems()
        {
            Deal deal = new Deal(InventoryVariables.CLEMENTINE_DEAL_MOD, 1, 1, 2);
            decimal actual = deal.GetDiscountedPrice(InventoryVariables.CLEMENTINE, 3); // 3 clementines
            decimal expected = InventoryVariables.CLEMENTINE_PRICE * 2; // for the price of 2
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Deal_Limit()
        {
            Deal deal = new Deal(InventoryVariables.CLEMENTINE_DEAL_MOD, 1, 1, 2);
            decimal actual = deal.GetDiscountedPrice(InventoryVariables.CLEMENTINE, 4); // 4 clementines
            decimal expected = InventoryVariables.CLEMENTINE_PRICE * 3; // for the price of 3
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Deal_PriceWithMoreThanOneRequirement()
        {
            Deal deal = new Deal(InventoryVariables.CLEMENTINE_DEAL_MOD, 2, 1, 3);
            decimal actual = deal.GetDiscountedPrice(InventoryVariables.CLEMENTINE, 3); // 3 clementines
            decimal expected = InventoryVariables.CLEMENTINE_PRICE * 2; // for the price of 2
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Deal_PriceWithMoreThanOneAcquirement()
        {
            Deal deal = new Deal(InventoryVariables.CLEMENTINE_DEAL_MOD, 2, 2, 4);
            decimal actual = deal.GetDiscountedPrice(InventoryVariables.CLEMENTINE, 5); // 5 clementines
            decimal expected = InventoryVariables.CLEMENTINE_PRICE * 3; // for the price of 3
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Deal_NotFree()
        {
            Deal deal = new Deal(InventoryVariables.DURIAN_DEAL_MOD, 1, 1, 2);
            decimal actual = deal.GetDiscountedPrice(InventoryVariables.DURIAN, 2); // 2 durians
            decimal expected = InventoryVariables.DURIAN_PRICE * 1.5m; // for the price of 1.5 durians
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Deal_MultipleDeals()
        {
            Deal deal = new Deal(InventoryVariables.DURIAN_DEAL_MOD, 2, 2, 8);
            decimal actual = deal.GetDiscountedPrice(InventoryVariables.DURIAN, 10); // 10 durians
            decimal expected = InventoryVariables.DURIAN_PRICE * 8; // for the price of 6 durians
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Deal_PartialFulfilledDeal()
        {
            Deal deal = new Deal(InventoryVariables.DURIAN_DEAL_MOD, 2, 2, 8);
            decimal actual = deal.GetDiscountedPrice(InventoryVariables.DURIAN, 7); // 7 durians
            decimal expected = InventoryVariables.DURIAN_PRICE * 6; // for the price of 6 durians
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Deal_MultipleFulfilledDeals()
        {
            Deal deal = new Deal(InventoryVariables.DURIAN_DEAL_MOD, 2, 2, 8);
            decimal actual = deal.GetDiscountedPrice(InventoryVariables.DURIAN, 8); // 8 durians
            decimal expected = InventoryVariables.DURIAN_PRICE * 6; // for the price of 6 durians
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Deal_HigherDealWithPartialDeal()
        {
            Deal deal = new Deal(InventoryVariables.CLEMENTINE_DEAL_MOD, 4, 4, 16);
            decimal actual = deal.GetDiscountedPrice(InventoryVariables.CLEMENTINE, 15); // 15 clementines
            decimal expected = InventoryVariables.CLEMENTINE_PRICE * 11; // for the price of 11 clementines
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Deal_WeightedItem()
        {
            Deal deal = new Deal(InventoryVariables.EGGPLANT_DEAL_MOD, 1.5m, 1.5m, 3);
            decimal actual = deal.GetDiscountedPrice(InventoryVariables.EGGPLANT, 2.5m); // 2.5 pounds of eggplant
            decimal expected = InventoryVariables.EGGPLANT_PRICE * 1.5m; // for the price of 1.5 eggplatns
            Assert.AreEqual(expected, actual);
        }
    }
}
