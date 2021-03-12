using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CW_WAD_8699.Models
{
    public class Book
    {
        [Range(0, int.MaxValue)]
        public int Id { get; set; }
        [Required]
        [MinLength(4)]
        public string Title { get; set; }
        [Range(1900, int.MaxValue)]
        public int IssueYear { get; set; }
        public bool IsAvailable { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
