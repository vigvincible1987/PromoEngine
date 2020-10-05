using System;
using System.Diagnostics;
using PromotionEngine.Entities;
using PromotionEngine.ItemFactory.Interfaces;

namespace PromotionEngine.ItemFactory
{
    public class ItemFactory : IItemFactory
    {
        public Item GetItem(string skuId)
        {
            var orderItem = new OrderItem(); 
            switch (skuId)
            {
                case "A":
                    orderItem.SkuId = "A";
                    orderItem.Price = 50;
                    break;
                case "B":
                    orderItem.SkuId = "B";
                    orderItem.Price = 30;
                    break;
                case "C":
                    orderItem.SkuId = "C";
                    orderItem.Price = 20;
                    break;
                case "D":
                    orderItem.SkuId = "D";
                    orderItem.Price = 15;
                    break;
            }

            return orderItem;
        }
    }
}
