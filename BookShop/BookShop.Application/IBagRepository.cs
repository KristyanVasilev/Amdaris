namespace BookShop.Application
{
    using BookShop.Domain.ForSchool.Bags;

    public interface IBagRepository
    {
        void CreateBag(Bag bag);

    }
}
