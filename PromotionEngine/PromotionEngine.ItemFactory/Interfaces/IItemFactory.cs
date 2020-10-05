﻿using System;
using System.Collections.Generic;
using System.Text;
using PromotionEngine.Entities;

namespace PromotionEngine.Factory.Interfaces
{
    interface IItemFactory
    {
        Item GetItem(string skuId);
    }
}
