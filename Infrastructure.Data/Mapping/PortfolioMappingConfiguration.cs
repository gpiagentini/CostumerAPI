using DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Mapping
{
    public class PortfolioMappingConfiguration : IEntityTypeConfiguration<Portfolio>
    {
        public void Configure(EntityTypeBuilder<Portfolio> builder)
        {
            builder.ToTable("portfolio");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasColumnName("id");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasMaxLength(100);

            builder.HasIndex(x => x.Name)
                .IsUnique();

            builder.Property(x => x.Description)
                .HasMaxLength(150)
                .HasColumnName("description");

            builder.Property(x => x.TotalBalance)
                .HasDefaultValue(0)
                .HasColumnName("totalBalance");

            builder.Property(x => x.CustomerId)
                .HasColumnName("customerId");

            builder.HasOne(p => p.Customer)
                .WithMany(c => c.Portfolios)
                .HasForeignKey(p => p.CustomerId);
        }
    }
}
