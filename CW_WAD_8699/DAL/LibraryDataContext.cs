using CW_WAD_8699.Models;
using Microsoft.EntityFrameworkCore;

namespace CW_WAD_8699.DAL
{
    public class LibraryDataContext : DbContext
    {
        public LibraryDataContext(DbContextOptions<LibraryDataContext> options) : base(options)
        {

        }
        public virtual DbSet<Book> Books { get; set; }
        public DbSet<CW_WAD_8699.Models.Category> Categories { get; set; }
    }
}
