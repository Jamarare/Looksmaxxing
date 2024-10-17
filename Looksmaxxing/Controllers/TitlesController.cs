using Microsoft.AspNetCore.Mvc;

namespace Looksmaxxing.Controllers
{
    public class TitlesController : Controller
    {
        /*
         * Sigmacontroller controls all functions for sigmas, including, missions.
         */
        public IActionResult Index()
        {
            return View();
        }
    }
}
