namespace BookShop.Application.Publications.Queries.GetPublicationByAuthor
{
    using BookShop.Application.Repositories;
    using BookShop.Application.SeedWork.Exceptions;
    using BookShop.Domain;
    using MediatR;

    public class GetPublicationByAuthorHandler : IRequestHandler<GetPublicationByAuthorQuery, IEnumerable<PublicationDto>>
    {
        private readonly IDeletableEntityRepository<Publication> repository;

        public GetPublicationByAuthorHandler(IDeletableEntityRepository<Publication> repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<PublicationDto>> Handle(GetPublicationByAuthorQuery request, CancellationToken cancellationToken)
        {
            var result =
                this.repository
                    .AllAsNoTracking()
                    .Where(x => x.Author == request.AuthorName)
                    .Select(publication => new PublicationDto
                    {
                        Id = publication.Id,
                        Name = publication.Name,
                        Price = publication.Price,
                        Author = publication.Author,
                        PageCount = publication.PageCount,
                        Rating = publication.Rating,
                        Description = publication.Description,
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
