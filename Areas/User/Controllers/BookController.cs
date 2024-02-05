using AppComplete.Services;
using AppModel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppComplete.Areas.User.Controllers
{
    [Area(RolesTypes.User)]
    [Authorize(Roles = RolesTypes.User + "," + RolesTypes.Admin)]
    public class BookController : Controller
    {
        private readonly BookServices _bookServices;
        public BookController(BookServices bookServices)
        {
            _bookServices = bookServices;
        }
        public IActionResult Index()
        {
            var books = _bookServices.GetAll();
            return View(books);
        }
    }
}
