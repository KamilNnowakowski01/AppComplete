using AppModel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppComplete.Areas.User.Controllers
{
    [Area(RolesTypes.User)]
    [Authorize(Roles = RolesTypes.User + "," + RolesTypes.Admin)]

    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
