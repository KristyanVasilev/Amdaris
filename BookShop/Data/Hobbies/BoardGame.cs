namespace Data.Hobbies
{
    using Data.Hobbies.Enums;

    public class BoardGame : Game
    {
        public BoardGame(string name, decimal price, string manufacturer, string description, GameType gameType)
         : base(name, price, manufacturer, description, gameType)
        {
            gameType = GameType.Board;
        }
    }
}
