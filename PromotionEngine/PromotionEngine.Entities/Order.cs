using System.Collections.Generic;

namespace PromotionEngine.Entities
{
    public class Order
    {
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public List<OrderItem> PromoItems { get; set; } = new List<OrderItem>();
    }
}