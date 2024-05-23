﻿// <auto-generated />
using System;
using LibraryManagementSystem.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryManagementSystem.Migrations
{
    [DbContext(typeof(ExcelTechnologiesDBContext))]
    [Migration("20240519013724_InitialMigiration")]
    partial class InitialMigiration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.3.24172.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LibraryManagementSystem.Models.Allergies", b =>
                {
                    b.Property<int>("AllergiesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AllergiesID"));

                    b.Property<string>("AllergiesName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AllergiesID");

                    b.ToTable("Allergies");
                });

            modelBuilder.Entity("LibraryManagementSystem.Models.Allergies_Details", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("AllergiesID")
                        .HasColumnType("int");

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AllergiesID");

                    b.HasIndex("PatientID");

                    b.ToTable("Allergies_Details");
                });

            modelBuilder.Entity("LibraryManagementSystem.Models.DiseaseInformation", b =>
                {
                    b.Property<int>("DiseaseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DiseaseID"));

                    b.Property<string>("DiseaseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DiseaseID");

                    b.ToTable("DiseaseInformation");
                });

            modelBuilder.Entity("LibraryManagementSystem.Models.Epilepsy", b =>
                {
                    b.Property<int>("EpilepsyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EpilepsyID"));

                    b.Property<string>("EpilepsyType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EpilepsyID");

                    b.ToTable("Epilepsy");
                });

            modelBuilder.Entity("LibraryManagementSystem.Models.NCD", b =>
                {
                    b.Property<int>("NCDID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NCDID"));

                    b.Property<string>("NCDName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NCDID");

                    b.ToTable("NCDs");
                });

            modelBuilder.Entity("LibraryManagementSystem.Models.NCD_Details", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("NCDID")
                        .HasColumnType("int");

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("NCDID");

                    b.HasIndex("PatientID");

                    b.ToTable("NCD_Details");
                });

            modelBuilder.Entity("LibraryManagementSystem.Models.Patient", b =>
                {
                    b.Property<int>("PatientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatientID"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientID");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("LibraryManagementSystem.Models.Allergies_Details", b =>
                {
                    b.HasOne("LibraryManagementSystem.Models.Allergies", "Allergies")
                        .WithMany()
                        .HasForeignKey("AllergiesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryManagementSystem.Models.Patient", "Patient")
                        .WithMany("Allergies_Details")
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Allergies");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("LibraryManagementSystem.Models.NCD_Details", b =>
                {
                    b.HasOne("LibraryManagementSystem.Models.NCD", "NCD")
                        .WithMany()
                        .HasForeignKey("NCDID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryManagementSystem.Models.Patient", "Patient")
                        .WithMany("NCD_Details")
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NCD");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("LibraryManagementSystem.Models.Patient", b =>
                {
                    b.Navigation("Allergies_Details");

                    b.Navigation("NCD_Details");
                });
#pragma warning restore 612, 618
        }
    }
}
