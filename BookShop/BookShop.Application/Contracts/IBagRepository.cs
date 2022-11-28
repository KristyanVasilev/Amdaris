namespace BookShop.Application.Contracts
{
    using BookShop.Domain;

    public interface IBagRepository
    {
        void CreateBag(Bag bag);

        string DeleteBag(int id);

        Bag GetSingleBag(int id);

        IEnumerable<Bag> GetBags();
    }
}
