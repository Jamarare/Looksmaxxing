using Microsoft.AspNetCore.Mvc;

namespace Looksmaxxing.Controllers
{
    public class CitiesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
