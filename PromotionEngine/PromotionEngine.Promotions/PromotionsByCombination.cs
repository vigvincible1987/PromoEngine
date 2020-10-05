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
            var firstItemCount = 0;
            var secondItemCount = 0;
            PromoItem promoItem = null;

            foreach (var orderItem in order.OrderItems)
            {
                if (orderItem.SkuId == _firstItem.SkuId) firstItemCount = orderItem.Count;
                if (orderItem.SkuId == _secondItem.SkuId) secondItemCount = orderItem.Count;
            }

            if (firstItemCount > 0 && secondItemCount > 0)
            {
                if (firstItemCount > secondItemCount)
                {
                    promoItem = new PromoItem();
                    promoItem.Price = _combinedPrice;
                    promoItem.Count = secondItemCount;
                    firstItemCount -= secondItemCount;
                    secondItemCount = 0;
                }
                else if (secondItemCount > firstItemCount)
                {
                    promoItem = new PromoItem();
                    promoItem.Price = _combinedPrice;
                    promoItem.Count = firstItemCount;
                    secondItemCount -= firstItemCount;
                    firstItemCount = 0;
                }
                else if (secondItemCount == firstItemCount)
                {
                    promoItem = new PromoItem();
                    promoItem.Price = _combinedPrice;
                    promoItem.Price = firstItemCount;
                    secondItemCount = 0;
                    firstItemCount = 0;
                }
            }

            foreach (var orderItem in order.OrderItems)
            {
                if (orderItem.SkuId == _firstItem.SkuId) orderItem.Count = firstItemCount;

                if (orderItem.SkuId == _secondItem.SkuId) orderItem.Count = secondItemCount;
            }

            if (promoItem != null)
            {
                order.PromoItems.Add(promoItem);
            }
            return order;
        }
    }
}
