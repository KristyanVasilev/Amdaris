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
            var emailBody = CreateEmailBody();

            foreach (var product in request.Products)
            {
                productName = product.Name;

                var game = this.gameRepository
                       .AllAsNoTracking()
                       .FirstOrDefault(x => x.Name == product.Name);
                       
                if (game != null && game.Quantity - product.Quantity >= 0)
                {
                    game.Quantity -= product.Quantity;
                    AppendProductToEmailBody(product, emailBody);
                    this.gameRepository.Update(game);
                    continue;
                }

                var publication = this.publicationRepository
                               .AllAsNoTracking()
                               .FirstOrDefault(x => x.Name == product.Name);

                if (publication != null && publication.Quantity - product.Quantity >= 0)
                {
                    publication.Quantity -= publication.Quantity;
                    AppendProductToEmailBody(product, emailBody);
                    this.publicationRepository.Update(publication);
                    continue;
                }

                var utensil = this.writingUtensilRepository
                             .AllAsNoTracking()
                             .FirstOrDefault(x => x.Name == product.Name);

                if (utensil != null && utensil.Quantity - product.Quantity >= 0)
                {
                    utensil.Quantity -= product.Quantity;
                    AppendProductToEmailBody(product, emailBody);
                    this.writingUtensilRepository.Update(utensil);
                    continue;
                }
                else
                {
                    isSucceed = false;
                    var error = $"{productName} not found or don't have enough quantity!";
                    emailBody.Clear();
                    emailBody.Append(error);
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
                    Address = request.Address,
                    TotalPrice = request.Products.Sum(x => x.Price),
                    Products = request.Products,                    
                    CreatedOn = DateTime.UtcNow,
                };
                await this.orderRepository.AddAsync(order);
                await this.orderRepository.SaveChangesAsync();
            }

            AppendTotalPriceAndOtherElementsToEmailBody(request.Products.Sum(x => x.Price), emailBody);
            return await Task.FromResult(emailBody.ToString());
        }

        private StringBuilder CreateEmailBody()
        {
            var emailBody = new StringBuilder();
            emailBody.AppendLine("<html>");
            emailBody.AppendLine("<head>");
            emailBody.AppendLine("<style>");
            emailBody.AppendLine("table {");
            emailBody.AppendLine("    border-collapse: collapse;");
            emailBody.AppendLine("}");
            emailBody.AppendLine("td {");
            emailBody.AppendLine("    border: 1px solid black;");
            emailBody.AppendLine("    padding: 5px;");
            emailBody.AppendLine("}");
            emailBody.AppendLine("</style>");
            emailBody.AppendLine("</head>");
            emailBody.AppendLine("<body>");
            emailBody.AppendLine("Thank you for your recent order with our store. Below is a summary of your purchase:</p>");
            emailBody.AppendLine("<table>");
            emailBody.AppendLine("<tr>");
            emailBody.AppendLine("<th>Name</th>");
            emailBody.AppendLine("<th>Quantity</th>");
            emailBody.AppendLine("<th>Price</th>");
            emailBody.AppendLine("</tr>");
            return emailBody;
        }

        private void AppendProductToEmailBody(Product product, StringBuilder emailBody)
        {
            emailBody.AppendLine("<tr>");
            emailBody.AppendLine("<td>" + product.Name + "</td>");
            emailBody.AppendLine("<td>" + product.Quantity + "</td>");
            emailBody.AppendLine("<td>" + product.Price + "</td>");
            emailBody.AppendLine("</tr>");
        }

        private void AppendTotalPriceAndOtherElementsToEmailBody(decimal totalPrice, StringBuilder emailBody)
        {
            emailBody.AppendLine("<tr>");
            emailBody.AppendLine("<td colspan='3'>Total Price : " + totalPrice + '$' +"</td>");
            emailBody.AppendLine("</tr>");
            emailBody.AppendLine("</table>");
            emailBody.AppendLine("<p>We hope you enjoy your purchase and thank you for choosing our store.</p>");
            emailBody.AppendLine("<p>Best regards,</p>");
            emailBody.AppendLine("<p>Your Store Team</p>");
            emailBody.AppendLine("</body>");
            emailBody.AppendLine("</html>");
        }
    }
}
