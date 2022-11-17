namespace BookShop.Infrastructure.Contracts
{
    using BookShop.Data;

    public interface IPublicationService
    {
        string AddBook(int id, decimal price, string name, string author,
            int pageCount, double rating, string description, string genre);

        Product GetBook(int id);
    }
}
