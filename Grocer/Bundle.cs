using System;
using System.Collections.Generic;
using System.Text;

namespace Grocer
{
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
            decimal numBundles = Math.Min((amount / _amountInBundle), (_limit / _amountInBundle));
            // round number of bundles to nearest whole number
            numBundles = Math.Floor(numBundles);
            // determine number of unbundled items.
            decimal totalUnbundled = amount - (numBundles * _amountInBundle);

            price = item.BundlePrice * numBundles;
            price += item.Price * totalUnbundled;

            return price;
        }
    }
}
