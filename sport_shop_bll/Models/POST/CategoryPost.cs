

using System.ComponentModel.DataAnnotations;

namespace sport_shop_bll.Models.POST
{
    public class CategoryPost : IValidatableObject
    {
        public string Name { get; set; } = null!;

        public int? RootCategoryId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (RootCategoryId != null && RootCategoryId <= 0)
            {
                yield return new ValidationResult("The root category id has to be more then 0. Change it or leave empty.",
                    new[] { "Category" });
            }
        }
    }
}
