namespace Data.Hobbies
{
    using Data.Hobbies.Enums;

    public class Chess : Game
    {
        public Chess(int id, decimal price, string name, string manufacturer, string description, GameType gameType)
            : base(id, price, name, manufacturer, description, gameType)
        {
            base.GameType = GameType.Board;
        }
    }
}
