namespace BookShop.Application.Images.UploadImages
{
    using BookShop.Application.Images.DTOs;
    using FluentValidation;

    public class UploadImagesValidator : AbstractValidator<UploadImagesCommand>
    {
        public UploadImagesValidator()
        {
            RuleFor(v => v.Files)
                .Must(FilesNotEmpty)
                .WithMessage("File cannot be empty");

            RuleFor(v => v.Files)
                .Must(IsValidContentType)
                .WithMessage("Invalid file type. Only '.jpg' and '.png' files are allowed");
        }

        private bool FilesNotEmpty(ICollection<FileDto> files)
        {
            if (files == null || files.Count == 0)
            {
                return false;
            }

            foreach (var file in files)
            {
                if (file.Content.Length == 0)
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsValidContentType(ICollection<FileDto> files)
        {
            var validContentTypes = new string[] { "image/jpeg", "image/png" };

            foreach (var file in files)
            {
                if (!validContentTypes.Contains(file.ContentType))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
