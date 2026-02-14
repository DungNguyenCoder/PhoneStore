using System;
using System.Collections.Generic;

namespace SellPhoneWebsite.Models.Entities;

public partial class Order
{
    public int Id { get; set; }

    public DateTime CreateAt { get; set; }

    public decimal TotalPrice { get; set; }

    public string Status { get; set; } = null!;

    public int UserId { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual User User { get; set; } = null!;
}
