namespace BookShop.Application.WritingUtensils.Queries.GetUtensils
{
    using BookShop.Application.Contracts;
    using MediatR;

    public class GetUtensilsHandler : IRequestHandler<GetUtensilsQuery, IEnumerable<WritingUtensilDto>>
    {
        private readonly IWritingUtensilsRepository repository;

        public GetUtensilsHandler(IWritingUtensilsRepository repository)
        {
            this.repository = repository;
        }

        public Task<IEnumerable<WritingUtensilDto>> Handle(GetUtensilsQuery request, CancellationToken cancellationToken)
        {
            var result = this.repository.GetUtensils().Select(utensil => new WritingUtensilDto
            {
                Id = utensil.Id,
                Name = utensil.Name,
                Price = utensil.Price,
                Color = utensil.Color,
                Manufacturer = utensil.Manufacturer,
                WritingUtensilsType = utensil.WritingUtensilsType.Name,
            });

            return Task.FromResult(result);
        }
    }
}
