namespace BookShop.Application.Images.UploadImages
{
    using BookShop.Application.Images.DTOs;
    using MediatR;

    public class UploadImagesCommand : IRequest<UrlDto>
    {
        public ICollection<FileDto> Files { get; set; } = new List<FileDto>();
    }
}
