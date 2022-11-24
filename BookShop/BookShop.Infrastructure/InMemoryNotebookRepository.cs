namespace BookShop.Infrastructure
{
    using BookShop.Application.Contracts;
    using BookShop.Domain.ForSchool.Notebooks;

    public class InMemoryNotebookRepository : INotebookRepository
    {
        private readonly List<Notebook> notebooks;

        public InMemoryNotebookRepository()
        {
            this.notebooks = new List<Notebook>();
        }

        public void CreateNotebook(Notebook notebook)
        {
            this.notebooks.Add(notebook);
        }
    }
}
