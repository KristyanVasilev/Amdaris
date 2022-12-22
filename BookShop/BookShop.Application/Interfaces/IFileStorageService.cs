namespace BookShop.Application.Interfaces
{
    using BookShop.Application.Images.DTOs;

    public interface IFileStorageService
    {
        Task<UrlDto> UploadAsync(ICollection<FileDto> files);
    }
}
