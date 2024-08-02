using DabClinic.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DabClinic.Domain.Models;

[Table("ClinicService")]
public partial class ClinicService : DomainObject
{
    [Column("service_name")]
    [StringLength(80)]
    public string? ServiceName { get; set; }

    [Column("description")]
    [StringLength(500)]
    public string Description { get; set; } = null!;

    [Column("price")]
    public int Price { get; set; }

    [Column("available")]
    public bool Available { get; set; }

    [Column("category_id")]
    public int CategoryId { get; set; }

    [Column("removed")]
    public bool Removed { get; set; }

    [Column("weekday")]
    public Weekday? Weekday { get; set; }

    [Column("in_slot_treatment")]
    public bool? InSlotTreatment { get; set; }

    [InverseProperty("Service")]
    public virtual ICollection<BookedService> BookedServices { get; set; } = new List<BookedService>();

    [ForeignKey("CategoryId")]
    [InverseProperty("ClinicServices")]
    public virtual ServiceCategory Category { get; set; } = null!;
}
