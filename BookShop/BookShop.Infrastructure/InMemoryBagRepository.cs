namespace BookShop.Infrastructure
{
    using BookShop.Application.Contracts;
    using BookShop.Domain.ForSchool.Bags;

    public class InMemoryBagRepository : IBagRepository
    {

        private readonly List<Bag> bags;

        public InMemoryBagRepository()
        {
            this.bags = new List<Bag>();
        }

        public void CreateBag(Bag bag)
        {
           this.bags.Add(bag);
        }
    }
}
