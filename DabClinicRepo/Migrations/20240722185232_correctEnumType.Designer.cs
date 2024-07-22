﻿// <auto-generated />
using System;
using DabClinicRepo.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DabClinicRepo.Migrations
{
    [DbContext(typeof(DabClinicContext))]
    [Migration("20240722185232_correctEnumType")]
    partial class correctEnumType
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DabClinicRepo.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("active");

                    b.Property<DateOnly?>("Birthdate")
                        .HasColumnType("date")
                        .HasColumnName("birthdate");

                    b.Property<DateTime>("CreationTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("creation_time")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("email");

                    b.Property<string>("Fullname")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("fullname");

                    b.Property<string>("Gender")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)")
                        .HasColumnName("gender");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("password_hash");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("phone");

                    b.Property<bool>("Removed")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("removed");

                    b.Property<int>("Role")
                        .HasColumnType("int")
                        .HasColumnName("role");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("username");

                    b.HasKey("Id")
                        .HasName("PK__Account__3213E83FCE57C7FE");

                    b.HasIndex(new[] { "Username" }, "UQ__Account__F3DBC5722D6EF97E")
                        .IsUnique();

                    b.ToTable("Account");
                });

            modelBuilder.Entity("DabClinicRepo.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AppointmentStatus")
                        .HasColumnType("int")
                        .HasColumnName("appointment_status");

                    b.Property<int>("AppointmentType")
                        .HasColumnType("int")
                        .HasColumnName("appointment_type");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("customer_id");

                    b.Property<int>("CycleCount")
                        .HasColumnType("int")
                        .HasColumnName("cycle_count");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date")
                        .HasColumnName("date");

                    b.Property<int>("DentistId")
                        .HasColumnType("int")
                        .HasColumnName("dentist_id");

                    b.Property<string>("DentistNote")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasDefaultValue("")
                        .HasColumnName("dentist_note");

                    b.Property<int>("Number")
                        .HasColumnType("int")
                        .HasColumnName("number");

                    b.Property<int>("PriceFinal")
                        .HasColumnType("int")
                        .HasColumnName("price_final");

                    b.Property<int>("SlotId")
                        .HasColumnType("int")
                        .HasColumnName("slot_id");

                    b.HasKey("Id")
                        .HasName("PK__Appointm__3213E83FABC7D14F");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DentistId");

                    b.HasIndex("SlotId");

                    b.ToTable("Appointment");
                });

            modelBuilder.Entity("DabClinicRepo.Models.BookedService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AppointmentId")
                        .HasColumnType("int")
                        .HasColumnName("appointment_id");

                    b.Property<int>("Price")
                        .HasColumnType("int")
                        .HasColumnName("price");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int")
                        .HasColumnName("service_id");

                    b.HasKey("Id")
                        .HasName("PK__BookedSe__3213E83FE26D8143");

                    b.HasIndex("AppointmentId");

                    b.HasIndex("ServiceId");

                    b.ToTable("BookedService");
                });

            modelBuilder.Entity("DabClinicRepo.Models.Clinic", b =>
                {
                    b.Property<int>("ClinicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("clinic_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClinicId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("address");

                    b.Property<int>("ClinicStatus")
                        .HasColumnType("int")
                        .HasColumnName("clinic_status");

                    b.Property<TimeOnly>("CloseHour")
                        .HasColumnType("time")
                        .HasColumnName("close_hour");

                    b.Property<string>("Description")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("")
                        .HasColumnName("description");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("name");

                    b.Property<TimeOnly>("OpenHour")
                        .HasColumnType("time")
                        .HasColumnName("open_hour");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("phone");

                    b.Property<bool>("Working")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("working");

                    b.HasKey("ClinicId")
                        .HasName("PK__Clinic__A0C8D19B1F4BF56A");

                    b.ToTable("Clinic");
                });

            modelBuilder.Entity("DabClinicRepo.Models.ClinicService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Available")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("available");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("description");

                    b.Property<bool?>("InSlotTreatment")
                        .HasColumnType("bit")
                        .HasColumnName("in_slot_treatment");

                    b.Property<int>("Price")
                        .HasColumnType("int")
                        .HasColumnName("price");

                    b.Property<bool>("Removed")
                        .HasColumnType("bit")
                        .HasColumnName("removed");

                    b.Property<string>("ServiceName")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasColumnName("service_name");

                    b.Property<int?>("Weekday")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0)
                        .HasColumnName("weekday");

                    b.HasKey("Id")
                        .HasName("PK__ClinicSe__3213E83FBA4C9E02");

                    b.HasIndex("CategoryId");

                    b.ToTable("ClinicService");
                });

            modelBuilder.Entity("DabClinicRepo.Models.ClinicSlot", b =>
                {
                    b.Property<int>("SlotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("slot_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SlotId"));

                    b.Property<TimeOnly>("End")
                        .HasColumnType("time")
                        .HasColumnName("end");

                    b.Property<int>("MaxCheckup")
                        .HasColumnType("int")
                        .HasColumnName("max_checkup");

                    b.Property<int>("MaxTreatment")
                        .HasColumnType("int")
                        .HasColumnName("max_treatment");

                    b.Property<TimeOnly>("Start")
                        .HasColumnType("time")
                        .HasColumnName("start");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("status");

                    b.Property<int>("TimeId")
                        .HasColumnType("int")
                        .HasColumnName("time_id");

                    b.Property<int>("Weekday")
                        .HasColumnType("int")
                        .HasColumnName("weekday");

                    b.HasKey("SlotId")
                        .HasName("PK__ClinicSl__971A01BB0C346FB0");

                    b.ToTable("ClinicSlot");
                });

            modelBuilder.Entity("DabClinicRepo.Models.ServiceCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PK__ServiceC__3213E83F667C2AEE");

                    b.ToTable("ServiceCategory");
                });

            modelBuilder.Entity("DabClinicRepo.Models.Appointment", b =>
                {
                    b.HasOne("DabClinicRepo.Models.Account", "Customer")
                        .WithMany("AppointmentCustomers")
                        .HasForeignKey("CustomerId")
                        .IsRequired()
                        .HasConstraintName("FK__Appointme__custo__4316F928");

                    b.HasOne("DabClinicRepo.Models.Account", "Dentist")
                        .WithMany("AppointmentDentists")
                        .HasForeignKey("DentistId")
                        .IsRequired()
                        .HasConstraintName("FK__Appointme__denti__440B1D61");

                    b.HasOne("DabClinicRepo.Models.ClinicSlot", "Slot")
                        .WithMany("Appointments")
                        .HasForeignKey("SlotId")
                        .IsRequired()
                        .HasConstraintName("FK__Appointme__slot___44FF419A");

                    b.Navigation("Customer");

                    b.Navigation("Dentist");

                    b.Navigation("Slot");
                });

            modelBuilder.Entity("DabClinicRepo.Models.BookedService", b =>
                {
                    b.HasOne("DabClinicRepo.Models.Appointment", "Appointment")
                        .WithMany("BookedServices")
                        .HasForeignKey("AppointmentId")
                        .IsRequired()
                        .HasConstraintName("FK__BookedSer__appoi__4222D4EF");

                    b.HasOne("DabClinicRepo.Models.ClinicService", "Service")
                        .WithMany("BookedServices")
                        .HasForeignKey("ServiceId")
                        .IsRequired()
                        .HasConstraintName("FK__BookedSer__servi__412EB0B6");

                    b.Navigation("Appointment");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("DabClinicRepo.Models.ClinicService", b =>
                {
                    b.HasOne("DabClinicRepo.Models.ServiceCategory", "Category")
                        .WithMany("ClinicServices")
                        .HasForeignKey("CategoryId")
                        .IsRequired()
                        .HasConstraintName("FK__ClinicSer__categ__403A8C7D");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("DabClinicRepo.Models.Account", b =>
                {
                    b.Navigation("AppointmentCustomers");

                    b.Navigation("AppointmentDentists");
                });

            modelBuilder.Entity("DabClinicRepo.Models.Appointment", b =>
                {
                    b.Navigation("BookedServices");
                });

            modelBuilder.Entity("DabClinicRepo.Models.ClinicService", b =>
                {
                    b.Navigation("BookedServices");
                });

            modelBuilder.Entity("DabClinicRepo.Models.ClinicSlot", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("DabClinicRepo.Models.ServiceCategory", b =>
                {
                    b.Navigation("ClinicServices");
                });
#pragma warning restore 612, 618
        }
    }
}
