namespace Looksmaxxing.Models.Sigmas
{
    public class SigmaImageViewModel
    {
        public Guid ImageID { get; set; }

        public string ImageTitle { get; set; }

        public byte[] ImageData { get; set; }

        public string Image {  get; set; }

        public Guid? SigmaID { get; set; }
    }
}
