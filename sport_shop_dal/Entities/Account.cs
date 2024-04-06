using System;
using System.Collections.Generic;

namespace sport_shop_dal.Entities;

public partial class Account : BaseEntity
{
    public int Id { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int Role { get; set; }

    public virtual ICollection<Cart> Carts { get; } = new List<Cart>();

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
