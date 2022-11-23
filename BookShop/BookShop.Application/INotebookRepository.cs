namespace BookShop.Application
{
    using BookShop.Domain.ForSchool.Notebooks;

    public interface INotebookRepository
    {

        void CreateNotebook(Notebook notebook);
    }
}
