using PromotionEngine.Entities;
using PromotionEngine.Promotions.Interfaces;

namespace PromotionEngine.Promotions
{
    public class PromotionsByCombination : IPromotion
    {
        private readonly OrderItem _firstItem;
        private readonly OrderItem _secondItem;
        private readonly decimal _combinedPrice;

        public PromotionsByCombination(OrderItem firstItem, OrderItem secondItem, decimal combinedPrice)
        {
            _firstItem = firstItem;
            _secondItem = secondItem;
            _combinedPrice = combinedPrice;
        }
        public Order ApplyPromotion(Order order)
        {
            var firstItemCount = 0;
            var secondItemCount = 0;
            OrderItem promoItem = null;

            foreach (var orderItem in order.OrderItems)
            {
                if (orderItem.SkuId == _firstItem.SkuId) firstItemCount = orderItem.Count;
                if (orderItem.SkuId == _secondItem.SkuId) secondItemCount = orderItem.Count;
            }

            if (firstItemCount > 0 && secondItemCount > 0)
            {
                if (firstItemCount > secondItemCount)
                {
                    promoItem = new OrderItem {Price = _combinedPrice, Count = secondItemCount};
                    firstItemCount -= secondItemCount;
                    secondItemCount = 0;
                }
                else if (secondItemCount > firstItemCount)
                {
                    promoItem = new OrderItem {Price = _combinedPrice, Count = firstItemCount};
                    secondItemCount -= firstItemCount;
                    firstItemCount = 0;
                }
                else if (secondItemCount == firstItemCount)
                {
                    promoItem = new OrderItem {Price = _combinedPrice, Count = firstItemCount};
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
