using System;
using System.Collections.Generic;

namespace SellPhoneWebsite.Models.Entities;

public partial class CartItem
{
    public int UserId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public DateTime CreateAt { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
