namespace BookShop.Tests.Publications.Commands
{
    using BookShop.Application;
    using BookShop.Application.Publications.Commands.UpdatePublication;
    using BookShop.Application.Repositories;
    using BookShop.Application.SeedWork.Exceptions;
    using BookShop.Domain;
    using BookShop.Tests.Mocks;

    using Moq;
    using Shouldly;
    using Xunit;

    public class UpdatePublicationCommandHandlerTest
    {
        private readonly Mock<IDeletableEntityRepository<Publication>> mockRepo;
        private readonly Mock<IRepository<Genre>> genreMockRepo;


        public UpdatePublicationCommandHandlerTest()
        {
            this.mockRepo = PublicationMockRepository.GetPublicationMockRepo();
            this.genreMockRepo = GenreMockRepository.GetGenreMockRepo();

        }

        [Fact]
        public async Task ShouldReturnIntTest()
        {
            var handler = new UpdatePublicationHandler(this.mockRepo.Object, this.genreMockRepo.Object);

            var result = await handler.Handle(new UpdatePublicationCommand
            {
                Id = 1,
                Price = 10,
                Name = "Harry Potter",
                Author = "Grisham",
                PageCount = 400,
                Description = "Some description",
                Genre = "Horror",
            }, CancellationToken.None);

            result.ShouldBeOfType<Int32>();
            Assert.Equal(1, result);
        }

        [Fact]
        public async Task ShouldThrowPublicationNotFoundExceptionTest()
        {
            var handler = new UpdatePublicationHandler(this.mockRepo.Object, this.genreMockRepo.Object);

            await Assert.ThrowsAsync<PublicationNotFoundException>(() => handler.Handle(new UpdatePublicationCommand(), CancellationToken.None));
        }

        [Fact]
        public async Task UpdatePublicationTest()
        {
            var handler = new UpdatePublicationHandler(this.mockRepo.Object, this.genreMockRepo.Object);

            var result = await handler.Handle(new UpdatePublicationCommand
            {
                Id = 1,
                Price = 10,
                Name = "Harry Potter",
                Author = "Grisham",
                PageCount = 400,
                Description = "Edited description",
                Genre = "Horror",
            }, CancellationToken.None);

            Assert.Equal(10, this.mockRepo.Object.All().First().Price);
            Assert.Equal("Harry Potter", this.mockRepo.Object.All().First().Name);
            Assert.Equal("Edited description", this.mockRepo.Object.All().First().Description);
        }
    }
}
