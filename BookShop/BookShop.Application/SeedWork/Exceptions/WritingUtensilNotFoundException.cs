namespace BookShop.Application.SeedWork.Exceptions
{
    public class WritingUtensilNotFoundException : Exception
    {
        public WritingUtensilNotFoundException(string message)
         : base(message)
        {
        }

        public WritingUtensilNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
