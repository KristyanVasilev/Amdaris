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
        private readonly Mock<IRepository<WritingUtensilsType>> typeMockRepo;

        public CreateWritingUtensilCommandHandlerTest()
        {
            this.mockRepo = WritingUtensilMockRepository.GetWritingUtensilMockRepo();
            this.typeMockRepo = WritingUtensilTypeMockRepository.GetWritingUtensilTypeMockRepo();
        }

        [Fact]
        public async Task CreateWritingUtensilTest()
        {
            var handler = new CreateUtensilsHandler(this.mockRepo.Object, this.typeMockRepo.Object);

            var result = await handler.Handle(new CreateUtensilsCommand
            {
                Id = 3,
                Price = 40,
                Name = "Marker c",
                Manufacturer = "Orange",
                Color = "red",
                WritingUtensilsType = "Marker",
            }, CancellationToken.None);

            var count = this.mockRepo.Object.All().Count();
            var utensil = this.mockRepo.Object.AllAsNoTracking().Skip(2).First();

            Assert.Equal("Marker c", utensil.Name);
            Assert.Equal(40, utensil.Price);

            Assert.True(count == 3);
        }

        [Fact]
        public async Task ShouldReturnIntTest()
        {
            var handler = new CreateUtensilsHandler(this.mockRepo.Object, this.typeMockRepo.Object);

            var result = await handler.Handle(new CreateUtensilsCommand
            {
                Id = 3,
                Price = 40,
                Name = "Marker c",
                Manufacturer = "Orange",
                Color = "red",
                WritingUtensilsType = "Marker",
            }, CancellationToken.None);

            result.ShouldBeOfType<Int32>();
        }

        [Fact]
        public async Task ShouldTrowArgumentExceptionForCreatingAlreadyExistingUtensil()
        {
            var handler = new CreateUtensilsHandler(this.mockRepo.Object, this.typeMockRepo.Object);

            var result = new CreateUtensilsCommand
            {
                Id = 3,
                Price = 40,
                Name = "Marker",
                Manufacturer = "Orange",
                Color = "red",
                WritingUtensilsType = "Marker",
            };

            await Assert.ThrowsAsync<ArgumentException>(() =>
            handler.Handle(result, CancellationToken.None));
        }
    }
}
