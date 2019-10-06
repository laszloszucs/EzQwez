﻿// <auto-generated />
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(PhraseContext))]
    partial class PhraseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0");

            modelBuilder.Entity("ApplicationCore.Models.Phrase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("English")
                        .HasColumnType("TEXT");

                    b.Property<string>("Hungarian")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("English")
                        .IsUnique();

                    b.HasIndex("Hungarian")
                        .IsUnique();

                    b.ToTable("Phrases","test");
                });
#pragma warning restore 612, 618
        }
    }
}