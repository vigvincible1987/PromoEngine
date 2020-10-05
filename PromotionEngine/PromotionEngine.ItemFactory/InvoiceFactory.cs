using PromotionEngine.Entities;
using PromotionEngine.Factory.Interfaces;

namespace PromotionEngine.Factory
{
    public class InvoiceFactory : IInvoiceFactory
    {
        public decimal CalculateTotalInvoiceAmount(Order order)
        {
            decimal invoiceAmount = 0;
            foreach (var orderItem in order.OrderItems)
                invoiceAmount = invoiceAmount + orderItem.Price * orderItem.Count;
            foreach (var promoItem in order.PromoItems)
                invoiceAmount = invoiceAmount + promoItem.Price * promoItem.Count;

            return invoiceAmount;
        }
    }
}