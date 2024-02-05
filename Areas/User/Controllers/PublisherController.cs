using AppComplete.Services;
using AppModel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppComplete.Areas.User.Controllers
{
    [Area(RolesTypes.User)]
    [Authorize(Roles = RolesTypes.User + "," + RolesTypes.Admin)]
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
    }
}
