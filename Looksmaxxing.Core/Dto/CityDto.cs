using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Looksmaxxing.Core.Dto
{

    public enum Difficulty
    {
        Eazy, Normal, Hard, Insane
    }

    public class CityDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public Difficulty Difficulty { get; set; }
        public int SigmaLevelRequirement { get; set; }
        public List<IFormFile> Files { get; set; }
        public IEnumerable<FileToDatabaseDto> Image {  get; set; } = new List<FileToDatabaseDto>();
    }      
}
