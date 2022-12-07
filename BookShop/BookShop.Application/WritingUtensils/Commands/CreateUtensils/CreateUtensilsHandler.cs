﻿namespace BookShop.Application.WritingUtensils.Commands.CreateUtensils
{
    using BookShop.Application.Repositories;
    using BookShop.Domain;
    using MediatR;

    public class CreateUtensilsHandler : IRequestHandler<CreateUtensilsCommand, int>
    {
        private readonly IDeletableEntityRepository<WritingUtensil> repository;
        private readonly IRepository<WritingUtensilsType> utensilRepository;

        public CreateUtensilsHandler(
            IDeletableEntityRepository<WritingUtensil> repository, 
            IRepository<WritingUtensilsType> utensilRepository)
        {
            this.repository = repository;
            this.utensilRepository = utensilRepository;
        }

        public async Task<int> Handle(CreateUtensilsCommand request, CancellationToken cancellationToken)
        {
            var type = this.utensilRepository
                            .AllAsNoTracking()
                            .FirstOrDefault(x => x.Name == request.WritingUtensilsType)
                            ?? new WritingUtensilsType { Name = request.WritingUtensilsType, CreatedOn = DateTime.UtcNow };

            var utensil = new WritingUtensil
            {
                Id = request.Id,
                Price = request.Price,
                Name = request.Name,
                Color = request.Color,
                Manufacturer = request.Manufacturer,
                WritingUtensilsType = type,
                CreatedOn = DateTime.UtcNow,
            };

            if (type.Id == 0) utensil.WritingUtensilsType = type;
            else utensil.WritingUtensilTypeId = type.Id;

            await this.repository.AddAsync(utensil);
            await this.repository.SaveChangesAsync();

            return await Task.FromResult(utensil.Id);
        }
    }
}
