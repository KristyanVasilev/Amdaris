namespace BookShop.Tests.Publications.Queries
{
    using BookShop.Application.Publications;
    using BookShop.Application.Publications.Queries.GetPublicationById;
    using BookShop.Application.Repositories;
    using BookShop.Application.SeedWork.Exceptions;
    using BookShop.Domain;
    using BookShop.Tests.Mocks;

    using Moq;
    using Shouldly;
    using Xunit;

    public class GetPublicationByIdQueryHandlerTest
    {
        private readonly Mock<IDeletableEntityRepository<Publication>> mockRepo;
        private readonly Mock<IRepository<Genre>> genreMockRepo;


        public GetPublicationByIdQueryHandlerTest()
        {
            this.mockRepo = PublicationMockRepository.GetPublicationMockRepo();
            this.genreMockRepo = GenreMockRepository.GetGenreMockRepo();
        }

        [Fact]
        public async Task GetSinglePublicationTest()
        {
            var handler = new GetPublicationByIdHandler(this.mockRepo.Object, this.genreMockRepo.Object);

            var result = await handler.Handle(new GetPublicationByIdQuery(1), CancellationToken.None);

            result.ShouldBeOfType<PublicationDto>();
        }

        [Fact]
        public async Task ShouldntChangeRepoCountTest()
        {
            var handler = new GetPublicationByIdHandler(this.mockRepo.Object, this.genreMockRepo.Object);

            var result = await handler.Handle(new GetPublicationByIdQuery(1), CancellationToken.None);

            var count = this.mockRepo.Object.All().Count();

            Assert.True(count == 2);
        }

        [Fact]
        public async Task ShouldThrowPublicationNotFoundExceptionTest()
        {
            var handler = new GetPublicationByIdHandler(this.mockRepo.Object, this.genreMockRepo.Object);

            await Assert.ThrowsAsync<PublicationNotFoundException>(() =>
            handler.Handle(new GetPublicationByIdQuery(12321), CancellationToken.None));
        }
    }
}
