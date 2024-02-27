using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sport_shop_bll.Models.GET
{
    public class CategoryGet
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int RootCategoryId { get; set; }
    }
}
