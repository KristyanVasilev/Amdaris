namespace BookShop.Application.WritingUtensils.Queries.GetUtensilById
{
    using MediatR;

    public class GetUtensilByIdQuery : IRequest<WritingUtensilDto>
    {
        public int Id { get; set; }

        public GetUtensilByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
