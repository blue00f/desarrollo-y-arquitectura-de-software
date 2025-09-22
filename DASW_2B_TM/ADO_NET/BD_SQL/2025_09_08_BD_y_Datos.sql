USE [master]
GO
/****** Object:  Database [DASW_2025_2B_TM]    Script Date: 08/09/2025 13:07:07 ******/
CREATE DATABASE [DASW_2025_2B_TM]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DASW_2025_2B_TM', FILENAME = N'/var/opt/mssql/data/DASW_2025_2B_TM.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DASW_2025_2B_TM_log', FILENAME = N'/var/opt/mssql/data/DASW_2025_2B_TM_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [DASW_2025_2B_TM] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DASW_2025_2B_TM].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DASW_2025_2B_TM] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DASW_2025_2B_TM] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DASW_2025_2B_TM] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DASW_2025_2B_TM] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DASW_2025_2B_TM] SET ARITHABORT OFF 
GO
ALTER DATABASE [DASW_2025_2B_TM] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DASW_2025_2B_TM] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DASW_2025_2B_TM] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DASW_2025_2B_TM] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DASW_2025_2B_TM] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DASW_2025_2B_TM] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DASW_2025_2B_TM] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DASW_2025_2B_TM] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DASW_2025_2B_TM] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DASW_2025_2B_TM] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DASW_2025_2B_TM] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DASW_2025_2B_TM] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DASW_2025_2B_TM] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DASW_2025_2B_TM] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DASW_2025_2B_TM] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DASW_2025_2B_TM] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DASW_2025_2B_TM] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DASW_2025_2B_TM] SET RECOVERY FULL 
GO
ALTER DATABASE [DASW_2025_2B_TM] SET  MULTI_USER 
GO
ALTER DATABASE [DASW_2025_2B_TM] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DASW_2025_2B_TM] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DASW_2025_2B_TM] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DASW_2025_2B_TM] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DASW_2025_2B_TM] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DASW_2025_2B_TM] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DASW_2025_2B_TM', N'ON'
GO
ALTER DATABASE [DASW_2025_2B_TM] SET QUERY_STORE = ON
GO
ALTER DATABASE [DASW_2025_2B_TM] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [DASW_2025_2B_TM]
GO
/****** Object:  Table [dbo].[Alumno]    Script Date: 08/09/2025 13:07:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alumno](
	[Legajo] [int] NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[Apellido] [nvarchar](50) NULL,
	[Ingreso] [date] NULL,
	[Activo] [bit] NULL,
 CONSTRAINT [PK_Alumno] PRIMARY KEY CLUSTERED 
(
	[Legajo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contacto]    Script Date: 08/09/2025 13:07:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NULL,
	[Alu_Legajo] [int] NULL,
	[Tip_Id] [int] NULL,
 CONSTRAINT [PK_Contacto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoContacto]    Script Date: 08/09/2025 13:07:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoContacto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NULL,
 CONSTRAINT [PK_TipoContacto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Alumno] ([Legajo], [Nombre], [Apellido], [Ingreso], [Activo]) VALUES (1, N'Cecilia', N'Roma', CAST(N'2021-01-01' AS Date), 1)
GO
INSERT [dbo].[Alumno] ([Legajo], [Nombre], [Apellido], [Ingreso], [Activo]) VALUES (4, N'Sol', N'Coude', CAST(N'2016-03-27' AS Date), 1)
GO
INSERT [dbo].[Alumno] ([Legajo], [Nombre], [Apellido], [Ingreso], [Activo]) VALUES (5, N'B', N'B', CAST(N'2022-02-02' AS Date), 1)
GO
INSERT [dbo].[Alumno] ([Legajo], [Nombre], [Apellido], [Ingreso], [Activo]) VALUES (6, N'Adriana', N'Nunez', CAST(N'2018-12-12' AS Date), 1)
GO
INSERT [dbo].[Alumno] ([Legajo], [Nombre], [Apellido], [Ingreso], [Activo]) VALUES (10, N'Cecilia', N'Fernandez', CAST(N'2025-03-25' AS Date), 1)
GO
INSERT [dbo].[Alumno] ([Legajo], [Nombre], [Apellido], [Ingreso], [Activo]) VALUES (11, N'Sandra', N'Zontes', CAST(N'2012-03-23' AS Date), 0)
GO
INSERT [dbo].[Alumno] ([Legajo], [Nombre], [Apellido], [Ingreso], [Activo]) VALUES (14, N'Ezeauiel', N'Bertz', CAST(N'2024-04-04' AS Date), 1)
GO
INSERT [dbo].[Alumno] ([Legajo], [Nombre], [Apellido], [Ingreso], [Activo]) VALUES (15, N'Ariel', N'Most', CAST(N'2024-04-04' AS Date), 1)
GO
INSERT [dbo].[Alumno] ([Legajo], [Nombre], [Apellido], [Ingreso], [Activo]) VALUES (16, N'w', N'w', CAST(N'2025-05-05' AS Date), 1)
GO
INSERT [dbo].[Alumno] ([Legajo], [Nombre], [Apellido], [Ingreso], [Activo]) VALUES (17, N'w', N'w', CAST(N'2025-05-05' AS Date), 1)
GO
INSERT [dbo].[Alumno] ([Legajo], [Nombre], [Apellido], [Ingreso], [Activo]) VALUES (18, N'Ana', N'Perez', CAST(N'2021-01-01' AS Date), 1)
GO
INSERT [dbo].[Alumno] ([Legajo], [Nombre], [Apellido], [Ingreso], [Activo]) VALUES (21, N'Adian', N'Siart', CAST(N'2024-04-04' AS Date), 1)
GO
INSERT [dbo].[Alumno] ([Legajo], [Nombre], [Apellido], [Ingreso], [Activo]) VALUES (33, N'Juana', N'Viet', CAST(N'2020-01-01' AS Date), 1)
GO
SET IDENTITY_INSERT [dbo].[Contacto] ON 
GO
INSERT [dbo].[Contacto] ([id], [Descripcion], [Alu_Legajo], [Tip_Id]) VALUES (1, N'mail@mimail.com', 4, 2)
GO
INSERT [dbo].[Contacto] ([id], [Descripcion], [Alu_Legajo], [Tip_Id]) VALUES (2, N'+54911 2334-9887', 4, 1)
GO
INSERT [dbo].[Contacto] ([id], [Descripcion], [Alu_Legajo], [Tip_Id]) VALUES (3, N'+54911 1111-2233', 5, 1)
GO
INSERT [dbo].[Contacto] ([id], [Descripcion], [Alu_Legajo], [Tip_Id]) VALUES (4, N'4573-0987', 6, 3)
GO
SET IDENTITY_INSERT [dbo].[Contacto] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoContacto] ON 
GO
INSERT [dbo].[TipoContacto] ([id], [Descripcion]) VALUES (1, N'Celular')
GO
INSERT [dbo].[TipoContacto] ([id], [Descripcion]) VALUES (2, N'Mail')
GO
INSERT [dbo].[TipoContacto] ([id], [Descripcion]) VALUES (3, N'Fijo')
GO
SET IDENTITY_INSERT [dbo].[TipoContacto] OFF
GO
/****** Object:  StoredProcedure [dbo].[sp_Alumno_Actualizar]    Script Date: 08/09/2025 13:07:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Alumno_Actualizar]
    @Legajo   INT,
    @Nombre   NVARCHAR(100),
    @Apellido NVARCHAR(100),
    @Ingreso  DATE,
    @Activo   BIT
AS
BEGIN
    UPDATE Alumno
    SET Nombre   = @Nombre,
        Apellido = @Apellido,
        Ingreso  = @Ingreso,
        Activo   = @Activo
    WHERE legajo = @Legajo;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_Alumno_Eliminar]    Script Date: 08/09/2025 13:07:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Alumno_Eliminar]
    @Legajo INT
AS
BEGIN
    DELETE FROM Alumno
    WHERE legajo = @Legajo;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_Alumno_Insertar]    Script Date: 08/09/2025 13:07:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Alumno_Insertar]
    @Legajo   INT,
    @Nombre   NVARCHAR(50),
    @Apellido NVARCHAR(50),
    @Ingreso  DATE,
    @Activo   BIT
AS
BEGIN
    INSERT INTO Alumno (legajo, Nombre, Apellido, Ingreso, Activo)
    VALUES (@Legajo, @Nombre, @Apellido, @Ingreso, @Activo);
END;
GO
USE [master]
GO
ALTER DATABASE [DASW_2025_2B_TM] SET  READ_WRITE 
GO
