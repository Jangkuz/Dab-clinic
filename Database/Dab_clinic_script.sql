USE [master]
GO
/****** Object:  Database [Dab_clinic]    Script Date: 7/12/2024 11:15:14 PM ******/
CREATE DATABASE [Dab_clinic]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Dab_clinic', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Dab_clinic.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Dab_clinic_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Dab_clinic_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Dab_clinic].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Dab_clinic] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Dab_clinic] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Dab_clinic] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Dab_clinic] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Dab_clinic] SET ARITHABORT OFF 
GO
ALTER DATABASE [Dab_clinic] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Dab_clinic] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Dab_clinic] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Dab_clinic] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Dab_clinic] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Dab_clinic] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Dab_clinic] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Dab_clinic] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Dab_clinic] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Dab_clinic] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Dab_clinic] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Dab_clinic] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Dab_clinic] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Dab_clinic] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Dab_clinic] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Dab_clinic] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Dab_clinic] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Dab_clinic] SET RECOVERY FULL 
GO
ALTER DATABASE [Dab_clinic] SET  MULTI_USER 
GO
ALTER DATABASE [Dab_clinic] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Dab_clinic] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Dab_clinic] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Dab_clinic] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Dab_clinic', N'ON'
GO
USE [Dab_clinic]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 7/12/2024 11:15:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](20) NOT NULL,
	[email] [nvarchar](64) NOT NULL,
	[password_hash] [nvarchar](128) NOT NULL,
	[creation_time] [datetime] NOT NULL,
	[fullname] [nvarchar](255) NULL,
	[birthdate] [date] NULL,
	[gender] [nvarchar](16) NULL,
	[phone] [nvarchar](10) NULL,
	[role] [nvarchar](255) NOT NULL,
	[active] [bit] NOT NULL,
	[removed] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Appointment]    Script Date: 7/12/2024 11:15:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[appointment_type] [nvarchar](255) NOT NULL,
	[number] [int] NOT NULL,
	[date] [date] NOT NULL,
	[slot_id] [int] NOT NULL,
	[customer_id] [int] NOT NULL,
	[dentist_id] [int] NOT NULL,
	[cycle_count] [int] NOT NULL,
	[dentist_note] [nvarchar](1000) NOT NULL,
	[status] [nvarchar](255) NOT NULL,
	[price_final] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookedService]    Script Date: 7/12/2024 11:15:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookedService](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[appointment_id] [int] NOT NULL,
	[service_id] [int] NOT NULL,
	[price] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clinic]    Script Date: 7/12/2024 11:15:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clinic](
	[clinic_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](128) NOT NULL,
	[address] [nvarchar](128) NOT NULL,
	[description] [text] NOT NULL,
	[phone] [nvarchar](10) NOT NULL,
	[email] [nvarchar](64) NOT NULL,
	[open_hour] [time](7) NOT NULL,
	[close_hour] [time](7) NOT NULL,
	[working] [bit] NOT NULL,
	[status] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[clinic_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClinicService]    Script Date: 7/12/2024 11:15:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClinicService](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[service_name] [nvarchar](80) NULL,
	[description] [nvarchar](500) NOT NULL,
	[price] [int] NOT NULL,
	[available] [bit] NOT NULL,
	[category_id] [int] NOT NULL,
	[removed] [bit] NOT NULL,
	[weekday] [tinyint] NULL,
	[in_slot_treatment] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClinicSlot]    Script Date: 7/12/2024 11:15:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClinicSlot](
	[slot_id] [int] IDENTITY(1,1) NOT NULL,
	[max_checkup] [int] NOT NULL,
	[max_treatment] [int] NOT NULL,
	[weekday] [tinyint] NOT NULL,
	[time_id] [int] NOT NULL,
	[status] [bit] NOT NULL,
	[start] [time](7) NOT NULL,
	[end] [time](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[slot_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceCategory]    Script Date: 7/12/2024 11:15:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceCategory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](32) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Account__F3DBC5723DB7B365]    Script Date: 7/12/2024 11:15:15 PM ******/
ALTER TABLE [dbo].[Account] ADD UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT (getdate()) FOR [creation_time]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT ('Patient') FOR [role]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT ((1)) FOR [active]
GO
ALTER TABLE [dbo].[Appointment] ADD  DEFAULT ('checkup') FOR [appointment_type]
GO
ALTER TABLE [dbo].[Appointment] ADD  DEFAULT ((0)) FOR [cycle_count]
GO
ALTER TABLE [dbo].[Appointment] ADD  DEFAULT ('') FOR [dentist_note]
GO
ALTER TABLE [dbo].[Appointment] ADD  DEFAULT ('booked') FOR [status]
GO
ALTER TABLE [dbo].[Appointment] ADD  DEFAULT ((0)) FOR [price_final]
GO
ALTER TABLE [dbo].[Clinic] ADD  DEFAULT ('') FOR [description]
GO
ALTER TABLE [dbo].[Clinic] ADD  DEFAULT ((1)) FOR [working]
GO
ALTER TABLE [dbo].[Clinic] ADD  DEFAULT ('verified') FOR [status]
GO
ALTER TABLE [dbo].[ClinicService] ADD  DEFAULT ((1)) FOR [available]
GO
ALTER TABLE [dbo].[ClinicService] ADD  DEFAULT ((127)) FOR [weekday]
GO
ALTER TABLE [dbo].[ClinicSlot] ADD  DEFAULT ('true') FOR [status]
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD  CONSTRAINT [FKAppointmen157913] FOREIGN KEY([dentist_id])
REFERENCES [dbo].[Account] ([id])
GO
ALTER TABLE [dbo].[Appointment] CHECK CONSTRAINT [FKAppointmen157913]
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD  CONSTRAINT [FKAppointmen366296] FOREIGN KEY([customer_id])
REFERENCES [dbo].[Account] ([id])
GO
ALTER TABLE [dbo].[Appointment] CHECK CONSTRAINT [FKAppointmen366296]
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD  CONSTRAINT [FKAppointmen998789] FOREIGN KEY([slot_id])
REFERENCES [dbo].[ClinicSlot] ([slot_id])
GO
ALTER TABLE [dbo].[Appointment] CHECK CONSTRAINT [FKAppointmen998789]
GO
ALTER TABLE [dbo].[BookedService]  WITH CHECK ADD  CONSTRAINT [FKBookedServ274862] FOREIGN KEY([appointment_id])
REFERENCES [dbo].[Appointment] ([id])
GO
ALTER TABLE [dbo].[BookedService] CHECK CONSTRAINT [FKBookedServ274862]
GO
ALTER TABLE [dbo].[BookedService]  WITH CHECK ADD  CONSTRAINT [FKBookedServ419526] FOREIGN KEY([service_id])
REFERENCES [dbo].[ClinicService] ([id])
GO
ALTER TABLE [dbo].[BookedService] CHECK CONSTRAINT [FKBookedServ419526]
GO
ALTER TABLE [dbo].[ClinicService]  WITH CHECK ADD  CONSTRAINT [FKClinicServ913410] FOREIGN KEY([category_id])
REFERENCES [dbo].[ServiceCategory] ([id])
GO
ALTER TABLE [dbo].[ClinicService] CHECK CONSTRAINT [FKClinicServ913410]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD CHECK  (([role]='Admin' OR [role]='Staff' OR [role]='Patient' OR [role]='Owner'))
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD CHECK  (([appointment_type]='treatment' OR [appointment_type]='checkup'))
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD CHECK  (([status]='no show' OR [status]='canceled' OR [status]='finished' OR [status]='booked'))
GO
ALTER TABLE [dbo].[Clinic]  WITH CHECK ADD CHECK  (([status]='removed' OR [status]='verified' OR [status]='unverified'))
GO
EXEC sys.sp_addextendedproperty @name=N'Column_Description', @value=N'0: Sunday 
1: Monday 
2: Tuesday 
3: Wednesday 
4: Thursday 
5: Friday 
6: Saturday' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ClinicSlot', @level2type=N'COLUMN',@level2name=N'weekday'
GO
USE [master]
GO
ALTER DATABASE [Dab_clinic] SET  READ_WRITE 
GO
