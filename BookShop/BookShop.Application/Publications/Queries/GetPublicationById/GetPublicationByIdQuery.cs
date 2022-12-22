namespace BookShop.Application.Publications.Queries.GetPublicationById
{
    using MediatR;

    public class GetPublicationByIdQuery : IRequest<PublicationDto>
    {
        public int Id { get; set; }

        public GetPublicationByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
