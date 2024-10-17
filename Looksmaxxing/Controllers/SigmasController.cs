using Looksmaxxing.Data;
using Looksmaxxing.Core.ServiceInterface;
using Looksmaxxing.Models.Sigmas;
using Microsoft.AspNetCore.Mvc;
using Looksmaxxing.ApplicationServices.Services;

namespace Looksmaxxing.Controllers
{
    public class SigmasController : Controller
    {
        /*
         * Sigmacontroller controls all functions for sigmas, including, missions.
         */

        private readonly LooksmaxxingContext _context;
        private readonly ISigmasServices _sigmasServices;

        public SigmasController(LooksmaxxingContext context, ISigmasServices sigmasServices)
        {
            _context = context;
            _sigmasServices = sigmasServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var resultingInventory = _context.Sigmas
                .OrderByDescending(y => y.SigmaLevel)
                .Select(x => new SigmaIndexViewModel
                {
                    Id = x.Id,
                    SigmaName = x.SigmaName,
                    SigmaType = (SigmaType)x.SigmaType,
                    SigmaLevel = x.SigmaLevel,
                });
            return View(resultingInventory);
        }
    }
}
