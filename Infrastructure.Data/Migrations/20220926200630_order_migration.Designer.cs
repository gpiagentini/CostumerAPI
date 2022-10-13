﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(MicroserviceDbContext))]
    [Migration("20220926200630_order_migration")]
    partial class order_migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("DomainModels.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("Direction")
                        .HasColumnType("int")
                        .HasColumnName("direction");

                    b.Property<DateTime>("LiquidatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("liquidatedAt");

                    b.Property<decimal>("NetValue")
                        .HasColumnType("decimal(65,30)")
                        .HasColumnName("netValue");

                    b.Property<int>("PortfolioId")
                        .HasColumnType("int")
                        .HasColumnName("portfolioId");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("productId");

                    b.Property<int>("Quotes")
                        .HasColumnType("int")
                        .HasColumnName("quotes");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(65,30)")
                        .HasColumnName("unitPrice");

                    b.HasKey("Id");

                    b.HasIndex("PortfolioId");

                    b.HasIndex("ProductId");

                    b.ToTable("order", (string)null);
                });

            modelBuilder.Entity("DomainModels.Portfolio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("customerId");

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.Property<decimal>("TotalBalance")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(65,30)")
                        .HasDefaultValue(0m)
                        .HasColumnName("totalBalance");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("portfolio", (string)null);
                });

            modelBuilder.Entity("DomainModels.PortfolioProduct", b =>
                {
                    b.Property<int>("PortfolioId")
                        .HasColumnType("int")
                        .HasColumnName("portfolioId");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("productId");

                    b.HasKey("PortfolioId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("portfolioProduct", (string)null);
                });

            modelBuilder.Entity("DomainModels.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("DaysToExpire")
                        .HasColumnType("int")
                        .HasColumnName("daysToExpire");

                    b.Property<DateTime>("ExpirationAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("expirationAt");

                    b.Property<DateTime>("IssuanceAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("issuanceAt");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("symbol");

                    b.Property<int>("Type")
                        .HasColumnType("int")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.ToTable("product", (string)null);
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

            modelBuilder.Entity("DomainModels.Order", b =>
                {
                    b.HasOne("DomainModels.Portfolio", "Portfolio")
                        .WithMany("Orders")
                        .HasForeignKey("PortfolioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DomainModels.Product", "Product")
                        .WithMany("Orders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Portfolio");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DomainModels.Portfolio", b =>
                {
                    b.HasOne("DomainModels.CustomerBase", "Customer")
                        .WithMany("Portfolios")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("DomainModels.PortfolioProduct", b =>
                {
                    b.HasOne("DomainModels.Portfolio", "Portfolio")
                        .WithMany("Products")
                        .HasForeignKey("PortfolioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DomainModels.Product", "Product")
                        .WithMany("Portfolios")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Portfolio");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DomainModels.CustomerBase", b =>
                {
                    b.Navigation("BankInfo");

                    b.Navigation("Portfolios");
                });

            modelBuilder.Entity("DomainModels.Portfolio", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("DomainModels.Product", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Portfolios");
                });
#pragma warning restore 612, 618
        }
    }
}
