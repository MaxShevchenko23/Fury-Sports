
namespace sport_shop_bll.Models.GET
{
    public class CategoryGet
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int RootCategoryId { get; set; }
    }
}
