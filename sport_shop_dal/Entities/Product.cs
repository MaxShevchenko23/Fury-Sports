using System;
using System.Collections.Generic;

namespace sport_shop_dal.Entities;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int CategoryId { get; set; }

    public int ManufacturerId { get; set; }

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public virtual ICollection<Specification> Specifications { get; } = new List<Specification>();
}
