namespace BookShop.Tests.WritingUtensils.Queries
{
    using BookShop.Application.Repositories;
    using BookShop.Application.WritingUtensils;
    using BookShop.Application.WritingUtensils.Queries.GetSingleUtensil;
    using BookShop.Domain;
    using BookShop.Tests.Mocks;

    using Moq;
    using Shouldly;
    using Xunit;

    public class GetSingleWritingUtensilCommandHandlerTest
    {
        private readonly Mock<IDeletableEntityRepository<WritingUtensil>> mockRepo;

        public GetSingleWritingUtensilCommandHandlerTest()
        {
            this.mockRepo = WritingUtensilMockRepository.GetWritingUtensilMockRepo();
        }

        [Fact]
        public async Task GetSingleWritingUtensilTest()
        {
            var handler = new GetSingleUtensilHandler(this.mockRepo.Object);

            var result = await handler.Handle(new GetSingleUtensilQuery(1), CancellationToken.None);

            result.ShouldBeOfType<WritingUtensilDto>();
        }

        [Fact]
        public async Task ShouldntChangeRepoCountTest()
        {
            var handler = new GetSingleUtensilHandler(this.mockRepo.Object);

            var result = await handler.Handle(new GetSingleUtensilQuery(1), CancellationToken.None);

            var count = this.mockRepo.Object.All().Count();

            Assert.True(count == 2);
        }

        [Fact]
        public async Task ShouldThrowNullReferenceExceptionTest()
        {
            var handler = new GetSingleUtensilHandler(this.mockRepo.Object);

            await Assert.ThrowsAsync<NullReferenceException>(() =>
            handler.Handle(new GetSingleUtensilQuery(12321), CancellationToken.None));
        }
    }
}
