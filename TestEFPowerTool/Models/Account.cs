﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TestEFPowerTool.Models;

[Table("Account")]
[Index("Username", Name = "UQ__Account__F3DBC572B9F57EB7", IsUnique = true)]
public partial class Account
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("username")]
    [StringLength(20)]
    public string Username { get; set; }

    [Required]
    [Column("email")]
    [StringLength(64)]
    public string Email { get; set; }

    [Required]
    [Column("password_hash")]
    [StringLength(128)]
    public string PasswordHash { get; set; }

    [Column("creation_time", TypeName = "datetime")]
    public DateTime CreationTime { get; set; }

    [Column("fullname")]
    [StringLength(255)]
    public string Fullname { get; set; }

    [Column("birthdate")]
    public DateOnly? Birthdate { get; set; }

    [Column("gender")]
    [StringLength(16)]
    public string Gender { get; set; }

    [Column("phone")]
    [StringLength(10)]
    public string Phone { get; set; }

    [Column("role")]
    public int Role { get; set; }

    [Column("active")]
    public bool Active { get; set; }

    [Column("removed")]
    public bool Removed { get; set; }

    [InverseProperty("Customer")]
    public virtual ICollection<Appointment> AppointmentCustomers { get; set; } = new List<Appointment>();

    [InverseProperty("Dentist")]
    public virtual ICollection<Appointment> AppointmentDentists { get; set; } = new List<Appointment>();
}