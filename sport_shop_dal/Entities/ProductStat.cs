using System;
using System.Collections.Generic;

namespace sport_shop_dal.Entities;

public partial class ProductStat : BaseEntity
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int Views { get; set; }

    public int Purchases { get; set; }

    public virtual Product Product { get; set; } = null!;
}
