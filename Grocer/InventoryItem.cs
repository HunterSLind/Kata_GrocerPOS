using System;
using System.Collections.Generic;
using System.Text;

namespace Grocer
{
    public class InventoryItem
    {
        public string Name { get; }
        public decimal Price { get; set; }
        public decimal MarkDown { get; set; }
        public DiscountType discountType { get; set; }


        public InventoryItem(string name)
        {
            Name = name;
        }

        public override bool Equals(object obj)
        {
            InventoryItem that = (InventoryItem)obj;
            if(this.Name == that.Name)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }


    }

    public enum DiscountType
    {
        NONE
    }
}
