﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TestEFPowerTool.Models;

[Table("BookedService")]
public partial class BookedService
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("appointment_id")]
    public int AppointmentId { get; set; }

    [Column("service_id")]
    public int ServiceId { get; set; }

    [Column("price")]
    public int Price { get; set; }

    [ForeignKey("AppointmentId")]
    [InverseProperty("BookedServices")]
    public virtual Appointment Appointment { get; set; }

    [ForeignKey("ServiceId")]
    [InverseProperty("BookedServices")]
    public virtual ClinicService Service { get; set; }
}