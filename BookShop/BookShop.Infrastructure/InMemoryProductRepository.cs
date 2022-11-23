namespace BookShop.Infrastructure
{
    using BookShop.Application;
    using BookShop.Domain.ForSchool.Bags;
    using BookShop.Domain.ForSchool.Notebooks;
    using BookShop.Domain.Hobbies;
    using BookShop.Domain.Publications;

    public class InMemoryProductRepository : IProductRepository
    {
        private readonly List<Publication> publications;
        private readonly List<Game> games;
        private readonly List<Bag> bags;
        private readonly List<Notebook> notebooks;

        public InMemoryProductRepository()
        {
            this.publications= new List<Publication>();
            this.games = new List<Game>();
            this.bags = new List<Bag>();
            this.notebooks = new List<Notebook>();
        }

        public void CreateBag(Bag bag)
        {
            this.bags.Add(bag);
        }

        public void CreateGame(Game game)
        {
            this.games.Add(game);
        }

        public void CreateNotebook(Notebook notebook)
        {
            this.notebooks.Add(notebook);
        }

        public void CreatePublication(Publication publication)
        {
            this.publications.Add(publication);
        }

        public IEnumerable<Publication> GetPublications()
        {
            return this.publications;
        }

        public Publication GetSinglePublication(int id)
        {
            return this.publications.FirstOrDefault(x => x.Id == id);
        }
    }
}
