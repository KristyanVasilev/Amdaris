namespace BookShop.Application
{
    using BookShop.Domain;

    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();

        Product GetProduct(int id);

        void CreateProduct(Product product);
    }
}
