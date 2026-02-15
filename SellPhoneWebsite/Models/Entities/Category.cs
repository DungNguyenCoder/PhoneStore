using System;
using System.Collections.Generic;

namespace SellPhoneWebsite.Models.Entities
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreateAt { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
