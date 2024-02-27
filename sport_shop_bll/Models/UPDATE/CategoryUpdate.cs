

namespace sport_shop_bll.Models.UPDATE
{
    public class CategoryUpdate
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int RootCategoryId { get; set; }
    }
}
