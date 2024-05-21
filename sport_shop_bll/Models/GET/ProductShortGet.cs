namespace sport_shop_bll.Models.GET
{
    public class ProductShortGet
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int CategoryId { get; set; }

        public int ManufacturerId { get; set; }
        public virtual ManufacturerGet Manufacturer { get; set; } = null!;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
        public string? Image { get; set; }
        public int? Views { get; set; }
        public int? Purchases { get; set; }


    }
}
