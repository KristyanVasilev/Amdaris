namespace BookShop.Infrastructure
{
    using BookShop.Application;
    using BookShop.Domain;
    using BookShop.Domain.ForSchool.Bags;
    using BookShop.Domain.ForSchool.Notebooks;
    using BookShop.Domain.ForSchool.WritingAndDrawing;
    using BookShop.Domain.Hobbies;
    using BookShop.Domain.Publications;
    using System.Linq.Expressions;

    public class InMemoryProductRepository : IProductRepository
    {
        private readonly List<Publication> publications;
        private readonly List<Game> games;
        private readonly List<Bag> bags;
        private readonly List<Notebook> notebooks;
        private readonly List<WritingUtensil> writingUtensil;

        public InMemoryProductRepository()
        {
            this.publications= new List<Publication>();
            this.games = new List<Game>();
            this.bags = new List<Bag>();
            this.notebooks = new List<Notebook>();
            this.writingUtensil = new List<WritingUtensil>();
        }

        public void CreateProduct(Product product)
        {
            if (product is Bag)
            {
                this.bags.Add(product as Bag);
            }
            else if (product is Game)
            {
                this.games.Add(product as Game);
            }
            else if (product is Publication)
            {
                this.publications.Add(product as Publication);
            }
            else if (product is Notebook)
            {
                this.notebooks.Add(product as Notebook);
            }
            else
            {
                this.writingUtensil.Add(product as WritingUtensil);
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
