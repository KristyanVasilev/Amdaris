namespace BookShop.Application.WritingUtensils.Commands.CreateUtensils
{
    using MediatR;

    public class CreateUtensilsCommand : BaseProductDto, IRequest<int>
    {
        public string Color { get; set; } = null!;

        public string Manufacturer { get; set; } = null!;

        public string WritingUtensilsType { get; set; } = null!;
    } 
}
