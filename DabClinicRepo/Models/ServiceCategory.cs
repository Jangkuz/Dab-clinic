﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DabClinicRepo.Models;

[Table("ServiceCategory")]
public partial class ServiceCategory
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(32)]
    public string Name { get; set; } = null!;

    [InverseProperty("Category")]
    public virtual ICollection<ClinicService> ClinicServices { get; set; } = new List<ClinicService>();
}
