using Microsoft.AspNetCore.Mvc;
using NineAPI.Models;

namespace NineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        static private List<Book> Books = new List<Book>
        {
            new Models.Book { Id = 1, Title = "1984", Author = "George Orwell", YearPublished = 1949 },
            new Models.Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", YearPublished = 1960 },
            new Models.Book { Id = 3, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", YearPublished = 1925 }
        };

        [HttpGet]
        public ActionResult<List<Book>> GetBooks()
        {
            return Ok(Books);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
        [HttpPost]
        public ActionResult<Book> CreateBook([FromBody] Book book)
        {
            if (book == null || string.IsNullOrWhiteSpace(book.Title) || string.IsNullOrWhiteSpace(book.Author))
            {
                return BadRequest("Invalid book data.");
            }
            book.Id = Books.Max(b => b.Id) + 1; // Simple ID generation
            Books.Add(book);
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public ActionResult<Book> UpdateBook(int id, [FromBody] Book updatedBook)
        {
            if (updatedBook == null || string.IsNullOrWhiteSpace(updatedBook.Title) || string.IsNullOrWhiteSpace(updatedBook.Author))
            {
                return BadRequest("Invalid book data.");
            }
            var book = Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.YearPublished = updatedBook.YearPublished;
            return Ok(book);
        }

        [HttpDelete("{id}")]    
        public ActionResult DeleteBook(int id)
        {
            var book = Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            Books.Remove(book);
            return NoContent();
        }
    }
}
