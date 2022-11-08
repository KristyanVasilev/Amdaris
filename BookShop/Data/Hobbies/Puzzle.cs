namespace Data.Hobbies
{
    using Data.Hobbies.Enums;

    public class Puzzle : Game
    {
        public Puzzle(string name, decimal price, string manufacturer, string description, GameType gameType)
            : base(name, price, manufacturer, description, gameType)
        {
            gameType = GameType.Strategy;
        }
    }
}
