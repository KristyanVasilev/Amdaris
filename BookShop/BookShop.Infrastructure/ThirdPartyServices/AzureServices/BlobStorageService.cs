﻿namespace BookShop.Infrastructure.ThirdPartyServices.AzureServices
{
    using Azure.Storage.Blobs;
    using Azure.Storage.Blobs.Models;
    using BookShop.Application.Images.DTOs;
    using BookShop.Application.Interfaces;

    public class BlobStorageService : IFileStorageService
    {
        private readonly BlobServiceClient _blobServiceClient;

        public BlobStorageService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task<UrlDto> UploadAsync(ICollection<FileDto> files)
        {
            if (files == null || files.Count == 0)
            {
                return null;
            }

            var containerClient = _blobServiceClient.GetBlobContainerClient("publicupload");


            var urls = new List<string>();


            foreach (var file in files)
            {
                var blobClient = containerClient.GetBlobClient(file.GetPathWithFileName());

                await blobClient.UploadAsync(file.Content, new BlobHttpHeaders { ContentType = file.ContentType });

                urls.Add(blobClient.Uri.ToString());
            }

            return new UrlDto(urls);
        }
    }
}
