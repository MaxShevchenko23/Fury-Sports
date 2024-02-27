

namespace sport_shop_bll.Models.UPDATE
{
    public class ManufacturerUpdate
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Country { get; set; } = null!;

        public int MainCategoryId { get; set; }
    }
}
