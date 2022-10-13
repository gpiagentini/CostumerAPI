using DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mapping
{
    public class CustomerBankInfoMappingConfiguration : IEntityTypeConfiguration<CustomerBankInfo>
    {
        public void Configure(EntityTypeBuilder<CustomerBankInfo> builder)
        {
            builder.ToTable("customerBankInfo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.AccountBalance)
                .HasColumnName("accountBalance")
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(x => x.CustomerId)
                .HasColumnName("customerId");
        }
    }
}
