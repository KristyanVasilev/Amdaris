namespace BookShop.Data.ApplicationUser
{
    using System.Text;

    public class ApplicationUser
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"User: {this.FirstName} {this.LastName} with Id - {this.Id}");
            sb.AppendLine($"Email: {this.Email}");

            return sb.ToString();
        }
    }
}
