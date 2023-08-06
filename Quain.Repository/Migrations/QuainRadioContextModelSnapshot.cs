﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Quain.Repository;

#nullable disable

namespace Quain.Repository.Migrations
{
    [DbContext(typeof(QuainRadioContext))]
    partial class QuainRadioContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("Modern_Spanish_CI_AI")
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Quain.Domain.Models.Client", b =>
                {
                    b.Property<string>("COD_CLIENT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CUIT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NOM_COM")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("TIPO_DOC")
                        .HasColumnType("smallint");

                    b.ToTable((string)null);

                    b.ToFunction("FN_GetClientByCodClient");
                });

            modelBuilder.Entity("Quain.Domain.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CUIT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodClient")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Quain.Domain.Models.Points", b =>
                {
                    b.Property<Guid>("PointsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("CurrentValue")
                        .HasColumnType("int");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("LastUpdate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("PointsId");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.ToTable("Points");
                });

            modelBuilder.Entity("Quain.Domain.Models.PointsChanges", b =>
                {
                    b.Property<Guid>("PointsChangesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("BillNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("ChangeDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("PointsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PointsChangesId");

                    b.HasIndex("PointsId");

                    b.ToTable("PointsChanges");
                });

            modelBuilder.Entity("Quain.Domain.Models.Sale", b =>
                {
                    b.Property<string>("N_COMP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalFacturado")
                        .HasColumnType("decimal(18,2)");

                    b.ToTable((string)null);

                    b.ToFunction("FN_GetBillAmount");
                });

            modelBuilder.Entity("Quain.Domain.Models.Points", b =>
                {
                    b.HasOne("Quain.Domain.Models.Customer", "Customer")
                        .WithOne("Points")
                        .HasForeignKey("Quain.Domain.Models.Points", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Quain.Domain.Models.PointsChanges", b =>
                {
                    b.HasOne("Quain.Domain.Models.Points", null)
                        .WithMany("PointsChanges")
                        .HasForeignKey("PointsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Quain.Domain.Models.Customer", b =>
                {
                    b.Navigation("Points")
                        .IsRequired();
                });

            modelBuilder.Entity("Quain.Domain.Models.Points", b =>
                {
                    b.Navigation("PointsChanges");
                });
#pragma warning restore 612, 618
        }
    }
}
