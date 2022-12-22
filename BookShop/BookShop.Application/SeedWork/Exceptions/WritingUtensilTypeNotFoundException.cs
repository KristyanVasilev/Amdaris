namespace BookShop.Application.SeedWork.Exceptions
{
    public class WritingUtensilTypeNotFoundException : Exception
    {
        public WritingUtensilTypeNotFoundException(string message)
         : base(message)
        {
        }

        public WritingUtensilTypeNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
