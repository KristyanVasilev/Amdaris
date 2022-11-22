namespace BookShop.Application
{
    using BookShop.Domain.Hobbies;
    using BookShop.Domain.Publications;

    public interface IProductRepository
    {

        void CreatePublication(Publication publication);

        void CreateGame(Game game);

        IEnumerable<Publication> GetPublications();

        Publication GetSinglePublication(int id);
    }
}
