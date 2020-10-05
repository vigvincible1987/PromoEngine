using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Entities;
using PromotionEngine.Factory;

namespace PromotionEngine.Test
{
    [TestClass]
    public class InvoiceFactoryTest
    {
        private readonly InvoiceFactory _invoiceFactory = new InvoiceFactory();
        [TestMethod]
        public void TestUsingOrderItemForInvoiceGeneration()
        {
            var itemA = new OrderItem {SkuId = "A", Count = 1, Price = 10};
            var itemB = new OrderItem { SkuId = "B", Count = 1, Price = 10 };
            var itemC = new OrderItem { SkuId = "C", Count = 1, Price = 10 };
            var itemD = new OrderItem { SkuId = "D", Count = 1, Price = 10 };
            var order = new Order();
            order.OrderItems.Add(itemA);
            order.OrderItems.Add(itemB);
            order.OrderItems.Add(itemC);
            order.OrderItems.Add(itemD);
            var invoiceAmount=_invoiceFactory.CalculateTotalInvoiceAmount(order);
            Assert.AreEqual(40,invoiceAmount);
        }
        [TestMethod]
        public void TestUsingPromoItemForInvoiceGeneration()
        {
            var itemA = new OrderItem { SkuId = "A", Count = 1, Price = 10 };
            var itemB = new OrderItem { SkuId = "B", Count = 1, Price = 10 };
            var itemC = new OrderItem { SkuId = "C", Count = 1, Price = 10 };
            var itemD = new OrderItem { SkuId = "D", Count = 1, Price = 10 };
            var order = new Order();
            order.PromoItems.Add(itemA);
            order.PromoItems.Add(itemB);
            order.PromoItems.Add(itemC);
            order.PromoItems.Add(itemD);
            var invoiceAmount = _invoiceFactory.CalculateTotalInvoiceAmount(order);
            Assert.AreEqual(40, invoiceAmount);
        }
        [TestMethod]
        public void TestForInvoiceGeneration()
        {
            var itemA = new OrderItem { SkuId = "A", Count = 1, Price = 10 };
            var itemB = new OrderItem { SkuId = "B", Count = 1, Price = 10 };
            var itemC = new OrderItem { SkuId = "C", Count = 1, Price = 10 };
            var itemD = new OrderItem { SkuId = "D", Count = 1, Price = 10 };
            var order = new Order();
            order.OrderItems.Add(itemA);
            order.OrderItems.Add(itemB);
            order.OrderItems.Add(itemC);
            order.OrderItems.Add(itemD);
            order.PromoItems.Add(itemA);
            order.PromoItems.Add(itemB);
            order.PromoItems.Add(itemC);
            order.PromoItems.Add(itemD);
            var invoiceAmount = _invoiceFactory.CalculateTotalInvoiceAmount(order);
            Assert.AreEqual(80, invoiceAmount);
        }
    }
}
