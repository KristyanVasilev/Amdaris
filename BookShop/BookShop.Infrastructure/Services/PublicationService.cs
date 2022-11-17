namespace BookShop.Infrastructure.Services
{
    using BookShop.Application;
    using BookShop.Data;
    using BookShop.Data.Publications;
    using BookShop.Infrastructure.Contracts;

    public class PublicationService : IPublicationService
    {
        private readonly IProductRepository repository;

        public PublicationService()
        {
            this.repository = new InMemoryProductRepository();
        }

        public string AddBook(int id, decimal price, string name, 
            string author, int pageCount, double rating, string description, string genre)
        {
            var bookGenre = new Genre(genre);

            var product = new Publication
            {
                Id = id,
                Price = price,
                Name = name,
                Author = author,
                PageCount = pageCount,
                Rating = rating,
                Description = description,
                PublicationType = PublicationType.Book,
                Genre = bookGenre,
            };

            this.repository.CreateProduct(product);
            return $"Successfuly added Book with Id - {id}, title - {name} by {author}.";
        }

        public Product GetBook(int id)
            => this.repository.GetProduct(id);
    }
}
