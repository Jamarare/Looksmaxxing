using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Looksmaxxing.Core.Dto
{
    public class SigmaDto
    {

    }

    public enum SigmaType
    {
        Alpha, Beta, Looksmaxxer, Ultra, Unknown
    }

    public enum SigmaStatus
    {
        Dead, Alive, Looksmaxxing
    }

    public class SigmaIndexViewModel
    {
        public Guid Id { get; set; }

        public string SigmaName { get; set; }
        public int SigmaXP { get; set; }
        public int SigmaXPNextLevel { get; set; }
        public int SigmaLevel { get; set; }
        public SigmaType SigmaType { get; set; }
        public int SigmaMovePower { get; set; }
        public int SigmaMove { get; set; }
        public int SpecialSigmaMovePower { get; set; }
        public int SpecialSigmaMove { get; set; }
        public DateTime SigmaWasBorn { get; set; }
        public DateTime SigmaDied { get; set; }

        //public List<IFormFile> Files { get; set; }
        //public IEnumerable<FileToDatabaseDto> Image { get; set; } = new List<FileToDatabaseDto>();

        //db only
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}