namespace Looksmaxxing.Models.Cities
{
    public class CreateViewModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public Difficulty Difficulty { get; set; }
        public int SigmaLevelRequirement { get; set; }
    }
}
