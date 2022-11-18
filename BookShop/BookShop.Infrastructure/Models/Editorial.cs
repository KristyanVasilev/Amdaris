namespace BookShop.Infrastructure.Models
{
    using BookShop.Data;

    public class Editorial : AbstractPublisher<Product>
    {
        private static Editorial instance;
        private static readonly object padlock = new object();

        private Editorial()
        {
            System.Console.WriteLine("Constructor called");
        }

        public static Editorial Instance
        {
            get
            {
                if (instance == null)
                {
                    System.Console.WriteLine("Instance called");
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new Editorial();
                        }
                    }
                }
                return instance;
            }
            private set { }
        }
    }
}
