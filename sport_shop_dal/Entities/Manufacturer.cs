using System;
using System.Collections.Generic;

namespace sport_shop_dal.Entities;

public partial class Manufacturer : BaseEntity
{
    public new int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Country { get; set; } = null!;

    public int MainCategoryId { get; set; }

    public virtual Category MainCategory { get; set; } = null!;
}
