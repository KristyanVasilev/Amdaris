namespace BookShop.Application.Games.Commands.UpdateGame
{
    using MediatR;

    public class UpdateGameCommand : GameDto, IRequest<int>
    {
    }
}
