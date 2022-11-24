namespace BookShop.Application.Publications.Queries.GetSinglePublication
{
    using BookShop.Application.Publications;
    using MediatR;

    public class GetSinglePublicationQuery : IRequest<PublicationDto>
    {
        public int Id { get; set; }

        public GetSinglePublicationQuery(int id)
        {
            this.Id = id;
        }
    }
}
