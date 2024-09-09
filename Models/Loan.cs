using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb4MVCRazor.Models
{
    public class Loan
    {
        [Key]
        public int LoanId { get; set; }
        [Required(ErrorMessage = "Customer is required")]

        public Customer Customer { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Book is required")]
        [ForeignKey("Book")]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Loan date is required")]
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public Book Book { get; set; }

        public bool Returned { get; set; }

    }
}
