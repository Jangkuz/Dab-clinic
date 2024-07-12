using System;
using System.Collections.Generic;

namespace Dab_clinic_repo.Models;

public partial class Account
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateTime CreationTime { get; set; }

    public string? Fullname { get; set; }

    public DateOnly? Birthdate { get; set; }

    public string? Gender { get; set; }

    public string? Phone { get; set; }

    public string Role { get; set; } = null!;

    public bool Active { get; set; }

    public bool Removed { get; set; }

    public virtual ICollection<Appointment> AppointmentCustomers { get; set; } = new List<Appointment>();

    public virtual ICollection<Appointment> AppointmentDentists { get; set; } = new List<Appointment>();
}
