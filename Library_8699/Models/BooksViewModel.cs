using Microsoft.AspNetCore.Mvc.Rendering;
using Library_8699_DAL.DBO;

namespace Library_8699.Models
{
    public class BooksViewModel : Book
    {
        public SelectList Categories { get; set; }
        public void CopyFromBook(Book b)
        {
            Id = b.Id;
            Title = b.Title;
            IssueYear = b.IssueYear;
            IsAvailable = b.IsAvailable;
            CategoryId = b.CategoryId;
        }
    }
}
