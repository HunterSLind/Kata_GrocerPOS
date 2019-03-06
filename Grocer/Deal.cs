using System;
using System.Collections.Generic;
using System.Text;

namespace Grocer
{
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
            // Find whether we have purchased over the limit for discount redemptions
            decimal baseAmountNumForDiscount = Math.Min(amount, _limit);
            if (item.SoldByWeight)
            {
                decimal price = 0;
                // determine the number of discounts we've earned
                decimal discountCount = Math.Floor(baseAmountNumForDiscount / (_amountRequiredForDeal));
                // Multiply the number of times we qualify for the deal by the amount required to find the amount of non discounted items
                decimal nonDiscounted = discountCount * _amountRequiredForDeal;
                // Determine the discounted item amount
                decimal discountItemCount = amount - nonDiscounted;
                // determine the modified price
                decimal modifiedPrice = item.Price - (item.Price * _dealMod);
                // Math for pricing.
                price += discountItemCount * modifiedPrice;
                price += nonDiscounted * item.Price;
                return price;
            }
            else
            {
                decimal price = 0;
                // determine the number of discounts we've earned
                decimal discountCount = Math.Floor(baseAmountNumForDiscount / (_amountAcquiredInDeal + _amountRequiredForDeal));
                // Determine the number of items that will be receiving a discount
                decimal discountItemCount = discountCount * _amountAcquiredInDeal;
                // Determine the number of items that will not be receiving a discount
                decimal nonDiscounted = amount - discountItemCount;
                // Determine modified price
                decimal modifiedPrice = item.Price - (item.Price * _dealMod);
                // Math for pricing.
                price += discountItemCount * modifiedPrice;
                price += nonDiscounted * item.Price;
                return price;
            }
        }
    }
}
