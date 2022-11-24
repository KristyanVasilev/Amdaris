namespace BookShop.Application.Contracts
{
    using BookShop.Domain.Hobbies;

    public interface IGameRepository
    {
        void CreateGame(Game game);
    }
}
