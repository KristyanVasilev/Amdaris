namespace BookShop.Application.WritingUtensils.Commands.CreateUtensils
{
    using BookShop.Application.Repositories;
    using BookShop.Domain;
    using MediatR;

    public class CreateUtensilsHandler : IRequestHandler<CreateUtensilsCommand, int>
    {
        private readonly IDeletableEntityRepository<WritingUtensil> repository;

        public CreateUtensilsHandler(IDeletableEntityRepository<WritingUtensil> repository)
        {
            this.repository = repository;
        }

        public async Task<int> Handle(CreateUtensilsCommand request, CancellationToken cancellationToken)
        {
            var untensilType = new WritingUtensilsType { Name = request.WritingUtensilsType.Name };

            var utensil = new WritingUtensil
            {
                Id = request.Id,
                Price = request.Price,
                Name = request.Name,
                Color = request.Color,
                Manufacturer = request.Manufacturer,
                WritingUtensilsType = untensilType,
            };

            await this.repository.AddAsync(utensil);
            await this.repository.SaveChangesAsync();

            return await Task.FromResult(utensil.Id);
        }
    }
}
