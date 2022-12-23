namespace BookShop.Tests.Publications.Queries
{
    using BookShop.Application.Publications;
    using BookShop.Application.Publications.Queries.GetPublicationByName;
    using BookShop.Application.Repositories;
    using BookShop.Application.SeedWork.Exceptions;
    using BookShop.Domain;
    using BookShop.Tests.Mocks;

    using Moq;
    using Shouldly;
    using Xunit;

    public class GetPublicationByNameQueryHandlerTest
    {
        private readonly Mock<IDeletableEntityRepository<Publication>> mockRepo;
        private readonly Mock<IRepository<Genre>> genreMockRepo;


        public GetPublicationByNameQueryHandlerTest()
        {
            this.mockRepo = PublicationMockRepository.GetPublicationMockRepo();
            this.genreMockRepo = GenreMockRepository.GetGenreMockRepo();
        }

        [Fact]
        public async Task GetGameByNameTest()
        {
            var handler = new GetPublicationByNameHandler(this.mockRepo.Object, this.genreMockRepo.Object);

            var result = await handler.Handle(new GetPublicationByNameQuery("The Boys from Biloxi"), CancellationToken.None);

            result.ShouldBeOfType<PublicationDto>();
        }

        [Fact]
        public async Task ShouldntChangeRepoCountTest()
        {
            var handler = new GetPublicationByNameHandler(this.mockRepo.Object, this.genreMockRepo.Object);

            var result = await handler.Handle(new GetPublicationByNameQuery("The Boys from Biloxi"), CancellationToken.None);

            var count = this.mockRepo.Object.All().Count();

            Assert.True(count == 2);
        }

        [Fact]
        public async Task ShouldThrowGameNotFoundExceptionTest()
        {
            var handler = new GetPublicationByNameHandler(this.mockRepo.Object, this.genreMockRepo.Object);

            await Assert.ThrowsAsync<PublicationNotFoundException>(() =>
            handler.Handle(new GetPublicationByNameQuery("asd"), CancellationToken.None));
        }
    }
}
