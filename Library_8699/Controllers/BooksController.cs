using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Library_8699_DAL.DBO;
using Library_8699_DAL.Repositories;
using System.Linq;
using Library_8699_DAL.DTO;

namespace Library_8699.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IRepository<Book> _book;
        public BooksController(IRepository<Book> book)
        {
            _book = book;
        }
        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDTO>>> GetBooks(int? categoryId)
        {
            var books = await _book.GetAll();
            if (categoryId.HasValue)
            {
                books = books.Where(s => s.CategoryId == categoryId).ToList();
            }
            return Ok(books.Select(b => new BookDTO
            {
                Id = b.Id,
                Title = b.Title,
                IssueYear = b.IssueYear,
                IsAvailable = b.IsAvailable,
                CategoryName = b.Category.Title
            }));
        }
        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _book.GetById(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }
        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _book.Update(book);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }
        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _book.Create(book);

            return CreatedAtAction("GetBook", new { id = book.Id }, book);
        }
        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _book.GetById(id);
            if (book == null)
            {
                return NotFound();
            }

            await _book.Delete(id);
            return NoContent();
        }
        private bool BookExists(int id)
        {
            return _book.Exists(id);
        }
    }
}
