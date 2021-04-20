using Library_8699_DAL.DAL;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library_8699_DAL.Repositories
{
    public abstract class BaseRepo<T>: IRepository<T> where T : class
    {
        protected readonly LibraryDataContext _context;
        protected BaseRepo(LibraryDataContext context)
        {
            _context = context;
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
            var entity = await _context.Set<T>().FindAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
        public abstract bool Exists(int id);
        public abstract Task<T> GetById(int id);
        public abstract Task<List<T>> GetAll();
    }
}
