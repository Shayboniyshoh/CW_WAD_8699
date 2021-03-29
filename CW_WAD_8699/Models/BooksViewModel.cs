using Library_8699_DAL.DBO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library_8699.Models
{
    public class BooksViewModel : Book
    {
        public SelectList Categories { get; set; }
    }
}
