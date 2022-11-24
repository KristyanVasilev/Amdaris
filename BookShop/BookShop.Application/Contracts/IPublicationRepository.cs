namespace BookShop.Application.Contracts
{
    using BookShop.Domain.Publications;

    public interface IPublicationRepository
    {
        void CreatePublication(Publication publication);

        IEnumerable<Publication> GetPublications();

        Publication GetSinglePublication(int id);
    }
}
