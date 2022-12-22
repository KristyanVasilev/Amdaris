namespace BookShop.Application.WritingUtensils.Queries.GetUtensilsByType
{
    using MediatR;

    public class GetUtensilsByTypeQuery : IRequest<IEnumerable<WritingUtensilDto>>
    {
        public GetUtensilsByTypeQuery(string utensilType)
        {
            this.UtensilType = utensilType;
        }

        public string UtensilType { get; set; }
    }
}
