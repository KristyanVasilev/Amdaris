namespace BookShop.Application.SeedWork.Exceptions
{
    public class ProductDontHaveEnoughQuantity : Exception
    {
        public ProductDontHaveEnoughQuantity(string message)
           : base(message)
        {
        }

        public ProductDontHaveEnoughQuantity(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
