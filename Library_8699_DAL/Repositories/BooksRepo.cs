using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Library_8699_DAL.DAL;
using Library_8699_DAL.DBO;

namespace Library_8699_DAL.Repositories
{
    public class BooksRepo : BaseRepo, IReposotory<Book>
    {

        public BooksRepo(LibraryDataContext context) : base(context)
        {
        }
        public async Task Create(Book entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var movie =  await _context.Books.FindAsync(id);
            _context.Books.Remove(movie);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Book>> GetAll()
        {
            return await _context.Books.Include(m => m.Category).ToListAsync();
        }

        public async Task<Book> GetById(int id)
        {
            return await _context.Books
                .Include(m => m.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task Update(Book entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
