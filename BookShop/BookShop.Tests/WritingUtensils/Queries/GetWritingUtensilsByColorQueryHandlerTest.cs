namespace BookShop.Tests.WritingUtensils.Queries
{
    using BookShop.Application.Repositories;
    using BookShop.Application.SeedWork.Exceptions;
    using BookShop.Application.WritingUtensils;
    using BookShop.Application.WritingUtensils.Commands.DeleteUtensils;
    using BookShop.Application.WritingUtensils.Queries.GetUtensilsByColor;
    using BookShop.Domain;
    using BookShop.Tests.Mocks;

    using Moq;
    using Shouldly;
    using Xunit;

    public class GetWritingUtensilsByColorQueryHandlerTest
    {
        private readonly Mock<IDeletableEntityRepository<WritingUtensil>> mockRepo;

        public GetWritingUtensilsByColorQueryHandlerTest()
        {
            this.mockRepo = WritingUtensilMockRepository.GetWritingUtensilMockRepo();
        }

        [Fact]
        public async Task GetWritingUtensilsTest()
        {
            var handler = new GetUtensilsByColorHandler(this.mockRepo.Object);

            var result = await handler.Handle(new GetUtensilsByColorQuery("red"), CancellationToken.None);

            result.ShouldBeOfType<EnumerableQuery<WritingUtensilDto>>();
        }

        [Fact]
        public async Task ShouldntChangeRepoCountTest()
        {
            var handler = new GetUtensilsByColorHandler(this.mockRepo.Object);

            var result = await handler.Handle(new GetUtensilsByColorQuery("red"), CancellationToken.None);

            var count = this.mockRepo.Object.AllAsNoTracking().Count();

            Assert.True(count == 2);
        }

        [Fact]
        public async Task ShouldThrowWritingUtensilNotFoundExceptionTest()
        {
            var handler = new GetUtensilsByColorHandler(this.mockRepo.Object);
            var deleteHandler = new DeleteUtensilHandler(this.mockRepo.Object);

            for (int i = 1; i < 3; i++)
            {
                var deleteResult = await deleteHandler.Handle(new DeleteUtensilCommand(i),
                    CancellationToken.None);
            }

            await Assert.ThrowsAsync<WritingUtensilNotFoundException>(() =>
            handler.Handle(new GetUtensilsByColorQuery("green"), CancellationToken.None));
        }
    }
}
