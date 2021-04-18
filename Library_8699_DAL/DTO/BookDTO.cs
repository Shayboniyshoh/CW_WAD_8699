using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_8699_DAL.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int IssueYear { get; set; }
        public bool IsAvailable { get; set; }
        public string CategoryName { get; set; }
    }
}
