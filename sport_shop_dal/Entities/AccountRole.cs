using System;
using System.Collections.Generic;

namespace sport_shop_dal.Entities;

public partial class AccountRole : BaseEntity
{
    public int Id { get; set; }

    public int Role { get; set; }
}
