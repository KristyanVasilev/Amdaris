namespace BookShop.Application
{
    using BookShop.Domain;
    using BookShop.Domain.Publications;

    public interface IProductRepository
    {

        void CreateProduct(Product product);

        IEnumerable<Publication> GetPublications();

        Publication GetSinglePublication(int id);
    }
}
