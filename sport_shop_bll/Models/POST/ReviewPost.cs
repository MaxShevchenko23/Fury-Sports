using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sport_shop_bll.Models.POST
{
    public class ReviewPost
    {
        public int AccountId { get; set; }

        public int ProductId { get; set; }

        public decimal Mark { get; set; }

        public string? ReviewContent { get; set; }
    }
}
