namespace BookShop.Tests.WritingUtensils.Commands
{
    using BookShop.Application.Repositories;
    using BookShop.Application.WritingUtensils.Commands.UpdateUtensils;
    using BookShop.Domain;
    using BookShop.Tests.Mocks;

    using Moq;
    using Shouldly;
    using Xunit;

    public class UpdateWritingUtensilCommandHandlerTest
    {
        private readonly Mock<IDeletableEntityRepository<WritingUtensil>> mockRepo;

        public UpdateWritingUtensilCommandHandlerTest()
        {
            this.mockRepo = WritingUtensilMockRepository.GetWritingUtensilMockRepo();
        }

        [Fact]
        public async Task ShouldReturnIntTest()
        {
            var handler = new UpdateUtensilsHandler(this.mockRepo.Object);

            var result = await handler.Handle(new UpdateUtensilsCommand
            {
                Id = 1,
                Price = 40,
                Name = "PEN",
                Manufacturer = "Orange",
                Color = "red",
                WritingUtensilsType = "Marker",
            }, CancellationToken.None);

            result.ShouldBeOfType<Int32>();
            Assert.Equal(1, result);
        }

        [Fact]
        public async Task ShouldThrowNullReferenceExceptionTest()
        {
            var handler = new UpdateUtensilsHandler(this.mockRepo.Object);

            await Assert.ThrowsAsync<InvalidOperationException>(() => handler.Handle(new UpdateUtensilsCommand(), CancellationToken.None));
        }

        [Fact]
        public async Task UpdatePublicationTest()
        {
            var handler = new UpdateUtensilsHandler(this.mockRepo.Object);

            var result = await handler.Handle(new UpdateUtensilsCommand
            {
                Id = 1,
                Price = 40,
                Name = "PEN",
                Manufacturer = "Orange",
                Color = "red",
                WritingUtensilsType = "Marker",
            }, CancellationToken.None);
            Assert.Equal("PEN", this.mockRepo.Object.All().FirstOrDefault(x => x.Id == 1).Name);
        }
    }
}
