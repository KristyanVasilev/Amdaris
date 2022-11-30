namespace BookShop.Application.WritingUtensils.Queries.GetUtensils
{
    using BookShop.Application.Repositories;
    using BookShop.Domain;
    using MediatR;

    public class GetUtensilsHandler : IRequestHandler<GetUtensilsQuery, IEnumerable<WritingUtensilDto>>
    {
        private readonly IDeletableEntityRepository<WritingUtensil> repository;

        public GetUtensilsHandler(IDeletableEntityRepository<WritingUtensil> repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<WritingUtensilDto>> Handle(GetUtensilsQuery request, CancellationToken cancellationToken)
        {
            var result = this.repository.AllAsNoTracking().Select(utensil => new WritingUtensilDto
            {
                Id = utensil.Id,
                Name = utensil.Name,
                Price = utensil.Price,
                Color = utensil.Color,
                Manufacturer = utensil.Manufacturer,
                WritingUtensilsType = utensil.WritingUtensilsType.Name,
            });

            if (result.Count() == 0)
            {
                throw new InvalidOperationException();
            }

            return await Task.FromResult(result);
        }
    }
}
