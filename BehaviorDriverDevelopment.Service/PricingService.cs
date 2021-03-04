using System;
using System.Collections.Generic;
using System.Linq;

namespace BehaviorDriverDevelopment.Service
{
    public class PricingService : IPricingService
    {
        public decimal GetBasketTotalAmount(Basket basket)
        {
            if (basket == null)
            {
                throw new ArgumentNullException(nameof(basket));
            }

            decimal basketValue = 0;
    
            if (basket.Products.Any(b => b.Name == "t-shirt"))
            {
                basketValue = 5;
            }
            
            if (basket.Products.Any(b => b.Name == "dress"))
            {
                basketValue = 100;
            }

            if (basket.User.IsLoggedIn)
            {
                return basketValue - (basketValue * 0.05m);
            }

            return basketValue;
        }
    }

    public interface IPricingService
    {
        decimal GetBasketTotalAmount(Basket basket);
    }

    public class User
    {
        public bool IsLoggedIn { get; init; }
    }

    public class Basket
    {
        public User User { get; init; }
        public List<Product> Products { get; } = new();
    }

    public class Product
    {
        public string Name { get; init; }
        public decimal Price { get; init; }
    }
}