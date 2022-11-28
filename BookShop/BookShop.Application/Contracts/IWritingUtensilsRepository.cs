namespace BookShop.Application.Contracts
{
    using BookShop.Domain;

    public interface IWritingUtensilsRepository
    {

        void CreateUtensil(WritingUtensil utensil);

        string DeleteUtensil(int id);

        WritingUtensil GetSingleUtensil(int id);

        IEnumerable<WritingUtensil> GetUtensils();
    }
}
