CREATE TABLE [Appointment] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [appointment_type] nvarchar(255) NOT NULL CHECK ([appointment_type] IN ('checkup', 'treatment')) DEFAULT 'checkup',
  [number] int NOT NULL,
  [date] date NOT NULL,
  [slot_id] int NOT NULL,
  [customer_id] int NOT NULL,
  [dentist_id] int NOT NULL,
  [cycle_count] int NOT NULL DEFAULT (0),
  [dentist_note] nvarchar(1000) NOT NULL DEFAULT '',
  [status] nvarchar(255) NOT NULL CHECK ([status] IN ('booked', 'finished', 'canceled', 'no show')) DEFAULT 'booked',
  [price_final] int NOT NULL DEFAULT (0)
)
GO

CREATE TABLE [BookedService] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [appointment_id] int NOT NULL,
  [service_id] int NOT NULL,
  [price] int NOT NULL
)
GO

CREATE TABLE [Clinic] (
  [clinic_id] int PRIMARY KEY IDENTITY(1, 1),
  [name] nvarchar(128) NOT NULL,
  [address] nvarchar(128) NOT NULL,
  [description] text NOT NULL DEFAULT '',
  [phone] nvarchar(10) NOT NULL,
  [email] nvarchar(64) NOT NULL,
  [open_hour] time(7) NOT NULL,
  [close_hour] time(7) NOT NULL,
  [working] bit NOT NULL DEFAULT (1),
  [status] nvarchar(255) NOT NULL CHECK ([status] IN ('unverified', 'verified', 'removed')) DEFAULT 'verified'
)
GO

CREATE TABLE [ClinicService] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [service_name] nvarchar(80),
  [description] nvarchar(500) NOT NULL,
  [price] int NOT NULL,
  [available] bit NOT NULL DEFAULT (1),
  [category_id] int NOT NULL,
  [removed] bit NOT NULL,
  [weekday] tinyint DEFAULT (127),
  [in_slot_treatment] bit
)
GO

CREATE TABLE [ClinicSlot] (
  [slot_id] int PRIMARY KEY IDENTITY(1, 1),
  [max_checkup] int NOT NULL,
  [max_treatment] int NOT NULL,
  [weekday] tinyint NOT NULL,
  [time_id] int NOT NULL,
  [status] bit NOT NULL DEFAULT 'true',
  [start] time(7) NOT NULL,
  [end] time(7) NOT NULL
)
GO

CREATE TABLE [ServiceCategory] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [name] nvarchar(32) NOT NULL
)
GO

CREATE TABLE [Account] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [username] nvarchar(20) UNIQUE NOT NULL,
  [email] nvarchar(64) NOT NULL,
  [password_hash] nvarchar(128) NOT NULL,
  [creation_time] datetime NOT NULL DEFAULT (GETDATE()),
  [fullname] nvarchar(255),
  [birthdate] date,
  [gender] nvarchar(16),
  [phone] nvarchar(10),
  [role] nvarchar(255) NOT NULL CHECK ([role] IN ('Owner', 'Patient', 'Staff', 'Admin')) DEFAULT 'Patient',
  [active] bit NOT NULL DEFAULT (1),
  [removed] bit NOT NULL
)
GO

EXEC sp_addextendedproperty
@name = N'Column_Description',
@value = '0: Sunday 
1: Monday 
2: Tuesday 
3: Wednesday 
4: Thursday 
5: Friday 
6: Saturday',
@level0type = N'Schema', @level0name = 'dbo',
@level1type = N'Table',  @level1name = 'ClinicSlot',
@level2type = N'Column', @level2name = 'weekday';
GO

ALTER TABLE [ClinicService] ADD CONSTRAINT [FKClinicServ913410] FOREIGN KEY ([category_id]) REFERENCES [ServiceCategory] ([id])
GO

ALTER TABLE [BookedService] ADD CONSTRAINT [FKBookedServ419526] FOREIGN KEY ([service_id]) REFERENCES [ClinicService] ([id])
GO

ALTER TABLE [BookedService] ADD CONSTRAINT [FKBookedServ274862] FOREIGN KEY ([appointment_id]) REFERENCES [Appointment] ([id])
GO

ALTER TABLE [Appointment] ADD CONSTRAINT [FKAppointmen366296] FOREIGN KEY ([customer_id]) REFERENCES [Account] ([id])
GO

ALTER TABLE [Appointment] ADD CONSTRAINT [FKAppointmen157913] FOREIGN KEY ([dentist_id]) REFERENCES [Account] ([id])
GO

ALTER TABLE [Appointment] ADD CONSTRAINT [FKAppointmen998789] FOREIGN KEY ([slot_id]) REFERENCES [ClinicSlot] ([slot_id])
GO
