using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMSAPI.Models
{
    public class Books
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required]
        public string BookTitle { get; set; }


        [Required]
        public string Author { get; set; }

        [Required]
        public string ISBN { get; set; }


        [Required]
        public int TotalCopies { get; set; }


        [Required]
        public int AvailableCopies { get; set; }
    }
}
