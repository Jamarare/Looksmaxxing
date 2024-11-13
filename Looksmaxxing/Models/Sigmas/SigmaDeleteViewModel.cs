namespace Looksmaxxing.Models.Sigmas
{
    public class SigmaDeleteViewModel
    {
        public Guid? Id { get; set; }

        public string SigmaName { get; set; }

        public int SigmaXP { get; set; }

        public int SigmaXPNextLevel { get; set; }

        public int SigmaLevel { get; set; }

        public SigmaType SigmaType { get; set; }

        public SigmaStatus SigmaStatus { get; set; }

        public int SigmaMovePower { get; set; }

        public string SigmaMove { get; set; }

        public int SpecialSigmaMovePower { get; set; }

        public string SpecialSigmaMove { get; set; }

        //public List<IFormFile> Files { get; set; }

        public List<SigmaImageViewModel> Image { get; set; } = new List<SigmaImageViewModel>();

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
