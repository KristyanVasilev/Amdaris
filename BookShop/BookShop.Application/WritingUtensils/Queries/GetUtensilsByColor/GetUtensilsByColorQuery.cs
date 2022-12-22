namespace BookShop.Application.WritingUtensils.Queries.GetUtensilsByColor
{
    using MediatR;

    public class GetUtensilsByColorQuery : IRequest<IEnumerable<WritingUtensilDto>>
    {
        public GetUtensilsByColorQuery(string color)
        {
            this.Color = color;
        }

        public string Color { get; set; }
    }
}
