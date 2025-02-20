using LMSAPI.Data;
using LMSAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;




namespace LMSAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Books>>> GetAllBooks()
        {
            var books = await _context.Books.ToListAsync();
            return Ok(books);
        }


        [HttpGet("available")]

        public async Task<ActionResult<IEnumerable<Books>>> GetAvailableBooks()
        {
            var availableBooks = await _context.Books.Where(b => b.AvailableCopies > 0).ToListAsync();
            return Ok(availableBooks);
        }


    }
}
