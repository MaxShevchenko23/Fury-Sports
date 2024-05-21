using sport_shop_dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sport_shop_bll.Models.UPDATE
{
    public class OrderUpdate
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

        public string? Post { get; set; }

        public string? Payment { get; set; }
    }
}
