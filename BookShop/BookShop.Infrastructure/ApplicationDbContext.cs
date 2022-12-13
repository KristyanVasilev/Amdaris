namespace BookShop.Infrastructure
{
    using BookShop.Domain;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Game> Games { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Publication> Publications { get; set; }

        public DbSet<WritingUtensil> WritingUtensils { get; set; }

        public DbSet<WritingUtensilsType> WritingUtensilsTypes { get; set; }
    }
}
