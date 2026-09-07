using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Configurations
{
    public class ProductConfiguration :IEntityTypeConfiguration<Product>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(P => P.Id);
            builder.Property(P => P.Id).UseIdentityColumn(1, 1);
            builder.Property(P => P.Name).IsRequired().HasMaxLength(50);
            builder.Property(P => P.Price).IsRequired().HasColumnType("decimal(18,2)");
        }
    }
}
