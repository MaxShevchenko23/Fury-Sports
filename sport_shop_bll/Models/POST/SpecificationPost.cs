

namespace sport_shop_bll.Models.POST
{
    public class SpecificationPost
    { 
        public int ProductId { get; set; }

        public string SpecificationName { get; set; } = null!;

        public string SpecificationValue { get; set; } = null!;
    }
}
