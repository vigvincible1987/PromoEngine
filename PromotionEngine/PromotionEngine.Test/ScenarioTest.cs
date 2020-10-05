using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Entities;
using PromotionEngine.Factory;
using PromotionEngine.Factory.Interfaces;
using PromotionEngine.Promotions;

namespace PromotionEngine.Test
{
    [TestClass]
    public class ScenarioTest
    {
        private readonly InvoiceFactory _invoiceFactory = new InvoiceFactory();
        private readonly IItemFactory _itemFactory = new ItemFactory();
        private readonly PromotionFactory _promotionFactory = new PromotionFactory();

        [TestMethod]
        public void TestForScenarioA()
        {
            var itemA = _itemFactory.GetItem("A");
            itemA.Count = 1;
            var itemB = _itemFactory.GetItem("B");
            itemB.Count = 1;
            var itemC = _itemFactory.GetItem("C");
            itemC.Count = 1;
            var order = new Order();
            order.OrderItems.Add(itemA);
            order.OrderItems.Add(itemB);
            order.OrderItems.Add(itemC);

            order = _promotionFactory.ApplyPromotion(order);

            var invoiceAmount = _invoiceFactory.CalculateTotalInvoiceAmount(order);

            Assert.AreEqual(100, invoiceAmount);
        }

        [TestMethod]
        public void TestForScenarioB()
        {
            var itemA = _itemFactory.GetItem("A");
            itemA.Count = 5;
            var itemB = _itemFactory.GetItem("B");
            itemB.Count = 5;
            var itemC = _itemFactory.GetItem("C");
            itemC.Count = 1;
            var order = new Order();
            order.OrderItems.Add(itemA);
            order.OrderItems.Add(itemB);
            order.OrderItems.Add(itemC);

            order = _promotionFactory.ApplyPromotion(order);

            var invoiceAmount = _invoiceFactory.CalculateTotalInvoiceAmount(order);

            Assert.AreEqual(370, invoiceAmount);
        }

        [TestMethod]
        public void TestForScenarioC()
        {
            var itemA = _itemFactory.GetItem("A");
            itemA.Count = 3;
            var itemB = _itemFactory.GetItem("B");
            itemB.Count = 5;
            var itemC = _itemFactory.GetItem("C");
            itemC.Count = 1;
            var itemD = _itemFactory.GetItem("D");
            itemD.Count = 1;
            var order = new Order();
            order.OrderItems.Add(itemA);
            order.OrderItems.Add(itemB);
            order.OrderItems.Add(itemC);
            order.OrderItems.Add(itemD);

            order = _promotionFactory.ApplyPromotion(order);

            var invoiceAmount = _invoiceFactory.CalculateTotalInvoiceAmount(order);

            Assert.AreEqual(280, invoiceAmount);
        }
    }
}