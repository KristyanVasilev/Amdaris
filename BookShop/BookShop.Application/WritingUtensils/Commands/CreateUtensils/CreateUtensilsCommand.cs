namespace BookShop.Application.WritingUtensils.Commands.CreateUtensils
{
    using MediatR;

    public class CreateUtensilsCommand : BaseProductModel, IRequest<int>
    {
        public string Color { get; set; } = null!;

        public string Manufacturer { get; set; } = null!;

        public WritingUtensilsTypeDto WritingUtensilsType { get; set; } = null!;
    } 
}
