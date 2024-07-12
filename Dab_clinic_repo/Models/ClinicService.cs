using System;
using System.Collections.Generic;

namespace Dab_clinic_repo.Models;

public partial class ClinicService
{
    public int Id { get; set; }

    public string? ServiceName { get; set; }

    public string Description { get; set; } = null!;

    public int Price { get; set; }

    public bool Available { get; set; }

    public int CategoryId { get; set; }

    public bool Removed { get; set; }

    public byte? Weekday { get; set; }

    public bool? InSlotTreatment { get; set; }

    public virtual ICollection<BookedService> BookedServices { get; set; } = new List<BookedService>();

    public virtual ServiceCategory Category { get; set; } = null!;
}
