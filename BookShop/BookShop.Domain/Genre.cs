namespace BookShop.Domain
{
    using BookShop.Domain.Models;

    public class Genre : BaseModel<int>
    {
        public Genre()
        {
            this.Publications = new HashSet<Publication>();
            this.Games = new HashSet<Game>();
        }

        public string Name { get; set; } = null!;

        public ICollection<Publication> Publications { get; set; } = null!;

        public ICollection<Game> Games { get; set; } = null!;
    }
}
