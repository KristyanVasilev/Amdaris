namespace BookShop.Infrastructure.EntityConfigurations
{
    using BookShop.Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Newtonsoft.Json;

    public class PublicationEntityTypeConfiguration : IEntityTypeConfiguration<Publication>
    {
        public void Configure(EntityTypeBuilder<Publication> builder)
        {
            builder.Property(n => n.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(a => a.Author)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(p => p.Price)
                   .IsRequired()
                   .HasColumnType("decimal(18,4)");

            builder.Property(p => p.PageCount)
                   .IsRequired();

            builder.Property(d => d.Description)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(i => i.Images)
                   .HasConversion(v => JsonConvert.SerializeObject(v),
                                  v => JsonConvert.DeserializeObject<string[]>(v) ?? new string[] { "No Images" });
        }
    }
}