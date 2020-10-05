using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Entities;
using PromotionEngine.Promotions;

namespace PromotionEngine.Test
{
    [TestClass]
    public class PromotionFactoryTest
    {
        private readonly PromotionFactory _promotionFactory = new PromotionFactory();

        [TestMethod]
        public void TestPromotionsByCount()
        {
            var itemA = new OrderItem {SkuId = "A", Count = 5, Price = 50};
            var order = new Order();
            order.OrderItems.Add(itemA);
            order = _promotionFactory.ApplyPromotion(order);
            Assert.AreEqual(2, order.OrderItems[0].Count);
            Assert.AreEqual(1, order.PromoItems[0].Count);
            Assert.AreEqual(130, order.PromoItems[0].Price);
            Assert.AreEqual(50, order.OrderItems[0].Price);
        }

        [TestMethod]
        public void TestPromotionsByCombination()
        {
            var itemC = new OrderItem {SkuId = "C", Count = 3, Price = 20};
            var itemD = new OrderItem {SkuId = "D", Count = 3, Price = 15};
            var order = new Order();
            order.OrderItems.Add(itemC);
            order.OrderItems.Add(itemD);
            order = _promotionFactory.ApplyPromotion(order);
            Assert.AreEqual(0, order.OrderItems[0].Count);
            Assert.AreEqual(0, order.OrderItems[1].Count);
            Assert.AreEqual(3, order.PromoItems[0].Count);
            Assert.AreEqual(30, order.PromoItems[0].Price);
        }
    }
}