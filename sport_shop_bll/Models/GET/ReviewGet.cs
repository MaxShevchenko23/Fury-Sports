using sport_shop_dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sport_shop_bll.Models.GET
{
    public class ReviewGet
    {
        public int Id { get; set; }

        public int AccountId { get; set; }

        public int ProductId { get; set; }

        public decimal Mark { get; set; }

        public string? ReviewContent { get; set; }

        public DateTime Date { get; set; }

        public Account Account { get; set; } = null!;
    }
}
