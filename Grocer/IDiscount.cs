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
            decimal numBundles = Math.Min((amount / _amountInBundle), (_limit / _amountInBundle));
            // round number of bundles to nearest whole number
            numBundles = Math.Floor(numBundles);
            // determine number of unbundled items.
            decimal totalUnbundled = amount - (numBundles*_amountInBundle);

            price = item.BundlePrice * numBundles;
            price += item.Price * totalUnbundled;
            
            return price;
        }
    }

    public class Deal : IDiscount
    {
        decimal _dealMod;
        int _limit;
        decimal _amountRequiredForDeal;
        decimal _amountAcquiredInDeal;
        public Deal(decimal dealMod, decimal amountRequiredForDeal, decimal amountAcquiredInDeal, int limit)
        {
            _dealMod = dealMod;
            _limit = limit;
            _amountRequiredForDeal = amountRequiredForDeal;
            _amountAcquiredInDeal = amountAcquiredInDeal;
        }
        public decimal GetDiscountedPrice(InventoryItem item, decimal amount)
        {
            decimal price = 0;
            decimal currentCount = 0;
            decimal currentCountReset = 0;
            decimal currentCountStart = 1; // Start of count, used to check if it's the first discounted item.
            bool isDeal = false;
            for (int i = 0; i < amount; i++)
            {
                currentCount++;
                if (!isDeal)
                {
                    price += item.Price;
                    if(currentCount == _amountRequiredForDeal && i < _limit)
                    {
                        currentCount = currentCountReset;
                        isDeal = true;
                    }
                }
                else
                {
                    decimal amountLeft = amount - i;
                    if (currentCount == currentCountStart && amountLeft < _amountAcquiredInDeal)
                    {
                        price += item.Price;
                    }
                    else
                    {
                        price += item.Price - (item.Price * _dealMod);
                    }
                    if(currentCount == _amountAcquiredInDeal)
                    {
                        currentCount = currentCountReset;
                        isDeal = false;
                    }
                }
            }
            return price;

        }
    }
}
