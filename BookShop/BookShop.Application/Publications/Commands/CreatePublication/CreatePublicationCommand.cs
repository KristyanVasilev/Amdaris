namespace BookShop.Application.Publications.Commands.CreatePublication
{
    using BookShop.Application;
    using MediatR;

    public class CreatePublicationCommand : BaseProductDto, IRequest<int>
    {
        public string Author { get; set; } = null!;

        public int PageCount { get; set; }

        public double Rating { get; set; }

        public string Description { get; set; } = null!;

        public string PublicationType { get; set; } = null!;

        public GenreDto Genre { get; set; } = null!;
    }
}
