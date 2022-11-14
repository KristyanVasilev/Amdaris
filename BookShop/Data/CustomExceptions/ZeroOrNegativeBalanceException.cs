namespace BookShop.Data.CustomExceptions
{
    public class ZeroOrNegativeBalanceException : Exception
    {
        public ZeroOrNegativeBalanceException(string? message)
            : base(message)
        {
        }
    }
}
