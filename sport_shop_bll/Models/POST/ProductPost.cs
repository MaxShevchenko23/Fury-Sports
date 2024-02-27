using sport_shop_dal.Entities;


namespace sport_shop_bll.Models.POST
{
    public class ProductPost
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int CategoryId { get; set; }

        public int ManufacturerId { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public ICollection<Specification> Specifications { get; } = new List<Specification>();
    }
}
