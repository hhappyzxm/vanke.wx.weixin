USE [master]
GO
/****** Object:  Database [EamonDemo]    Script Date: 5/13/2016 8:36:38 PM ******/
CREATE DATABASE [EamonDemo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EamonDemo', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\EamonDemo.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EamonDemo_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\EamonDemo_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [EamonDemo] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EamonDemo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EamonDemo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EamonDemo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EamonDemo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EamonDemo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EamonDemo] SET ARITHABORT OFF 
GO
ALTER DATABASE [EamonDemo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EamonDemo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EamonDemo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EamonDemo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EamonDemo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EamonDemo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EamonDemo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EamonDemo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EamonDemo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EamonDemo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EamonDemo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EamonDemo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EamonDemo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EamonDemo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EamonDemo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EamonDemo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EamonDemo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EamonDemo] SET RECOVERY FULL 
GO
ALTER DATABASE [EamonDemo] SET  MULTI_USER 
GO
ALTER DATABASE [EamonDemo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EamonDemo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EamonDemo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EamonDemo] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'EamonDemo', N'ON'
GO
USE [EamonDemo]
GO
/****** Object:  Table [dbo].[Admins]    Script Date: 5/13/2016 8:36:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Admins](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[RealName] [varchar](50) NOT NULL,
	[LoginName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Status] [int] NOT NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
 CONSTRAINT [PK_Admins] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DinnerPlaces]    Script Date: 5/13/2016 8:36:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DinnerPlaces](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Place] [varchar](50) NOT NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
 CONSTRAINT [PK_DinnerPlaces] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DinnerRegisterHistories]    Script Date: 5/13/2016 8:36:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DinnerRegisterHistories](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[StaffID] [bigint] NOT NULL,
	[DinnerDate] [datetime] NOT NULL,
	[DinnerPeopleCount] [int] NOT NULL,
	[TypeID] [bigint] NOT NULL,
	[PlaceID] [bigint] NOT NULL,
	[Comment] [text] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
 CONSTRAINT [PK_DinnerRegisterHistories] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DinnerTypes]    Script Date: 5/13/2016 8:36:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DinnerTypes](
	[ID] [bigint] NOT NULL,
	[Type] [varchar](50) NOT NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
 CONSTRAINT [PK_DinnerTypes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ExternalPersonnelDiningRegisterHistories]    Script Date: 5/13/2016 8:36:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExternalPersonnelDiningRegisterHistories](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[StaffID] [bigint] NOT NULL,
	[CardNumber] [int] NOT NULL,
	[Comment] [text] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
 CONSTRAINT [PK_ExternalPersonnelDiningRegisterHistories] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Staffs]    Script Date: 5/13/2016 8:36:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Staffs](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[RealName] [varchar](50) NOT NULL,
	[LoginName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Status] [int] NOT NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
 CONSTRAINT [PK_Staffs] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[DinnerRegisterHistories]  WITH CHECK ADD  CONSTRAINT [FK_DinnerRegisterHistories_DinnerPlaces] FOREIGN KEY([PlaceID])
REFERENCES [dbo].[DinnerPlaces] ([ID])
GO
ALTER TABLE [dbo].[DinnerRegisterHistories] CHECK CONSTRAINT [FK_DinnerRegisterHistories_DinnerPlaces]
GO
ALTER TABLE [dbo].[DinnerRegisterHistories]  WITH CHECK ADD  CONSTRAINT [FK_DinnerRegisterHistories_DinnerRegisterHistories] FOREIGN KEY([TypeID])
REFERENCES [dbo].[DinnerTypes] ([ID])
GO
ALTER TABLE [dbo].[DinnerRegisterHistories] CHECK CONSTRAINT [FK_DinnerRegisterHistories_DinnerRegisterHistories]
GO
ALTER TABLE [dbo].[DinnerRegisterHistories]  WITH CHECK ADD  CONSTRAINT [FK_DinnerRegisterHistories_Staffs] FOREIGN KEY([StaffID])
REFERENCES [dbo].[Staffs] ([ID])
GO
ALTER TABLE [dbo].[DinnerRegisterHistories] CHECK CONSTRAINT [FK_DinnerRegisterHistories_Staffs]
GO
ALTER TABLE [dbo].[ExternalPersonnelDiningRegisterHistories]  WITH CHECK ADD  CONSTRAINT [FK_ExternalPersonnelDiningRegisterHistories_Staffs] FOREIGN KEY([ID])
REFERENCES [dbo].[Staffs] ([ID])
GO
ALTER TABLE [dbo].[ExternalPersonnelDiningRegisterHistories] CHECK CONSTRAINT [FK_ExternalPersonnelDiningRegisterHistories_Staffs]
GO
USE [master]
GO
ALTER DATABASE [EamonDemo] SET  READ_WRITE 
GO
