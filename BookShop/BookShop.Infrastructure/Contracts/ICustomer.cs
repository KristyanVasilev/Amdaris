namespace BookShop.Infrastructure.Contracts
{
    using BookShop.Data;

    public interface ICustomer
    {
        string AddToOrder(Product product);

        string Buy();

        string Deposit(decimal amount);

        string Withdraw(decimal amount);

        string AddToWatchlist(Product product);

        string RemoveProductFromWatchlist(Product product);

        string UserInfo();
    }
}
