using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DabClinic.Domain.Models;

[Table("ServiceCategory")]
public partial class ServiceCategory :DomainObject
{
    [Column("name")]
    [StringLength(32)]
    public string Name { get; set; } = null!;

    [InverseProperty("Category")]
    public virtual ICollection<ClinicService> ClinicServices { get; set; } = new List<ClinicService>();
}
