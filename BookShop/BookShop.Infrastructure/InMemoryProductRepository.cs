namespace BookShop.Infrastructure
{
    using BookShop.Application;
    using BookShop.Data;

    public class InMemoryProductRepository : IProductRepository
    {
        private readonly List<Product> products;

        public InMemoryProductRepository()
        {
            this.products = new List<Product>();
        }

        public void CreateProduct(Product product)
        {
            this.products.Add(product);
        }

        public Product GetProduct(int id)
        {
            return this.products.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return this.products;
        }
    }
}
