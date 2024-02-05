using AppComplete.Services;
using Microsoft.AspNetCore.Mvc;
using AppModel.Models;
using Microsoft.AspNetCore.Authorization;

namespace AppComplete.Areas.Admin.Controllers
{
    [Area(RolesTypes.Admin)]
    [Authorize(Roles = RolesTypes.Admin)]
    public class AuthorController : Controller
    {

        private readonly AuthorServices _authorServices;

        public AuthorController(AuthorServices authorServices)
        {
            _authorServices = authorServices;
        }

        public IActionResult Index()
        {
            var author = _authorServices.GetAll();
            return View(author);
        }

        public IActionResult Details(int id)
        {
            var author = _authorServices.GetById(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                _authorServices.Create(author);
                return RedirectToAction(nameof(Index));
            }
            
            return View(author);
        }

        public IActionResult Edit(int id)
        {
            var author = _authorServices.GetById(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Author author)
        {
            if (id != author.AuthorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _authorServices.Update(author);
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        public IActionResult Delete(int id)
        {
            var author = _authorServices.GetById(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _authorServices.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
