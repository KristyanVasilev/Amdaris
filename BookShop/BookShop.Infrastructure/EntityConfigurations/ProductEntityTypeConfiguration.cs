namespace BookShop.Infrastructure.EntityConfigurations
{
    using BookShop.Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(n => n.Name)
                  .IsRequired()
                  .HasMaxLength(50);

            builder.Property(q => q.Quantity)
                   .IsRequired();

            builder.Property(p => p.Price)
                   .IsRequired()
                   .HasColumnType("decimal(18,4)");
        }
    }
}
