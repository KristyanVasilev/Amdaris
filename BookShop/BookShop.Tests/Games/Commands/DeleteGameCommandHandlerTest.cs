namespace BookShop.Tests.Games.Commands
{
    using BookShop.Application.Games.Commands.DeleteGame;
    using BookShop.Application.Repositories;
    using BookShop.Domain;
    using BookShop.Tests.Mocks;

    using Moq;
    using Shouldly;
    using Xunit;

    public class DeleteGameCommandHandlerTest
    {
        private readonly Mock<IDeletableEntityRepository<Game>> mockRepo;

        public DeleteGameCommandHandlerTest()
        {
            this.mockRepo = GameMockRepository.GetGameMockRepo();
        }

        [Fact]
        public async Task DeleteGameTest()
        {
            var handler = new DeleteGameHandler(this.mockRepo.Object);

            var result = await handler.Handle(new DeleteGameCommand { Id = 1 }, CancellationToken.None);

            var count = this.mockRepo.Object.AllAsNoTracking().Count();

            Assert.True(count == 1);
            Assert.Equal("Game with id - 1 deleted successfully!", result);
        }

        [Fact]
        public async Task ShouldReturnStringTest()
        {
            var handler = new DeleteGameHandler(this.mockRepo.Object);

            var result = await handler.Handle(new DeleteGameCommand { Id = 1 }, CancellationToken.None);

            result.ShouldBeOfType<string>();
        }

        [Fact]
        public async Task ShouldThrowInvalidOperationExceptionTest()
        {
            var handler = new DeleteGameHandler(this.mockRepo.Object);

            var firstDelete = await handler.Handle(new DeleteGameCommand { Id = 1 }, CancellationToken.None);
            await Assert.ThrowsAsync<InvalidOperationException>(() =>
            handler.Handle(new DeleteGameCommand { Id = 12312 }, CancellationToken.None));

            var SecondDelete = await handler.Handle(new DeleteGameCommand { Id = 2 }, CancellationToken.None);

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
            handler.Handle(new DeleteGameCommand { Id = 3 }, CancellationToken.None));
        }
    }
}
