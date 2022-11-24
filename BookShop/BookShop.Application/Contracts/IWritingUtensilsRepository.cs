namespace BookShop.Application.Contracts
{
    using BookShop.Domain.ForSchool.WritingAndDrawing;

    public interface IWritingUtensilsRepository
    {

        void CreateUtensil(WritingUtensil utensil);

        string DeleteUtensil(int id);

        WritingUtensil GetSingleUtensil(int id);

        IEnumerable<WritingUtensil> GetUtensils();
    }
}
