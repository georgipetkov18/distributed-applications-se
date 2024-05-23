﻿// <auto-generated />
using System;
using InvestmentManagerApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InvestmentManagerApi.Data.Migrations
{
    [DbContext(typeof(InvestmentManagerDbContext))]
    partial class InvestmentManagerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InvestmentManagerApi.Data.Entities.Currency", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActivated")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ToEuroRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Currencies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("66e9e89e-41a1-47d3-a43a-b365ac9f0b16"),
                            Code = "EUR",
                            CreatedOn = new DateTime(2024, 5, 23, 19, 24, 20, 406, DateTimeKind.Utc).AddTicks(9291),
                            IsActivated = true,
                            Name = "Euro",
                            ToEuroRate = 1m,
                            UpdatedOn = new DateTime(2024, 5, 23, 19, 24, 20, 406, DateTimeKind.Utc).AddTicks(9293)
                        },
                        new
                        {
                            Id = new Guid("116d72aa-0815-41b4-bc3e-bd4ed357a8c6"),
                            Code = "BGN",
                            CreatedOn = new DateTime(2024, 5, 23, 19, 24, 20, 406, DateTimeKind.Utc).AddTicks(9305),
                            IsActivated = true,
                            Name = "Lev",
                            ToEuroRate = 1.95m,
                            UpdatedOn = new DateTime(2024, 5, 23, 19, 24, 20, 406, DateTimeKind.Utc).AddTicks(9306)
                        },
                        new
                        {
                            Id = new Guid("e61f4fee-912c-4562-b7c4-2f35e49d3fac"),
                            Code = "USD",
                            CreatedOn = new DateTime(2024, 5, 23, 19, 24, 20, 406, DateTimeKind.Utc).AddTicks(9327),
                            IsActivated = true,
                            Name = "American Dollar",
                            ToEuroRate = 0.93m,
                            UpdatedOn = new DateTime(2024, 5, 23, 19, 24, 20, 406, DateTimeKind.Utc).AddTicks(9328)
                        });
                });

            modelBuilder.Entity("InvestmentManagerApi.Data.Entities.Etf", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActivated")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SingleValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Etfs");
                });

            modelBuilder.Entity("InvestmentManagerApi.Data.Entities.Investment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EtfId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActivated")
                        .HasColumnType("bit");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("WalletId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EtfId");

                    b.HasIndex("WalletId");

                    b.ToTable("Investments");
                });

            modelBuilder.Entity("InvestmentManagerApi.Data.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActivated")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("InvestmentManagerApi.Data.Entities.Wallet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CurrencyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActivated")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("UserId");

                    b.ToTable("Wallets");
                });

            modelBuilder.Entity("InvestmentManagerApi.Data.Entities.Investment", b =>
                {
                    b.HasOne("InvestmentManagerApi.Data.Entities.Etf", "Etf")
                        .WithMany("Investments")
                        .HasForeignKey("EtfId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InvestmentManagerApi.Data.Entities.Wallet", "Wallet")
                        .WithMany("Investments")
                        .HasForeignKey("WalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Etf");

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("InvestmentManagerApi.Data.Entities.Wallet", b =>
                {
                    b.HasOne("InvestmentManagerApi.Data.Entities.Currency", "Currency")
                        .WithMany("Wallets")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InvestmentManagerApi.Data.Entities.User", "User")
                        .WithMany("Wallets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");

                    b.Navigation("User");
                });

            modelBuilder.Entity("InvestmentManagerApi.Data.Entities.Currency", b =>
                {
                    b.Navigation("Wallets");
                });

            modelBuilder.Entity("InvestmentManagerApi.Data.Entities.Etf", b =>
                {
                    b.Navigation("Investments");
                });

            modelBuilder.Entity("InvestmentManagerApi.Data.Entities.User", b =>
                {
                    b.Navigation("Wallets");
                });

            modelBuilder.Entity("InvestmentManagerApi.Data.Entities.Wallet", b =>
                {
                    b.Navigation("Investments");
                });
#pragma warning restore 612, 618
        }
    }
}
