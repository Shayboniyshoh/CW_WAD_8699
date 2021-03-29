using Library_8699_DAL.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library_8699_DAL.Repositories
{
    public abstract class BaseRepo
    {
        protected readonly LibraryDataContext _context;

        protected BaseRepo(LibraryDataContext context)
        {
            _context = context;
        }
    }
}
