using BookShop.Application;
using BookShop.Domain;
using BookShop.Domain.ApplicationUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Infrastructure
{
    public class InMemoryApplicationUserRepository : IApplicationUserRepository
    {
        private readonly List<ApplicationUser> users;

        public InMemoryApplicationUserRepository()
        {
            this.users = new List<ApplicationUser>();
        }

        public void CreateUser(ApplicationUser user)
        {
            this.users.Add(user);
        }

        public ApplicationUser GetUser(int id)
        {
            return this.users.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<ApplicationUser> GetUsers()
        {
            return this.users;
        }
    }
}
