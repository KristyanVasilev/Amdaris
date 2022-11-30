namespace BookShop.Tests.WritingUtensils.Commands
{
    using BookShop.Application.Repositories;
    using BookShop.Application.WritingUtensils.Commands.CreateUtensils;
    using BookShop.Domain;
    using BookShop.Tests.Mocks;

    using Moq;
    using Shouldly;
    using Xunit;

    public class CreateWritingUtensilCommandHandlerTest
    {
        private readonly Mock<IDeletableEntityRepository<WritingUtensil>> mockRepo;

        public CreateWritingUtensilCommandHandlerTest()
        {
            this.mockRepo = WritingUtensilMockRepository.GetWritingUtensilMockRepo();
        }

        [Fact]
        public async Task CreateWritingUtensilTest()
        {
            var handler = new CreateUtensilsHandler(this.mockRepo.Object);

            var result = await handler.Handle(new CreateUtensilsCommand
            {
                Id = 3,
                Price = 40,
                Name = "Marker",
                Manufacturer = "Orange",
                Color = "red",
                WritingUtensilsType = new WritingUtensilsTypeDto { Name = "Marker" },
            }, CancellationToken.None);

            var count = this.mockRepo.Object.All().Count();
            Assert.Equal(1, this.mockRepo.Object.All().FirstOrDefault(x => x.Id == 1).Id);

            Assert.True(count == 3);
        }

        [Fact]
        public async Task ShouldReturnIntTest()
        {
            var handler = new CreateUtensilsHandler(this.mockRepo.Object);

            var result = await handler.Handle(new CreateUtensilsCommand
            {
                Id = 3,
                Price = 40,
                Name = "Marker",
                Manufacturer = "Orange",
                Color = "red",
                WritingUtensilsType = new WritingUtensilsTypeDto { Name = "Marker" },
            }, CancellationToken.None);

            result.ShouldBeOfType<Int32>();
        }

        [Fact]
        public async Task ShouldThrowNullReferenceExceptionTest()
        {
            var handler = new CreateUtensilsHandler(this.mockRepo.Object);

            await Assert.ThrowsAsync<NullReferenceException>(() => handler.Handle(new CreateUtensilsCommand(), CancellationToken.None));
        }
    }
}
