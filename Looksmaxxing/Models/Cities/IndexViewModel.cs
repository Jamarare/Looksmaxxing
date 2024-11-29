namespace Looksmaxxing.Models.Cities
{
    public enum Difficulty
    {
        Eazy, Normal, Hard, Insane
    }

    public class IndexViewModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public Difficulty Difficulty { get; set; }
        public int SigmaLevelRequirement { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<ImageViewModel> Image { get; set; } = new List<ImageViewModel>();
    }
}
