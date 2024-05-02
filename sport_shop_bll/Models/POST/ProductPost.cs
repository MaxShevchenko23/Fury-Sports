using sport_shop_dal.Entities;
using System.ComponentModel.DataAnnotations;

namespace sport_shop_bll.Models.POST
{
    public class ProductPost : IValidatableObject
    {

        public string Name { get; set; } = null!;

        public int CategoryId { get; set; }

        public int ManufacturerId { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
        public virtual Manufacturer Manufacturer { get; set; } = null!;

        public string? Image { get; set; }

        public ICollection<Specification> Specifications { get; } = new List<Specification>();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (CategoryId <= 0)
            {
                yield return new ValidationResult("Category id cannot be below 1. Set the proper value",
                    new[] { "Product" });
            }
            if (ManufacturerId <= 0)
            {
                yield return new ValidationResult("Manufacturer id cannot be below 1. Set the proper value",
                    new[] { "Product" });
            }
            if (Price < 0)
            {
                yield return new ValidationResult("The price cannot be less than 0",
                    new[] { "Product" });
            }
            if (Quantity < 0)
            {
                yield return new ValidationResult("Quantity cannot be below 0. Set the proper value",
                    new[] { "Product" });
            }
        }
    }
}
