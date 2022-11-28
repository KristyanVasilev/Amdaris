namespace BookShop.Application.Contracts
{
    using BookShop.Domain;

    public interface IPublicationRepository
    {
        void CreatePublication(Publication publication);

        IEnumerable<Publication> GetPublications();

        Publication GetSinglePublication(int id);

        string DeletePublication(int id);
    }
}
