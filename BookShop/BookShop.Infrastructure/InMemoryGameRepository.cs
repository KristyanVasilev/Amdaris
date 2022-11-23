namespace BookShop.Infrastructure
{
    using BookShop.Application;
    using BookShop.Domain.Hobbies;

    public class InMemoryGameRepository : IGameRepository
    {

        private readonly List<Game> games;

        public InMemoryGameRepository()
        {
            this.games = new List<Game>();
        }

        public void CreateGame(Game game)
        {
            this.games.Add(game);
        }
    }
}
