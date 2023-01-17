namespace BookShop.Application.Email
{
    public class EmailAttachment
    {
        public byte[] Content { get; set; } = null!;

        public string FileName { get; set; } = null!;

        public string MimeType { get; set; } = null!;
    }
}
