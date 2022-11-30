namespace BookShop.Tests.Mocks
{
    using BookShop.Application.Repositories;
    using BookShop.Domain;
    using Moq;

    public class GameMockRepository
    {
        public static Mock<IDeletableEntityRepository<Game>> GetGameMockRepo()
        {
            var mockRepo = new Mock<IDeletableEntityRepository<Game>>();

            var list = new List<Game>()
            {
                new Game
                {
                    Id = 1,
                    Price = 140,
                    Name = "Chess",
                    Manufacturer = "Some carpenter",
                    Description = "Some description",
                    Genre = new Genre { Name = "Board" },
                },
                new Game
                {
                    Id = 2,
                    Price = 140,
                    Name = "Monopoly",
                    Manufacturer = "Some genius",
                    Description = "Some description",
                    Genre = new Genre { Name = "Strategy" },
                },
            };

            mockRepo.Setup(r => r.All()).Returns(list.Where(x => x.IsDeleted == false).AsQueryable());
            mockRepo.Setup(r => r.AllAsNoTracking()).Returns(list.Where(x => x.IsDeleted == false).AsQueryable());
            mockRepo.Setup(r => r.AllAsNoTrackingWithDeleted()).Returns(list.AsQueryable());
            mockRepo.Setup(r => r.Delete(It.IsAny<Game>()))
                                 .Callback((Game game) => list.Remove(game));
            mockRepo.Setup(r => r.AddAsync(It.IsAny<Game>()))
                                 .Callback((Game game) => list.Add(game));

            return mockRepo;
        }
    }
}
