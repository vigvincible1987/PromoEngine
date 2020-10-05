using PromotionEngine.Entities;
using PromotionEngine.Promotions.Interfaces;

namespace PromotionEngine.Promotions
{
    public class PromotionsByCount : IPromotion
    {
        private readonly OrderItem _item;
        private readonly int _count;
        private readonly decimal _price;

        public PromotionsByCount(OrderItem item, int count, decimal price)
        {
            _item = item;
            _count = count;
            _price = price;
        }

        public Order ApplyPromotion(Order order)
        {
            foreach (var orderItem in order.OrderItems )
            {
                OrderItem promoItem = null;
                if (orderItem.SkuId == _item.SkuId && orderItem.Count>=_count)
                {
                    promoItem = new OrderItem();
                    promoItem.Count = orderItem.Count / _count;
                    promoItem.Price = _price;
                    orderItem.Count = orderItem.Count % _count;
                }
                if (promoItem != null)
                {
                    order.PromoItems.Add(promoItem);
                }
            }

            return order;
        }
    }
}
