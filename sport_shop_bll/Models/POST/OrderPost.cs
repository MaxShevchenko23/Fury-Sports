using System.ComponentModel.DataAnnotations;

namespace sport_shop_bll.Models.POST
{
    public class OrderPost //: IValidatableObject
    {
        [MinLength(5)]
        public string ClientName { get; set; } = null!;
        public int ProductId { get; set; }
        
        public int Quantity { get; set; }

        public int AccountId { get; set; }

        [MaxLength(12)]
        [RegularExpression(@"\d*")]
        public string ClientPhoneNumber { get; set; } = null!;
        [MinLength(5)]
        public string ClientAddress { get; set; } = null!;

        public int Status { get; set; }

        public string? Post { get; set; }

        public string? Payment { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            throw new NotImplementedException();

            
        }
    }
}
