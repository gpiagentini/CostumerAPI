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
    public class ProductMappingConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("product");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnName("id");

            builder.Property(x => x.Symbol)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("symbol");

            builder.Property(x => x.IssuanceAt)
                .IsRequired()
                .HasColumnName("issuanceAt");

            builder.Property(x => x.ExpirationAt)
                .IsRequired()
                .HasColumnName("expirationAt");

            builder.Property(x => x.DaysToExpire)
                .IsRequired()
                .HasColumnName("daysToExpire");

            builder.Property(x => x.Type)
                .IsRequired()
                .HasColumnName("type");
        }   
    }
}
