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
                if(_hamburger == null)
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

        public static void ResetInventory()
        {
            _hamburger = null;
            ClientInventory.InventoryDictionary = new Dictionary<string, InventoryItem>
            {
                {InventoryVariables.HAMBURGER_ID, InventoryVariables.HAMBURGER }
            };
        }
    }
}
