using System;
using System.Collections.Generic;

namespace sport_shop_dal.Entities;

public partial class Review : BaseEntity
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int ProductId { get; set; }

    public decimal Mark { get; set; }

    public string? ReviewContent { get; set; }

    public DateTime Date { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
