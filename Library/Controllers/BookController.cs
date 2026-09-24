using Library.Models.ApplicationContext;
using Library.Models.DTOs.BookDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly AppDBContext _Context;
        public BookController(AppDBContext context)
        {
            _Context = context;
        }
        [HttpGet("Bookprice")]

        public IActionResult GetByPrice(int price)
        {
            var book = _Context.Books.Where(a => a.Price > price).ToList();
            return Ok(book);
        }
        //2
        [HttpGet("getbetween")]
        public IActionResult getbooksbetween(int max,int min)
        {
            var book = _Context.Books.Where(a => a.Price >= min && a.Price <= max).ToList();
            return Ok(book);
        }
        //3
        [HttpGet("search")]
        public IActionResult searchbykeyword(string keyword)
        {
            var book = _Context.Books.Where(a => a.Title.Contains(keyword)).ToList();
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
        //4
        [HttpGet("getfirstbook")]
        public IActionResult getfirst()
        {
            var book=_Context.Books.FirstOrDefault();
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
        //5
        [HttpGet("availablebooks")]
        public IActionResult getfirstavailable()
        {
            var book = _Context.Books.FirstOrDefault(a => a.AvailableCopies > 0);
            if (book == null)
            {
                return NotFound();  
            }
            return Ok(book);
        }
        //6
        [HttpGet("getbyid")]
        public IActionResult getbyId(int id)
        {
            var book = _Context.Books.Include(a => a.Category).FirstOrDefault(a => a.BookId == id);
            if (book == null)
            {
                return NotFound();
            }
            var dto = new BookDTO
            {
                BookId = book.BookId,
                Title = book.Title,
                Author = book.Author,
                PublishedYear = book.PublishedYear,
                AvailableCopies = book.AvailableCopies,
                Price= book.Price,
                CategoryName = book.Category.Name,
            };
            return Ok(dto);
        }
        //7
        [HttpGet("lastbook")]
        public IActionResult getlastBook()
        {
            var book = _Context.Books.LastOrDefault();
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);

        }

        //8
        [HttpGet ("Check")]
        public IActionResult Check(int id)
        {
            var book=_Context.Books.AnyAsync(a => a.BookId == id);
            return Ok(book);
        }
        //9
        [HttpGet("Available")]
        public IActionResult CheckifAvailable()
        {
            var book = _Context.Books.AllAsync(a => a.AvailableCopies > 0);
            return Ok(book);

        }
        //10
        [HttpGet("Gettitleonly")]
        public IActionResult Gettitle()
        {
            var book = _Context.Books.Select(a => a.Title).ToList();
            return Ok(book);
        }
        //11
        [HttpGet("sortbooks")]
        public IActionResult sorttitle()
        {
            var book=_Context.Books.OrderBy(a => a.Title).ToList();
            return Ok(book);
        }
        //12
        [HttpGet("lowestprice")]
        public IActionResult getlowestprice()
        {
            var book = _Context.Books.Min(a => a.Price);
            return Ok(book);
        }
      
    }
}
