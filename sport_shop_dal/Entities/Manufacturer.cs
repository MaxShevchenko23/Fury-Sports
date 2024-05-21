using System;
using System.Collections.Generic;

namespace sport_shop_dal.Entities;

public partial class Manufacturer : BaseEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Country { get; set; } = null!;

    public int MainCategoryId { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
