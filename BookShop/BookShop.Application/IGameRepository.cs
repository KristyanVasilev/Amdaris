namespace BookShop.Application
{
    using BookShop.Domain.Hobbies;

    public interface IGameRepository
    {
        void CreateGame(Game game);
    }
}
