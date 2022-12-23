namespace BookShop.Tests.Games.Commands
{
    using BookShop.Application.Games.Commands.CreateGame;
    using BookShop.Application.Repositories;
    using BookShop.Domain;
    using BookShop.Tests.Mocks;

    using Moq;
    using Shouldly;
    using Xunit;

    public class CreateGameCommandHandlerTest
    {
        private readonly Mock<IDeletableEntityRepository<Game>> mockRepo;
        private readonly Mock<IRepository<Genre>> genreMockRepo;

        public CreateGameCommandHandlerTest()
        {
            this.mockRepo = GameMockRepository.GetGameMockRepo();
            this.genreMockRepo = GenreMockRepository.GetGenreMockRepo();
        }

        [Fact]
        public async Task CreateGameTest()
        {
            var handler = new CreateGameHandler(this.mockRepo.Object, this.genreMockRepo.Object);

            var result = await handler.Handle(new CreateGameCommand
            {
                Id = 1,
                Price = 140,
                Name = "Europolia",
                Manufacturer = "Some genius",
                Description = "Some description",
                Genre = "Strategy",
            }, CancellationToken.None);

            var count = this.mockRepo.Object.All().Count();
            var game = this.mockRepo.Object.AllAsNoTracking().Skip(2).First();

            Assert.Equal("Europolia", game.Name);
            Assert.Equal(140, game.Price);

            Assert.True(count == 3);
        }

        [Fact]
        public async Task ShouldReturnIntTest()
        {
            var handler = new CreateGameHandler(this.mockRepo.Object, this.genreMockRepo.Object);

            var result = await handler.Handle(new CreateGameCommand
            {
                Id = 1,
                Price = 140,
                Name = "Europolia",
                Manufacturer = "Some genius",
                Description = "Some description",
                Genre = "Strategy",
            }, CancellationToken.None);

            result.ShouldBeOfType<Int32>();
        }

        [Fact]
        public async Task ShouldTrowArgumentExceptionForCreatingAlreadyExistingGame()
        {
            var handler = new CreateGameHandler(this.mockRepo.Object, this.genreMockRepo.Object);

            var result = new CreateGameCommand
            {
                Id = 1,
                Price = 140,
                Name = "Chess",
                Manufacturer = "Some genius",
                Description = "Some description",
                Genre = "Strategy",
            };

            await Assert.ThrowsAsync<ArgumentException>(() =>
            handler.Handle(result, CancellationToken.None));
        }
    }
}
