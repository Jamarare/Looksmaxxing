namespace Looksmaxxing.Models.Cities
{
    public class DetailsViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Difficulty Difficulty { get; set; }
        public int SigmaLevelRequirement { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<ImageViewModel> Image {  get; set; } = new List<ImageViewModel>();
    }
}
