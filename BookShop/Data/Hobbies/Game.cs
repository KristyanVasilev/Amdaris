using Data.Hobbies.Enums;
using System.Text;

namespace Data.Hobbies
{
    public abstract class Game : Product
    {
        private string manufacturer;
        private string description;

        protected Game(int id, decimal price, string name, string manufacturer, string description, GameType gameType)
            : base(id, price, name)
        {
            this.Manufacturer = manufacturer;
            this.Description = description;
            this.GameType = gameType;
        }

        public string Manufacturer
        {
            get { return manufacturer; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Manufacturer cannot be null or empty!");
                }
                manufacturer = value;
            }
        }

        public string Description
        {
            get { return description; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Description cannot be null or empty!");
                }
                description = value;
            }
        }

        public GameType GameType { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString());
            sb.AppendLine($"The game is {this.GameType.ToString()}.");
            sb.AppendLine($"Manufacturer: {this.manufacturer}.");
            sb.AppendLine($"Description; {this.Description}.");
            return sb.ToString().TrimEnd();
        }
    }
}
