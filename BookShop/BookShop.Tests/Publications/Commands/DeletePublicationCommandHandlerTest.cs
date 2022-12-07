namespace BookShop.Tests.Publications.Commands
{
    using BookShop.Application.Publications.Commands.DeletePublication;
    using BookShop.Application.Repositories;
    using BookShop.Domain;
    using BookShop.Tests.Mocks;

    using Moq;
    using Shouldly;
    using Xunit;

    public class DeletePublicationCommandHandlerTest
    {
        private readonly Mock<IDeletableEntityRepository<Publication>> mockRepo;

        public DeletePublicationCommandHandlerTest()
        {
            this.mockRepo = PublicationMockRepository.GetPublicationMockRepo();
        }

        [Fact]
        public async Task DeletePublicationTest()
        {
            var handler = new DeletePublicationHandler(this.mockRepo.Object);

            var result = await handler.Handle(new DeletePublicationCommand(1), CancellationToken.None);

            var count = this.mockRepo.Object.AllAsNoTracking().Count();

            Assert.True(count == 1);
        }

        [Fact]
        public async Task ShouldReturnStringTest()
        {
            var handler = new DeletePublicationHandler(this.mockRepo.Object);

            var result = await handler.Handle(new DeletePublicationCommand(2), CancellationToken.None);

            result.ShouldBeOfType<string>();
            Assert.Equal("Publication Test with id - 2 deleted successfully!", result);
        }

        [Fact]
        public async Task ShouldThrowInvalidOperationExceptionTest()
        {
            var handler = new DeletePublicationHandler(this.mockRepo.Object);

            var firstDelete = await handler.Handle(new DeletePublicationCommand(1), CancellationToken.None);
            await Assert.ThrowsAsync<InvalidOperationException>(() =>
            handler.Handle(new DeletePublicationCommand(1234), CancellationToken.None));

            var SecondDelete = await handler.Handle(new DeletePublicationCommand(2), CancellationToken.None);

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
            handler.Handle(new DeletePublicationCommand(1), CancellationToken.None));
        }
    }
}
