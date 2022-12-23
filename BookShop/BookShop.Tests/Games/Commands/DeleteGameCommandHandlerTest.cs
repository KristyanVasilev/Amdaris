namespace BookShop.Tests.Games.Commands
{
    using BookShop.Application.Games.Commands.DeleteGame;
    using BookShop.Application.Repositories;
    using BookShop.Application.SeedWork.Exceptions;
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

            var result = await handler.Handle(new DeleteGameCommand(1), CancellationToken.None);

            var count = this.mockRepo.Object.AllAsNoTracking().Count();

            Assert.True(count == 1);
            Assert.Equal("Game Chess with id - 1 deleted successfully!", result);
        }

        [Fact]
        public async Task ShouldReturnStringTest()
        {
            var handler = new DeleteGameHandler(this.mockRepo.Object);

            var result = await handler.Handle(new DeleteGameCommand(1), CancellationToken.None);

            result.ShouldBeOfType<string>();
        }

        [Fact]
        public async Task ShouldThrowGameNotFoundExceptionTest()
        {
            var handler = new DeleteGameHandler(this.mockRepo.Object);

            var firstDelete = await handler.Handle(new DeleteGameCommand(1), CancellationToken.None);
            await Assert.ThrowsAsync<GameNotFoundException>(() =>
            handler.Handle(new DeleteGameCommand(12131), CancellationToken.None));

            var SecondDelete = await handler.Handle(new DeleteGameCommand(2), CancellationToken.None);

            await Assert.ThrowsAsync<GameNotFoundException>(() =>
            handler.Handle(new DeleteGameCommand(1), CancellationToken.None));
        }
    }
}
