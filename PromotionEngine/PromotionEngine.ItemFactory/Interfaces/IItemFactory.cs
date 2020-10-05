using System;
using System.Collections.Generic;
using System.Text;
using PromotionEngine.Entities;

namespace PromotionEngine.ItemFactory.Interfaces
{
    interface IItemFactory
    {
        Item GetItem(string skuId);
    }
}
