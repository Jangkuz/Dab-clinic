using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DabClinic.Domain.Models;

[Table("BookedService")]
public partial class BookedService : DomainObject
{
    [Column("appointment_id")]
    public int AppointmentId { get; set; }

    [Column("service_id")]
    public int ServiceId { get; set; }

    [Column("price")]
    public int Price { get; set; }

    [ForeignKey("AppointmentId")]
    [InverseProperty("BookedServices")]
    public virtual Appointment Appointment { get; set; } = null!;

    [ForeignKey("ServiceId")]
    [InverseProperty("BookedServices")]
    public virtual ClinicService Service { get; set; } = null!;
}
