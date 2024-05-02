namespace sport_shop_bll.Models.UPDATE
{
    public class ProductUpdate
    {

        public string Name { get; set; } = null!;

        public int CategoryId { get; set; }

        public int ManufacturerId { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
        public string? Image { get; set; }

    }
}
