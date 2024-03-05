

using sport_shop_dal.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace sport_shop_bll.Models.POST
{
    public class SpecificationPost:IValidatableObject
    { 
        public int ProductId { get; set; }

        public string SpecificationName { get; set; } = null!;

        public string SpecificationValue { get; set; } = null!;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ProductId <= 0)
            {
                yield return new ValidationResult("Product id cannot be below 1. Set the proper value",
                    new[] { "Specification" });
            }
            if (SpecificationName == SpecificationValue)
            {
                yield return new ValidationResult("The name cannot be the same as its value",
                    new[] { "Specification" });
            }
            if (Regex.IsMatch(SpecificationName, @"\d"))
            {
                yield return new ValidationResult("Name must contain only letters",
                    new[] { "Specification" });
            }
        }
    }
}
