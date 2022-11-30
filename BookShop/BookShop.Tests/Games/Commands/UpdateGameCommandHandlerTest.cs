namespace BookShop.Tests.Games.Commands
{
    using BookShop.Application;
    using BookShop.Application.Games.Commands.UpdateGame;
    using BookShop.Application.Repositories;
    using BookShop.Domain;
    using BookShop.Tests.Mocks;

    using Moq;
    using Shouldly;
    using Xunit;

    public class UpdateGameCommandHandlerTest
    {
        private readonly Mock<IDeletableEntityRepository<Game>> mockRepo;

        public UpdateGameCommandHandlerTest()
        {
            this.mockRepo = GameMockRepository.GetGameMockRepo();
        }

        [Fact]
        public async Task ShouldReturnIntTest()
        {
            var handler = new UpdateGameHandler(this.mockRepo.Object);

            var result = await handler.Handle(new UpdateGameCommand
            {
                Id = 1,
                Price = 140,
                Name = "Europolia",
                Manufacturer = "Some genius",
                Description = "Some description",
                Genre = new GenreDto { Name = "Strategy" },
            }, CancellationToken.None);

            result.ShouldBeOfType<Int32>();
            Assert.Equal(1, result);
        }

        [Fact]
        public async Task ShouldThrowNullReferenceExceptionTest()
        {
            var handler = new UpdateGameHandler(this.mockRepo.Object);

            await Assert.ThrowsAsync<NullReferenceException>(() => handler.Handle(new UpdateGameCommand(), CancellationToken.None));
        }

        [Fact]
        public async Task UpdatePublicationTest()
        {
            var handler = new UpdateGameHandler(this.mockRepo.Object);

            var result = await handler.Handle(new UpdateGameCommand
            {

                Id = 1,
                Price = 14032,
                Name = "Europolia",
                Manufacturer = "Some genius",
                Description = "Some description",
                Genre = new GenreDto { Name = "Strategy" },
            }, CancellationToken.None);
            Assert.Equal(14032, this.mockRepo.Object.All().FirstOrDefault(x => x.Id == 1).Price);
        }
    }
}
