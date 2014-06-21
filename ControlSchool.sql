USE [master]
GO
/****** Object:  Database [ControlSchool]    Script Date: 21/06/2014 17:27:12 ******/
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
/****** Object:  Table [dbo].[Classes]    Script Date: 21/06/2014 17:27:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TeacherId] [int] NOT NULL,
	[SubjectId] [int] NOT NULL,
 CONSTRAINT [pk_Classes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Result]    Script Date: 21/06/2014 17:27:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Result](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[SubjectId] [int] NOT NULL,
	[Result] [int] NOT NULL,
 CONSTRAINT [pk_Result] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Student]    Script Date: 21/06/2014 17:27:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[Lastname1] [varchar](30) NOT NULL,
	[Lastname2] [varchar](30) NOT NULL,
	[Gender] [varchar](15) NOT NULL,
	[Age] [int] NOT NULL,
	[Telephone] [int] NOT NULL,
 CONSTRAINT [pk_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentClasses]    Script Date: 21/06/2014 17:27:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentClasses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[ClassId] [int] NOT NULL,
 CONSTRAINT [pk_StudentClasses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StudentSubject]    Script Date: 21/06/2014 17:27:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentSubject](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[SubjectId] [int] NOT NULL,
	[ResultId] [int] NOT NULL,
 CONSTRAINT [pk_StudentSubject] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Subject]    Script Date: 21/06/2014 17:27:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Subject](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NOT NULL,
 CONSTRAINT [pk_Subject] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 21/06/2014 17:27:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Teacher](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](15) NOT NULL,
	[Lastname1] [varchar](30) NOT NULL,
	[Lastname2] [varchar](30) NOT NULL,
	[Gender] [varchar](20) NOT NULL,
	[Age] [int] NOT NULL,
	[Telephone] [int] NOT NULL,
 CONSTRAINT [pk_Teacher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TeacherSubject]    Script Date: 21/06/2014 17:27:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeacherSubject](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TeacherId] [int] NOT NULL,
	[SubjectId] [int] NOT NULL,
 CONSTRAINT [pk_TeacherSubject] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [fk_Classes_SubjectId] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subject] ([Id])
GO
ALTER TABLE [dbo].[Classes] CHECK CONSTRAINT [fk_Classes_SubjectId]
GO
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [fk_Classes_TeacherId] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teacher] ([Id])
GO
ALTER TABLE [dbo].[Classes] CHECK CONSTRAINT [fk_Classes_TeacherId]
GO
ALTER TABLE [dbo].[StudentClasses]  WITH CHECK ADD  CONSTRAINT [fk_StudentClasses_ClassId] FOREIGN KEY([ClassId])
REFERENCES [dbo].[Classes] ([Id])
GO
ALTER TABLE [dbo].[StudentClasses] CHECK CONSTRAINT [fk_StudentClasses_ClassId]
GO
ALTER TABLE [dbo].[StudentClasses]  WITH CHECK ADD  CONSTRAINT [fk_StudentClasses_StudentId] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
GO
ALTER TABLE [dbo].[StudentClasses] CHECK CONSTRAINT [fk_StudentClasses_StudentId]
GO
ALTER TABLE [dbo].[StudentSubject]  WITH CHECK ADD  CONSTRAINT [fk_StudentSubject_ResultId] FOREIGN KEY([ResultId])
REFERENCES [dbo].[Result] ([Id])
GO
ALTER TABLE [dbo].[StudentSubject] CHECK CONSTRAINT [fk_StudentSubject_ResultId]
GO
ALTER TABLE [dbo].[StudentSubject]  WITH CHECK ADD  CONSTRAINT [fk_StudentSubject_StudentId] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
GO
ALTER TABLE [dbo].[StudentSubject] CHECK CONSTRAINT [fk_StudentSubject_StudentId]
GO
ALTER TABLE [dbo].[StudentSubject]  WITH CHECK ADD  CONSTRAINT [fk_StudentSubject_SubjectId] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subject] ([Id])
GO
ALTER TABLE [dbo].[StudentSubject] CHECK CONSTRAINT [fk_StudentSubject_SubjectId]
GO
ALTER TABLE [dbo].[TeacherSubject]  WITH CHECK ADD  CONSTRAINT [fk_TeacherSubject_SubjectId] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subject] ([Id])
GO
ALTER TABLE [dbo].[TeacherSubject] CHECK CONSTRAINT [fk_TeacherSubject_SubjectId]
GO
ALTER TABLE [dbo].[TeacherSubject]  WITH CHECK ADD  CONSTRAINT [fk_TeacherSubject_TeacherId] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teacher] ([Id])
GO
ALTER TABLE [dbo].[TeacherSubject] CHECK CONSTRAINT [fk_TeacherSubject_TeacherId]
GO
USE [master]
GO
ALTER DATABASE [ControlSchool] SET  READ_WRITE 
GO
