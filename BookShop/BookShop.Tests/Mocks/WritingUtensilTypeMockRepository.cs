namespace BookShop.Tests.Mocks
{
    using BookShop.Application.Repositories;
    using BookShop.Domain;
    using Moq;

    public class WritingUtensilTypeMockRepository
    {
        public static Mock<IRepository<WritingUtensilsType>> GetWritingUtensilTypeMockRepo()
        {
            var mockRepo = new Mock<IRepository<WritingUtensilsType>>();

            var list = new List<WritingUtensilsType>()
            {
                new WritingUtensilsType
                {
                    Id = 1,
                    Name = "Pen",
                    CreatedOn = DateTime.Now,
                },
                new WritingUtensilsType
                {
                    Id = 2,
                    Name = "Pensil",
                    CreatedOn = DateTime.Now,
                },
            };

            mockRepo.Setup(r => r.All()).Returns(list.AsQueryable());
            mockRepo.Setup(r => r.AllAsNoTracking()).Returns(list.AsQueryable());
            mockRepo.Setup(r => r.Delete(It.IsAny<WritingUtensilsType>()))
                                 .Callback((WritingUtensilsType writingUtensilsType) => list.Remove(writingUtensilsType));
            mockRepo.Setup(r => r.AddAsync(It.IsAny<WritingUtensilsType>()))
                                 .Callback((WritingUtensilsType writingUtensilsType) => list.Add(writingUtensilsType));

            return mockRepo;
        }
    }
}
