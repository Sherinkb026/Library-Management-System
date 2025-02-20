using LMSAPI.Data;
using LMSAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace LMSAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]


    public class BorrowController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        private readonly ILogger<BorrowController> _logger;

        public BorrowController(ApplicationDbContext context, ILogger<BorrowController> logger)
        {
            _context = context;
            _logger = logger;
        }


        [HttpPost]
        public async Task<IActionResult> BorrowBook([FromBody] BorrowRequest request)
        {
           
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == request.BookId);
            

            if (book == null )
            {
                return BadRequest("Book not found.");
            }
           

            //calling sp

            try
            {
                await _context.Database.ExecuteSqlRawAsync("EXEC BorrowBook @UserId, @BookId",
                    new SqlParameter("@UserId", request.UserId),
                    new SqlParameter("BookId", request.BookId));


                return Ok("Book Borrowed Successfully");

            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpGet("{userId}")]

        public async Task<IActionResult> GetBorrowedBooks(int userId)
        {
            var borrowedBooks = await _context.BorrowRecords.Where(br => br.UserId == userId).ToListAsync();
            return Ok(borrowedBooks);
        }


    }
}
