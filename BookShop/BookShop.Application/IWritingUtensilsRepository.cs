
namespace BookShop.Application
{
    using BookShop.Domain.ForSchool.WritingAndDrawing;

    public interface IWritingUtensilsRepository
    {

        void CreateUtensil(WritingUtensil utensil);
    }
}
