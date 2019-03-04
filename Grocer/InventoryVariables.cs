using System;
using System.Collections.Generic;
using System.Text;

namespace Grocer
{
    public static class InventoryVariables
    {
        #region HAMBURGER
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
        #endregion

        #region APPLE
        public static readonly string APPLE_ID = "apple";
        public static readonly decimal APPLE_PRICE = 1.49m;
        public static readonly decimal APPLE_MARKDOWN = 0.50m;
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
                        Discount = new Markdown()
                };
                }
                return _apple;
            }
        }
        #endregion

        #region BANANA
        public static readonly string BANANA_ID = "banana";
        public static readonly decimal BANANA_PRICE = 0.99m;
        public static readonly decimal BANANA_BUNDLE_PRICE = 1.49m;
        private static InventoryItem _banana { get; set; }
        public static InventoryItem BANANA
        {
            get
            {
                if (_banana == null)
                {
                    _banana = new InventoryItem(BANANA_ID)
                    {
                        Price = BANANA_PRICE,
                        BundlePrice = BANANA_BUNDLE_PRICE
                    };
                }
                return _banana;
            }
        }
        #endregion

        #region CLEMENTINE
        public static readonly string CLEMENTINE_ID = "clementine";
        public static readonly decimal CLEMENTINE_PRICE = 1.99m;
        public static readonly decimal CLEMENTINE_DEAL_MOD = 1.00m; // 100% off
        private static InventoryItem _clementine { get; set; }
        public static InventoryItem CLEMENTINE
        {
            get
            {
                if (_clementine == null)
                {
                    _clementine = new InventoryItem(CLEMENTINE_ID)
                    {
                        Price = CLEMENTINE_PRICE
                    };
                }
                return _clementine;
            }
        }
        #endregion

        #region DURIAN
        public static readonly string DURIAN_ID = "durian";
        public static readonly decimal DURIAN_PRICE = 1.99m;
        public static readonly decimal DURIAN_DEAL_MOD = 0.5m; // 50% off
        private static InventoryItem _durian { get; set; }
        public static InventoryItem DURIAN
        {
            get
            {
                if (_durian == null)
                {
                    _durian = new InventoryItem(DURIAN_ID)
                    {
                        Price = DURIAN_PRICE
                    };
                }
                return _durian;
            }
        }
        #endregion

        #region EGGPLANT
        public static readonly string EGGPLANT_ID = "eggplant";
        public static readonly decimal EGGPLANT_PRICE = 3.99m;
        public static readonly decimal EGGPLANT_MARKDOWN = 0;
        public static readonly decimal EGGPLANT_DEAL_MOD = 1.0m;
        public static readonly bool EGGPLANT_BYWEIGHT = true;
        private static InventoryItem _eggplant { get; set; }
        public static InventoryItem EGGPLANT
        {
            get
            {
                if (_eggplant == null)
                {
                    _eggplant = new InventoryItem(EGGPLANT_ID)
                    {
                        Price = EGGPLANT_PRICE,
                        MarkDown = EGGPLANT_MARKDOWN,
                        SoldByWeight = EGGPLANT_BYWEIGHT
                    };
                }
                return _eggplant;
            }
        }
        #endregion

        #region FRENCHDIP
        public static readonly string FRENCHDIP_ID = "frenchdip";
        public static readonly decimal FRENCHDIP_PRICE = 1.69m;
        public static readonly decimal FRENCHDIP_MARKDOWN = 0;
        public static readonly bool FRENCHDIP_BYWEIGHT = true;
        private static InventoryItem _frenchdip { get; set; }
        public static InventoryItem FRENCHDIP
        {
            get
            {
                if (_frenchdip == null)
                {
                    _frenchdip = new InventoryItem(FRENCHDIP_ID)
                    {
                        Price = FRENCHDIP_PRICE,
                        MarkDown = FRENCHDIP_MARKDOWN,
                        SoldByWeight = FRENCHDIP_BYWEIGHT
                    };
                }
                return _frenchdip;
            }
        }
        #endregion

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
