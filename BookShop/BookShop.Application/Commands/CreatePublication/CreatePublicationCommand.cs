namespace BookShop.Application.Commands.CreateProduct
{
    using BookShop.Data.Publications;
    using MediatR;

    public class CreatePublicationCommand : BaseProductModel, IRequest<int>
    {
        public string Author { get; set; } = null!;

        public int PageCount { get; set; }

        public decimal Rating { get; set; } = 0;

        public string Description { get; set; } = null!;

        public PublicationType PublicationType { get; private set; }

        public Genre Genre { get; private set; } = null!;
    }
}
