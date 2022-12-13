namespace BookShop.Application.Games.Commands.CreateGame
{
    using MediatR;

    public class CreateGameCommand : GameDto, IRequest<int>
    {
    }
}
