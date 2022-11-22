namespace BookShop.Infrastructure
{
    using BookShop.Application;
    using BookShop.Domain.Hobbies;
    using BookShop.Domain.Publications;

    public class InMemoryProductRepository : IProductRepository
    {
        private readonly List<Publication> publications;
        private readonly List<Game> games;

        public InMemoryProductRepository()
        {
            this.publications= new List<Publication>();
            this.games = new List<Game>();
        }

        public void CreateGame(Game game)
        {
            this.games.Add(game);
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
