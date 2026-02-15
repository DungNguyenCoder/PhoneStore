using System;
using System.Collections.Generic;

namespace SellPhoneWebsite.Models.Entities
{
    public class Order
    {
        public int ID { get; set; }
        public DateTime CreateAt { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; } = null!;

        public int UserID { get; set; }
        public ApplicationUser? User { get; set; }

        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}
