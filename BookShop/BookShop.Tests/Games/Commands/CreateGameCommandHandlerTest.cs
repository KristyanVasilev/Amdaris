namespace BookShop.Tests.Games.Commands
{
    using BookShop.Application;
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

        public CreateGameCommandHandlerTest()
        {
            this.mockRepo = GameMockRepository.GetGameMockRepo();
        }

        [Fact]
        public async Task CreateGameTest()
        {
            var handler = new CreateGameHandler(this.mockRepo.Object);

            var result = await handler.Handle(new CreateGameCommand
            {
                Id = 1,
                Price = 140,
                Name = "Europolia",
                Manufacturer = "Some genius",
                Description = "Some description",
                Genre = new GenreDto { Name = "Strategy" },
            }, CancellationToken.None);

            var count = this.mockRepo.Object.All().Count();
            Assert.Equal(1, this.mockRepo.Object.All().FirstOrDefault(x => x.Id == 1).Id);

            Assert.True(count == 3);
        }

        [Fact]
        public async Task ShouldReturnIntTest()
        {
            var handler = new CreateGameHandler(this.mockRepo.Object);

            var result = await handler.Handle(new CreateGameCommand
            {
                Id = 1,
                Price = 140,
                Name = "Europolia",
                Manufacturer = "Some genius",
                Description = "Some description",
                Genre = new GenreDto { Name = "Strategy" },
            }, CancellationToken.None);

            result.ShouldBeOfType<Int32>();
        }

        [Fact]
        public async Task ShouldThrowNullReferenceExceptionTest()
        {
            var handler = new CreateGameHandler(this.mockRepo.Object);

            await Assert.ThrowsAsync<NullReferenceException>(() => handler.Handle(new CreateGameCommand(), CancellationToken.None));
        }
    }
}
