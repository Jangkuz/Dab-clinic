using DabClinic.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DabClinic.Domain.Models;

[Table("Account")]
[Index("Username", Name = "UQ__Account__F3DBC5722D6EF97E", IsUnique = true)]
public partial class Account : DomainObject
{
    [Column("username")]
    [StringLength(20)]
    public string Username { get; set; } = null!;

    [Column("email")]
    [StringLength(64)]
    public string Email { get; set; } = null!;

    [Column("password_hash")]
    [StringLength(128)]
    public string PasswordHash { get; set; } = null!;

    [Column("creation_time", TypeName = "datetime")]
    public DateTime CreationTime { get; set; }

    [Column("fullname")]
    [StringLength(255)]
    public string? Fullname { get; set; }

    [Column("birthdate")]
    public DateOnly? Birthdate { get; set; }

    [Column("gender")]
    [StringLength(16)]
    public string? Gender { get; set; }

    [Column("phone")]
    [StringLength(20)]
    public string? Phone { get; set; }

    [Column("role")]
    public Role Role { get; set; }

    [Column("active")]
    public bool Active { get; set; }

    [Column("removed")]
    public bool Removed { get; set; }

    [InverseProperty("Customer")]
    public virtual ICollection<Appointment> AppointmentCustomers { get; set; } = new List<Appointment>();

    [InverseProperty("Dentist")]
    public virtual ICollection<Appointment> AppointmentDentists { get; set; } = new List<Appointment>();
}
