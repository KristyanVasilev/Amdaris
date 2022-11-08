namespace Data.Hobbies
{
    using Data.Hobbies.Enums;

    public class Family : Game
    {
        public Family(int id, decimal price, string name, string manufacturer, string description, GameType gameType) 
            : base(id, price, name, manufacturer, description, gameType)
        {
        }
    }
}
