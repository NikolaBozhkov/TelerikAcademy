USE [master]
GO
/****** Object:  Database [WorldDB]    Script Date: 22.8.2014 г. 10:47:11 ******/
CREATE DATABASE [WorldDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WorldDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\WorldDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'WorldDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\WorldDB_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [WorldDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WorldDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WorldDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WorldDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WorldDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WorldDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WorldDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [WorldDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WorldDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [WorldDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WorldDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WorldDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WorldDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WorldDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WorldDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WorldDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WorldDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WorldDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WorldDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WorldDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WorldDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WorldDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WorldDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WorldDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WorldDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WorldDB] SET RECOVERY FULL 
GO
ALTER DATABASE [WorldDB] SET  MULTI_USER 
GO
ALTER DATABASE [WorldDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WorldDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WorldDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WorldDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'WorldDB', N'ON'
GO
USE [WorldDB]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 22.8.2014 г. 10:47:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[AddressId] [int] IDENTITY(1,1) NOT NULL,
	[AddressText] [text] NULL,
	[TownId] [int] NOT NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Continents]    Script Date: 22.8.2014 г. 10:47:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Continents](
	[ContinentId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Continents] PRIMARY KEY CLUSTERED 
(
	[ContinentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Countries]    Script Date: 22.8.2014 г. 10:47:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[CountryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ContinetId] [int] NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[People]    Script Date: 22.8.2014 г. 10:47:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[People](
	[PersonId] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[AddressId] [int] NOT NULL,
 CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Towns]    Script Date: 22.8.2014 г. 10:47:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Towns](
	[TownId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CountryId] [int] NOT NULL,
 CONSTRAINT [PK_Towns] PRIMARY KEY CLUSTERED 
(
	[TownId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Addresses] ON 

INSERT [dbo].[Addresses] ([AddressId], [AddressText], [TownId]) VALUES (2, N'Address in Sofia 1', 1)
INSERT [dbo].[Addresses] ([AddressId], [AddressText], [TownId]) VALUES (3, N'Address in Paris 1', 2)
INSERT [dbo].[Addresses] ([AddressId], [AddressText], [TownId]) VALUES (4, N'Address in Sofia 2', 1)
INSERT [dbo].[Addresses] ([AddressId], [AddressText], [TownId]) VALUES (5, N'Address in Tokyo', 3)
INSERT [dbo].[Addresses] ([AddressId], [AddressText], [TownId]) VALUES (6, N'Address in Washington', 4)
INSERT [dbo].[Addresses] ([AddressId], [AddressText], [TownId]) VALUES (7, N'Address in Plovdiv 1', 6)
SET IDENTITY_INSERT [dbo].[Addresses] OFF
SET IDENTITY_INSERT [dbo].[Continents] ON 

INSERT [dbo].[Continents] ([ContinentId], [Name]) VALUES (1, N'Europe')
INSERT [dbo].[Continents] ([ContinentId], [Name]) VALUES (2, N'Asia')
INSERT [dbo].[Continents] ([ContinentId], [Name]) VALUES (3, N'North America')
SET IDENTITY_INSERT [dbo].[Continents] OFF
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([CountryId], [Name], [ContinetId]) VALUES (1, N'Bulgaria', 1)
INSERT [dbo].[Countries] ([CountryId], [Name], [ContinetId]) VALUES (2, N'USA', 3)
INSERT [dbo].[Countries] ([CountryId], [Name], [ContinetId]) VALUES (3, N'France', 1)
INSERT [dbo].[Countries] ([CountryId], [Name], [ContinetId]) VALUES (4, N'Canada', 3)
INSERT [dbo].[Countries] ([CountryId], [Name], [ContinetId]) VALUES (5, N'Japan', 2)
SET IDENTITY_INSERT [dbo].[Countries] OFF
SET IDENTITY_INSERT [dbo].[Towns] ON 

INSERT [dbo].[Towns] ([TownId], [Name], [CountryId]) VALUES (1, N'Sofia', 1)
INSERT [dbo].[Towns] ([TownId], [Name], [CountryId]) VALUES (2, N'Paris', 1)
INSERT [dbo].[Towns] ([TownId], [Name], [CountryId]) VALUES (3, N'Tokyo', 5)
INSERT [dbo].[Towns] ([TownId], [Name], [CountryId]) VALUES (4, N'Washington DC', 2)
INSERT [dbo].[Towns] ([TownId], [Name], [CountryId]) VALUES (5, N'Ottawa', 3)
INSERT [dbo].[Towns] ([TownId], [Name], [CountryId]) VALUES (6, N'Plovdiv', 1)
SET IDENTITY_INSERT [dbo].[Towns] OFF
ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Addresses_Towns] FOREIGN KEY([TownId])
REFERENCES [dbo].[Towns] ([TownId])
GO
ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK_Addresses_Towns]
GO
ALTER TABLE [dbo].[Countries]  WITH CHECK ADD  CONSTRAINT [FK_Countries_Continents] FOREIGN KEY([ContinetId])
REFERENCES [dbo].[Continents] ([ContinentId])
GO
ALTER TABLE [dbo].[Countries] CHECK CONSTRAINT [FK_Countries_Continents]
GO
ALTER TABLE [dbo].[People]  WITH CHECK ADD  CONSTRAINT [FK_People_Addresses] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Addresses] ([AddressId])
GO
ALTER TABLE [dbo].[People] CHECK CONSTRAINT [FK_People_Addresses]
GO
ALTER TABLE [dbo].[Towns]  WITH CHECK ADD  CONSTRAINT [FK_Towns_Countries] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([CountryId])
GO
ALTER TABLE [dbo].[Towns] CHECK CONSTRAINT [FK_Towns_Countries]
GO
USE [master]
GO
ALTER DATABASE [WorldDB] SET  READ_WRITE 
GO
