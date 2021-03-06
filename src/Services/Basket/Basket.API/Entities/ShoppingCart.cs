using System.Collections.Generic;

namespace src.Services.Basket.Basket.API.Entities
{
    public class ShoppingCart
    {
        public string UserName { get; set; }
        public List<ShoppingCartItem> Items { get; set; }

        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = 0;
                foreach (var item in Items)
                {
                    totalPrice += item.Price * item.Quantity;
                }
                return totalPrice;
            }
        }

        // public ShoppingCart()
        // {
        // }
        // public ShoppingCart(string username)
        // {
        //     UserName = username;
        // }
    }
}