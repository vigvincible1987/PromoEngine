using System;
using PromotionEngine.Entities;
using PromotionEngine.Promotions.Interfaces;

namespace PromotionEngine.Promotions
{
    public class PromotionsByCombination : IPromotion
    {
        private Item _firstItem;
        private Item _secondItem;
        private decimal _combinedPrice;

        public PromotionsByCombination(Item firstItem, Item secondItem, decimal combinedPrice)
        {
            _firstItem = firstItem;
            _secondItem = secondItem;
            _combinedPrice = combinedPrice;
        }
        public Order ApplyPromotion(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
