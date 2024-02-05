using AppComplete.Services;
using AppModel.Models;
using DataBaseComplete;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AppComplete.Controllers
{
    public class HomeController : Controller
    {

        private readonly BookServices _bookServices;
        public HomeController(BookServices bookServices)
        {
            _bookServices = bookServices;
        }

        public IActionResult Index()
        {
            var books = _bookServices.GetAll();
            return View(books);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
