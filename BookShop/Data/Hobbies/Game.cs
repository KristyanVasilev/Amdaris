using Data.Hobbies.Enums;

namespace Data.Hobbies
{
    public abstract class Game
    {
        private string name;
        private decimal price;
        private string manufacturer;
        private string description;

        public Game(string name, decimal price, string manufacturer, string description, GameType gameType)
        {
            this.Name = name;
            this.Price = price;
            this.Manufacturer = manufacturer;
            this.Description = description;
            this.GameType = gameType;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or empty!");
                }
                name = value;
            }
        }

        public decimal Price
        {
            get { return price; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price cannot be negative or equal to zero!");
                }
                price = value;
            }
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
    }
}
