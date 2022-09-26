﻿using DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mapping
{
    public class PorfolioProductMappingConfiguration : IEntityTypeConfiguration<PortfolioProduct>
    {
        public void Configure(EntityTypeBuilder<PortfolioProduct> builder)
        {
            builder.ToTable("portfolioProduct");

            builder.Property(x => x.PortfolioId)
                .IsRequired()
                .HasColumnName("portfolioId");

            builder.Property(x => x.ProductId)
                .IsRequired()
                .HasColumnName("productId");

            builder.HasKey(x => new { x.PortfolioId, x.ProductId });

            builder.HasOne(pp => pp.Portfolio)
                .WithMany(po => po.Products)
                .HasForeignKey(pp => pp.PortfolioId);

            builder.HasOne(pp => pp.Product)
                .WithMany(po => po.Portfolios)
                .HasForeignKey(pp => pp.ProductId);
        }
    }
}
