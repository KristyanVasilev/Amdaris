namespace BookShop.Domain.Publications
{
    public class Genre
    {
        public Genre(string name)
        {
            Name = name;
        }

        public string Name { get; set; } = null!;
    }
}
