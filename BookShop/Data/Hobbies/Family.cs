namespace Data.Hobbies
{
    using Data.Hobbies.Enums;

    public class Family : Game
    {
        public Family(string name, decimal price, string manufacturer, string description, GameType gameType)
            : base(name, price, manufacturer, description, gameType)
        {
        }
    }
}
