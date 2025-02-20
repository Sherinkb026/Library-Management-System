using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace LMSAPI.Models
{
    public class BorrowRecords
    {
        [Key]
        public int BorrowId { get; set; }


        [ForeignKey("Books")]
        public int BookId { get; set; }


        [ForeignKey("Users")]
        public int UserId { get; set; }


        [Required]
        public DateTime? BorrowDate { get; set; }


        public DateTime? DueDate { get; set; }

        public DateTime? ReturnDate { get; set; }
    }
}
