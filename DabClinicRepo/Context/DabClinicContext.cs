using System;
using System.Collections.Generic;
using DabClinicRepo.Models;
using DabClinicRepo.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DabClinicRepo.Context;

public partial class DabClinicContext : DbContext
{
    public DabClinicContext()
    {
    }

    public DabClinicContext(DbContextOptions<DabClinicContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<BookedServiceRepository> BookedServices { get; set; }

    public virtual DbSet<ClinicRepository> Clinics { get; set; }

    public virtual DbSet<ClinicService> ClinicServices { get; set; }

    public virtual DbSet<ClinicSlot> ClinicSlots { get; set; }

    public virtual DbSet<ServiceCategory> ServiceCategories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(GetConnectionString());

    private string GetConnectionString()
    {
        IConfiguration config = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, true)
                    .Build();
        var strConn = config["ConnectionStrings:DefaultConnectionStringDB"];

        return strConn!;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Account__3213E83F05C0B589");

            entity.ToTable("Account");

            entity.HasIndex(e => e.Username, "UQ__Account__F3DBC5723DB7B365").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active)
                .HasDefaultValue(true)
                .HasColumnName("active");
            entity.Property(e => e.Birthdate).HasColumnName("birthdate");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creation_time");
            entity.Property(e => e.Email)
                .HasMaxLength(64)
                .HasColumnName("email");
            entity.Property(e => e.Fullname)
                .HasMaxLength(255)
                .HasColumnName("fullname");
            entity.Property(e => e.Gender)
                .HasMaxLength(16)
                .HasColumnName("gender");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(128)
                .HasColumnName("password_hash");
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .HasColumnName("phone");
            entity.Property(e => e.Removed).HasColumnName("removed");
            entity.Property(e => e.Role)
                .HasMaxLength(255)
                .HasDefaultValue("Patient")
                .HasColumnName("role");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Appointm__3213E83FB795826B");

            entity.ToTable("Appointment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AppointmentType)
                .HasMaxLength(255)
                .HasDefaultValue("checkup")
                .HasColumnName("appointment_type");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.CycleCount).HasColumnName("cycle_count");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.DentistId).HasColumnName("dentist_id");
            entity.Property(e => e.DentistNote)
                .HasMaxLength(1000)
                .HasDefaultValue("")
                .HasColumnName("dentist_note");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.PriceFinal).HasColumnName("price_final");
            entity.Property(e => e.SlotId).HasColumnName("slot_id");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasDefaultValue("booked")
                .HasColumnName("status");

            entity.HasOne(d => d.Customer).WithMany(p => p.AppointmentCustomers)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKAppointmen366296");

            entity.HasOne(d => d.Dentist).WithMany(p => p.AppointmentDentists)
                .HasForeignKey(d => d.DentistId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKAppointmen157913");

            entity.HasOne(d => d.Slot).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.SlotId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKAppointmen998789");
        });

        modelBuilder.Entity<BookedService>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BookedSe__3213E83FD44025BD");

            entity.ToTable("BookedService");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AppointmentId).HasColumnName("appointment_id");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");

            entity.HasOne(d => d.Appointment).WithMany(p => p.BookedServices)
                .HasForeignKey(d => d.AppointmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKBookedServ274862");

            entity.HasOne(d => d.Service).WithMany(p => p.BookedServices)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKBookedServ419526");
        });

        modelBuilder.Entity<Clinic>(entity =>
        {
            entity.HasKey(e => e.ClinicId).HasName("PK__Clinic__A0C8D19BE209F2F4");

            entity.ToTable("Clinic");

            entity.Property(e => e.ClinicId).HasColumnName("clinic_id");
            entity.Property(e => e.Address)
                .HasMaxLength(128)
                .HasColumnName("address");
            entity.Property(e => e.CloseHour).HasColumnName("close_hour");
            entity.Property(e => e.Description)
                .HasDefaultValue("")
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Email)
                .HasMaxLength(64)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .HasColumnName("name");
            entity.Property(e => e.OpenHour).HasColumnName("open_hour");
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .HasColumnName("phone");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasDefaultValue("verified")
                .HasColumnName("status");
            entity.Property(e => e.Working)
                .HasDefaultValue(true)
                .HasColumnName("working");
        });

        modelBuilder.Entity<ClinicService>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ClinicSe__3213E83F644416FC");

            entity.ToTable("ClinicService");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Available)
                .HasDefaultValue(true)
                .HasColumnName("available");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.InSlotTreatment).HasColumnName("in_slot_treatment");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Removed).HasColumnName("removed");
            entity.Property(e => e.ServiceName)
                .HasMaxLength(80)
                .HasColumnName("service_name");
            entity.Property(e => e.Weekday)
                .HasDefaultValue((byte)127)
                .HasColumnName("weekday");

            entity.HasOne(d => d.Category).WithMany(p => p.ClinicServices)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKClinicServ913410");
        });

        modelBuilder.Entity<ClinicSlot>(entity =>
        {
            entity.HasKey(e => e.SlotId).HasName("PK__ClinicSl__971A01BB57ED0AA2");

            entity.ToTable("ClinicSlot");

            entity.Property(e => e.SlotId).HasColumnName("slot_id");
            entity.Property(e => e.End).HasColumnName("end");
            entity.Property(e => e.MaxCheckup).HasColumnName("max_checkup");
            entity.Property(e => e.MaxTreatment).HasColumnName("max_treatment");
            entity.Property(e => e.Start).HasColumnName("start");
            entity.Property(e => e.Status)
                .HasDefaultValue(true)
                .HasColumnName("status");
            entity.Property(e => e.TimeId).HasColumnName("time_id");
            entity.Property(e => e.Weekday).HasColumnName("weekday");
        });

        modelBuilder.Entity<ServiceCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ServiceC__3213E83FB04EE20F");

            entity.ToTable("ServiceCategory");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(32)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
