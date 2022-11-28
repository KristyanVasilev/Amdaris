namespace BookShop.Infrastructure
{
    using BookShop.Application.Contracts;
    using BookShop.Domain;

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

        public string DeleteGame(int id)
        {
            var gameToRemove = GetSingleGame(id);
            this.games.Remove(gameToRemove);

            return $"Game with Id - {id} deleted succesufuly!";
        }

        public IEnumerable<Game> GetGames()
        {
            return this.games;
        }

        public Game GetSingleGame(int id)
        {
            var result = this.games.FirstOrDefault(x => x.Id == id);
            if (result == null)
            {
                throw new InvalidOperationException("Game not found!");
            }

            return result;
        }
    }
}
