using AppComplete.Services;
using AppModel.Models;
using AppModel.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AppComplete.Areas.Admin.Controllers
{
    [Area(RolesTypes.Admin)]
    [Authorize(Roles = RolesTypes.Admin)]
    public class BookController : Controller
    {
        private readonly BookServices _bookServices;
        private readonly AuthorServices _authorServices;
        private readonly PublisherServices _publisherServices;
        private readonly BookAuthorServices _bookAuthorServices;

        public BookController(BookServices bookServices, AuthorServices authorServices, PublisherServices publisherServices, BookAuthorServices bookAuthorServices)
        {
            _bookServices = bookServices;
            _authorServices = authorServices;
            _publisherServices = publisherServices;
            _bookAuthorServices = bookAuthorServices;
        }

        public IActionResult Index()
        {
            var books = _bookServices.GetAll();
            return View(books);
        }

        public IActionResult Details(int id)
        {
            var book = _bookServices.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        public IActionResult Create()
        {
            var authors = _authorServices.GetAll();
            var publishers = _publisherServices.GetAll();

            var model = new BookWithListCollectionVM();

            model.Book = new Book();
            model.Authors = authors;
            model.Publishers = publishers;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BookWithListCollectionVM model)
        {

            if (ModelState.IsValid)
            {
                _bookServices.Create(model.Book);

                if (model.AuthorsIds != null && model.AuthorsIds.Length > 0)
                {
                    foreach (var authorId in model.AuthorsIds)
                    {
                        _bookAuthorServices.Create(model.Book.BookId, authorId);
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var book = _bookServices.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Book book)
        {
            if (id != book.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bookServices.Update(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        public IActionResult Delete(int id)
        {
            var book = _bookServices.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _bookServices.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
