using FluentAssertions;
using NUnit.Framework;
using Starz.FruitCalculator.Components;
using Starz.FruitCalculator.Models;
using System.Collections.Generic;

namespace Starz.FruitCalculator.Tests
{
    public class Tests
    {
        [Test]
        public void CalculateTotal_NoDiscount()
        {
            var productList = new List<Product>()
            {
                new Product() { ItemType = ItemType.Apples, Price = 5.0m },
                new Product() { ItemType = ItemType.Oranges, Price = 10.0m}
            };

            var basketItems = new List<BasketItem>()
            {
                new BasketItem() { ItemType = ItemType.Apples, Quantity = 1 },
                new BasketItem() { ItemType = ItemType.Oranges, Quantity = 5 }
            };

            var component = new ShoppingBasketComponent();

            var result = component.CalculateTotal(productList, basketItems);

            result.Should().Be(55);

        }

        [Test]
        public void CalculateTotal_WithDiscount()
        {
            var productList = new List<Product>()
            {
                new Product() { ItemType = ItemType.Apples, Price = 5.0m },
                new Product() { ItemType = ItemType.Oranges, Price = 10.0m}
            };

            var basketItems = new List<BasketItem>()
            {
                new BasketItem() { ItemType = ItemType.Apples, Quantity = 1 },
                new BasketItem() { ItemType = ItemType.Oranges, Quantity = 5 }
            };

            var promotions = new List<Promotion>()
            {
                new Promotion() { ItemType = ItemType.Oranges, DiscountPercentage = 0.5m }
            };

            var component = new ShoppingBasketComponent();

            var result = component.CalculateTotal(productList, basketItems, promotions);

            result.Should().Be(30);

        }
    }
}