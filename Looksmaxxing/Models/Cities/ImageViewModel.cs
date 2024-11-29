namespace Looksmaxxing.Models.Cities
{
    public class ImageViewModel
    {
        public Guid ImageID { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public string Image {  get; set; }
        public Guid? CityID { get; set; }
    }
}
