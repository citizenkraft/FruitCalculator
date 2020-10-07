using Starz.FruitCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Starz.FruitCalculator.Components
{
    public class ShoppingBasketComponent
    {
        public decimal CalculateTotal(List<Product> products, List<BasketItem> basketItems, List<Promotion> promotions = null)
        {
            decimal total = 0;

            foreach(var item in basketItems)
            {
                var product = products.FirstOrDefault(x => x.ItemType == item.ItemType);
                if (product == null)
                {
                    throw new Exception($"Product {item.ItemType} not found in price list");
                } 
                else
                {
                    var promotion = promotions?.FirstOrDefault(x => x.ItemType == item.ItemType);
                    var lineTotal = (item.Quantity * product.Price);
                    if (promotion != null)
                    {
                        lineTotal = Convert.ToInt32(lineTotal * promotion.DiscountPercentage);
                    }
                    total += lineTotal;
                }
            }

            return total;
        }
    }
}
