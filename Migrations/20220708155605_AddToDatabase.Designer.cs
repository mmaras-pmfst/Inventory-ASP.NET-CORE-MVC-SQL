﻿// <auto-generated />
using System;
using Inventory.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Inventory.Migrations
{
    [DbContext(typeof(InventoryContext))]
    [Migration("20220708155605_AddToDatabase")]
    partial class AddToDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Inventory.DbModels.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CategoryID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Inventory.DbModels.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ItemID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemId"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("CategoryID");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("UnitId")
                        .HasColumnType("int")
                        .HasColumnName("UnitID");

                    b.HasKey("ItemId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UnitId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Inventory.DbModels.Stock", b =>
                {
                    b.Property<int>("StockId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("StockID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StockId"), 1L, 1);

                    b.Property<string>("StockName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("StockId");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("Inventory.DbModels.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TransactionID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionId"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<int>("StockId")
                        .HasColumnType("int")
                        .HasColumnName("StockID");

                    b.Property<int>("TransactionTypeId")
                        .HasColumnType("int")
                        .HasColumnName("TransactionTypeID");

                    b.HasKey("TransactionId");

                    b.HasIndex("StockId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Inventory.DbModels.TransactionItem", b =>
                {
                    b.Property<int>("TransactionItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TransactionItemID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionItemId"), 1L, 1);

                    b.Property<int>("ItemId")
                        .HasColumnType("int")
                        .HasColumnName("ItemID");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<decimal>("Qty")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("TransactionId")
                        .HasColumnType("int")
                        .HasColumnName("TransactionID");

                    b.HasKey("TransactionItemId");

                    b.HasIndex("ItemId");

                    b.HasIndex("TransactionId");

                    b.ToTable("TransactionItems");
                });

            modelBuilder.Entity("Inventory.DbModels.Unit", b =>
                {
                    b.Property<int>("UnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UnitID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UnitId"), 1L, 1);

                    b.Property<string>("UnitName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("UnitId");

                    b.ToTable("Units");

                    b.HasData(
                        new
                        {
                            UnitId = 1,
                            UnitName = "kom"
                        },
                        new
                        {
                            UnitId = 2,
                            UnitName = "kg"
                        },
                        new
                        {
                            UnitId = 3,
                            UnitName = "lit"
                        });
                });

            modelBuilder.Entity("Inventory.DbModels.Item", b =>
                {
                    b.HasOne("Inventory.DbModels.Category", "Category")
                        .WithMany("Items")
                        .HasForeignKey("CategoryId")
                        .IsRequired()
                        .HasConstraintName("FK_Items_Categories");

                    b.HasOne("Inventory.DbModels.Unit", "Unit")
                        .WithMany("Items")
                        .HasForeignKey("UnitId")
                        .IsRequired()
                        .HasConstraintName("FK_Items_Units");

                    b.Navigation("Category");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("Inventory.DbModels.Transaction", b =>
                {
                    b.HasOne("Inventory.DbModels.Stock", "Stock")
                        .WithMany("Transactions")
                        .HasForeignKey("StockId")
                        .IsRequired()
                        .HasConstraintName("FK_Transactions_Stocks");

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("Inventory.DbModels.TransactionItem", b =>
                {
                    b.HasOne("Inventory.DbModels.Item", "Item")
                        .WithMany("TransactionItems")
                        .HasForeignKey("ItemId")
                        .IsRequired()
                        .HasConstraintName("FK_TransactionItems_Items");

                    b.HasOne("Inventory.DbModels.Transaction", "Transaction")
                        .WithMany("TransactionItems")
                        .HasForeignKey("TransactionId")
                        .IsRequired()
                        .HasConstraintName("FK_TransactionItems_Transactions");

                    b.Navigation("Item");

                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("Inventory.DbModels.Category", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Inventory.DbModels.Item", b =>
                {
                    b.Navigation("TransactionItems");
                });

            modelBuilder.Entity("Inventory.DbModels.Stock", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("Inventory.DbModels.Transaction", b =>
                {
                    b.Navigation("TransactionItems");
                });

            modelBuilder.Entity("Inventory.DbModels.Unit", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}