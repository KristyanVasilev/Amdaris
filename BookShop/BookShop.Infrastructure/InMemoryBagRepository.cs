namespace BookShop.Infrastructure
{
    using BookShop.Application.Contracts;
    using BookShop.Domain.ForSchool.Bags;
    using System.Collections.Generic;

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

        public string DeleteBag(int id)
        {
            var bagToRemove = GetSingleBag(id);
            this.bags.Remove(bagToRemove);

            return $"Bag with Id - {id} deleted succesufuly!";
        }

        public IEnumerable<Bag> GetBags()
        {
            return this.bags;
        }

        public Bag GetSingleBag(int id)
        {
            return this.bags.FirstOrDefault(x => x.Id == id);
        }
    }
}
