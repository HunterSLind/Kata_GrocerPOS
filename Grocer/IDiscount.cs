using System;
using System.Collections.Generic;
using System.Text;

namespace Grocer
{
    public interface IDiscount
    {
        decimal GetDiscountedPrice(InventoryItem item, decimal amount);
    }

    public class Markdown : IDiscount
    {
        public decimal GetDiscountedPrice(InventoryItem item, decimal amount)
        {
            decimal newPrice = item.Price - item.MarkDown;
            return newPrice * amount;
        }
    }

    public class Bundle : IDiscount
    {
        private decimal _amountInBundle { get; set; }
        private int _limit { get; set; }
        public Bundle(decimal amountInBundle, int limit)
        {
            _amountInBundle = amountInBundle;
            _limit = limit;
        }
        public decimal GetDiscountedPrice(InventoryItem item, decimal amount)
        {
            decimal price = 0;
            // determine how many bundles there are:
            decimal numBundles = amount / _amountInBundle;
            // round number of bundles to nearest whole number
            numBundles = Math.Floor(numBundles);
            // now determine the number of banana's that will not be bundled
            decimal totalBundled = numBundles* _amountInBundle;
            decimal totalUnbundled = amount - totalBundled;

            price = item.BundlePrice * numBundles;
            price += item.Price * totalUnbundled;
            
            return price;
        }
    }
}
