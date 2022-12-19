namespace BookShop.Application.Images.UploadImages
{
    using BookShop.Application.Images.DTOs;
    using BookShop.Application.Images.Interfaces;
    using MediatR;

    public class UploadImagesHandler : IRequestHandler<UploadImagesCommand, UrlDto>
    {
        private readonly IFileStorageService fileStotageService;

        public UploadImagesHandler(IFileStorageService fileStotageService)
        {
            this.fileStotageService = fileStotageService;
        }

        public async Task<UrlDto> Handle(UploadImagesCommand request, CancellationToken cancellationToken)
        {
            var urls = await this.fileStotageService.UploadAsync(request.Files);

            return urls;
        }
    }
}
