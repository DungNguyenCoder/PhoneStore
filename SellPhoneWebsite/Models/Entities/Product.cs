using System;
using System.Collections.Generic;

namespace SellPhoneWebsite.Models.Entities
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreateAt { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; } = null!;

        public int CategoryID { get; set; }
        public Category? Category { get; set; }

        public ICollection<ProductImage>? ProductImages { get; set; }
        public ICollection<OrderItem>? OrderItems { get; set; }
        public ICollection<CartItem>? CartItems { get; set; }
    }
}
