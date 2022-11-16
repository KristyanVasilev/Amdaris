namespace BookShop
{
    using BookShop.Application;
    using BookShop.Application.Publications.Commands.CreatePublication;
    using BookShop.Data;
    using BookShop.Data.ForSchool.Bags;
    using BookShop.Data.ForSchool.Bags.Enums;
    using BookShop.Data.ForSchool.Notebooks;
    using BookShop.Data.ForSchool.Notebooks.Enums;
    using BookShop.Data.Hobbies;
    using BookShop.Data.Hobbies.Enums;
    using BookShop.Data.Publications;
    using BookShop.Infrastructure;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;

    internal class Program
    {
        public static async Task Main(string[] args)
        {
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
                Genre = new GenreDto("Horror")               
            });

        //            public string Author { get; set; } = null!;

        //public int PageCount { get; set; }

        //public decimal Rating { get; set; } = 0;

        //public string Description { get; set; } = null!;

        //public PublicationType PublicationType { get; private set; }

        //public Genre Genre { get; private set; } = null!;
            // var products = await mediator.Send(new GetProductsListQuery());
            ;

            //var bookGenre = new Genre("horror");
            //Product book = new Book(1, 10, "opa", "az", 123, bookGenre);

            //Console.WriteLine(book.ToString());

            //Console.WriteLine("-----------------------------");

            //var bag = new Bagpack(2, 25, "ranica", "blue", "az", 123, Gender.Boy);
            //Console.WriteLine(bag.ToString());

            //Console.WriteLine("-----------------------------");

            //var notebook = new NoteBook(2, 15, "tetradka", "blue", "sini", 100, LineType.Squares);
            //Console.WriteLine(notebook.ToString());


            //Console.WriteLine("-----------------------------");

            //var chess = new Chess(2, 150, "shaho", "az", "qk shah", GameType.Strategy);
            //Console.WriteLine(chess.ToString());

            //Console.WriteLine("-----------------------------");

            //var customer = new Customer(1, "Pesho", "Petrov", "pesho123@gmail.com", 20);
            //Console.WriteLine(customer.UserInfo());
            //Console.WriteLine("-----------------------------");

            //Console.WriteLine(customer.AddToOrder(notebook));
            ////Console.WriteLine(customer.AddToOrder(chess));
            //Console.WriteLine(customer.Buy());

            //Console.WriteLine("-----------------------------");

            ////Console.WriteLine(customer.Buy());
            //Console.WriteLine(customer.Deposit(50));
            //Console.WriteLine(customer.AddToOrder(book));
            //Console.WriteLine(customer.AddToOrder(bag));
            //Console.WriteLine(customer.Buy());
            //Console.WriteLine(customer.Withdraw(10));
            ////Console.WriteLine(customer.Withdraw(-10));
            ////Console.WriteLine(customer.Withdraw(150000));

            //Console.WriteLine("-----------------------------");

            //Console.WriteLine(customer.AddToWatchlist(book));

            //Console.WriteLine("-----------------------------");

            //Console.WriteLine(customer.UserInfo());

            //Console.WriteLine("-----------------------------");

            //Console.WriteLine(customer.RemoveProductFromWatchlist(book));
            ////Console.WriteLine(customer.RemoveProductFromWatchlist(book));

            //Console.WriteLine("-----------------------------");

            //Console.WriteLine(customer.UserInfo());
        }
    }
}