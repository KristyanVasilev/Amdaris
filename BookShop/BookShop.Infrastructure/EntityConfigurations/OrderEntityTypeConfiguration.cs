namespace BookShop.Infrastructure.EntityConfigurations
{
    using BookShop.Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(u => u.UserName)
                  .IsRequired()
                  .HasMaxLength(50);

            builder.Property(e => e.Email)
                   .IsRequired();

            builder.Property(t => t.TotalPrice)
                   .IsRequired()
                   .HasColumnType("decimal(18,4)");
        }
    }
}
