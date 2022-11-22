namespace BookShop.Application.Publications.Commands.CreatePublication
{
    using BookShop.Domain.Publications;

    public class GenreDto : Genre
    {
        public GenreDto(string name)
            : base(name)
        {
        }
    }
}
