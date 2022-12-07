namespace BookShop.Tests.Games.Queries
{
    using BookShop.Application.Games;
    using BookShop.Application.Games.Queries.GetSingleGame;
    using BookShop.Application.Repositories;
    using BookShop.Domain;
    using BookShop.Tests.Mocks;

    using Moq;
    using Shouldly;
    using Xunit;

    public class GetSingleGameCommandHandlerTest
    {
        private readonly Mock<IDeletableEntityRepository<Game>> mockRepo;
        private readonly Mock<IRepository<Genre>> genreMockRepo;

        public GetSingleGameCommandHandlerTest()
        {
            this.mockRepo = GameMockRepository.GetGameMockRepo();
            this.genreMockRepo = GenreMockRepository.GetGenreMockRepo();
        }

        [Fact]
        public async Task GetSingleGameTest()
        {
            var handler = new GetSingleGameHandler(this.mockRepo.Object, this.genreMockRepo.Object);

            var result = await handler.Handle(new GetSingleGameQuery(1), CancellationToken.None);

            result.ShouldBeOfType<GameDto>();
        }

        [Fact]
        public async Task ShouldntChangeRepoCountTest()
        {
            var handler = new GetSingleGameHandler(this.mockRepo.Object, this.genreMockRepo.Object);

            var result = await handler.Handle(new GetSingleGameQuery(1), CancellationToken.None);

            var count = this.mockRepo.Object.All().Count();

            Assert.True(count == 2);
        }

        [Fact]
        public async Task ShouldThrowInvalidOperationExceptionTest()
        {
            var handler = new GetSingleGameHandler(this.mockRepo.Object, this.genreMockRepo.Object);

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
            handler.Handle(new GetSingleGameQuery(12321), CancellationToken.None));
        }
    }
}
