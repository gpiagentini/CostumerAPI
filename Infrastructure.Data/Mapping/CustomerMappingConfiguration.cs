using DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mapping
{
    public class CustomerMappingConfiguration : IEntityTypeConfiguration<CustomerBase>
    {
        public void Configure(EntityTypeBuilder<CustomerBase> builder)
        {
            builder
                .ToTable("customer");

            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Id)
                .HasColumnName("id");

            builder
                .Property(e => e.FullName)
                .IsRequired()
                .HasColumnName("fullName");

            builder
                .Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("email");

            builder
                .Property(e => e.Cpf)
                .IsRequired()
                .HasMaxLength(11)
                .HasColumnName("cpf");

            builder
                .HasIndex(e => e.Cpf)
                .IsUnique();

            builder
                .Property(e => e.Cellphone)
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnName("cellphone");

            builder
                .Property(e => e.Birthdate)
                .IsRequired()
                .HasColumnName("birthdate");

            builder
                .Property(e => e.EmailSms)
                .IsRequired()
                .HasColumnName("emailSms");

            builder
                .Property(e => e.Whatsapp)
                .IsRequired()
                .HasColumnName("whatsapp");

            builder
                .Property(e => e.Country)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("country");

            builder
                .Property(e => e.City)
                .IsRequired()
                .HasMaxLength(60)
                .HasColumnName("city");

            builder
                .Property(e => e.PostalCode)
                .IsRequired()
                .HasMaxLength(9)
                .HasColumnName("postalCode");

            builder
                .Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("address");

            builder
                .Property(e => e.Number)
                .IsRequired()
                .HasColumnName("number");
        }
    }
}
