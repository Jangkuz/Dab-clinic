using System;
using System.Collections.Generic;

namespace Dab_clinic_repo.Models;

public partial class Clinic
{
    public int ClinicId { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public TimeOnly OpenHour { get; set; }

    public TimeOnly CloseHour { get; set; }

    public bool Working { get; set; }

    public string Status { get; set; } = null!;
}
