using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Looksmaxxing.Core.Domain;
using Looksmaxxing.Core.Dto;

namespace Looksmaxxing.Core.ServiceInterface
{
    public interface ICitiesServices
    {
        Task<City> Create(CityDto dto);
        Task<City> DetailsAsync(Guid id);
    }
}
