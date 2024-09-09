using System.ComponentModel.DataAnnotations;

namespace Labb4MVCRazor.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Title is Mandatory")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is Required")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Publication year is Required")]
        public int PublicationYear { get; set; }


    }
}
