//namespace BookShop
//{
//    using BookShop.Application.Games.Commands.CreateGame;
//    using BookShop.Application.Games.Commands.DeleteGame;
//    using BookShop.Application.Games.Queries.GetGames;
//    using BookShop.Application.Games.Queries.GetSingleGame;
//    using BookShop.Application.Publications.Commands.CreatePublication;
//    using BookShop.Application.Publications.Commands.DeletePublication;
//    using BookShop.Application.Publications.Queries.GetPublication;
//    using BookShop.Application.Publications.Queries.GetSinglePublication;
//    using BookShop.Application.Users.Commands.CreateApplicatioUser;
//    using BookShop.Application.WritingUtensils.Commands.CreateUtensils;
//    using BookShop.Application.WritingUtensils.Commands.DeleteUtensils;
//    using BookShop.Application.WritingUtensils.Queries.GetSingleUtensil;
//    using BookShop.Application.WritingUtensils.Queries.GetUtensils;

//    using MediatR;
//    using Microsoft.Extensions.DependencyInjection;

//    internal class Program
//    {
//        public static async Task Main(string[] args)
//        {

//            var diContainer = new ServiceCollection()
//               .AddMediatR(typeof(IPublicationRepository))
//               .AddMediatR(typeof(IApplicationUserRepository))
//               .AddMediatR(typeof(IGameRepository))
//               .AddMediatR(typeof(IWritingUtensilsRepository))
//               .AddMediatR(typeof(IBagRepository))
//               .AddScoped<IPublicationRepository, InMemoryPublicationRepository>()
//               .AddScoped<IApplicationUserRepository, InMemoryApplicationUserRepository>()
//               .AddScoped<IGameRepository, InMemoryGameRepository>()
//               .AddScoped<IWritingUtensilsRepository, InMemoryWritingUtensilsRepository>()
//               .AddScoped<IBagRepository, InMemoryBagRepository>()
//               .BuildServiceProvider();

//            var mediator = diContainer.GetRequiredService<IMediator>();

//            await PublicationsCommandsAndQueries(mediator);

//            await BagCommandsAndQueries(mediator);

//            await GameCommandsAndQueries(mediator);

//            await UtensilCommandAndQueries(mediator);

//            var user = await mediator.Send(new CreateApplicationUserCommand
//            {
//                Id = 1,
//                FirstName = "Gosho",
//                LastName = "Goshov",
//                Email = "Gosho@abv.bg"
//            });
//        }
     
//        private static async Task PublicationsCommandsAndQueries(IMediator mediator)
//        {
//            var publicationId = await mediator.Send(new CreatePublicationCommand
//            {
//                Id = 1,
//                Price = 10,
//                Name = "The Boys from Biloxi",
//                Author = "John Grisham",
//                PageCount = 400,
//                Description = "Some description",
//                Genre = new GenreDto { Name = "Horror" },
//                PublicationType = "Book",
//            });

//            var publicationId2 = await mediator.Send(new CreatePublicationCommand
//            {
//                Id = 2,
//                Price = 10,
//                Name = "The Boys from Biloxi",
//                Author = "Grisham",
//                PageCount = 400,
//                Description = "Some description",
//                Genre = new GenreDto { Name = "Horror" },
//                PublicationType = "Book",
//            });

//            Console.WriteLine(await mediator.Send(new DeletePublicationCommand { Id = 2 }));

//            var publications = await mediator.Send(new GetPublicationsQuery());
//            foreach (var publication in publications)
//            {
//                Console.WriteLine(publication.Author);
//            }

//            var book = await mediator.Send(new GetSinglePublicationQuery(1));
//        }

//        private static async Task BagCommandsAndQueries(IMediator mediator)
//        {
//            var bagId = await mediator.Send(new CreateBagCommand
//            {
//                Id = 1,
//                Price = 40,
//                Name = "Nike bag",
//                Manufacturer = "Nike",
//                Capacity = 50,
//                Color = "black",
//                Gender = "Boy",
//                BagType = new BagTypeDto { Name = "Big" }
//            });

//            var bagId2 = await mediator.Send(new CreateBagCommand
//            {
//                Id = 2,
//                Price = 40,
//                Name = "Adidas bag",
//                Manufacturer = "Adidas",
//                Capacity = 50,
//                Color = "white",
//                Gender = "Boy",
//                BagType = new BagTypeDto { Name = "Big" }
//            });

//            Console.WriteLine(await mediator.Send(new DeleteBagCommand { Id = 2 }));

//            var bags = await mediator.Send(new GetBagsQuery());
//            foreach (var currBag in bags)
//            {
//                Console.WriteLine(currBag.Manufacturer);
//            }

//            var bag = await mediator.Send(new GetSingleBagQuery(1));
//        }

//        private static async Task GameCommandsAndQueries(IMediator mediator)
//        {
//            var gameId = await mediator.Send(new CreateGameCommand
//            {
//                Id = 1,
//                Price = 140,
//                Name = "Chess",
//                Manufacturer = "Some carpenter",
//                Description = "Some description",
//                GameType = "Strategy",
//            });

//            var gameId2 = await mediator.Send(new CreateGameCommand
//            {
//                Id = 2,
//                Price = 120,
//                Name = "Chess",
//                Manufacturer = "Some carpenter2",
//                Description = "Some description2",
//                GameType = "Strategy",
//            });

//            Console.WriteLine(await mediator.Send(new DeleteGameCommand { Id = 2 }));

//            var games = await mediator.Send(new GetGamesQuery());
//            foreach (var currGame in games)
//            {
//                Console.WriteLine(currGame.Name);
//            }

//            var game = await mediator.Send(new GetSingleGameQuery(1));

//        }

//        private static async Task UtensilCommandAndQueries(IMediator mediator)
//        {
//            var utensilId = await mediator.Send(new CreateUtensilsCommand
//            {
//                Id = 1,
//                Price = 40,
//                Name = "Nike pen",
//                Manufacturer = "Orange",
//                Color = "red",
//                WritingUtensilsType = new WritingUtensilsTypeDto { Name = "Pen" },
//            });

//            var utensilId2 = await mediator.Send(new CreateUtensilsCommand
//            {
//                Id = 2,
//                Price = 40,
//                Name = "Adidas pen",
//                Manufacturer = "Orange",
//                Color = "red",
//                WritingUtensilsType = new WritingUtensilsTypeDto { Name = "Pen" },
//            });

//            Console.WriteLine(await mediator.Send(new DeleteUtensilCommand { Id = 2 }));

//            var utensils = await mediator.Send(new GetUtensilsQuery());
//            foreach (var currUtensil in utensils)
//            {
//                Console.WriteLine(currUtensil.Name);
//            }

//            var utensil = await mediator.Send(new GetSingleUtensilQuery(1));
//        }
//    }
//}