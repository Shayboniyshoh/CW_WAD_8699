using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using CW_WAD_8699.DAL;
using CW_WAD_8699.Models;

namespace Week3DbLogic.Repositories
{
    public class CategoriesRepo : BaseRepo, IReposotory<Category>
    {
        public CategoriesRepo(LibraryDataContext context) : base(context)
        {
        }
        public async Task Create(Category entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var genre = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(genre);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Category>> GetAll()
        {
            return await _context.Categories.Include(p => p.Books).ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task Update(Category entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
        public bool Exists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
