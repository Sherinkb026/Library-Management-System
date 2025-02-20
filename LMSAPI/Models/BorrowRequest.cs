using System.ComponentModel.DataAnnotations;


namespace LMSAPI.Models
{
    public class BorrowRequest
    {

        [Required]
        public int BookId { get; set; }


        [Required]

        public int UserId { get; set; }
    }
}
