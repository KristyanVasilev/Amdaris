namespace BookShop.Application.Publications.Commands.UpdatePublication
{
    using MediatR;

    public class UpdatePublicationCommand : BaseProductDto, IRequest<int>
    {
        public string Author { get; set; } = null!;

        public int PageCount { get; set; }

        public double Rating { get; set; }

        public string Description { get; set; } = null!;

        public string PublicationType { get; set; } = null!;

        public string Genre { get; set; } = null!;
    }
}
