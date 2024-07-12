using System;
using System.Collections.Generic;

namespace Dab_clinic_repo.Models;

public partial class Appointment
{
    public int Id { get; set; }

    public string AppointmentType { get; set; } = null!;

    public int Number { get; set; }

    public DateOnly Date { get; set; }

    public int SlotId { get; set; }

    public int CustomerId { get; set; }

    public int DentistId { get; set; }

    public int CycleCount { get; set; }

    public string DentistNote { get; set; } = null!;

    public string Status { get; set; } = null!;

    public int PriceFinal { get; set; }

    public virtual ICollection<BookedService> BookedServices { get; set; } = new List<BookedService>();

    public virtual Account Customer { get; set; } = null!;

    public virtual Account Dentist { get; set; } = null!;

    public virtual ClinicSlot Slot { get; set; } = null!;
}
