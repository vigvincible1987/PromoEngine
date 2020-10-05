using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Factory;
using PromotionEngine.Factory.Interfaces;

namespace PromotionEngine.Test
{
    [TestClass]
    public class ItemFactoryTest
    {
        private readonly IItemFactory _itemFactory = new ItemFactory();

        [TestMethod]
        public void TestForItemA()
        {
            var item = _itemFactory.GetItem("A");
            Assert.AreEqual("A", item.SkuId);
        }


        [TestMethod]
        public void TestForItemB()
        {
            var item = _itemFactory.GetItem("b");
            Assert.AreEqual("B", item.SkuId);
        }

        [TestMethod]
        public void TestForItemC()
        {
            var item = _itemFactory.GetItem("C");
            Assert.AreEqual("C", item.SkuId);
        }

        [TestMethod]
        public void TestForItemD()
        {
            var item = _itemFactory.GetItem("D");
            Assert.AreEqual("D", item.SkuId);
        }

        [TestMethod]
        public void TestForInvalidSku()
        {
            var item = _itemFactory.GetItem("E");
            Assert.IsNull(item);
        }
    }
}