namespace BookShop.Infrastructure.CustomExceptions
{
    public class ZeroOrNegativeBalanceException : Exception
    {
        public ZeroOrNegativeBalanceException(string? message)
            : base(message)
        {
        }
    }
}
