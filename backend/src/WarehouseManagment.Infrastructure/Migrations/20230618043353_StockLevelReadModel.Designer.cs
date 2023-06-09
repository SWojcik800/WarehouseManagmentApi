﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WarehouseManagment.Infrastructure.Data;

#nullable disable

namespace WarehouseManagment.Infrastructure.Migrations
{
    [DbContext(typeof(WarehouseContext))]
    [Migration("20230618043353_StockLevelReadModel")]
    partial class StockLevelReadModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WarehouseManagment.Core.Products.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("_isDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("isDeleted");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("WarehouseManagment.Core.StockLevels.Entities.StockLevel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("StockLevels");
                });

            modelBuilder.Entity("WarehouseManagment.Core.Products.Product", b =>
                {
                    b.OwnsOne("WarehouseManagment.Core.Products.ProductDescription", "Description", b1 =>
                        {
                            b1.Property<long>("ProductId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Description");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.OwnsOne("WarehouseManagment.Core.Products.ProductManufacturer", "Manufacturer", b1 =>
                        {
                            b1.Property<long>("ProductId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Manufacturer");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.OwnsOne("WarehouseManagment.Core.Products.ProductName", "Name", b1 =>
                        {
                            b1.Property<long>("ProductId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Name");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.Navigation("Description")
                        .IsRequired();

                    b.Navigation("Manufacturer")
                        .IsRequired();

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("WarehouseManagment.Core.StockLevels.Entities.StockLevel", b =>
                {
                    b.HasOne("WarehouseManagment.Core.Products.Product", null)
                        .WithOne()
                        .HasForeignKey("WarehouseManagment.Core.StockLevels.Entities.StockLevel", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("WarehouseManagment.Core.StockLevels.ValueObjects.StockLevelCount", "Count", b1 =>
                        {
                            b1.Property<long>("StockLevelId")
                                .HasColumnType("bigint");

                            b1.Property<long>("Value")
                                .HasColumnType("bigint")
                                .HasColumnName("Count");

                            b1.HasKey("StockLevelId");

                            b1.ToTable("StockLevels");

                            b1.WithOwner()
                                .HasForeignKey("StockLevelId");
                        });

                    b.Navigation("Count")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
