using CW_WAD_8699.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Week3DbLogic.Repositories
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
