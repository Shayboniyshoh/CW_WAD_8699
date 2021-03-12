using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CW_WAD_8699.Models
{
    public class Category
    {
        [Range(0, int.MaxValue)]
        public int Id { get; set; }
        [Required]
        [MinLength(4)]
        public string Title { get; set; }
        [Range(1900, int.MaxValue)]
        public int IssueYear { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
