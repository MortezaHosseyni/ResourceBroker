﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ResourceBroker.Context;

#nullable disable

namespace ResourceBroker.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("ResourceBroker.Models.Allocate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ResourceId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ResourceId");

                    b.HasIndex("UserId");

                    b.ToTable("Allocates");
                });

            modelBuilder.Entity("ResourceBroker.Models.Package", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Algorithm")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Complexity")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasMaxLength(225)
                        .HasColumnType("TEXT");

                    b.Property<double>("Efficiency")
                        .HasColumnType("REAL");

                    b.Property<bool>("IsQosCompliant")
                        .HasColumnType("INTEGER");

                    b.Property<double>("QosScore")
                        .HasColumnType("REAL");

                    b.Property<double>("TakenTimeForCreation")
                        .HasColumnType("REAL");

                    b.Property<string>("Title")
                        .HasMaxLength(225)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("ResourceBroker.Models.Request", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ResourceId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ResourceId");

                    b.HasIndex("UserId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("ResourceBroker.Models.Resource", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("AllocateId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Capacity")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Cost")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasMaxLength(555)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAllocated")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("PackageId")
                        .HasColumnType("TEXT");

                    b.Property<double>("ResponseTime")
                        .HasColumnType("REAL");

                    b.Property<Guid>("ServiceId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AllocateId");

                    b.HasIndex("PackageId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("ResourceBroker.Models.Service", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<float>("Bandwidth")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasMaxLength(555)
                        .HasColumnType("TEXT");

                    b.Property<float>("Download")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<float>("Upload")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("ResourceBroker.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ResourceBroker.Models.Allocate", b =>
                {
                    b.HasOne("ResourceBroker.Models.Resource", "Resource")
                        .WithMany()
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ResourceBroker.Models.User", "User")
                        .WithMany("Allocates")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resource");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ResourceBroker.Models.Request", b =>
                {
                    b.HasOne("ResourceBroker.Models.Resource", "Resource")
                        .WithMany("Requests")
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ResourceBroker.Models.User", "User")
                        .WithMany("Requests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resource");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ResourceBroker.Models.Resource", b =>
                {
                    b.HasOne("ResourceBroker.Models.Allocate", "Allocate")
                        .WithMany()
                        .HasForeignKey("AllocateId");

                    b.HasOne("ResourceBroker.Models.Package", "Package")
                        .WithMany("Resources")
                        .HasForeignKey("PackageId");

                    b.HasOne("ResourceBroker.Models.Service", "Service")
                        .WithMany("Resources")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Allocate");

                    b.Navigation("Package");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("ResourceBroker.Models.Package", b =>
                {
                    b.Navigation("Resources");
                });

            modelBuilder.Entity("ResourceBroker.Models.Resource", b =>
                {
                    b.Navigation("Requests");
                });

            modelBuilder.Entity("ResourceBroker.Models.Service", b =>
                {
                    b.Navigation("Resources");
                });

            modelBuilder.Entity("ResourceBroker.Models.User", b =>
                {
                    b.Navigation("Allocates");

                    b.Navigation("Requests");
                });
#pragma warning restore 612, 618
        }
    }
}
