USE [master]
GO
/****** Object:  Database [GAForecast]    Script Date: 23/07/2017 03:45:34 ******/
CREATE DATABASE [GAForecast]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GAForecast', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MS2014\MSSQL\DATA\GAForecast.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'GAForecast_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MS2014\MSSQL\DATA\GAForecast_log.ldf' , SIZE = 2816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [GAForecast] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GAForecast].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GAForecast] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GAForecast] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GAForecast] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GAForecast] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GAForecast] SET ARITHABORT OFF 
GO
ALTER DATABASE [GAForecast] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GAForecast] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GAForecast] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GAForecast] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GAForecast] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GAForecast] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GAForecast] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GAForecast] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GAForecast] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GAForecast] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GAForecast] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GAForecast] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GAForecast] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GAForecast] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GAForecast] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GAForecast] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GAForecast] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GAForecast] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GAForecast] SET  MULTI_USER 
GO
ALTER DATABASE [GAForecast] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GAForecast] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GAForecast] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GAForecast] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [GAForecast] SET DELAYED_DURABILITY = DISABLED 
GO
USE [GAForecast]
GO
/****** Object:  Table [dbo].[CostDataMonths]    Script Date: 23/07/2017 03:45:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CostDataMonths](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Arbetskostnad] [decimal](12, 4) NULL,
	[Materialkostnad] [decimal](12, 4) NULL,
	[Verktygskostnad] [decimal](12, 4) NULL,
	[Rapporteringsdatum] [datetime] NULL,
 CONSTRAINT [PK_CostData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rapporteringsdatum]    Script Date: 23/07/2017 03:45:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rapporteringsdatum](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Placering] [nvarchar](max) NULL,
	[Placeringens_beskrivning] [nvarchar](max) NULL,
	[Arbetsorder] [nvarchar](max) NULL,
	[överliggande_ao] [int] NULL,
	[Arbetsorderbeskrivning_och_långtext] [ntext] NULL,
	[Rapporteringsdatum] [datetime] NULL,
	[Verkligt_startdatum] [datetime] NULL,
	[verkligt_slutdatum] [datetime] NULL,
	[Arbetstyp] [nvarchar](max) NULL,
	[Problemkod] [nvarchar](max) NULL,
	[Problemkodsbeskrivning] [nvarchar](max) NULL,
	[Orsakskod] [nvarchar](max) NULL,
	[Orsaksbeskrivning] [nvarchar](max) NULL,
	[Åtgärdskod] [nvarchar](max) NULL,
	[Åtgärdskodsbeskrivning] [nvarchar](max) NULL,
	[Beskrivning_av_utfört_arbete_och_långtext] [ntext] NULL,
	[Antal_timmar] [int] NULL,
	[Arbetskostnad] [decimal](12, 4) NULL,
	[Materialkostnad] [decimal](12, 4) NULL,
	[Verktygskostnad] [decimal](12, 4) NULL,
 CONSTRAINT [PK_Rapporteringsdatum] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StationaryCostData]    Script Date: 23/07/2017 03:45:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StationaryCostData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Arbetskostnad] [decimal](10, 6) NULL,
	[Materialkostnad] [decimal](10, 6) NULL,
	[Verktygskostnad] [decimal](10, 6) NULL,
	[Rapporteringsdatum] [datetime] NULL,
	[lags_Arbetskostnad] [decimal](10, 6) NULL,
	[lags_Materialkostnad] [decimal](10, 6) NULL,
	[lags_Verktygskostnad] [decimal](10, 6) NULL,
 CONSTRAINT [PK_StationaryCostData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [GAForecast] SET  READ_WRITE 
GO
