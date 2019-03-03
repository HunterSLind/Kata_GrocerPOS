using System;
using System.Collections.Generic;
using System.Text;

namespace Grocer
{
    public interface IDiscount
    {
        decimal GetDiscountedPrice(InventoryItem item, decimal amount);
    }
}
