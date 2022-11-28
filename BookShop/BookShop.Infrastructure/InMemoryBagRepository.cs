namespace BookShop.Infrastructure
{
    using BookShop.Application.Contracts;
    using BookShop.Domain;
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
            var result = this.bags.FirstOrDefault(x => x.Id == id);
            if (result == null)
            {
                throw new InvalidOperationException("Bag not found!");
            }

            return result;
        }
    }
}
