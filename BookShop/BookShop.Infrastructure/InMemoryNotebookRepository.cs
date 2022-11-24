using BookShop.Application;
using BookShop.Domain.ForSchool.Notebooks;
using BookShop.Domain.Hobbies;

namespace BookShop.Infrastructure
{
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
