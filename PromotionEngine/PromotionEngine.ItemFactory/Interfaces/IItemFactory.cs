using System;
using System.Collections.Generic;
using System.Text;
using PromotionEngine.Entities;

namespace PromotionEngine.Factory.Interfaces
{
    public interface IItemFactory
    {
        OrderItem GetItem(string skuId);
    }
}
