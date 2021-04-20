using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Library_8699_DAL.DAL;
using Library_8699_DAL.DBO;
using System.Linq;

namespace Library_8699_DAL.Repositories
{
    public class BooksRepo : BaseRepo<Book>
    {
        public BooksRepo(LibraryDataContext context) 
            : base(context)
        {
        }
        public override bool Exists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
        public override async Task<List<Book>> GetAll()
        {
           return await _context.Books.Include(m => m.Category).ToListAsync();
        }
        public override async Task<Book> GetById(int id)
        {
            return await _context.Books
                .Include(m => m.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
