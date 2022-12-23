namespace BookShop.Tests.WritingUtensils.Commands
{
    using BookShop.Application.Repositories;
    using BookShop.Application.SeedWork.Exceptions;
    using BookShop.Application.WritingUtensils.Commands.DeleteUtensils;
    using BookShop.Domain;
    using BookShop.Tests.Mocks;

    using Moq;
    using Shouldly;
    using Xunit;

    public class DeleteWritingUtensilCommandHandlerTest
    {
        private readonly Mock<IDeletableEntityRepository<WritingUtensil>> mockRepo;

        public DeleteWritingUtensilCommandHandlerTest()
        {
            this.mockRepo = WritingUtensilMockRepository.GetWritingUtensilMockRepo();
        }

        [Fact]
        public async Task DeleteUtensilTest()
        {
            var handler = new DeleteUtensilHandler(this.mockRepo.Object);

            var result = await handler.Handle(new DeleteUtensilCommand(1), CancellationToken.None);

            var count = this.mockRepo.Object.AllAsNoTracking().Count();

            Assert.True(count == 1);
            Assert.Equal("Utensil Pen with id - 1 deleted successfully!", result);
        }

        [Fact]
        public async Task ShouldReturnStringTest()
        {
            var handler = new DeleteUtensilHandler(this.mockRepo.Object);

            var result = await handler.Handle(new DeleteUtensilCommand(1), CancellationToken.None);

            result.ShouldBeOfType<string>();
        }

        [Fact]
        public async Task ShouldThrowWritingUtensilNotFoundExceptionTest()
        {
            var handler = new DeleteUtensilHandler(this.mockRepo.Object);

            var firstDelete = await handler.Handle(new DeleteUtensilCommand(1), CancellationToken.None);
            await Assert.ThrowsAsync<WritingUtensilNotFoundException>(() =>
            handler.Handle(new DeleteUtensilCommand(12312), CancellationToken.None));

            var SecondDelete = await handler.Handle(new DeleteUtensilCommand(2), CancellationToken.None);

            await Assert.ThrowsAsync<WritingUtensilNotFoundException>(() =>
            handler.Handle(new DeleteUtensilCommand(1), CancellationToken.None));
        }
    }
}
