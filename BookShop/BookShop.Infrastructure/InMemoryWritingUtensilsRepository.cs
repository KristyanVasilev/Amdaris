namespace BookShop.Infrastructure
{
    using BookShop.Application.Contracts;
    using BookShop.Domain.ForSchool.WritingAndDrawing;

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
    }
}
