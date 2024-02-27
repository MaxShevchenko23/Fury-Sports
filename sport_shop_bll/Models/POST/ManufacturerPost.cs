

namespace sport_shop_bll.Models.POST
{
    public class ManufacturerPost
    {
        public string Name { get; set; } = null!;

        public string Country { get; set; } = null!;

        public int MainCategoryId { get; set; }
    }
}
