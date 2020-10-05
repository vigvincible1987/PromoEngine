using System;
using System.Collections.Generic;
using System.Text;
using PromotionEngine.Entities;
using PromotionEngine.Promotions.Interfaces;

namespace PromotionEngine.Promotions
{
    public class PromotionsByCount : IPromotion
    {
        private Item _item;
        private int _count;
        private decimal _price;

        public PromotionsByCount(Item item, int count, decimal price)
        {
            _item = item;
            _count = count;
            _price = price;
        }

        public Order ApplyPromotion(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
