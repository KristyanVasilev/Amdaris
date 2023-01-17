namespace BookShop.Application.Orders.Commands.CreateOrder
{
    using BookShop.Application.Repositories;
    using BookShop.Application.SeedWork.Exceptions;
    using BookShop.Domain;
    using MediatR;
    using System.Linq;
    using System.Text;

    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, string>
    {
        private readonly IDeletableEntityRepository<Game> gameRepository;
        private readonly IDeletableEntityRepository<Order> orderRepository;
        private readonly IDeletableEntityRepository<Publication> publicationRepository;
        private readonly IDeletableEntityRepository<WritingUtensil> writingUtensilRepository;

        public CreateOrderHandler(
            IDeletableEntityRepository<Game> gameRepository,
            IDeletableEntityRepository<Publication> publicationRepository,
            IDeletableEntityRepository<WritingUtensil> writingUtensilRepository,
            IDeletableEntityRepository<Order> orderRepository)
        {
            this.gameRepository = gameRepository;
            this.publicationRepository = publicationRepository;
            this.writingUtensilRepository = writingUtensilRepository;
            this.orderRepository = orderRepository;
        }

        public async Task<string> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var isSucceed = true;
            var productName = "";
            var sb = new StringBuilder();

            foreach (var product in request.Products)
            {
                productName = product.Name;

                var game = this.gameRepository
                       .AllAsNoTracking()
                       .FirstOrDefault(x => x.Name == product.Name);
                       
                if (game != null && game.Quantity - product.Quantity >= 0)
                {
                    game.Quantity -= product.Quantity;
                    sb.AppendLine($"{product.Name}, Quantity: {product.Quantity}, Price: {product.Price}");
                    this.gameRepository.Update(game);
                    continue;
                }

                var publication = this.publicationRepository
                               .AllAsNoTracking()
                               .FirstOrDefault(x => x.Name == product.Name);

                if (publication != null && publication.Quantity - product.Quantity >= 0)
                {
                    publication.Quantity -= publication.Quantity;
                    sb.AppendLine($"{product.Name}, Quantity: {product.Quantity}, Price: {product.Price}");
                    this.publicationRepository.Update(publication);
                    continue;
                }

                var utensil = this.writingUtensilRepository
                             .AllAsNoTracking()
                             .FirstOrDefault(x => x.Name == product.Name);

                if (utensil != null && utensil.Quantity - product.Quantity >= 0)
                {
                    utensil.Quantity -= product.Quantity;
                    sb.AppendLine($"{product.Name}, Quantity: {product.Quantity}, Price: {product.Price}");
                    this.writingUtensilRepository.Update(utensil);
                    continue;
                }
                else
                {
                    isSucceed = false;
                    var error = $"{productName} not found or don't have enough quantity!";
                    sb.Clear();
                    sb.Append(error);
                    throw new ProductDontHaveEnoughQuantity(error);
                }
            }

            await this.gameRepository.SaveChangesAsync();
            await this.publicationRepository.SaveChangesAsync();
            await this.writingUtensilRepository.SaveChangesAsync();

            if (isSucceed)
            {
                var order = new Order
                {
                    UserName = request.UserName,
                    Email = request.Email,
                    TotalPrice = request.Products.Sum(x => x.Price),
                    Products = request.Products,                    
                    CreatedOn = DateTime.UtcNow,
                };
                await this.orderRepository.AddAsync(order);
                await this.orderRepository.SaveChangesAsync();
            }

            sb.AppendLine($"Total amount: {request.Products.Sum(x => x.Price)}$");
            return await Task.FromResult(sb.ToString());
        }
    }
}
