namespace BookShop.Tests.WritingUtensils.Queries
{
    using BookShop.Application.Repositories;
    using BookShop.Application.SeedWork.Exceptions;
    using BookShop.Application.WritingUtensils;
    using BookShop.Application.WritingUtensils.Queries.GetUtensilById;
    using BookShop.Domain;
    using BookShop.Tests.Mocks;

    using Moq;
    using Shouldly;
    using Xunit;

    public class GetWritingUtensilByIdQueryHandlerTest
    {
        private readonly Mock<IDeletableEntityRepository<WritingUtensil>> mockRepo;
        private readonly Mock<IRepository<WritingUtensilsType>> typeMockRepo;

        public GetWritingUtensilByIdQueryHandlerTest()
        {
            this.mockRepo = WritingUtensilMockRepository.GetWritingUtensilMockRepo();
            this.typeMockRepo = WritingUtensilTypeMockRepository.GetWritingUtensilTypeMockRepo();
        }

        [Fact]
        public async Task GetSingleWritingUtensilTest()
        {
            var handler = new GetUtensilByIdHandler(this.mockRepo.Object, this.typeMockRepo.Object);

            var result = await handler.Handle(new GetUtensilByIdQuery(1), CancellationToken.None);

            result.ShouldBeOfType<WritingUtensilDto>();
        }

        [Fact]
        public async Task ShouldntChangeRepoCountTest()
        {
            var handler = new GetUtensilByIdHandler(this.mockRepo.Object, this.typeMockRepo.Object);

            var result = await handler.Handle(new GetUtensilByIdQuery(1), CancellationToken.None);

            var count = this.mockRepo.Object.All().Count();

            Assert.True(count == 2);
        }

        [Fact]
        public async Task ShouldThrowWritingUtensilNotFoundExceptionTest()
        {
            var handler = new GetUtensilByIdHandler(this.mockRepo.Object, this.typeMockRepo.Object);

            await Assert.ThrowsAsync<WritingUtensilNotFoundException>(() =>
            handler.Handle(new GetUtensilByIdQuery(12321), CancellationToken.None));
        }
    }
}
