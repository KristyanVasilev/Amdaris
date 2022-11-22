namespace BookShop
{
    using BookShop.Application;
    using BookShop.Application.Publications.Commands.CreatePublication;
    using BookShop.Infrastructure;
    using BookShop.Infrastructure.Models;

    using MediatR;
    using Microsoft.Extensions.DependencyInjection;

    internal class Program
    {
        public static async Task Main(string[] args)
        {
            var editorial = Editorial.Instance;

            var diContainer = new ServiceCollection()
               .AddMediatR(typeof(IProductRepository))
               .AddScoped<IProductRepository, InMemoryProductRepository>()
               .BuildServiceProvider();

            var mediator = diContainer.GetRequiredService<IMediator>();

            var productId = await mediator.Send(new CreatePublicationCommand
            {
                Id = 1,
                Price = 10,
                Name = "The Boys from Biloxi",
                Author = "John Grisham",
                PageCount = 400,
                Description = "Some description",
                Genre = new GenreDto("Horror"),
                PublicationType = "Book",
            });
        }
    }
}