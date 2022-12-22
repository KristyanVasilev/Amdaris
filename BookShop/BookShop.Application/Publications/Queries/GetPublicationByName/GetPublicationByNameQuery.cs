namespace BookShop.Application.Publications.Queries.GetPublicationByName
{
    using MediatR;

    public class GetPublicationByNameQuery : IRequest<PublicationDto>
    {
        public GetPublicationByNameQuery(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
