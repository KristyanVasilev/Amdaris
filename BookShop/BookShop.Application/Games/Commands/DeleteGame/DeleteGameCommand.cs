namespace BookShop.Application.Games.Commands.DeleteGame
{
    using MediatR;

    public class DeleteGameCommand : IRequest<string>
    {
        public DeleteGameCommand(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }
    }
}
