namespace BookShop.Application.WritingUtensils.Queries.GetSingleUtensil
{
    using MediatR;

    public class GetSingleUtensilQuery : IRequest<WritingUtensilDto>
    {
        public int Id { get; set; }

        public GetSingleUtensilQuery(int id)
        {
            this.Id = id;
        }
    }
}
