﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using StudentInformation.Infrastructure.Context;

#nullable disable

namespace StudentInformation.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231128191523_version_1")]
    partial class version_1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("StudentInformation.Domain.Students.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("FamilyName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("family_name");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("number");

                    b.HasKey("Id")
                        .HasName("pk_students");

                    b.ToTable("students", (string)null);
                });

            modelBuilder.Entity("StudentInformation.Domain.Teachers.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("FamilyName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("family_name");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.HasKey("Id")
                        .HasName("pk_teachers");

                    b.ToTable("teachers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("8df7e8ac-7b8f-4b84-8ac8-7b0e3108c243"),
                            FamilyName = "Mert",
                            FirstName = "Fatih Rahman"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
