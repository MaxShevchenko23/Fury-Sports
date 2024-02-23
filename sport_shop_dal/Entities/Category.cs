using System;
using System.Collections.Generic;

namespace sport_shop_dal.Entities;

public partial class Category: BaseEntity
{
    public new int Id { get; set; }

    public string Name { get; set; } = null!;

    public int RootCategoryId { get; set; }

    public virtual ICollection<Manufacturer> Manufacturers { get; } = new List<Manufacturer>();
}
