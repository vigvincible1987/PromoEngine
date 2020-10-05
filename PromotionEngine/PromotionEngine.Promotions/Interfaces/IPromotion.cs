using PromotionEngine.Entities;

namespace PromotionEngine.Promotions.Interfaces
{
    public interface IPromotion
    {
        Order ApplyPromotion(Order order);
    }
}