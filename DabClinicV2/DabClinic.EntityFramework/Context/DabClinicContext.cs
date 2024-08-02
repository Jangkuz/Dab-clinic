using DabClinic.Domain.Enums;
using DabClinic.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DabClinicRepo.Context;

public partial class DabClinicContext : DbContext
{
    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<BookedService> BookedServices { get; set; }

    public virtual DbSet<Clinic> Clinics { get; set; }

    public virtual DbSet<ClinicService> ClinicServices { get; set; }

    public virtual DbSet<ClinicSlot> ClinicSlots { get; set; }

    public virtual DbSet<ServiceCategory> ServiceCategories { get; set; }

    public DabClinicContext()
    {
    }

    public DabClinicContext(DbContextOptions<DabClinicContext> options)
        : base(options)
    {
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //    => optionsBuilder.UseSqlServer("server =(local); database=Dab_clinic; uid=sa; pwd=12345; TrustServerCertificate=True");
    ////=> optionsBuilder.UseSqlServer(GetConnectionString());

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Account__3213E83FCE57C7FE");
            //entity.Property(e => e.Username).
            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.Removed).HasDefaultValue(false);
            entity.Property(e => e.Role).HasDefaultValue(Role.Patient);
            entity.Property(e => e.CreationTime).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Appointm__3213E83FABC7D14F");

            entity.Property(e => e.DentistNote).HasDefaultValue("");
            entity.Property(e => e.AppointmentStatus).HasDefaultValue(AppointmentStatus.no_show);
            entity.Property(e => e.AppointmentType).HasDefaultValue(AppointmentType.treatment);

            entity.HasOne(d => d.Customer).WithMany(p => p.AppointmentCustomers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Appointme__custo__4316F928");

            entity.HasOne(d => d.Dentist).WithMany(p => p.AppointmentDentists)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Appointme__denti__440B1D61");

            entity.HasOne(d => d.Slot).WithMany(p => p.Appointments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Appointme__slot___44FF419A");
        });

        modelBuilder.Entity<BookedService>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BookedSe__3213E83FE26D8143");

            entity.HasOne(d => d.Appointment).WithMany(p => p.BookedServices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BookedSer__appoi__4222D4EF");

            entity.HasOne(d => d.Service).WithMany(p => p.BookedServices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BookedSer__servi__412EB0B6");
        });

        modelBuilder.Entity<Clinic>(entity =>
        {
            entity.HasKey(e => e.ClinicId).HasName("PK__Clinic__A0C8D19B1F4BF56A");

            entity.Property(e => e.Description).HasDefaultValue("");
            entity.Property(e => e.Working).HasDefaultValue(true);
            entity.Property(e => e.ClinicStatus).HasDefaultValue(ClinicStatus.removed);
        });

        modelBuilder.Entity<ClinicService>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ClinicSe__3213E83FBA4C9E02");

            entity.Property(e => e.Available).HasDefaultValue(true);
            entity.Property(e => e.Weekday).HasDefaultValue(Weekday.Sunday);

            entity.HasOne(d => d.Category).WithMany(p => p.ClinicServices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ClinicSer__categ__403A8C7D");
        });

        modelBuilder.Entity<ClinicSlot>(entity =>
        {
            entity.HasKey(e => e.SlotId).HasName("PK__ClinicSl__971A01BB0C346FB0");

            entity.Property(e => e.Status).HasDefaultValue(true);
            entity.Property(e => e.Weekday).HasDefaultValue(Weekday.Sunday);
        });

        modelBuilder.Entity<ServiceCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ServiceC__3213E83F667C2AEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
