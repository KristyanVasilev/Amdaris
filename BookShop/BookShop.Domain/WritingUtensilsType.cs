namespace BookShop.Domain
{
    using BookShop.Domain.Models;

    public class WritingUtensilsType : BaseModel<int>
    {
        public WritingUtensilsType()
        {
            this.WritingUtensil = new HashSet<WritingUtensil>();
        }

        public string Name { get; set; } = null!;

        public ICollection<WritingUtensil> WritingUtensil { get; set; } = null!;
    }
}
