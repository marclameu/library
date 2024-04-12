using bookLibraryData.Models;
using EFCoreExample;
using Microsoft.AspNetCore.Mvc;

namespace bookLibraryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private AppDbContext _dbContext;

        public BookController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet()]
        public IEnumerable<Book> getBooks()
        {
            return _dbContext.Books;
        }

        [HttpPost]
        public void PostBook([FromBody] Book book)
        {
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
        }

        [HttpGet("search")]
        public IEnumerable<Book> searchBy(string by, string value)
        {
            switch (by.ToLower())
            {
                case "title":
                    return _dbContext.Books.Where(b => b.Title.Contains(value));
                case "isbn":
                    return _dbContext.Books.Where(b => b.ISBN.Contains(value));
                case "author":
                    return _dbContext.Books.Where(b => b.FirstName.Contains(value));
                default:
                    return Enumerable.Empty<Book>();
            }
        }
    }
}
