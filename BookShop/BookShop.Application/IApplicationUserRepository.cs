namespace BookShop.Application
{
    using BookShop.Domain.ApplicationUser;

    public interface IApplicationUserRepository
    {
        IEnumerable<ApplicationUser> GetUsers();

        ApplicationUser GetUser(int id);

        void CreateUser(ApplicationUser user);
    }
}
