namespace BookShop.Tests.Mocks
{
    using BookShop.Application.Repositories;
    using BookShop.Application.WritingUtensils.Commands.CreateUtensils;
    using BookShop.Domain;
    using Moq;

    public class WritingUtensilMockRepository
    {
        public static Mock<IDeletableEntityRepository<WritingUtensil>> GetWritingUtensilMockRepo()
        {
            var mockRepo = new Mock<IDeletableEntityRepository<WritingUtensil>>();

            var list = new List<WritingUtensil>()
            {
                new WritingUtensil
                {
                   Id = 1,
                   Price = 30,
                   Name = "Pen",
                   Manufacturer = "Orange",
                   Color = "red",
                   WritingUtensilsType = new WritingUtensilsTypeDto { Name = "Pen" },
                },
                new WritingUtensil
                {
                   Id = 2,
                   Price = 40,
                   Name = "Marker",
                   Manufacturer = "Orange",
                   Color = "red",
                   WritingUtensilsType = new WritingUtensilsTypeDto { Name = "Marker" },                  
                },
            };

            mockRepo.Setup(r => r.All()).Returns(list.Where(x => x.IsDeleted == false).AsQueryable());
            mockRepo.Setup(r => r.AllAsNoTracking()).Returns(list.Where(x => x.IsDeleted == false).AsQueryable());
            mockRepo.Setup(r => r.AllAsNoTrackingWithDeleted()).Returns(list.AsQueryable());
            mockRepo.Setup(r => r.Delete(It.IsAny<WritingUtensil>()))
                                 .Callback((WritingUtensil writingUtensil) => list.Remove(writingUtensil));
            mockRepo.Setup(r => r.AddAsync(It.IsAny<WritingUtensil>()))
                                 .Callback((WritingUtensil writingUtensil) => list.Add(writingUtensil));

            return mockRepo;
        }
    }
}
