using PromotionEngine.Entities;
using PromotionEngine.Promotions.Interfaces;

namespace PromotionEngine.Promotions
{
    public class PromotionsByCount : IPromotion
    {
        private readonly Item _item;
        private readonly int _count;
        private readonly decimal _price;

        public PromotionsByCount(Item item, int count, decimal price)
        {
            _item = item;
            _count = count;
            _price = price;
        }

        public Order ApplyPromotion(Order order)
        {
            Order orderToReturn = new Order();
            foreach (var orderItem in order.OrderItems )
            {
                OrderItem orderItemToAdd = new OrderItem();
                PromoItem promoItem = null;
                orderItemToAdd.SkuId = orderItem.SkuId;
                orderItemToAdd.Price = orderItem.Price;
                if (orderItem.SkuId == _item.SkuId && orderItem.Count>=_count)
                {
                    orderItemToAdd.Count = orderItem.Count % _count;
                    promoItem = new PromoItem();
                    promoItem.Count = orderItem.Count / _count;
                    promoItem.Price = _price;
                }
                else
                {
                    orderItemToAdd.Count = orderItem.Count;
                }
                orderToReturn.OrderItems.Add(orderItemToAdd);
                if (promoItem != null)
                {
                    orderToReturn.PromoItems.Add(promoItem);
                }
            }

            return orderToReturn;
        }
    }
}
