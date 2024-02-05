using AppComplete.Services;
using AppModel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AppComplete.Areas.User.Controllers
{
    [Area(RolesTypes.User)]
    [Authorize(Roles = RolesTypes.User + "," + RolesTypes.Admin)]
    public class AuthorController : Controller
    {
        private readonly AuthorServices _authorServices;
        public AuthorController(AuthorServices authorServices)
        {
            _authorServices = authorServices;
        }
        public IActionResult Index()
        {
            var authors = _authorServices.GetAll();
            return View(authors);
        }
    }
}
