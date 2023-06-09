﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using biblioteca_server.Data;

#nullable disable

namespace biblioteca_server.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230329160937_addAutor")]
    partial class addAutor
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("biblioteca_server.Data.Models.Livro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Autor")
                        .HasColumnType("TEXT");

                    b.Property<string>("Categoria")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataLancamento")
                        .HasColumnType("TEXT");

                    b.Property<bool?>("ENacional")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Livro");
                });
#pragma warning restore 612, 618
        }
    }
}
