using System;
using System.Collections.Generic;

namespace sport_shop_dal.Entities;

public partial class Cart : BaseEntity
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public int AccountId { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
