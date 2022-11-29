namespace BookShop.Tests.Mocks
{
    using BookShop.Application.Repositories;
    using BookShop.Domain;
    using Moq;

    public class PublicationMockRepository
    {
        public static Mock<IDeletableEntityRepository<Publication>> GetPublicationMockRepo()
        {
            var mockRepo = new Mock<IDeletableEntityRepository<Publication>>();

            var list = new List<Publication>()
            {
                new Publication
                {
                    Id = 1,
                    Price = 10,
                    Name = "The Boys from Biloxi",
                    Author = "John Grisham",
                    PageCount = 400,
                    Description = "Some description",
                    Genre = new Genre { Name = "Horror" },
                },
                new Publication
                {
                    Id = 2,
                    Price = 10,
                    Name = "Test",
                    Author = "John",
                    PageCount = 40,
                    Description = "description",
                    Genre = new Genre { Name = "Thriller" },
                },
            };

            mockRepo.Setup(r => r.All()).Returns(list.AsQueryable());
            mockRepo.Setup(r => r.AllAsNoTracking()).Returns(list.AsQueryable());
            mockRepo.Setup(r => r.AddAsync(It.IsAny<Publication>()))
                                 .Callback((Publication publication) => list.Add(publication));

            return mockRepo;
        }
    }
}
