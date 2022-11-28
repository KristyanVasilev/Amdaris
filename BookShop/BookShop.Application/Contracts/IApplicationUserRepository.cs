namespace BookShop.Application.Contracts
{
    using BookShop.Domain;

    public interface IApplicationUserRepository
    {
        IEnumerable<ApplicationUser> GetUsers();

        ApplicationUser GetUser(int id);

        void CreateUser(ApplicationUser user);
    }
}
