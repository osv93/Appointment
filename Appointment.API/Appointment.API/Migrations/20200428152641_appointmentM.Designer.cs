﻿// <auto-generated />
using System;
using Appointment.API.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Appointment.API.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20200428152641_appointmentM")]
    partial class appointmentM
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Appointment.API.Entities.Appointment", b =>
                {
                    b.Property<int>("AppointmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("PatientID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AppointmentID");

                    b.HasIndex("PatientID");

                    b.ToTable("Appointment");

                    b.HasData(
                        new
                        {
                            AppointmentID = 1,
                            Active = false,
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PatientID = "111"
                        });
                });

            modelBuilder.Entity("Appointment.API.Entities.Patient", b =>
                {
                    b.Property<string>("PatientID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("PatientID");

                    b.ToTable("Patient");

                    b.HasData(
                        new
                        {
                            PatientID = "111",
                            LastName = "LastName 1",
                            Name = "Patient 1"
                        },
                        new
                        {
                            PatientID = "222",
                            LastName = "LastName 2",
                            Name = "Patient 2"
                        },
                        new
                        {
                            PatientID = "333",
                            LastName = "LastName 3",
                            Name = "Patient 3"
                        },
                        new
                        {
                            PatientID = "444",
                            LastName = "LastName 4",
                            Name = "Patient 4"
                        });
                });

            modelBuilder.Entity("Appointment.API.Entities.Appointment", b =>
                {
                    b.HasOne("Appointment.API.Entities.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientID");
                });
#pragma warning restore 612, 618
        }
    }
}
