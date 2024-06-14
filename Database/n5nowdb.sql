USE [master]
GO
/****** Object:  Database [N5Now-DB]    Script Date: 14/06/2024 3:08:22 ******/
CREATE DATABASE [N5Now-DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ngnow-db', FILENAME = N'/var/opt/mssql/data/ngnow-db.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ngnow-db_log', FILENAME = N'/var/opt/mssql/data/ngnow-db_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [N5Now-DB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [N5Now-DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [N5Now-DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [N5Now-DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [N5Now-DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [N5Now-DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [N5Now-DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [N5Now-DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [N5Now-DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [N5Now-DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [N5Now-DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [N5Now-DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [N5Now-DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [N5Now-DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [N5Now-DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [N5Now-DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [N5Now-DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [N5Now-DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [N5Now-DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [N5Now-DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [N5Now-DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [N5Now-DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [N5Now-DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [N5Now-DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [N5Now-DB] SET RECOVERY FULL 
GO
ALTER DATABASE [N5Now-DB] SET  MULTI_USER 
GO
ALTER DATABASE [N5Now-DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [N5Now-DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [N5Now-DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [N5Now-DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [N5Now-DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [N5Now-DB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'N5Now-DB', N'ON'
GO
ALTER DATABASE [N5Now-DB] SET QUERY_STORE = OFF
GO
USE [N5Now-DB]
GO
/****** Object:  Table [dbo].[Permissions]    Script Date: 14/06/2024 3:08:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permissions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreEmpleado] [text] NOT NULL,
	[ApellidoEmpleado] [text] NOT NULL,
	[TipoPermiso] [int] NOT NULL,
	[FechaPermiso] [date] NOT NULL,
 CONSTRAINT [PK_Permissions_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PermissionsTypes]    Script Date: 14/06/2024 3:08:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PermissionsTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [text] NOT NULL,
 CONSTRAINT [PK_PermissionsTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Permissions] ON 
GO
INSERT [dbo].[Permissions] ([Id], [NombreEmpleado], [ApellidoEmpleado], [TipoPermiso], [FechaPermiso]) VALUES (1, N'Alexander', N'Martinez', 1, CAST(N'2024-06-14' AS Date))
GO
INSERT [dbo].[Permissions] ([Id], [NombreEmpleado], [ApellidoEmpleado], [TipoPermiso], [FechaPermiso]) VALUES (2, N'Dayana', N'Bustamante', 2, CAST(N'2024-06-14' AS Date))
GO
INSERT [dbo].[Permissions] ([Id], [NombreEmpleado], [ApellidoEmpleado], [TipoPermiso], [FechaPermiso]) VALUES (3, N'Oscar', N'Torres', 1, CAST(N'2024-06-14' AS Date))
GO
INSERT [dbo].[Permissions] ([Id], [NombreEmpleado], [ApellidoEmpleado], [TipoPermiso], [FechaPermiso]) VALUES (4, N'Andres', N'Castillo', 2, CAST(N'2024-06-14' AS Date))
GO
SET IDENTITY_INSERT [dbo].[Permissions] OFF
GO
SET IDENTITY_INSERT [dbo].[PermissionsTypes] ON 
GO
INSERT [dbo].[PermissionsTypes] ([Id], [Description]) VALUES (1, N'Admin')
GO
INSERT [dbo].[PermissionsTypes] ([Id], [Description]) VALUES (2, N'User')
GO
SET IDENTITY_INSERT [dbo].[PermissionsTypes] OFF
GO
ALTER TABLE [dbo].[Permissions]  WITH CHECK ADD  CONSTRAINT [FK_Permissions_PermissionsTypes] FOREIGN KEY([TipoPermiso])
REFERENCES [dbo].[PermissionsTypes] ([Id])
GO
ALTER TABLE [dbo].[Permissions] CHECK CONSTRAINT [FK_Permissions_PermissionsTypes]
GO
USE [master]
GO
ALTER DATABASE [N5Now-DB] SET  READ_WRITE 
GO
