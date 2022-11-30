namespace BookShop.Tests.Publications.Commands
{
    using BookShop.Application;
    using BookShop.Application.Publications.Commands.UpdatePublication;
    using BookShop.Application.Repositories;
    using BookShop.Domain;
    using BookShop.Tests.Mocks;

    using Moq;
    using Shouldly;
    using Xunit;

    public class UpdatePublicationCommandHandlerTest
    {
        private readonly Mock<IDeletableEntityRepository<Publication>> mockRepo;

        public UpdatePublicationCommandHandlerTest()
        {
            this.mockRepo = PublicationMockRepository.GetPublicationMockRepo();
        }


        [Fact]
        public async Task ShouldReturnIntTest()
        {
            var handler = new UpdatePublicationHandler(this.mockRepo.Object);

            var result = await handler.Handle(new UpdatePublicationCommand
            {
                Id = 2,
                Price = 10234423,
                Name = "The Boys from Biloxi",
                Author = "Grisham",
                PageCount = 423400,
                Description = "Some description",
                Genre = new GenreDto { Name = "Horror" },
                PublicationType = "Book",
            }, CancellationToken.None);

            result.ShouldBeOfType<Int32>();
        }

        [Fact]
        public async Task ShouldThrowNullReferenceExceptionTest()
        {
            var handler = new UpdatePublicationHandler(this.mockRepo.Object);

            await Assert.ThrowsAsync<NullReferenceException>(() => handler.Handle(new UpdatePublicationCommand(), CancellationToken.None));
        }

        [Fact]
        public async Task UpdatePublicationTest()
        {
            var handler = new UpdatePublicationHandler(this.mockRepo.Object);

            var result = await handler.Handle(new UpdatePublicationCommand
            {
                Id = 1,
                Price = 10000,
                Name = "The Boys from Biloxi",
                Author = "Grisham",
                PageCount = 400,
                Description = "Some description",
                Genre = new GenreDto { Name = "Horror" },
                PublicationType = "Book",
            }, CancellationToken.None);
            Assert.Equal(10000, this.mockRepo.Object.All().FirstOrDefault(x => x.Id == 1).Price);         
        }
    }
}
