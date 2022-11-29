﻿namespace BookShop.Tests.Publications.Commands
{
    using BookShop.Application;
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

        public CreatePublicationCommandHandlerTest()
        {
            this.mockRepo = PublicationMockRepository.GetPublicationMockRepo();
        }

        [Fact]
        public async Task CreatePublicationTest()
        {
            var handler = new CreatePublicationHandler(this.mockRepo.Object);

            var result = await handler.Handle(new CreatePublicationCommand
            {
                Id = 2,
                Price = 10,
                Name = "The Boys from Biloxi",
                Author = "Grisham",
                PageCount = 400,
                Description = "Some description",
                Genre = new GenreDto { Name = "Horror" },
                PublicationType = "Book",
            }, CancellationToken.None);

            var count = this.mockRepo.Object.All().Count();
            Assert.Equal(this.mockRepo.Object.All().FirstOrDefault(x => x.Id == 1).Id, 1);
            result.ShouldBeOfType<Int32>();

            Assert.True(count == 3);
        }

        [Fact]
        public async Task ShouldReturnIntTest()
        {
            var handler = new CreatePublicationHandler(this.mockRepo.Object);

            var result = await handler.Handle(new CreatePublicationCommand
            {
                Id = 2,
                Price = 10,
                Name = "The Boys from Biloxi",
                Author = "Grisham",
                PageCount = 400,
                Description = "Some description",
                Genre = new GenreDto { Name = "Horror" },
                PublicationType = "Book",
            }, CancellationToken.None);

            result.ShouldBeOfType<Int32>();
        }

        [Fact]
        public async Task ShouldThrowException()
        {
            var handler = new CreatePublicationHandler(this.mockRepo.Object);

            var ex = Assert.ThrowsAsync<NullReferenceException>(() => handler.Handle(new CreatePublicationCommand(), CancellationToken.None));
        }
    }
}