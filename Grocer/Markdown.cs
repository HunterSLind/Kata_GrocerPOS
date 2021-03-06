﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Grocer
{
    public class Markdown : IDiscount
    {
        public decimal GetDiscountedPrice(InventoryItem item, decimal amount)
        {
            decimal newPrice = item.Price - item.MarkDown;
            return newPrice * amount;
        }
    }

}
