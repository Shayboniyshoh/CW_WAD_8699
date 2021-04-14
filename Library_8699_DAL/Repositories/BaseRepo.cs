using Library_8699_DAL.DAL;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library_8699_DAL.Repositories
{
    public abstract class BaseRepo<T>: IRepository<T> where T : class
    {
        protected readonly LibraryDataContext _context;
        internal DbSet<T> dbset;
        protected BaseRepo(LibraryDataContext context)
        {
            _context = context;
            this.dbset = _context.Set<T>(); 
        }
        public async Task Create(T entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Update(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            /*
            var movie = await _context.Books.FindAsync(id);
            _context.Books.Remove(movie);
            await _context.SaveChangesAsync();*/
            var entity = await dbset.FindAsync(id);
            dbset.Remove(entity);
            await _context.SaveChangesAsync();
        }
        public abstract bool Exists(int id);
        public abstract Task<List<T>> GetAll();
        public abstract Task<T> GetById(int id);
    }
}
