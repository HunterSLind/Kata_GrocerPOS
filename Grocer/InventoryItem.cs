﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Grocer
{
    public class InventoryItem
    {
        public string Name { get; }
        public decimal Price { get; set; }
        public decimal MarkDown { get; set; }
        public decimal BundlePrice { get; set; }
        public IDiscount Discount { get; set; }
        public bool SoldByWeight { get; set; }


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

        /// <summary>
        /// Not the prettiest way to execute on this, would do something more elaborate if necessary.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }


    }
}
