﻿// <auto-generated />
using System;
using Gadajec.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Gadajec.Persistance.Migrations
{
    [DbContext(typeof(GadajecDBContext))]
    partial class GadajecDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Gadajec")
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Gadajec.Domain.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("MessageDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MessageText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoomID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Messages", "Gadajec");
                });

            modelBuilder.Entity("Gadajec.Domain.Models.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rooms", "Gadajec");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6213b149-c6df-41e4-a6a7-5636f50a5e63"),
                            CreatedAt = new DateTime(2022, 11, 8, 0, 0, 0, 0, DateTimeKind.Local),
                            CreatedBy = "Admin",
                            Name = "C# - devs"
                        },
                        new
                        {
                            Id = new Guid("6013a924-85d9-405d-8f0e-86391f89b64b"),
                            CreatedAt = new DateTime(2022, 11, 8, 18, 26, 19, 557, DateTimeKind.Local).AddTicks(3671),
                            CreatedBy = "Admin",
                            Name = "SQL - devs"
                        });
                });

            modelBuilder.Entity("Gadajec.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Users", "Gadajec");

                    b.HasData(
                        new
                        {
                            Id = new Guid("72e2e9a6-7a14-4695-8312-aeabb9138f6f"),
                            CreatedAt = new DateTime(2022, 11, 8, 18, 26, 19, 557, DateTimeKind.Local).AddTicks(3330),
                            Email = "Bartosz@mail.com.pl",
                            FirstName = "Bartosz",
                            LastName = "Bagiński",
                            Password = "SGFzbG8="
                        });
                });

            modelBuilder.Entity("RoomUser", b =>
                {
                    b.Property<Guid>("RoomsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RoomsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("RoomUser", "Gadajec");
                });

            modelBuilder.Entity("RoomUser", b =>
                {
                    b.HasOne("Gadajec.Domain.Models.Room", null)
                        .WithMany()
                        .HasForeignKey("RoomsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gadajec.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}