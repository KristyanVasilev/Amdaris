namespace BookShop.Infrastructure
{
    using BookShop.Application.Contracts;
    using BookShop.Domain;

    public class InMemoryWritingUtensilsRepository : IWritingUtensilsRepository
    {

        private readonly List<WritingUtensil> writingUtensil;

        public InMemoryWritingUtensilsRepository()
        {
            this.writingUtensil = new List<WritingUtensil>();
        }

        public void CreateUtensil(WritingUtensil utensil)
        {
            this.writingUtensil.Add(utensil);
        }

        public string DeleteUtensil(int id)
        {
            var utensilToRemove = GetSingleUtensil(id);
            this.writingUtensil.Remove(utensilToRemove);

            return $"Utensil with Id - {id} deleted succesufuly!";
        }

        public IEnumerable<WritingUtensil> GetUtensils()
        {
            return this.writingUtensil;
        }

        public WritingUtensil GetSingleUtensil(int id)
        {
            var result = this.writingUtensil.FirstOrDefault(x => x.Id == id);
            if (result == null)
            {
                throw new InvalidOperationException("Utensil not found!");
            }

            return result;
        }
    }
}
