namespace BookShop.Tests.Publications.Queries
{
    using BookShop.Application.Publications;
    using BookShop.Application.Publications.Queries.GetSinglePublication;
    using BookShop.Application.Repositories;
    using BookShop.Domain;
    using BookShop.Tests.Mocks;

    using Moq;
    using Shouldly;
    using Xunit;

    public class GetSinglePublicationCommandHandlerTest
    {
        private readonly Mock<IDeletableEntityRepository<Publication>> mockRepo;

        public GetSinglePublicationCommandHandlerTest()
        {
            this.mockRepo = PublicationMockRepository.GetPublicationMockRepo();
        }

        [Fact]
        public async Task GetSinglePublicationTest()
        {
            var handler = new GetSinglePublicationHandler(this.mockRepo.Object);

            var result = await handler.Handle(new GetSinglePublicationQuery(1), CancellationToken.None);

            result.ShouldBeOfType<PublicationDto>();
        }

        [Fact]
        public async Task ShouldntChangeRepoCountTest()
        {
            var handler = new GetSinglePublicationHandler(this.mockRepo.Object);

            var result = await handler.Handle(new GetSinglePublicationQuery(1), CancellationToken.None);

            var count = this.mockRepo.Object.All().Count();

            Assert.True(count == 2);
        }

        [Fact]
        public async Task ShouldThrowNullReferenceExceptionTest()
        {
            var handler = new GetSinglePublicationHandler(this.mockRepo.Object);

            await Assert.ThrowsAsync<NullReferenceException>(() =>
            handler.Handle(new GetSinglePublicationQuery(12321), CancellationToken.None));
        }
    }
}
