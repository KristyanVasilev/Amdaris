namespace BookShop.Tests.Mocks
{
    using BookShop.Application.Repositories;
    using BookShop.Domain;
    using Moq;

    public class GenreMockRepository
    {
        public static Mock<IRepository<Genre>> GetGenreMockRepo()
        {
            var mockRepo = new Mock<IRepository<Genre>>();

            var list = new List<Genre>()
            {
                new Genre
                {
                    Id = 1,
                    Name = "Horror",
                    CreatedOn = DateTime.Now,
                },
                new Genre
                {
                    Id = 2,
                    Name = "Strategy",
                    CreatedOn = DateTime.Now,
                },
            };

            mockRepo.Setup(r => r.All()).Returns(list.AsQueryable());
            mockRepo.Setup(r => r.AllAsNoTracking()).Returns(list.AsQueryable());
            mockRepo.Setup(r => r.Delete(It.IsAny<Genre>()))
                                 .Callback((Genre genre) => list.Remove(genre));
            mockRepo.Setup(r => r.AddAsync(It.IsAny<Genre>()))
                                 .Callback((Genre genre) => list.Add(genre));

            return mockRepo;
        }
    }
}
