namespace BookShop.Tests.WritingUtensils.Queries
{
    using BookShop.Application.Repositories;
    using BookShop.Application.WritingUtensils;
    using BookShop.Application.WritingUtensils.Commands.DeleteUtensils;
    using BookShop.Application.WritingUtensils.Queries.GetUtensils;
    using BookShop.Domain;
    using BookShop.Tests.Mocks;

    using Moq;
    using Shouldly;
    using Xunit;

    public class GetWritingUtensilsCommandHandlerTest
    {
        private readonly Mock<IDeletableEntityRepository<WritingUtensil>> mockRepo;

        public GetWritingUtensilsCommandHandlerTest()
        {
            this.mockRepo = WritingUtensilMockRepository.GetWritingUtensilMockRepo();
        }

        [Fact]
        public async Task GetWritingUtensilsTest()
        {
            var handler = new GetUtensilsHandler(this.mockRepo.Object);

            var result = await handler.Handle(new GetUtensilsQuery(), CancellationToken.None);

            result.ShouldBeOfType<EnumerableQuery<WritingUtensilDto>>();
        }

        [Fact]
        public async Task ShouldntChangeRepoCountTest()
        {
            var handler = new GetUtensilsHandler(this.mockRepo.Object);

            var result = await handler.Handle(new GetUtensilsQuery(), CancellationToken.None);

            var count = this.mockRepo.Object.AllAsNoTracking().Count();

            Assert.True(count == 2);
        }

        [Fact]
        public async Task ShouldThrowInvalidOperationExceptionTest()
        {
            var handler = new GetUtensilsHandler(this.mockRepo.Object);
            var deleteHandler = new DeleteUtensilHandler(this.mockRepo.Object);

            for (int i = 1; i < 3; i++)
            {
                var deleteResult = await deleteHandler.Handle(new DeleteUtensilCommand(i),
                    CancellationToken.None);
            }

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
            handler.Handle(new GetUtensilsQuery(), CancellationToken.None));
        }
    }
}
