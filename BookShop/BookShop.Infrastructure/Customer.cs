namespace BookShop.Infrastructure
{
    using System.Linq;
    using System.Text;

    using BookShop.Data;
    using BookShop.Data.User;
    using BookShop.Infrastructure.Contracts;
    using BookShop.Infrastructure.CustomExceptions;

    public class Customer : User, ICustomer
    {
        private Order order;

        public Customer(int id, string firstName, string lastName, string email, decimal balance) 
            : base(id, firstName, lastName, email, balance)
        {
            this.order = new Order(1, base.Id);
        }

        public string AddToOrder(Product product)
        {
            int counter = 2;

            if (this.order.IsCompleted)
            {
                this.order = new Order(counter, base.Id);
                counter++;
            }

            this.order.Products.Add(product);
            base.Orders.Add(order);

            return $"Product {product.Name} added successfuly to Order with Id-{order.Id}";
        }

        public string Buy()
        {
            CheckOrderIsValid();
            CheckBalanceAmount(this.order.Products.Sum(p => p.Price));

            this.Balance -= order.Products.Sum(p => p.Price);
            this.order.IsCompleted = true;

            var sb = new StringBuilder();
            sb.AppendLine($"Successfuly completed order with Id-{this.order.Id} with products:");
            foreach (var product in this.order.Products)
            {
                sb.AppendLine($"-{product.Name}");
            }
            sb.AppendLine("Thanks for buying! :D");

            return sb.ToString().TrimEnd();
        }

        public string Deposit(decimal amount)
        {
            CheckAmount(amount);

            base.Balance += amount;

            return $"Successfuly deposit {amount}$";
        }

        public string Withdraw(decimal amount)
        {
            CheckBalanceAmount(amount);
            CheckAmount(amount);

            base.Balance -= amount;

            return $"Successfuly withdraw {amount}$";
        }

        private void CheckBalanceAmount(decimal amount)
        {
            if (this.Balance <= 0 || (this.Balance - amount) < 0)
            {
                throw new ZeroOrNegativeBalanceException("Your balance cannot be zero or negative!");
            }
        }

        private void CheckOrderIsValid()
        {
            if (this.order.Products.Count == 0 || order.IsCompleted == true)
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
