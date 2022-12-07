namespace BookShop.Tests.Publications.Queries
{
    using BookShop.Application.Publications;
    using BookShop.Application.Publications.Commands.DeletePublication;
    using BookShop.Application.Publications.Queries.GetPublication;
    using BookShop.Application.Repositories;
    using BookShop.Domain;
    using BookShop.Tests.Mocks;

    using Moq;
    using Shouldly;
    using Xunit;

    public class GetPublicationsCommandHandlerTest
    {
        private readonly Mock<IDeletableEntityRepository<Publication>> mockRepo;

        public GetPublicationsCommandHandlerTest()
        {
            this.mockRepo = PublicationMockRepository.GetPublicationMockRepo();
        }

        [Fact]
        public async Task GetPublicationsTest()
        {
            var handler = new GetPublicationsHandler(this.mockRepo.Object);

            var result = await handler.Handle(new GetPublicationsQuery(), CancellationToken.None);

            result.ShouldBeOfType<EnumerableQuery<PublicationDto>>();
        }

        [Fact]
        public async Task ShouldntChangeRepoCountTest()
        {
            var handler = new GetPublicationsHandler(this.mockRepo.Object);

            var result = await handler.Handle(new GetPublicationsQuery(), CancellationToken.None);

            var count = this.mockRepo.Object.AllAsNoTracking().Count();

            Assert.True(count == 2);
        }

        [Fact]
        public async Task ShouldThrowNullReferenceExceptionTest()
        {
            var handler = new GetPublicationsHandler(this.mockRepo.Object);
            var deleteHandler = new DeletePublicationHandler(this.mockRepo.Object);

            for (int i = 1; i < 3; i++)
            {
                var deleteResult = await deleteHandler.Handle(new DeletePublicationCommand(i),
                    CancellationToken.None);
            }

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
            handler.Handle(new GetPublicationsQuery(), CancellationToken.None));
        }
    }
}
