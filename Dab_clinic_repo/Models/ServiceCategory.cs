﻿using System;
using System.Collections.Generic;

namespace Dab_clinic_repo.Models;

public partial class ServiceCategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ClinicService> ClinicServices { get; set; } = new List<ClinicService>();
}
