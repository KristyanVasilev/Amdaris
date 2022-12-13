namespace BookShop.Tests.Publications.Commands
{
    using BookShop.Application.Publications.Commands.CreatePublication;
    using BookShop.Application.Repositories;
    using BookShop.Domain;
    using BookShop.Tests.Mocks;

    using Moq;
    using Shouldly;
    using Xunit;

    public class CreatePublicationCommandHandlerTest
    {
        private readonly Mock<IDeletableEntityRepository<Publication>> mockRepo;
        private readonly Mock<IRepository<Genre>> genreMockRepo;

        public CreatePublicationCommandHandlerTest()
        {
            this.mockRepo = PublicationMockRepository.GetPublicationMockRepo();
            this.genreMockRepo = GenreMockRepository.GetGenreMockRepo();
        }

        [Fact]
        public async Task CreatePublicationTest()
        {
            var handler = new CreatePublicationHandler(this.mockRepo.Object, this.genreMockRepo.Object);

            var result = await handler.Handle(new CreatePublicationCommand
            {
                Id = 3,
                Price = 10,
                Name = "Harry Potter",
                Author = "Grisham",
                PageCount = 400,
                Description = "Some description",
                Genre = "Horror",
            }, CancellationToken.None);

            var count = this.mockRepo.Object.All().Count();
            var publication = this.mockRepo.Object.AllAsNoTracking().Skip(2).First();

            Assert.Equal("Harry Potter", publication.Name);
            Assert.Equal(10, publication.Price);

            Assert.True(count == 3);
        }

        [Fact]
        public async Task ShouldReturnIntTest()
        {
            var handler = new CreatePublicationHandler(this.mockRepo.Object, this.genreMockRepo.Object);

            var result = await handler.Handle(new CreatePublicationCommand
            {
                Id = 3,
                Price = 10,
                Name = "Harry Potter",
                Author = "Grisham",
                PageCount = 400,
                Description = "Some description",
                Genre = "Horror",
            }, CancellationToken.None);

            result.ShouldBeOfType<Int32>();
        }
    }
}
