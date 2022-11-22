namespace BookShop.Application
{
    using BookShop.Domain;
    using BookShop.Domain.Publications;

    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();

        Product GetProduct(int id);

        void CreateProduct(Product product);

        void CreatePublication(Publication publication);

        IEnumerable<Publication> GetPublications();
    }
}
