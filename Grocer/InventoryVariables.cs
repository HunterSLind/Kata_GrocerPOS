using System;
using System.Collections.Generic;
using System.Text;

namespace Grocer
{
    public static class InventoryVariables
    {
        public static readonly string HAMBURGER_ID = "hamburger";
        public static readonly decimal HAMBURGER_PRICE = 4.99m;
        public static readonly decimal HAMBURGER_MARKDOWN = 0;
        private static InventoryItem _hamburger { get; set; }
        public static InventoryItem HAMBURGER
        {
            get
            {
                if (_hamburger == null)
                {
                    _hamburger = new InventoryItem(HAMBURGER_ID)
                    {
                        Price = HAMBURGER_PRICE,
                        MarkDown = HAMBURGER_MARKDOWN
                    };
                }
                return _hamburger;
            }
        }

        public static readonly string APPLE_ID = "apple";
        public static readonly decimal APPLE_PRICE = 1.49m;
        public static readonly decimal APPLE_MARKDOWN = 0.50m;
        public static readonly DiscountType APPLE_DISCOUNT = DiscountType.MARKDOWN;
        private static InventoryItem _apple { get; set; }
        public static InventoryItem APPLE
        {
            get
            {
                if (_apple == null)
                {
                    _apple = new InventoryItem(APPLE_ID)
                    {
                        Price = APPLE_PRICE,
                        MarkDown = APPLE_MARKDOWN,
                        discountType = DiscountType.MARKDOWN
                    };
                }
                return _apple;
            }
        }


        public static void ResetInventory()
        {
            _hamburger = null;
            _apple = null;
            ClientInventory.InventoryDictionary = new Dictionary<string, InventoryItem>
            {
                {InventoryVariables.HAMBURGER_ID, InventoryVariables.HAMBURGER },
                {InventoryVariables.APPLE_ID, InventoryVariables.APPLE }
            };
        }
    }
}
