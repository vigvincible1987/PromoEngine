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
            var itemA = new Item {SkuId = "A"};
            var itemB = new Item {SkuId = "B"};
            var itemC = new Item {SkuId = "C"};
            var itemD = new Item {SkuId = "D"};
            _promotions.Add(new PromotionsByCount(itemA,3,130));
            _promotions.Add(new PromotionsByCount(itemB,2,45));
            _promotions.Add(new PromotionsByCombination(itemC,itemD,30));
        }

        public Order ApplyPromotion(Order order)
        {
            var orderToReturn = new Order();
            foreach (var promotion in _promotions)
            {
                orderToReturn = promotion.ApplyPromotion(order);
            }

            return orderToReturn;
        }
    }
}
