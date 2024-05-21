using System;
using System.Collections.Generic;

namespace sport_shop_dal.Entities;

public partial class Category : BaseEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? RootCategoryId { get; set; }

    public virtual ICollection<Category> InverseRootCategory { get; } = new List<Category>();

    public virtual ICollection<Product> Products { get; } = new List<Product>();

    public virtual Category? RootCategory { get; set; }
}
