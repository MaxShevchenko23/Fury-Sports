using System;
using System.Collections.Generic;

namespace sport_shop_dal.Entities;

public partial class ProductImage : BaseEntity
{
    public int Id { get; set; }

    public string ImageUrl { get; set; } = null!;

    public int ProductId { get; set; }

    public virtual Product Product { get; set; } = null!;
}
