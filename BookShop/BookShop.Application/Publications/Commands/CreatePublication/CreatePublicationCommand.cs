namespace BookShop.Application.Publications.Commands.CreatePublication
{
    using MediatR;

    public class CreatePublicationCommand : PublicationDto, IRequest<int>
    {
    }
}
