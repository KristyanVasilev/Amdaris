namespace BookShop.Application.WritingUtensils.Queries.GetUtensilByKeyWord
{
    using BookShop.Application.Repositories;
    using BookShop.Application.SeedWork.Exceptions;
    using BookShop.Domain;
    using MediatR;

    public class GetUtensilByKeyWordHandler : IRequestHandler<GetUtensilByKeyWordQuery, IEnumerable<WritingUtensilDto>>
    {
        private readonly IDeletableEntityRepository<WritingUtensil> repository;

        public GetUtensilByKeyWordHandler(IDeletableEntityRepository<WritingUtensil> repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<WritingUtensilDto>> Handle(GetUtensilByKeyWordQuery request, CancellationToken cancellationToken)
        {
            var result = this.repository.AllAsNoTracking().Where(k => k.KeyWords.Contains(request.KeyWord)).Select(utensil => new WritingUtensilDto
            {
                Id = utensil.Id,
                Name = utensil.Name,
                Price = utensil.Price,
                Color = utensil.Color,
                Manufacturer = utensil.Manufacturer,
                KeyWords = utensil.KeyWords,
                Quantity = utensil.Quantity,
                Images = utensil.Images,
                WritingUtensilsType = utensil.WritingUtensilsType.Name,

            }).OrderBy(x => x.Price);

            if (!result.Any())
            {
                throw new WritingUtensilNotFoundException("No Utensils found!");
            }

            return await Task.FromResult(result);
        }
    }
}
