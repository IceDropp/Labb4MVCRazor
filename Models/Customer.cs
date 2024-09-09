using System.ComponentModel.DataAnnotations;

namespace Labb4MVCRazor.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 15)]
        public string Email { get; set; }

        [Required(ErrorMessage = "The customer's phone number is mandatory.")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "The phone number must be a 8-digit number.")]
        public string PhoneNumber { get; set; }



    }
}
