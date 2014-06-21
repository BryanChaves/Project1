USE [master]
GO
/****** Object:  Database [ControlSchool]    Script Date: 21/06/2014 11:43:32 ******/
CREATE DATABASE [ControlSchool]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ControlSchool', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ControlSchool.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ControlSchool_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ControlSchool_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ControlSchool] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ControlSchool].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ControlSchool] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ControlSchool] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ControlSchool] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ControlSchool] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ControlSchool] SET ARITHABORT OFF 
GO
ALTER DATABASE [ControlSchool] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ControlSchool] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ControlSchool] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ControlSchool] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ControlSchool] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ControlSchool] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ControlSchool] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ControlSchool] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ControlSchool] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ControlSchool] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ControlSchool] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ControlSchool] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ControlSchool] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ControlSchool] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ControlSchool] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ControlSchool] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ControlSchool] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ControlSchool] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ControlSchool] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ControlSchool] SET  MULTI_USER 
GO
ALTER DATABASE [ControlSchool] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ControlSchool] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ControlSchool] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ControlSchool] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [ControlSchool]
GO
/****** Object:  Table [dbo].[Classes]    Script Date: 21/06/2014 11:43:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classes](
	[id_class] [int] IDENTITY(1,1) NOT NULL,
	[id_teacher] [int] NOT NULL,
	[id_subject] [int] NOT NULL,
 CONSTRAINT [PK_class] PRIMARY KEY CLUSTERED 
(
	[id_class] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Result]    Script Date: 21/06/2014 11:43:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Result](
	[id_result] [int] IDENTITY(1,1) NOT NULL,
	[id_student] [int] NOT NULL,
	[id_subject] [int] NOT NULL,
	[result] [int] NOT NULL,
 CONSTRAINT [PK_Result] PRIMARY KEY CLUSTERED 
(
	[id_result] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Student]    Script Date: 21/06/2014 11:43:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Student](
	[id_student] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[lastname1] [varchar](50) NOT NULL,
	[lastname2] [varchar](50) NOT NULL,
	[gender] [varchar](15) NOT NULL,
	[age] [int] NOT NULL,
	[telephone] [int] NOT NULL,
 CONSTRAINT [PK_student] PRIMARY KEY CLUSTERED 
(
	[id_student] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentClasses]    Script Date: 21/06/2014 11:43:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentClasses](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_student] [int] NOT NULL,
	[id_class] [int] NOT NULL,
 CONSTRAINT [PK_StudentClasses] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StudentSubject]    Script Date: 21/06/2014 11:43:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentSubject](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_student] [int] NOT NULL,
	[id_subject] [int] NOT NULL,
	[id_result] [int] NOT NULL,
 CONSTRAINT [PK_StudentSubject] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Subject]    Script Date: 21/06/2014 11:43:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Subject](
	[id_subject] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_subject] PRIMARY KEY CLUSTERED 
(
	[id_subject] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 21/06/2014 11:43:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Teacher](
	[id_teacher] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[lastname1] [varchar](50) NOT NULL,
	[lastname2] [varchar](50) NOT NULL,
	[gender] [varchar](15) NOT NULL,
	[age] [int] NOT NULL,
	[telephone] [int] NOT NULL,
 CONSTRAINT [PK_teacher] PRIMARY KEY CLUSTERED 
(
	[id_teacher] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TeacherSubject]    Script Date: 21/06/2014 11:43:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeacherSubject](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_teacher] [int] NOT NULL,
	[id_subject] [int] NOT NULL,
 CONSTRAINT [PK_TeacherSubject] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Classes_subject] FOREIGN KEY([id_subject])
REFERENCES [dbo].[Subject] ([id_subject])
GO
ALTER TABLE [dbo].[Classes] CHECK CONSTRAINT [FK_Classes_subject]
GO
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Classes_teacher] FOREIGN KEY([id_teacher])
REFERENCES [dbo].[Teacher] ([id_teacher])
GO
ALTER TABLE [dbo].[Classes] CHECK CONSTRAINT [FK_Classes_teacher]
GO
ALTER TABLE [dbo].[StudentClasses]  WITH CHECK ADD  CONSTRAINT [FK_StudentClasses] FOREIGN KEY([id_student])
REFERENCES [dbo].[Student] ([id_student])
GO
ALTER TABLE [dbo].[StudentClasses] CHECK CONSTRAINT [FK_StudentClasses]
GO
ALTER TABLE [dbo].[StudentClasses]  WITH CHECK ADD  CONSTRAINT [FK_StudentClasses_class] FOREIGN KEY([id_class])
REFERENCES [dbo].[Classes] ([id_class])
GO
ALTER TABLE [dbo].[StudentClasses] CHECK CONSTRAINT [FK_StudentClasses_class]
GO
ALTER TABLE [dbo].[StudentSubject]  WITH CHECK ADD  CONSTRAINT [FK_StudentSubject_result] FOREIGN KEY([id_result])
REFERENCES [dbo].[Result] ([id_result])
GO
ALTER TABLE [dbo].[StudentSubject] CHECK CONSTRAINT [FK_StudentSubject_result]
GO
ALTER TABLE [dbo].[StudentSubject]  WITH CHECK ADD  CONSTRAINT [FK_StudentSubject_student] FOREIGN KEY([id_student])
REFERENCES [dbo].[Student] ([id_student])
GO
ALTER TABLE [dbo].[StudentSubject] CHECK CONSTRAINT [FK_StudentSubject_student]
GO
ALTER TABLE [dbo].[StudentSubject]  WITH CHECK ADD  CONSTRAINT [FK_StudentSubject_subject] FOREIGN KEY([id_subject])
REFERENCES [dbo].[Subject] ([id_subject])
GO
ALTER TABLE [dbo].[StudentSubject] CHECK CONSTRAINT [FK_StudentSubject_subject]
GO
ALTER TABLE [dbo].[TeacherSubject]  WITH CHECK ADD  CONSTRAINT [FK_TeacherSubject_subject] FOREIGN KEY([id_subject])
REFERENCES [dbo].[Subject] ([id_subject])
GO
ALTER TABLE [dbo].[TeacherSubject] CHECK CONSTRAINT [FK_TeacherSubject_subject]
GO
ALTER TABLE [dbo].[TeacherSubject]  WITH CHECK ADD  CONSTRAINT [FK_TeacherSubject_teacher] FOREIGN KEY([id_teacher])
REFERENCES [dbo].[Teacher] ([id_teacher])
GO
ALTER TABLE [dbo].[TeacherSubject] CHECK CONSTRAINT [FK_TeacherSubject_teacher]
GO
USE [master]
GO
ALTER DATABASE [ControlSchool] SET  READ_WRITE 
GO
