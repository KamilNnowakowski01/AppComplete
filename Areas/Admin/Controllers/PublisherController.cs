using AppComplete.Services;
using Microsoft.AspNetCore.Mvc;
using AppModel.Models;
using Microsoft.AspNetCore.Authorization;

namespace AppComplete.Areas.Admin.Controllers
{
    [Area(RolesTypes.Admin)]
    [Authorize(Roles = RolesTypes.Admin)]
    public class PublisherController : Controller
    {

        private readonly PublisherServices _publisherServices;

        public PublisherController(PublisherServices publisherServices)
        {
            _publisherServices = publisherServices;
        }

        public IActionResult Index()
        {
            var publishers = _publisherServices.GetAll();
            return View(publishers);
        }

        public IActionResult Details(int id)
        {
            var publisher = _publisherServices.GetById(id);
            if (publisher == null)
            {
                return NotFound();
            }
            return View(publisher);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                _publisherServices.Create(publisher);
                return RedirectToAction(nameof(Index));
            }
            
            return View(publisher);
        }

        public IActionResult Edit(int id)
        {
            var publisher = _publisherServices.GetById(id);
            if (publisher == null)
            {
                return NotFound();
            }
            return View(publisher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Publisher publisher)
        {
            if (id != publisher.PublisherId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _publisherServices.Update(publisher);
                return RedirectToAction(nameof(Index));
            }
            return View(publisher);
        }

        public IActionResult Delete(int id)
        {
            var publisher = _publisherServices.GetById(id);
            if (publisher == null)
            {
                return NotFound();
            }
            return View(publisher);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _publisherServices.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
