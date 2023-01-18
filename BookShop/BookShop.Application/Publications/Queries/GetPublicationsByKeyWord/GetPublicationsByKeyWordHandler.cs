namespace BookShop.Application.Publications.Queries.GetPublicationsByKeyWord
{
    using BookShop.Application.Repositories;
    using BookShop.Application.SeedWork.Exceptions;
    using BookShop.Domain;
    using MediatR;

    public class GetPublicationsByKeyWordHandler : IRequestHandler<GetPublicationsByKeyWordQuery, IEnumerable<PublicationDto>>
    {
        private readonly IDeletableEntityRepository<Publication> repository;

        public GetPublicationsByKeyWordHandler(IDeletableEntityRepository<Publication> repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<PublicationDto>> Handle(GetPublicationsByKeyWordQuery request, CancellationToken cancellationToken)
        {
            var result = this.repository.AllAsNoTracking().Where(k => k.KeyWords.Contains(request.KeyWord)).Select(publication => new PublicationDto
            {
                Id = publication.Id,
                Name = publication.Name,
                Price = publication.Price,
                Author = publication.Author,
                PageCount = publication.PageCount,
                Rating = publication.Rating,
                Description = publication.Description,
                KeyWords = publication.KeyWords,
                Quantity = publication.Quantity,
                Images = publication.Images,
                Genre = publication.Genre.Name,

            }).OrderBy(x => x.Price);

            if (!result.Any())
            {
                throw new PublicationNotFoundException("No Publications found!");
            }

            return await Task.FromResult(result);
        }
    }
}
