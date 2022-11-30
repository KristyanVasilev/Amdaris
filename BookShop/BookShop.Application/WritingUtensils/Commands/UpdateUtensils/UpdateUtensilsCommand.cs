namespace BookShop.Application.WritingUtensils.Commands.UpdateUtensils
{
    using MediatR;

    public class UpdateUtensilsCommand : BaseProductDto, IRequest<int>
    {
        public string Color { get; set; } = null!;

        public string Manufacturer { get; set; } = null!;

        public string WritingUtensilsType { get; set; } = null!;
    }
}
