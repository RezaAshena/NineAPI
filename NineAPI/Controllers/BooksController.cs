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
    }
}
