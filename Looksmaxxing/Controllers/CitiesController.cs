using Looksmaxxing.ApplicationServices.Services;
using Looksmaxxing.Core.Dto;
using Looksmaxxing.Core.ServiceInterface;
using Looksmaxxing.Data;
using Looksmaxxing.Models.Cities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Looksmaxxing.Controllers
{
    public class CitiesController : Controller
    {

        private readonly LooksmaxxingContext _context;
        private readonly ICitiesServices _citiesServices;
        private readonly IFileServices _fileServices;

        public CitiesController(LooksmaxxingContext context,ICitiesServices citiesServices, IFileServices fileServices)
        {
            _context = context;
            _citiesServices = citiesServices;
            _fileServices = fileServices;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var resultingInventory = _context.Cities
                .OrderByDescending(y => y.CreatedAt)
                .Select(x => new IndexViewModel
                {
                    ID = x.ID,
                    Name = x.Name,
                    Difficulty = (Models.Cities.Difficulty)x.Difficulty,
                    SigmaLevelRequirement = x.SigmaLevelRequirement,
                })
                .ToList();

            return View(resultingInventory);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateViewModel vm = new();
            return View("Create", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateViewModel vm)
        {
            var dto = new CityDto
            {
                Name = vm.Name,
                Difficulty = (Core.Dto.Difficulty)vm.Difficulty,
                SigmaLevelRequirement = vm.SigmaLevelRequirement,
                Files = vm.Files,
                Image = vm.Image.Select(x => new FileToDatabaseDto
                {
                    ID = x.ImageID,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    CityID = x.CityID,
                }).ToArray()
            };
            var result = await _citiesServices.Create(dto);
            if (result != null)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", vm);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var City = await _citiesServices.DetailsAsync(id);

            if (City == null)
            {
                return NotFound();
            }

            var images = await _context.FilesToDatabase
            .Where(c => c.SigmaID == id)
            .Select(y => new ImageViewModel
            {
                CityID = y.ID,
                ImageID = y.ID,
                ImageData = y.ImageData,
                ImageTitle = y.ImageTitle,
                Image = string.Format("data:image/gif;base64{0}", Convert.ToBase64String(y.ImageData))
            }).ToArrayAsync();
            var vm = new DetailsViewModel();
            vm.Name = vm.Name;
            vm.Difficulty = vm.Difficulty;
            vm.SigmaLevelRequirement = vm.SigmaLevelRequirement;
            vm.Files = vm.Files;
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var City = await _citiesServices.DetailsAsync(id);

            if (City == null)
            {
                return NotFound();
            }

            var images = await _context.FilesToDatabase
            .Where(c => c.SigmaID == id)
            .Select(y => new ImageViewModel
            {
                CityID = y.ID,
                ImageID = y.ID,
                ImageData = y.ImageData,
                ImageTitle = y.ImageTitle,
                Image = string.Format("data:image/gif;base64{0}", Convert.ToBase64String(y.ImageData))
            }).ToArrayAsync();
            var vm = new DetailsViewModel();
            vm.Name = vm.Name;
            vm.Difficulty = vm.Difficulty;
            vm.SigmaLevelRequirement = vm.SigmaLevelRequirement;
            vm.Files = vm.Files;
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var cityToDelete = await _citiesServices.Delete(id);

            if (cityToDelete == null) { return RedirectToAction("Index"); }

            return RedirectToAction("Index");
        }
    }
}
