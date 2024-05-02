using sport_shop_dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sport_shop_bll.Models.POST
{
    public class AccountPost
    {
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
