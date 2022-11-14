namespace BookShop.Infrastructure.Contracts
{
    using BookShop.Data;

    public interface ICustomer
    {
        string AddToOrder(Product product);

        string Buy();
    }
}
