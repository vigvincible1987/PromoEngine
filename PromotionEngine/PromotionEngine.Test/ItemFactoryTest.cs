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
            Assert.AreEqual(item.SkuId, "A");
        }


        [TestMethod]
        public void TestForItemB()
        {
            var item = _itemFactory.GetItem("b");
            Assert.AreEqual(item.SkuId, "B");
        }

        [TestMethod]
        public void TestForItemC()
        {
            var item = _itemFactory.GetItem("C");
            Assert.AreEqual(item.SkuId, "C");
        }

        [TestMethod]
        public void TestForItemD()
        {
            var item = _itemFactory.GetItem("D");
            Assert.AreEqual(item.SkuId, "D");
        }

        [TestMethod]
        public void TestForInvalidSku()
        {
            var item = _itemFactory.GetItem("E");
            Assert.IsNull(item);
        }
    }
}
