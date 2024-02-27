

namespace sport_shop_bll.Models.GET
{
    public class SpecificationGet
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string SpecificationName { get; set; } = null!;

        public string SpecificationValue { get; set; } = null!;
    }
}
