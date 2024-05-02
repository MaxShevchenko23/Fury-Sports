using sport_shop_dal.Entities;

namespace sport_shop_bll.Models.GET
{
    public class ProductFullGet
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int CategoryId { get; set; }

        public int ManufacturerId { get; set; }
        public virtual ManufacturerGet Manufacturer { get; set; } = null!;

        public string? Description { get; set; }

        public decimal Price { get; set; }
        public string? Image { get; set; }
        public int Quantity { get; set; }
        public int? Views { get; set; }

        public int? Purchases { get; set; }



        public decimal Rating
        {
            get
            {
                var reviews = Reviews;
                int reviewsNumber = Reviews.Count() == 0 ? 1 : Reviews.Count();
                decimal totalRating = 0;

                foreach (var item in reviews)
                {
                    totalRating += item.Mark;
                }

                return totalRating / reviewsNumber;
            }
        }

        public IEnumerable<SpecificationGet> Specifications { get; set; }

        //public IEnumerable<ProductImage> ProductImages { get; set; }

        public IEnumerable<ReviewGet> Reviews { get; set; }


    }
}
