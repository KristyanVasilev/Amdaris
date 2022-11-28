namespace BookShop.Application.WritingUtensils.Queries.GetSingleUtensil
{
    using BookShop.Application.Repositories;
    using BookShop.Domain;
    using MediatR;

    public class GetSingleUtensilHandler : IRequestHandler<GetSingleUtensilQuery, WritingUtensilDto>
    {
        private readonly IDeletableEntityRepository<WritingUtensil> repository;

        public GetSingleUtensilHandler(IDeletableEntityRepository<WritingUtensil> repository)
        {
            this.repository = repository;
        }

        public Task<WritingUtensilDto> Handle(GetSingleUtensilQuery request, CancellationToken cancellationToken)
        {
            var utensil = this.repository.AllAsNoTracking().FirstOrDefault(x => x.Id == request.Id);

            var result = new WritingUtensilDto
            {
                Id = utensil.Id,
                Name = utensil.Name,
                Price = utensil.Price,
                Color= utensil.Color,
                Manufacturer = utensil.Manufacturer,
                WritingUtensilsType = utensil.WritingUtensilsType.Name,
            };

            return Task.FromResult(result);
        }
    }
}
