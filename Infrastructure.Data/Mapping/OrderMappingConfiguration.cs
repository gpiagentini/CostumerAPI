using DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mapping
{
    public class OrderMappingConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("order");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(e => e.PortfolioId)
                .HasColumnName("portfolioId")
                .IsRequired();

            builder.HasOne(o => o.Portfolio)
                .WithMany(p => p.Orders)
                .HasForeignKey(o => o.PortfolioId);

            builder.Property(e => e.ProductId)
                .HasColumnName("productId")
                .IsRequired();

            builder.HasOne(o => o.Product)
                .WithMany(p => p.Orders)
                .HasForeignKey(o => o.ProductId);

            builder.Property(e => e.Quotes)
                .HasColumnName("quotes")
                .IsRequired();

            builder.Property(e => e.UnitPrice)
                .HasColumnName("unitPrice")
                .IsRequired();

            builder.Property(e => e.NetValue)
                .HasColumnName("netValue")
                .IsRequired();

            builder.Property(e => e.LiquidatedAt)
                .HasColumnName("liquidatedAt")
                .IsRequired();

            builder.Property(e => e.Direction)
                .HasColumnName("direction")
                .IsRequired();
        }
    }
}
