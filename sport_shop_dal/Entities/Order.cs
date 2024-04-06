using System;
using System.Collections.Generic;

namespace sport_shop_dal.Entities;

public partial class Order : BaseEntity
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public string ClientName { get; set; } = null!;

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public int? AccountId { get; set; }

    public string ClientPhoneNumber { get; set; } = null!;

    public string ClientAddress { get; set; } = null!;

    public int Status { get; set; }

    public virtual Account? Account { get; set; }

    public virtual Product Product { get; set; } = null!;
}
