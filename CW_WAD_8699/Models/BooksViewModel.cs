using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_WAD_8699.Models
{
    public class BooksViewModel : Book
    {
        public SelectList Categories { get; set; }
    }
}
