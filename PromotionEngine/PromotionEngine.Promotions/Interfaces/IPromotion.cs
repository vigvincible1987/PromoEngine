using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using PromotionEngine.Entities;

namespace PromotionEngine.Promotions.Interfaces
{
    public interface IPromotion
    {
        Order ApplyPromotion(Order order);
    }
}
