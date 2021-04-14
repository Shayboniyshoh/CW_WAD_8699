using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Library_8699_DAL.DAL;
using Library_8699_DAL.DBO;


namespace Library_8699_DAL.Repositories
{
    public class CategoriesRepo : BaseRepo<Category>
    {
        public CategoriesRepo(LibraryDataContext context) 
            : base(context)
        {
        }

        public override bool Exists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
        public override async Task<List<Category>> GetAll()
        {
           return await _context.Categories.Include(p => p.Books).ToListAsync();
        }
        public override async Task<Category> GetById(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
