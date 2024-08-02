using DabClinic.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DabClinic.Domain.Models;

[Table("Appointment")]
public partial class Appointment : DomainObject
{
    [Column("appointment_type")]
    public AppointmentType AppointmentType { get; set; }

    [Column("number")]
    public int Number { get; set; }

    [Column("date")]
    public DateOnly Date { get; set; }

    [Column("slot_id")]
    public int SlotId { get; set; }

    [Column("customer_id")]
    public int CustomerId { get; set; }

    [Column("dentist_id")]
    public int DentistId { get; set; }

    [Column("cycle_count")]
    public int CycleCount { get; set; }

    [Column("dentist_note")]
    [StringLength(1000)]
    public string DentistNote { get; set; } = null!;

    [Column("appointment_status")]
    public AppointmentStatus AppointmentStatus { get; set; }

    [Column("price_final")]
    public int PriceFinal { get; set; }

    [InverseProperty("Appointment")]
    public virtual ICollection<BookedService> BookedServices { get; set; } = new List<BookedService>();

    [ForeignKey("CustomerId")]
    [InverseProperty("AppointmentCustomers")]
    public virtual Account Customer { get; set; } = null!;

    [ForeignKey("DentistId")]
    [InverseProperty("AppointmentDentists")]
    public virtual Account Dentist { get; set; } = null!;

    [ForeignKey("SlotId")]
    [InverseProperty("Appointments")]
    public virtual ClinicSlot Slot { get; set; } = null!;
}
