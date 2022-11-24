namespace BookShop.Application.Games.Commands.DeleteGame
{
    using BookShop.Application.Contracts;
    using MediatR;

    public class DeleteGameHandler : IRequestHandler<DeleteGameCommand, string>
    {
        private readonly IGameRepository repository;

        public DeleteGameHandler(IGameRepository repository)
        {
            this.repository = repository;
        }

        public Task<string> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(this.repository.DeleteGame(request.Id));
        }
    }
}
