namespace BookShop.Application.WritingUtensils.Queries.GetSingleUtensil
{
    using BookShop.Application.Contracts;
    using MediatR;

    public class GetSingleUtensilHandler : IRequestHandler<GetSingleUtensilQuery, WritingUtensilDto>
    {
        private readonly IWritingUtensilsRepository repository;

        public GetSingleUtensilHandler(IWritingUtensilsRepository repository)
        {
            this.repository = repository;
        }

        public Task<WritingUtensilDto> Handle(GetSingleUtensilQuery request, CancellationToken cancellationToken)
        {
            var utensil = this.repository.GetSingleUtensil(request.Id);

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
