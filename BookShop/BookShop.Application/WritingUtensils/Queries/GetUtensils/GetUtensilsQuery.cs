namespace BookShop.Application.WritingUtensils.Queries.GetUtensils
{
    using MediatR;

    public class GetUtensilsQuery : IRequest<IEnumerable<WritingUtensilDto>>
    {
    }
}
