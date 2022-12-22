namespace BookShop.Application.SeedWork.Exceptions
{
    public class PublicationNotFoundException : Exception
    {
        public PublicationNotFoundException(string message)
           : base(message)
        {
        }

        public PublicationNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
