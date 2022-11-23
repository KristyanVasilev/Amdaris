namespace BookShop.Infrastructure
{
    using BookShop.Application;
    using BookShop.Domain;
    using BookShop.Domain.ForSchool.Bags;
    using BookShop.Domain.ForSchool.Notebooks;
    using BookShop.Domain.ForSchool.WritingAndDrawing;
    using BookShop.Domain.Hobbies;
    using BookShop.Domain.Publications;

    public class InMemoryProductRepository : IProductRepository
    {
        private readonly List<Publication> publications;
        private readonly List<Game> games;
        private readonly List<Bag> bags;
        private readonly List<Notebook> notebooks;
        private readonly List<WritingUtensil> writingUtensil;

        public InMemoryProductRepository()
        {
            this.publications = new List<Publication>();
            this.games = new List<Game>();
            this.bags = new List<Bag>();
            this.notebooks = new List<Notebook>();
            this.writingUtensil = new List<WritingUtensil>();
        }

        public void CreateProduct(Product product)
        {
            if (product is Bag)
            {
                this.bags.Add((Bag)product);
            }
            else if (product is Game)
            {
                this.games.Add((Game)product);
            }
            else if (product is Publication)
            {
                this.publications.Add((Publication)product);
            }
            else if (product is Notebook)
            {
                this.notebooks.Add((Notebook)product);
            }
            else if (product is WritingUtensil)
            {
                this.writingUtensil.Add((WritingUtensil)product);
            }
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
