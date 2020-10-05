using System;
using PromotionEngine.Entities;
using PromotionEngine.Factory;
using PromotionEngine.Promotions;

namespace PromotionEngine.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order();
            Console.WriteLine("Enter the number of items in the order");
            var sNumberOfItems = Console.ReadLine();
            if (int.TryParse(sNumberOfItems, out var numberOfItems))
            {
                for (int i = 1; i <= numberOfItems; i++)
                {
                    Console.WriteLine("Enter SkuId for item #"+i.ToString());
                    var itemFactory = new ItemFactory();
                    var item = itemFactory.GetItem(Console.ReadLine());
                    if (item != null)
                    {
                        Console.WriteLine("Enter count for item #" + i.ToString());
                        var sItemCount = Console.ReadLine();
                        if(int.TryParse(sItemCount,out var itemCount))
                        {
                            item.Count = itemCount;
                            order.OrderItems.Add(item);
                        }
                        else
                        {
                            Console.WriteLine("Invalid Entry");
                            Console.ReadLine();
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Entry");
                        Console.ReadLine();
                        break;
                    }
                    
                }
            }
            
            var promotionFactory = new PromotionFactory();
            promotionFactory.ApplyPromotion(order);

            var invoiceFactory = new InvoiceFactory();
            var invoice = invoiceFactory.CalculateTotalInvoiceAmount(order);
            Console.WriteLine(invoice.ToString());
            Console.ReadLine();
        }
    }
}
