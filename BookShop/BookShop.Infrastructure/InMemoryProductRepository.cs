namespace BookShop.Infrastructure
{
    using BookShop.Application;
    using BookShop.Domain;
    using BookShop.Domain.Publications;

    public class InMemoryProductRepository : IProductRepository
    {
        private readonly List<Product> products;
        private readonly List<Publication> publications;

        public InMemoryProductRepository()
        {
            this.products = new List<Product>();
            this.publications= new List<Publication>();
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

        public void CreatePublication(Publication publication)
        {
            this.publications.Add(publication);
        }

        public IEnumerable<Publication> GetPublications()
        {
            return this.publications;
        }
    }
}
