namespace BookShop.Infrastructure.CustomExceptions
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(string? message)
        : base(message)
        {
        }
    }
}
