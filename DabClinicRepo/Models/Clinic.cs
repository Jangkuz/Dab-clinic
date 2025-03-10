﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DabClinicRepo.Enums;
using Microsoft.EntityFrameworkCore;

namespace DabClinicRepo.Models;

[Table("Clinic")]
public partial class Clinic
{
    [Key]
    [Column("clinic_id")]
    public int ClinicId { get; set; }

    [Column("name")]
    [StringLength(128)]
    public string Name { get; set; } = null!;

    [Column("address")]
    [StringLength(128)]
    public string Address { get; set; } = null!;

    [Column("description", TypeName = "text")]
    public string Description { get; set; } = null!;

    [Column("phone")]
    [StringLength(10)]
    public string Phone { get; set; } = null!;

    [Column("email")]
    [StringLength(64)]
    public string Email { get; set; } = null!;

    [Column("open_hour")]
    public TimeOnly OpenHour { get; set; }

    [Column("close_hour")]
    public TimeOnly CloseHour { get; set; }

    [Column("working")]
    public bool Working { get; set; }

    [Column("clinic_status")]
    public ClinicStatus ClinicStatus { get; set; }
}
