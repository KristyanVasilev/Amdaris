namespace BookShop.Application.Publications.Commands.CreatePublication
{
    using BookShop.Application;
    using BookShop.Domain;
    using MediatR;

    public class CreatePublicationCommand : BaseProductDto, IRequest<int>
    {
        public string Author { get; set; } = null!;

        public int PageCount { get; set; }

        public double Rating { get; set; }

        public string Description { get; set; } = null!;

        public string PublicationType { get; set; } = null!;

        public string Genre { get; set; } = null!;
    }
}
