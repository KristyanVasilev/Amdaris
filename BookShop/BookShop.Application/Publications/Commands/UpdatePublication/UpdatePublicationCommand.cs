namespace BookShop.Application.Publications.Commands.UpdatePublication
{
    using MediatR;

    public class UpdatePublicationCommand : PublicationDto, IRequest<int>
    {
    }
}
