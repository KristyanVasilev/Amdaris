namespace BookShop.Application.WritingUtensils.Queries.GetUtensilsByName
{
    using MediatR;

    public class GetUtensilsByNameQuery : IRequest<WritingUtensilDto>
    {
        public GetUtensilsByNameQuery(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
