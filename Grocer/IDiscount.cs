﻿using System;
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
            decimal totalUnbundled = amount - (numBundles * _amountInBundle);

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
            decimal discountCount = 0;

            if(amount > _limit)
            {
                discountCount = Math.Floor(_limit / (_amountAcquiredInDeal + _amountRequiredForDeal)) * _amountAcquiredInDeal;
            }
            else
            {
                discountCount = Math.Floor(amount / (_amountAcquiredInDeal + _amountRequiredForDeal)) * _amountAcquiredInDeal;
            }
            decimal nonDiscounted = amount - discountCount;

            decimal modifiedPrice = item.Price - (item.Price * _dealMod);
            price += discountCount * modifiedPrice;
            price += nonDiscounted * item.Price;
            return price;
        }
    }
}
