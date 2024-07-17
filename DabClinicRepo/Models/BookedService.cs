using System;
using System.Collections.Generic;

namespace DabClinicRepo.Models;

public partial class BookedService
{
    public int Id { get; set; }

    public int AppointmentId { get; set; }

    public int ServiceId { get; set; }

    public int Price { get; set; }

    public virtual Appointment Appointment { get; set; } = null!;

    public virtual ClinicService Service { get; set; } = null!;
}
