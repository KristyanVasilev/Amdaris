namespace BookShop.Application
{
    using BookShop.Domain.ForSchool.Bags;
    using BookShop.Domain.ForSchool.Notebooks;
    using BookShop.Domain.Hobbies;
    using BookShop.Domain.Publications;

    public interface IProductRepository
    {

        void CreatePublication(Publication publication);

        void CreateGame(Game game);

        void CreateBag(Bag bag);

        void CreateNotebook(Notebook notebook);

        IEnumerable<Publication> GetPublications();

        Publication GetSinglePublication(int id);
    }
}
