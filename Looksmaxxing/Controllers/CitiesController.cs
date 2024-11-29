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
                    Difficulty = (Models.Cities.Difficulty)x.Difficulty, // Cast the difficulty enum
                    SigmaLevelRequirement = x.SigmaLevelRequirement,
                })
                .ToList(); // Convert to list to pass to the view

            return View(resultingInventory); // Make sure you pass a collection of IndexViewModel
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
    }
}
