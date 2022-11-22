namespace BookShop.Application.Publications.Queries.GetSinglePublication
{
    using MediatR;

    public class GetSinglePublicationQuery : IRequest<PublicationViewModel>
    {
        public int Id { get; set; }
        public GetSinglePublicationQuery(int id)
        {
            this.Id = id;
        }
    }
}
