namespace BookShop.Domain.Hobbies
{
    using BookShop.Domain.Hobbies.Enums;
    using System.Text;

    public class Game : Product
    {
        public string Manufacturer { get; set; } = null!;

        public string Description { get; set; } = null!;

        public GameType GameType { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString());
            sb.AppendLine($"The game is {this.GameType.ToString()}.");
            sb.AppendLine($"Manufacturer: {this.Manufacturer}.");
            sb.AppendLine($"Description: {this.Description}.");
            return sb.ToString().TrimEnd();
        }
    }
}
