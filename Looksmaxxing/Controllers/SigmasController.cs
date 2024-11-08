using Looksmaxxing.Data;
using Looksmaxxing.Core.ServiceInterface;
using Looksmaxxing.Models.Sigmas;
using Microsoft.AspNetCore.Mvc;
using Looksmaxxing.ApplicationServices.Services;
using Looksmaxxing.Core.Dto;
using Microsoft.EntityFrameworkCore;

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
                    SigmaType = (Models.Sigmas.SigmaType)(Core.Dto.SigmaType)x.SigmaType,
                    SigmaLevel = x.SigmaLevel,
                });
            return View(resultingInventory);
        }
        [HttpGet]
        public IActionResult Create()
        {
            SigmaCreateViewModel vm = new();
            return View("Create",vm);
        }
        [HttpPost , ActionName("Create")] 
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SigmaCreateViewModel vm)
        {
            var dto = new SigmaDto()
            {
                SigmaName = vm.SigmaName,
                SigmaXP = 0,
                SigmaXPNextLevel = 100,
                SigmaLevel = 0,
                SigmaType = (Core.Dto.SigmaType)vm.SigmaType,
                SigmaStatus = (Core.Dto.SigmaStatus)vm.SigmaStatus,
                SigmaMove = vm.SigmaMove,
                SigmaMovePower = vm.SigmaMovePower,
                SpecialSigmaMove = vm.SpecialSigmaMove,
                SpecialSigmaMovePower = vm.SpecialSigmaMovePower,
                SigmaWasBorn = vm.SigmaWasBorn,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Files = vm.Files,
                Image = vm.Image
                .Select(x => new FileToDatabaseDto
                 {
                    ID = x.ImageID,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    SigmaID = x.ImageID,
                 }).ToArray()
            };
            var result = await _sigmasServices.Create(dto);

            if (result != null)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", vm);
        }

        public async Task<IActionResult> Details(Guid id /*, Guid ref*/)
        {
            var sigma = await _sigmasServices.DetailsAsync(id);

            if (sigma == null)
            {
                return NotFound(); // <- TODO; custom partial view with message, sigma is not located
            }

            var images = await _context.FilesToDatabase
                .Where(s => s.SigmaID == id)
                .Select( y => new SigmaImageViewModel
                {
                    SigmaID = y.ID,
                    ImageID = y.ID,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();

            var vm = new SigmaDetailsViewModel();
            vm.Id = sigma.Id;
            vm.SigmaName = sigma.SigmaName;
            vm.SigmaXP = sigma.SigmaXP;
            vm.SigmaLevel = sigma.SigmaLevel;
            vm.SigmaType = (Models.Sigmas.SigmaType)sigma.SigmaType;
            vm.SigmaStatus = (Models.Sigmas.SigmaStatus)sigma.SigmaStatus;
            vm.SigmaMove = sigma.SigmaMove;
            vm.SigmaMovePower = sigma.SigmaMovePower;
            vm.SpecialSigmaMove = sigma.SpecialSigmaMove;
            vm.SpecialSigmaMovePower = sigma.SpecialSigmaMovePower;
            vm.Image.AddRange(images);

            return View(vm); 
        }
    }
}
