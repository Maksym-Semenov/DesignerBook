﻿// <auto-generated />
using System;
using DesignerBook.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DesignerBook.Migrations
{
    [DbContext(typeof(DesignerBookContext))]
    partial class DesignerBookContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DesignerBook.Models.TEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("EventDateRegister")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("EventSerialNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("NextDateCommunication")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("TPersonId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("TPersonId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("DesignerBook.Models.TPerson", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int?>("EventsCount")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("DesignerBook.Models.TEvent", b =>
                {
                    b.HasOne("DesignerBook.Models.TPerson", null)
                        .WithMany("Events")
                        .HasForeignKey("TPersonId");
                });

            modelBuilder.Entity("DesignerBook.Models.TPerson", b =>
                {
                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
