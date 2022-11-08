namespace Data.Hobbies
{
    using Data.Hobbies.Enums;

    public class Puzzle : Game
    {
        public Puzzle(int id, decimal price, string name, string manufacturer, string description, GameType gameType)
            : base(id, price, name, manufacturer, description, gameType)
        {
            gameType = GameType.Strategy;
        }
    }
}
