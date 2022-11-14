namespace BookShop.Infrastructure.CustomExceptions
{
    public class InvalidOrderException : Exception
    {
        public InvalidOrderException(string? message)
         : base(message)
        {
        }
    }
}
