

using System.ComponentModel.DataAnnotations;

namespace sport_shop_bll.Models.POST
{
    public class ManufacturerPost : IValidatableObject
    {
        public string Name { get; set; } = null!;

        public string Country { get; set; } = null!;

        public int MainCategoryId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (MainCategoryId <= 0)
            {
                yield return new ValidationResult("The main category id has to be more then 0.",
                    new[] { "Manufacturer" });
            }
        }
    }
}