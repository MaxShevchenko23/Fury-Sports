using sport_shop_dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sport_shop_bll.Models.GET
{
    public class ProductFullGet
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
}
