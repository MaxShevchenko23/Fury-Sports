using System;
using System.Collections.Generic;

namespace sport_shop_dal.Entities;

public partial class Specification : BaseEntity
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string SpecificationName { get; set; } = null!;

    public string SpecificationValue { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
