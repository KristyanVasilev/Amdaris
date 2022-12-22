namespace BookShop.Application.SeedWork.Exceptions
{
    public class GenreNotFoundException : Exception
    {
        public GenreNotFoundException(string message)
           : base(message)
        {
        }

        public GenreNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
