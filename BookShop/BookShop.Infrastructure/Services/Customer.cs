namespace BookShop.Infrastructure.Services
{
    using System.Linq;
    using System.Text;

    using BookShop.Data;
    using BookShop.Data.ApplicationUser;
    using BookShop.Infrastructure.Contracts;
    using BookShop.Infrastructure.CustomExceptions;

    public class Customer : ApplicationUser, ICustomer
    {
        private Order order;
        private decimal balance;
        private int counter = 1;

        public Customer()
        {
            order = new Order();
            Balance = balance;
            Orders = new List<Order>();
            Watchlist = new HashSet<Product>();
        }

        public decimal Balance
        {
            get { return balance; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("balance cannot be negative!");
                }
                balance = value;
            }
        }

        public ICollection<Order> Orders { get; private set; }

        public ICollection<Product> Watchlist { get; private set; }

        public string AddToOrder(Product product)
        {
            if (order.IsCompleted)
            {
                counter++;
                order = new Order { Id = counter, UserId = Id };
            }

            order.Products.Add(product);
            if (!Orders.Contains(order))
            {
                Orders.Add(order);
            }

            return $"Product {product.Name} added successfuly to Order with Id-{order.Id}";
        }

        public string Buy()
        {
            CheckOrderIsValid();
            CheckBalanceAmount(order.Products.Sum(p => p.Price));

            Balance -= order.Products.Sum(p => p.Price);
            order.IsCompleted = true;

            var sb = new StringBuilder();
            sb.AppendLine($"Successfuly completed order with Id-{order.Id} with products:");
            foreach (var product in order.Products)
            {
                sb.AppendLine($"-{product.Name}");
            }
            sb.AppendLine("Thanks for buying! :D");

            return sb.ToString().TrimEnd();
        }

        public string Deposit(decimal amount)
        {
            CheckAmount(amount);

            Balance += amount;

            return $"Successfuly deposited {amount}$";
        }

        public string Withdraw(decimal amount)
        {
            CheckBalanceAmount(amount);
            CheckAmount(amount);

            Balance -= amount;

            return $"Successfuly withdrawed {amount}$";
        }

        public string AddToWatchlist(Product product)
        {
            Watchlist.Add(product);

            return $"Successfuly added product {product.Name} to watchlist!";
        }

        public string RemoveProductFromWatchlist(Product product)
        {
            if (!Watchlist.Contains(product))
            {
                throw new ProductNotFoundException("Product not found!");
            }

            Watchlist.Remove(product);

            return $"Successfuly removed product {product.Name} to watchlist!";
        }

        public string UserInfo()
        {
            var sb = new StringBuilder(base.ToString());
            foreach (var currOrder in Orders)
            {
                sb.AppendLine($"Order Id - {currOrder.Id} with items {currOrder.Products.Count}:");
                foreach (var product in currOrder.Products.OrderByDescending(x => x.Name))
                {
                    sb.AppendLine($"    -{product.Name}");
                }
            }
            if (Watchlist.Any())
            {
                sb.AppendLine($"Products in wachtlist:");
            }
            foreach (var currProduct in Watchlist)
            {
                sb.AppendLine($"    -{currProduct.Name} ");
            }

            return sb.ToString().TrimEnd();
        }

        private void CheckBalanceAmount(decimal amount)
        {
            if (Balance <= 0 || Balance - amount < 0)
            {
                throw new ZeroOrNegativeBalanceException("Your balance cannot be zero or negative!");
            }
        }

        private void CheckOrderIsValid()
        {
            if (order.Products.Count == 0 || order.IsCompleted == true)
            {
                throw new InvalidOrderException("Invalid Order!");
            }
        }

        private static void CheckAmount(decimal amount)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException("Amount cannot be zero or negative number!");
            }
        }
    }
}
