using System;

namespace SellPhoneWebsite.Models.Entities
{
    public class CartItem
    {
        public int UserID { get; set; }
        public ApplicationUser? User { get; set; }

        public int ProductID { get; set; }
        public Product? Product { get; set; }

        public int Quantity { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
