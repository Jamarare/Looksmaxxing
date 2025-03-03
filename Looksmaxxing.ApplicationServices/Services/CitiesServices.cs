using System.Runtime.CompilerServices;
using Looksmaxxing.Core.Domain;
using Looksmaxxing.Core.Dto;
using Looksmaxxing.Core.ServiceInterface;
using Looksmaxxing.Data;
using Microsoft.EntityFrameworkCore;

namespace Looksmaxxing.ApplicationServices.Services
{
    public class CitiesServices : ICitiesServices
    {
        private readonly LooksmaxxingContext _context;
        private readonly ICitiesServices _citiesServices;
        private readonly IFileServices _fileServices;


        public CitiesServices(LooksmaxxingContext context, IFileServices fileServices)
        {
            _context = context;
            _fileServices = fileServices;
        }
        public async Task<City> DetailsAsync(Guid id)
        {
            var result = await _context.Cities
                .FirstOrDefaultAsync(x => x.ID == id);
            return result;
        }

        public async Task<City> Create(CityDto dto)
        {
            City city = new();
            city.ID = Guid.NewGuid();
            city.Name = dto.Name;
            city.Difficulty = (Core.Domain.Difficulty)dto.Difficulty;
            city.SigmaLevelRequirement = dto.SigmaLevelRequirement;
            await _context.Cities.AddAsync(city);
            await _context.SaveChangesAsync();
            return city;
        }

        public async Task<City> Delete (Guid id)
        {
            var result = await _context.Cities.FirstOrDefaultAsync(x => x.ID == id);
            _context.Cities.Remove(result);
            await _context.SaveChangesAsync();
            return result;
        }
    }
}
