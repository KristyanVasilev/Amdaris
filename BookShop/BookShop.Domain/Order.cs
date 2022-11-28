﻿namespace BookShop.Domain
{
    public class Order
    {
        public Order()
        {
            this.Products = new List<Product>();
        }

        public int Id { get; set; }

        public int UserId {get; set; }

        public ICollection<Product> Products { get; set; }

        public bool IsCompleted { get; set; }
    }
}