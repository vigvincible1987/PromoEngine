using PromotionEngine.Entities;

namespace PromotionEngine.Factory.Interfaces
{
    public interface IInvoiceFactory
    {
        decimal CalculateTotalInvoiceAmount(Order order);
    }
}
