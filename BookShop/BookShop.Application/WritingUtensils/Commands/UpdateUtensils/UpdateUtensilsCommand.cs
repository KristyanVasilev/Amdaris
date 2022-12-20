namespace BookShop.Application.WritingUtensils.Commands.UpdateUtensils
{
    using MediatR;

    public class UpdateUtensilsCommand : WritingUtensilDto, IRequest<int>
    {
    }
}
