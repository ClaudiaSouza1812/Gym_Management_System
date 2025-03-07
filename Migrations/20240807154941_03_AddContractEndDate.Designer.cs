﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.DAL;

#nullable disable

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Migrations
{
    [DbContext(typeof(CA_RS11_P2_2_ClaudiaSouza_DBContext))]
    [Migration("20240807154941_03_AddContractEndDate")]
    partial class _03_AddContractEndDate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("Loyal")
                        .HasColumnType("bit");

                    b.Property<string>("NIF")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<int>("PaymentType")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Client");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Rua teste1, 123",
                            BirthDate = new DateTime(1992, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Coimbra",
                            Country = "Portugal",
                            CreatedAt = new DateTime(2024, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "teste1@teste.com",
                            FirstName = "Claudia",
                            LastName = "Souza",
                            Loyal = false,
                            NIF = "999999999",
                            PaymentType = 1,
                            PhoneNumber = "123456789",
                            PostalCode = "9999-999",
                            Status = 1
                        },
                        new
                        {
                            Id = 2,
                            Address = "Rua teste2, 321",
                            BirthDate = new DateTime(1984, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "São Paulo",
                            Country = "Brasil",
                            CreatedAt = new DateTime(2024, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "teste2@teste.com",
                            FirstName = "Simone",
                            LastName = "Souza",
                            Loyal = false,
                            NIF = "888888888",
                            PaymentType = 2,
                            PhoneNumber = "987654321",
                            PostalCode = "8888-888",
                            Status = 1
                        });
                });

            modelBuilder.Entity("P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models.Contract", b =>
                {
                    b.Property<int>("ContractId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContractId"), 1L, 1);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("date");

                    b.Property<int>("MembershipId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.HasKey("ContractId");

                    b.HasIndex("ClientId");

                    b.HasIndex("MembershipId");

                    b.ToTable("Contract");
                });

            modelBuilder.Entity("P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models.ContractModality", b =>
                {
                    b.Property<int>("ContractId")
                        .HasColumnType("int");

                    b.Property<int>("ModalityId")
                        .HasColumnType("int");

                    b.HasKey("ContractId", "ModalityId");

                    b.HasIndex("ModalityId");

                    b.ToTable("ContractModality");
                });

            modelBuilder.Entity("P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models.CreateClientViewModel", b =>
                {
                    b.Property<DateTime>("ContractDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("PaymentBaseRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PaymentBaseValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.ToTable("CreateClientViewModel");
                });

            modelBuilder.Entity("P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models.Membership", b =>
                {
                    b.Property<int>("MembershipId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MembershipId"), 1L, 1);

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(5,2)");

                    b.Property<int>("MembershipType")
                        .HasColumnType("int");

                    b.HasKey("MembershipId");

                    b.ToTable("Membership");
                });

            modelBuilder.Entity("P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models.Modality", b =>
                {
                    b.Property<int>("ModalityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ModalityId"), 1L, 1);

                    b.Property<int>("ModalityName")
                        .HasColumnType("int");

                    b.Property<int>("ModalityPackage")
                        .HasColumnType("int");

                    b.HasKey("ModalityId");

                    b.ToTable("Modality");
                });

            modelBuilder.Entity("P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"), 1L, 1);

                    b.Property<int>("ContractId")
                        .HasColumnType("int");

                    b.Property<decimal>("PaymentBaseRate")
                        .HasColumnType("decimal(6,2)");

                    b.Property<decimal>("PaymentBaseValue")
                        .HasColumnType("decimal(6,2)");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("date");

                    b.HasKey("PaymentId");

                    b.HasIndex("ContractId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models.Contract", b =>
                {
                    b.HasOne("P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models.Client", "Client")
                        .WithMany("Contracts")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models.Membership", "Membership")
                        .WithMany("Contracts")
                        .HasForeignKey("MembershipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Membership");
                });

            modelBuilder.Entity("P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models.ContractModality", b =>
                {
                    b.HasOne("P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models.Contract", "Contract")
                        .WithMany("ContractModalities")
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models.Modality", "Modality")
                        .WithMany("ContractModalities")
                        .HasForeignKey("ModalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contract");

                    b.Navigation("Modality");
                });

            modelBuilder.Entity("P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models.Payment", b =>
                {
                    b.HasOne("P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models.Contract", "Contract")
                        .WithMany("Payments")
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contract");
                });

            modelBuilder.Entity("P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models.Client", b =>
                {
                    b.Navigation("Contracts");
                });

            modelBuilder.Entity("P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models.Contract", b =>
                {
                    b.Navigation("ContractModalities");

                    b.Navigation("Payments");
                });

            modelBuilder.Entity("P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models.Membership", b =>
                {
                    b.Navigation("Contracts");
                });

            modelBuilder.Entity("P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models.Modality", b =>
                {
                    b.Navigation("ContractModalities");
                });
#pragma warning restore 612, 618
        }
    }
}
