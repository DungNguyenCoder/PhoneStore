using Microsoft.AspNetCore.Identity;
using System;

namespace SellPhoneWebsite.Models.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public DateTime CreatedDate { get; set; }

        public ICollection<Order>? Orders { get; set; }
        public ICollection<CartItem>? CartItems { get; set; }
    }
}
