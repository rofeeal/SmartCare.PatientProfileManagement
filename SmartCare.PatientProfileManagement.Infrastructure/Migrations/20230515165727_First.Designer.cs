﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartCare.PatientProfileManagement.Infrastructure.Context;

#nullable disable

namespace SmartCare.PatientProfileManagement.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230515165727_First")]
    partial class First
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SmartCare.PatientProfileManagement.Domain.Entites.PatientProfile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("PatientProfiles");
                });

            modelBuilder.Entity("SmartCare.PatientProfileManagement.Domain.Entites.PatientProfile", b =>
                {
                    b.OwnsOne("SmartCare.PatientProfileManagement.Shared.Models.BasicInformation", "BasicInformation", b1 =>
                        {
                            b1.Property<Guid>("PatientProfileId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("DateOfBirth")
                                .HasColumnType("datetime2");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("Gender")
                                .HasColumnType("int");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PatientProfileId");

                            b1.ToTable("PatientProfiles");

                            b1.WithOwner()
                                .HasForeignKey("PatientProfileId");
                        });

                    b.OwnsOne("SmartCare.PatientProfileManagement.Shared.Models.ContactInformation", "ContactInfo", b1 =>
                        {
                            b1.Property<Guid>("PatientProfileId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Email")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Phone")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PatientProfileId");

                            b1.ToTable("PatientProfiles");

                            b1.WithOwner()
                                .HasForeignKey("PatientProfileId");

                            b1.OwnsOne("SmartCare.PatientProfileManagement.Shared.ValueObjects.Address", "Address", b2 =>
                                {
                                    b2.Property<Guid>("ContactInformationPatientProfileId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<string>("City")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<string>("Country")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<string>("State")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<string>("Street")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<string>("ZipCode")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.HasKey("ContactInformationPatientProfileId");

                                    b2.ToTable("PatientProfiles");

                                    b2.WithOwner()
                                        .HasForeignKey("ContactInformationPatientProfileId");
                                });

                            b1.Navigation("Address")
                                .IsRequired();
                        });

                    b.OwnsOne("SmartCare.PatientProfileManagement.Shared.Models.MedicalInformation", "MedicalInfo", b1 =>
                        {
                            b1.Property<Guid>("PatientProfileId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("BloodPressure")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("BloodSugar")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("BloodType")
                                .HasColumnType("int");

                            b1.Property<string>("Cholesterol")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PatientProfileId");

                            b1.ToTable("PatientProfiles");

                            b1.WithOwner()
                                .HasForeignKey("PatientProfileId");
                        });

                    b.Navigation("BasicInformation")
                        .IsRequired();

                    b.Navigation("ContactInfo")
                        .IsRequired();

                    b.Navigation("MedicalInfo")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}