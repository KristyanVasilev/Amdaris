namespace BookShop.Tests.Games.Commands
{
    using BookShop.Application.Games.Commands.UpdateGame;
    using BookShop.Application.Repositories;
    using BookShop.Application.SeedWork.Exceptions;
    using BookShop.Domain;
    using BookShop.Tests.Mocks;

    using Moq;
    using Shouldly;
    using Xunit;

    public class UpdateGameCommandHandlerTest
    {
        private readonly Mock<IDeletableEntityRepository<Game>> mockRepo;
        private readonly Mock<IRepository<Genre>> genreMockRepo;

        public UpdateGameCommandHandlerTest()
        {
            this.mockRepo = GameMockRepository.GetGameMockRepo();
            this.genreMockRepo = GenreMockRepository.GetGenreMockRepo();
        }

        [Fact]
        public async Task ShouldReturnIntTest()
        {
            var handler = new UpdateGameHandler(this.mockRepo.Object, this.genreMockRepo.Object);

            var result = await handler.Handle(new UpdateGameCommand
            {
                Id = 1,
                Price = 140,
                Name = "Europolia",
                Manufacturer = "Some genius",
                Description = "Some description",
                Genre = "Strategy",
            }, CancellationToken.None);

            result.ShouldBeOfType<Int32>();
            Assert.Equal(1, result);
        }

        [Fact]
        public async Task ShouldThrowGameNotFoundExceptionTest()
        {
            var handler = new UpdateGameHandler(this.mockRepo.Object, this.genreMockRepo.Object);

            await Assert.ThrowsAsync<GameNotFoundException>(() => 
            handler.Handle(new UpdateGameCommand(), CancellationToken.None));
        }

        [Fact]
        public async Task UpdateGameTest()
        {
            var handler = new UpdateGameHandler(this.mockRepo.Object, this.genreMockRepo.Object);

            var result = await handler.Handle(new UpdateGameCommand
            {
                Id = 1,
                Price = 14,
                Name = "Fifa",
                Manufacturer = "Some genius",
                Description = "Edited description",
                Genre = "Strategy",
            }, CancellationToken.None);

            Assert.Equal(14, this.mockRepo.Object.All().First().Price);
            Assert.Equal("Fifa", this.mockRepo.Object.All().First().Name);
            Assert.Equal("Edited description", this.mockRepo.Object.All().First().Description);
        }
    }
}
