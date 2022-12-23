namespace BookShop.Tests.Publications.Queries
{
    using BookShop.Application.Publications;
    using BookShop.Application.Publications.Queries.GetPublicationByAuthor;
    using BookShop.Application.Repositories;
    using BookShop.Application.SeedWork.Exceptions;
    using BookShop.Domain;
    using BookShop.Tests.Mocks;

    using Moq;
    using Shouldly;
    using Xunit;

    public class GetPublicationByAuthorQueryHandlerTest
    {
        private readonly Mock<IDeletableEntityRepository<Publication>> mockRepo;

        public GetPublicationByAuthorQueryHandlerTest()
        {
            this.mockRepo = PublicationMockRepository.GetPublicationMockRepo();
        }

        [Fact]
        public async Task GetGameByNameTest()
        {
            var handler = new GetPublicationByAuthorHandler(this.mockRepo.Object);

            var result = await handler.Handle(new GetPublicationByAuthorQuery("John Grisham"), CancellationToken.None);

            result.ShouldBeOfType<EnumerableQuery<PublicationDto>>();
        }

        [Fact]
        public async Task ShouldntChangeRepoCountTest()
        {
            var handler = new GetPublicationByAuthorHandler(this.mockRepo.Object);

            var result = await handler.Handle(new GetPublicationByAuthorQuery("John Grisham"), CancellationToken.None);

            var count = this.mockRepo.Object.All().Count();

            Assert.True(count == 2);
        }

        [Fact]
        public async Task ShouldThrowGameNotFoundExceptionTest()
        {
            var handler = new GetPublicationByAuthorHandler(this.mockRepo.Object);

            await Assert.ThrowsAsync<PublicationNotFoundException>(() =>
            handler.Handle(new GetPublicationByAuthorQuery("asd"), CancellationToken.None));
        }
    }
}
