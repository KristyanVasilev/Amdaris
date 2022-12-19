﻿namespace BookShop.Application.Images.DTOs
{
    using BookShop.Application.SeedWork.Extensions;

    public class FileDto
    {
        public Stream Content { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string ContentType { get; set; } = null!;

        public string GetPathWithFileName()
        {
            string uniqueAutoGeneratedFileName = Path.GetRandomFileName();
            string shortClientSideFileNameWithoutExt = Path.GetFileNameWithoutExtension(Name).TruncateLongString(10);  //Trimming to max 10 as client side file name can be too long
            string ext = Path.GetExtension(Name);
            string basePath = "user1/images/";

            return basePath + uniqueAutoGeneratedFileName + "_" + shortClientSideFileNameWithoutExt + ext;
        }
    }
}
