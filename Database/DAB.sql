CREATE TABLE [Appointment] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [appointment_type] int NOT NULL DEFAULT (1),
  [number] int NOT NULL,
  [date] date NOT NULL,
  [slot_id] int NOT NULL,
  [customer_id] int NOT NULL,
  [dentist_id] int NOT NULL,
  [cycle_count] int NOT NULL DEFAULT (0),
  [dentist_note] nvarchar(1000) NOT NULL DEFAULT '',
  [appointment_status] int NOT NULL DEFAULT (1),
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
  [clinic_status] int NOT NULL DEFAULT (1)
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
  [weekday] int NOT NULL DEFAULT (0),
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
  [role] int NOT NULL DEFAULT (1),
  [active] bit NOT NULL DEFAULT (1),
  [removed] bit NOT NULL DEFAULT (0)
)
GO

ALTER TABLE [ClinicService] ADD FOREIGN KEY ([category_id]) REFERENCES [ServiceCategory] ([id])
GO

ALTER TABLE [BookedService] ADD FOREIGN KEY ([service_id]) REFERENCES [ClinicService] ([id])
GO

ALTER TABLE [BookedService] ADD FOREIGN KEY ([appointment_id]) REFERENCES [Appointment] ([id])
GO

ALTER TABLE [Appointment] ADD FOREIGN KEY ([customer_id]) REFERENCES [Account] ([id])
GO

ALTER TABLE [Appointment] ADD FOREIGN KEY ([dentist_id]) REFERENCES [Account] ([id])
GO

ALTER TABLE [Appointment] ADD FOREIGN KEY ([slot_id]) REFERENCES [ClinicSlot] ([slot_id])
GO
