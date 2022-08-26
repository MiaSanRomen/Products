﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Products.Data;

#nullable disable

namespace Products.Migrations
{
    [DbContext(typeof(ProductsContext))]
    [Migration("20220826155702_AddCategoryCountAndUnknownCategory")]
    partial class AddCategoryCountAndUnknownCategory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Products.Data.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Count = 2,
                            ImageId = 2,
                            Name = "Еда"
                        },
                        new
                        {
                            Id = 2,
                            Count = 1,
                            ImageId = 7,
                            Name = "Вкусности"
                        },
                        new
                        {
                            Id = 3,
                            Count = 1,
                            ImageId = 6,
                            Name = "Вода"
                        },
                        new
                        {
                            Id = 4,
                            Count = 0,
                            ImageId = 8,
                            Name = "Без категории"
                        });
                });

            modelBuilder.Entity("Products.Data.Models.GeneralNote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GeneralNotes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Акция"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Вкусная"
                        },
                        new
                        {
                            Id = 3,
                            Name = "С ключом"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Вятский"
                        });
                });

            modelBuilder.Entity("Products.Data.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Bytes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Images");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Path = "/images/fish.jfif"
                        },
                        new
                        {
                            Id = 2,
                            Path = "/images/food.jpg"
                        },
                        new
                        {
                            Id = 3,
                            Path = "/images/kvas.jpg"
                        },
                        new
                        {
                            Id = 4,
                            Path = "/images/meat.jpg"
                        },
                        new
                        {
                            Id = 5,
                            Path = "/images/sugarmilk.jpg"
                        },
                        new
                        {
                            Id = 6,
                            Path = "/images/water.jpg"
                        },
                        new
                        {
                            Id = 7,
                            Path = "/images/yummy.jpg"
                        },
                        new
                        {
                            Id = 8,
                            Path = "/images/food-unknown.jpg"
                        });
                });

            modelBuilder.Entity("Products.Data.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GeneralNoteId")
                        .HasColumnType("int");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoteCustom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("GeneralNoteId");

                    b.HasIndex("ImageId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "Селедка соленая",
                            GeneralNoteId = 1,
                            ImageId = 1,
                            Name = "Селедка",
                            NoteCustom = "Пересоленая",
                            Price = 10000m
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "Тушенка говяжая",
                            GeneralNoteId = 2,
                            ImageId = 4,
                            Name = "Тушенка",
                            NoteCustom = "Жилы",
                            Price = 20000m
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Description = "В банках",
                            GeneralNoteId = 3,
                            ImageId = 5,
                            Name = "Сгущенка",
                            NoteCustom = "Вкусная",
                            Price = 30000m
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 3,
                            Description = "В бутылках",
                            GeneralNoteId = 4,
                            ImageId = 3,
                            Name = "Квас",
                            NoteCustom = "Теплый",
                            Price = 15000m
                        });
                });

            modelBuilder.Entity("Products.Data.Models.Category", b =>
                {
                    b.HasOne("Products.Data.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("Products.Data.Models.Product", b =>
                {
                    b.HasOne("Products.Data.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Products.Data.Models.GeneralNote", "GeneralNote")
                        .WithMany()
                        .HasForeignKey("GeneralNoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Products.Data.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId");

                    b.Navigation("Category");

                    b.Navigation("GeneralNote");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("Products.Data.Models.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
