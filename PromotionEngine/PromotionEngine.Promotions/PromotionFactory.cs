using System.Collections.Generic;
using PromotionEngine.Entities;
using PromotionEngine.Promotions.Interfaces;

namespace PromotionEngine.Promotions
{
    public class PromotionFactory : IPromotion
    {
        private readonly List<IPromotion> _promotions = new List<IPromotion>();

        public PromotionFactory()
        {
            var itemA = new OrderItem { SkuId = "A"};
            var itemB = new OrderItem { SkuId = "B"};
            var itemC = new OrderItem { SkuId = "C"};
            var itemD = new OrderItem { SkuId = "D"};
            _promotions.Add(new PromotionsByCount(itemA,3,130));
            _promotions.Add(new PromotionsByCount(itemB,2,45));
            _promotions.Add(new PromotionsByCombination(itemC,itemD,30));
        }

        public Order ApplyPromotion(Order order)
        {
            foreach (var promotion in _promotions)
            {
                order = promotion.ApplyPromotion(order);
            }

            return order;
        }
    }
}
