USE [master]
GO
/****** Object:  Database [ControlSchool]    Script Date: 22/06/2014 22:55:20 ******/
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
/****** Object:  Table [dbo].[Level]    Script Date: 22/06/2014 22:55:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Level](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Level] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Level] PRIMARY KEY CLUSTERED 
(
	[Level] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Result]    Script Date: 22/06/2014 22:55:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Result](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Result] [int] NOT NULL,
 CONSTRAINT [PK_Result] PRIMARY KEY CLUSTERED 
(
	[Result] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ResultSubjectStudent]    Script Date: 22/06/2014 22:55:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ResultSubjectStudent](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Student] [int] NOT NULL,
	[Subject] [varchar](50) NOT NULL,
	[Result] [int] NOT NULL,
 CONSTRAINT [PK_ResultSubjectStudent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Section]    Script Date: 22/06/2014 22:55:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Section](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Section] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Section] PRIMARY KEY CLUSTERED 
(
	[Section] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SectionLevel]    Script Date: 22/06/2014 22:55:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SectionLevel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Level] [varchar](50) NOT NULL,
	[Section] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SectionLevel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Student]    Script Date: 22/06/2014 22:55:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Identification] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Lastname1] [varchar](50) NOT NULL,
	[Lastname2] [varchar](50) NOT NULL,
	[Gender] [varchar](15) NOT NULL,
	[Age] [int] NOT NULL,
	[Telephone] [int] NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Identification] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentLevel]    Script Date: 22/06/2014 22:55:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StudentLevel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Student] [int] NOT NULL,
	[Level] [varchar](50) NOT NULL,
 CONSTRAINT [PK_StudentLevel] PRIMARY KEY CLUSTERED 
(
	[Level] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentSection]    Script Date: 22/06/2014 22:55:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StudentSection](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Student] [int] NOT NULL,
	[Section] [varchar](50) NOT NULL,
 CONSTRAINT [PK_StudentSection] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentSubject]    Script Date: 22/06/2014 22:55:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StudentSubject](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Student] [int] NOT NULL,
	[Subject] [varchar](50) NOT NULL,
 CONSTRAINT [PK_StudentSubject] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Subject]    Script Date: 22/06/2014 22:55:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Subject](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Subject] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[Subject] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[ResultSubjectStudent]  WITH CHECK ADD  CONSTRAINT [FK_ResultSubjectStudent_Result] FOREIGN KEY([Result])
REFERENCES [dbo].[Result] ([Result])
GO
ALTER TABLE [dbo].[ResultSubjectStudent] CHECK CONSTRAINT [FK_ResultSubjectStudent_Result]
GO
ALTER TABLE [dbo].[ResultSubjectStudent]  WITH CHECK ADD  CONSTRAINT [FK_ResultSubjectStudent_Student] FOREIGN KEY([Student])
REFERENCES [dbo].[Student] ([Identification])
GO
ALTER TABLE [dbo].[ResultSubjectStudent] CHECK CONSTRAINT [FK_ResultSubjectStudent_Student]
GO
ALTER TABLE [dbo].[ResultSubjectStudent]  WITH CHECK ADD  CONSTRAINT [FK_ResultSubjectStudent_Subject] FOREIGN KEY([Subject])
REFERENCES [dbo].[Subject] ([Subject])
GO
ALTER TABLE [dbo].[ResultSubjectStudent] CHECK CONSTRAINT [FK_ResultSubjectStudent_Subject]
GO
ALTER TABLE [dbo].[SectionLevel]  WITH CHECK ADD  CONSTRAINT [FK_SectionLevel_Level] FOREIGN KEY([Level])
REFERENCES [dbo].[Level] ([Level])
GO
ALTER TABLE [dbo].[SectionLevel] CHECK CONSTRAINT [FK_SectionLevel_Level]
GO
ALTER TABLE [dbo].[SectionLevel]  WITH CHECK ADD  CONSTRAINT [FK_SectionLevel_Section] FOREIGN KEY([Section])
REFERENCES [dbo].[Section] ([Section])
GO
ALTER TABLE [dbo].[SectionLevel] CHECK CONSTRAINT [FK_SectionLevel_Section]
GO
ALTER TABLE [dbo].[StudentLevel]  WITH CHECK ADD  CONSTRAINT [FK_SectionLevel_Student] FOREIGN KEY([Student])
REFERENCES [dbo].[Student] ([Identification])
GO
ALTER TABLE [dbo].[StudentLevel] CHECK CONSTRAINT [FK_SectionLevel_Student]
GO
ALTER TABLE [dbo].[StudentSection]  WITH CHECK ADD  CONSTRAINT [FK_StudentSection_Section] FOREIGN KEY([Section])
REFERENCES [dbo].[Section] ([Section])
GO
ALTER TABLE [dbo].[StudentSection] CHECK CONSTRAINT [FK_StudentSection_Section]
GO
ALTER TABLE [dbo].[StudentSection]  WITH CHECK ADD  CONSTRAINT [FK_StudentSection_Student] FOREIGN KEY([Student])
REFERENCES [dbo].[Student] ([Identification])
GO
ALTER TABLE [dbo].[StudentSection] CHECK CONSTRAINT [FK_StudentSection_Student]
GO
ALTER TABLE [dbo].[StudentSubject]  WITH CHECK ADD  CONSTRAINT [FK_StudentSubject_Student] FOREIGN KEY([Student])
REFERENCES [dbo].[Student] ([Identification])
GO
ALTER TABLE [dbo].[StudentSubject] CHECK CONSTRAINT [FK_StudentSubject_Student]
GO
ALTER TABLE [dbo].[StudentSubject]  WITH CHECK ADD  CONSTRAINT [FK_StudentSubject_Subject] FOREIGN KEY([Subject])
REFERENCES [dbo].[Subject] ([Subject])
GO
ALTER TABLE [dbo].[StudentSubject] CHECK CONSTRAINT [FK_StudentSubject_Subject]
GO
USE [master]
GO
ALTER DATABASE [ControlSchool] SET  READ_WRITE 
GO
