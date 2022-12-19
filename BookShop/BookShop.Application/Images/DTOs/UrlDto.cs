namespace BookShop.Application.Images.DTOs
{
    public class UrlDto
    {
        public UrlDto(ICollection<string> urls)
        {
            Urls = urls;
        }

        public ICollection<string> Urls { get; set; }
    }
}
