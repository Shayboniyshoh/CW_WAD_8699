using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Library_8699_DAL.DBO
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
        [JsonIgnore]
        public virtual Category Category { get; set; }
    }
}
