namespace BookShop.Application.WritingUtensils.Commands.CreateUtensils
{
    using MediatR;

    public class CreateUtensilsCommand : WritingUtensilDto, IRequest<int>
    {
    } 
}
