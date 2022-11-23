namespace BookShop.Application.WritingUtensils.Commands.CreateUtensils
{
    using BookShop.Domain.ForSchool.WritingAndDrawing;
    using MediatR;

    public class CreateUtensilsHandler : IRequestHandler<CreateUtensilsCommand, int>
    {
        private readonly IProductRepository repository;

        public CreateUtensilsHandler(IProductRepository repository)
        {
            this.repository = repository;
        }

        public Task<int> Handle(CreateUtensilsCommand request, CancellationToken cancellationToken)
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

            this.repository.CreateProduct(utensil);

            return Task.FromResult(utensil.Id);
        }
    }
}
