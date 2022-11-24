namespace BookShop.Application.Games.Commands.DeleteGame
{
    using MediatR;

    public class DeleteGameCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
