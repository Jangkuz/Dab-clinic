﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DabClinicRepo.Enums;
using Microsoft.EntityFrameworkCore;

namespace DabClinicRepo.Models;

[Table("ClinicSlot")]
public partial class ClinicSlot
{
    [Key]
    [Column("slot_id")]
    public int SlotId { get; set; }

    [Column("max_checkup")]
    public int MaxCheckup { get; set; }

    [Column("max_treatment")]
    public int MaxTreatment { get; set; }

    [Column("weekday")]
    public Weekday Weekday { get; set; }

    [Column("time_id")]
    public int TimeId { get; set; }

    [Column("status")]
    public bool Status { get; set; }

    [Column("start")]
    public TimeOnly Start { get; set; }

    [Column("end")]
    public TimeOnly End { get; set; }

    [InverseProperty("Slot")]
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
