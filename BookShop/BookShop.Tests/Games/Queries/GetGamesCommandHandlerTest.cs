namespace BookShop.Tests.Games.Queries
{
    using BookShop.Application.Games;
    using BookShop.Application.Games.Commands.DeleteGame;
    using BookShop.Application.Games.Queries.GetGames;
    using BookShop.Application.Repositories;
    using BookShop.Domain;
    using BookShop.Tests.Mocks;

    using Moq;
    using Shouldly;
    using Xunit;

    public class GetGamesCommandHandlerTest
    {
        private readonly Mock<IDeletableEntityRepository<Game>> mockRepo;

        public GetGamesCommandHandlerTest()
        {
            this.mockRepo = GameMockRepository.GetGameMockRepo();
        }

        [Fact]
        public async Task GetGamesTest()
        {
            var handler = new GetGamesHandler(this.mockRepo.Object);

            var result = await handler.Handle(new GetGamesQuery(), CancellationToken.None);

            result.ShouldBeOfType<EnumerableQuery<GameDto>>();
        }

        [Fact]
        public async Task ShouldntChangeRepoCountTest()
        {
            var handler = new GetGamesHandler(this.mockRepo.Object);

            var result = await handler.Handle(new GetGamesQuery(), CancellationToken.None);

            var count = this.mockRepo.Object.AllAsNoTracking().Count();

            Assert.True(count == 2);
        }

        [Fact]
        public async Task ShouldThrowNullReferenceExceptionTest()
        {
            var handler = new GetGamesHandler(this.mockRepo.Object);
            var deleteHandler = new DeleteGameHandler(this.mockRepo.Object);

            for (int i = 1; i < 3; i++)
            {
                var deleteResult = await deleteHandler.Handle(new DeleteGameCommand { Id = i },
                    CancellationToken.None);
            }

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
            handler.Handle(new GetGamesQuery(), CancellationToken.None));
        }
    }
}
