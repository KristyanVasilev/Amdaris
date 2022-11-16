namespace BookShop.Application.Publications.Commands.CreatePublication
{
    using BookShop.Data.Publications;
    using MediatR;

    public class CreatePublicationCommand : BaseProductModel, IRequest<int>
    {
        public string Author { get; set; } = null!;

        public int PageCount { get; set; }

        public string Description { get; set; } = null!;

        public PublicationType PublicationType { get; private set; }

        public GenreDto Genre { get; set; } = null!;
    }
}
