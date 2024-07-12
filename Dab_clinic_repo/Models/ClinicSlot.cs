using System;
using System.Collections.Generic;

namespace Dab_clinic_repo.Models;

public partial class ClinicSlot
{
    public int SlotId { get; set; }

    public int MaxCheckup { get; set; }

    public int MaxTreatment { get; set; }

    public byte Weekday { get; set; }

    public int TimeId { get; set; }

    public bool Status { get; set; }

    public TimeOnly Start { get; set; }

    public TimeOnly End { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
