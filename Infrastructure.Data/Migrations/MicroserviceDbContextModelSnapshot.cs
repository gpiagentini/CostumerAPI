﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(MicroserviceDbContext))]
    partial class MicroserviceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DomainModels.CustomerBankInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<decimal>("AccountBalance")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(65,30)")
                        .HasDefaultValue(0m)
                        .HasColumnName("accountBalance");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("customerId");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.ToTable("customerBankInfo", (string)null);
                });

            modelBuilder.Entity("DomainModels.CustomerBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("address");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("birthdate");

                    b.Property<string>("Cellphone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("cellphone");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("city");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("country");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)")
                        .HasColumnName("cpf");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("email");

                    b.Property<bool>("EmailSms")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("emailSms");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("fullName");

                    b.Property<int>("Number")
                        .HasColumnType("int")
                        .HasColumnName("number");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("varchar(9)")
                        .HasColumnName("postalCode");

                    b.Property<bool>("Whatsapp")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("whatsapp");

                    b.HasKey("Id");

                    b.HasIndex("Cpf")
                        .IsUnique();

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("customer", (string)null);
                });

            modelBuilder.Entity("DomainModels.CustomerBankInfo", b =>
                {
                    b.HasOne("DomainModels.CustomerBase", "Customer")
                        .WithOne("BankInfo")
                        .HasForeignKey("DomainModels.CustomerBankInfo", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("DomainModels.CustomerBase", b =>
                {
                    b.Navigation("BankInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
