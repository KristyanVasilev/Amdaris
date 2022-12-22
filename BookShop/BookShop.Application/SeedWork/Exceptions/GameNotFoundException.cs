namespace BookShop.Application.SeedWork.Exceptions
{
    public class GameNotFoundException : Exception
    {
        public GameNotFoundException(string message)
            : base(message)
        {
        }

        public GameNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
