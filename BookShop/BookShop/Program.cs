namespace BookShop
{
    using BookShop.Application;
    using BookShop.Application.Games.Commands.CreateGame;
    using BookShop.Application.Publications.Commands.CreatePublication;
    using BookShop.Application.Publications.Queries.GetPublication;
    using BookShop.Application.Users.Commands.CreateApplicatioUser;
    using BookShop.Infrastructure;

    using MediatR;
    using Microsoft.Extensions.DependencyInjection;

    internal class Program
    {
        public static async Task Main(string[] args)
        {
            //var editorial = Editorial.Instance;

            var diContainer = new ServiceCollection()
               .AddMediatR(typeof(IProductRepository))
               .AddMediatR(typeof(IApplicationUserRepository))
               .AddScoped<IProductRepository, InMemoryProductRepository>()
               .AddScoped<IApplicationUserRepository, InMemoryApplicationUserRepository>()
               .BuildServiceProvider();

            var mediator = diContainer.GetRequiredService<IMediator>();

            var publicationId = await mediator.Send(new CreatePublicationCommand
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

            var publicationId2 = await mediator.Send(new CreatePublicationCommand
            {
                Id = 2,
                Price = 10,
                Name = "The Boys from Biloxi",
                Author = "Grisham",
                PageCount = 400,
                Description = "Some description",
                Genre = new GenreDto("Horror"),
                PublicationType = "Book",
            });

            var gameId = await mediator.Send(new CreateGameCommand
            {
                Id = 1,
                Price = 140,
                Name = "Chess",
                Manufacturer = "Some carpenter",
                Description = "Some description",
                GameType = "Strategy",
            });

            var publications = await mediator.Send(new GetPublicationQuery());
            foreach (var publication in publications)
            {
                Console.WriteLine(publication.Author);
            }

            var user = await mediator.Send(new CreateApplicationUserCommand
            {
                Id = 1,
                FirstName = "Gosho",
                LastName = "Goshov",
                Email = "Gosho@abv.bg"
            });
        }
    }
}