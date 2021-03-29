using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library_8699_DAL.Repositories;
using Library_8699_DAL.DBO;
using Library_8699.Models;

namespace Library_8699.Controllers
{
    public class BooksController : Controller
    {
        private readonly IReposotory<Book> _bookRepo;
        private readonly IReposotory<Category> _categoryRepo;

        public BooksController(IReposotory<Book> bookRepo, IReposotory<Category> categoryRepo)
        {
            _bookRepo = bookRepo;
            _categoryRepo = categoryRepo;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            return View(await _bookRepo.GetAll());
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _bookRepo.GetById(id.Value);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public async Task<IActionResult> Create()
        {
            var bookViewModel = new BooksViewModel();
            bookViewModel.Categories = new SelectList(await _categoryRepo.GetAll(), "Id", "Title");
            return View(bookViewModel);
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,IssueYear,IsAvailable,CategoryId")] Book book)
        {
            if (ModelState.IsValid)
            {
                await _bookRepo.Create(book);
                return RedirectToAction(nameof(Index));
            }
            var bookViewModel = new BooksViewModel();
            bookViewModel.Categories = new SelectList(await _categoryRepo.GetAll(), "Id", "Title", book.CategoryId);
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _bookRepo.GetById(id.Value);
            if (book == null)
            {
                return NotFound();
            }
            var bookViewModel = new BooksViewModel();
            bookViewModel.CopyFromBook(book);
            bookViewModel.Categories = new SelectList(await _categoryRepo.GetAll(), "Id", "Title", book.CategoryId);
            return View(bookViewModel);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,IssueYear,IsAvailable,CategoryId")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _bookRepo.Update(book);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Exists(book.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            var bookViewModel = new BooksViewModel();
            bookViewModel.Categories = new SelectList(await _categoryRepo.GetAll(), "Id", "Title", book.CategoryId);
            return View(bookViewModel);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _bookRepo.GetById(id.Value);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _bookRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool Exists(int id)
        {
            return _bookRepo.Exists(id);
        }
    }
}
