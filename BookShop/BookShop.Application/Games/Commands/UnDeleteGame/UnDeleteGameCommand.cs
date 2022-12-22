namespace BookShop.Application.Games.Commands.UnDeleteGame
{
    using MediatR;

    public class UnDeleteGameCommand : IRequest<GameDto>
    {
        public UnDeleteGameCommand(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
