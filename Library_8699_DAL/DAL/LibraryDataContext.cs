using Library_8699_DAL.DBO;
using Microsoft.EntityFrameworkCore;

namespace Library_8699_DAL.DAL
{
    public class LibraryDataContext : DbContext
    {
        public LibraryDataContext(DbContextOptions<LibraryDataContext> options) 
            : base(options)
        {
        }
        public virtual DbSet<Book> Books { get; set; }
        public DbSet<Library_8699_DAL.DBO.Category> Categories { get; set; }
    }
}
