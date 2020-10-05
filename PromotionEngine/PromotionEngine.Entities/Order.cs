using System.Collections.Generic;

namespace PromotionEngine.Entities
{
    public class Order
    {
        public List<OrderItem> OrderItems { get; set; }
        public List<PromoItem> PromoItems { get; set; }
        
    }
}
