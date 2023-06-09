USE [master]
GO
/****** Object:  Database [Araclar]    Script Date: 20.03.2023 16:50:39 ******/
CREATE DATABASE [Araclar]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Araclar', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Araclar.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Araclar_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Araclar_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Araclar] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Araclar].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Araclar] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Araclar] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Araclar] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Araclar] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Araclar] SET ARITHABORT OFF 
GO
ALTER DATABASE [Araclar] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Araclar] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Araclar] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Araclar] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Araclar] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Araclar] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Araclar] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Araclar] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Araclar] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Araclar] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Araclar] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Araclar] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Araclar] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Araclar] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Araclar] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Araclar] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Araclar] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Araclar] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Araclar] SET  MULTI_USER 
GO
ALTER DATABASE [Araclar] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Araclar] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Araclar] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Araclar] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Araclar] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Araclar] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Araclar] SET QUERY_STORE = ON
GO
ALTER DATABASE [Araclar] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Araclar]
GO
/****** Object:  Table [dbo].[AraclarBilgi]    Script Date: 20.03.2023 16:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AraclarBilgi](
	[AracNo] [int] IDENTITY(1,1) NOT NULL,
	[AracAdi] [varchar](50) NULL,
	[AracOzellik] [varchar](50) NULL,
	[Fiyat] [int] NULL,
	[UretimYeri] [varchar](50) NULL,
 CONSTRAINT [PK_Araclar] PRIMARY KEY CLUSTERED 
(
	[AracNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KullanicilarBilgi]    Script Date: 20.03.2023 16:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KullanicilarBilgi](
	[KullaniciNo] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciAdi] [varchar](50) NULL,
	[Sifre] [varchar](50) NULL,
 CONSTRAINT [PK_Kullanicilar] PRIMARY KEY CLUSTERED 
(
	[KullaniciNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SehirlerBilgi]    Script Date: 20.03.2023 16:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SehirlerBilgi](
	[SehirNo] [int] IDENTITY(1,1) NOT NULL,
	[SehirAdi] [varchar](50) NULL,
	[SehirBolge] [varchar](50) NULL,
	[SehirNufus] [int] NULL,
	[AracNo] [int] NULL,
 CONSTRAINT [PK_SehirBilgi] PRIMARY KEY CLUSTERED 
(
	[SehirNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubelerBilgi]    Script Date: 20.03.2023 16:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubelerBilgi](
	[SubeNo] [int] IDENTITY(1,1) NOT NULL,
	[SubeAdi] [varchar](50) NULL,
	[SubeAdres] [varchar](50) NULL,
	[SubeTelefon] [nchar](11) NULL,
	[SehirNo] [int] NULL,
 CONSTRAINT [PK_SubeBilgi] PRIMARY KEY CLUSTERED 
(
	[SubeNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AraclarBilgi] ON 

INSERT [dbo].[AraclarBilgi] ([AracNo], [AracAdi], [AracOzellik], [Fiyat], [UretimYeri]) VALUES (1, N'volvoo', N'Elektrikli', 30000, N'türkiye')
INSERT [dbo].[AraclarBilgi] ([AracNo], [AracAdi], [AracOzellik], [Fiyat], [UretimYeri]) VALUES (2, N'renault', N'Elektrikli', 30000, N'türkiye')
SET IDENTITY_INSERT [dbo].[AraclarBilgi] OFF
GO
SET IDENTITY_INSERT [dbo].[KullanicilarBilgi] ON 

INSERT [dbo].[KullanicilarBilgi] ([KullaniciNo], [KullaniciAdi], [Sifre]) VALUES (1, N'Sinem', N'12345')
INSERT [dbo].[KullanicilarBilgi] ([KullaniciNo], [KullaniciAdi], [Sifre]) VALUES (2, N'Admin', N'12345')
SET IDENTITY_INSERT [dbo].[KullanicilarBilgi] OFF
GO
SET IDENTITY_INSERT [dbo].[SehirlerBilgi] ON 

INSERT [dbo].[SehirlerBilgi] ([SehirNo], [SehirAdi], [SehirBolge], [SehirNufus], [AracNo]) VALUES (1, N'İstanbul', N'Marmara', 416565, 2)
INSERT [dbo].[SehirlerBilgi] ([SehirNo], [SehirAdi], [SehirBolge], [SehirNufus], [AracNo]) VALUES (2, N'Tokat', N'Karadeniz', 5444658, 3)
SET IDENTITY_INSERT [dbo].[SehirlerBilgi] OFF
GO
SET IDENTITY_INSERT [dbo].[SubelerBilgi] ON 

INSERT [dbo].[SubelerBilgi] ([SubeNo], [SubeAdi], [SubeAdres], [SubeTelefon], [SehirNo]) VALUES (1, N'Kadıköyy', N'jhjkkjbjhv', N'6565654    ', 34)
INSERT [dbo].[SubelerBilgi] ([SubeNo], [SubeAdi], [SubeAdres], [SubeTelefon], [SehirNo]) VALUES (3, N'Ümraniye', N'Ümraniye', N'4545645    ', 34)
SET IDENTITY_INSERT [dbo].[SubelerBilgi] OFF
GO
/****** Object:  StoredProcedure [dbo].[AracEkle]    Script Date: 20.03.2023 16:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[AracEkle]
@Aracadi varchar(50),
@AracOzellik varchar(50),
@Fiyat money,
@UretimYeri varchar(50)
as begin
insert into AraclarBilgi
(AracAdi,AracOzellik,Fiyat,UretimYeri)values(@AracAdi,@AracOzellik,@Fiyat,@UretimYeri)
end
GO
/****** Object:  StoredProcedure [dbo].[AraclarListele]    Script Date: 20.03.2023 16:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AraclarListele]
as begin
select *from AraclarBilgi
end
GO
/****** Object:  StoredProcedure [dbo].[AracSil]    Script Date: 20.03.2023 16:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AracSil]
@aracno int
as begin
delete from AraclarBilgi where AracNo=@Aracno
end
GO
/****** Object:  StoredProcedure [dbo].[AracYenile]    Script Date: 20.03.2023 16:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[AracYenile]
@aracNo int,
@AracAdi varchar(50),
@AracOzellik varchar(50),
@Fiyat money,
@UretimYeri varchar(50)
as begin
update AraclarBilgi set
AracAdi=@AracAdi,AracOzellik=@AracOzellik,Fiyat=@Fiyat,UretimYeri=@UretimYeri where AracNo=@aracNo
end
GO
/****** Object:  StoredProcedure [dbo].[SehirEkle]    Script Date: 20.03.2023 16:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SehirEkle]
@SehirAdi varchar(50),
@SehirBolge varchar(50),
@SehirNufus varchar(50),
@AracNo int
 as begin
 insert into SehirlerBilgi
 (SehirAdi,SehirBolge,SehirNufus,AracNo)values(@SehirAdi,@SehirBolge,@SehirNufus,@AracNo)
 end
GO
/****** Object:  StoredProcedure [dbo].[SehirlerListele]    Script Date: 20.03.2023 16:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SehirlerListele]
as begin
select*from SehirlerBilgi
end
GO
/****** Object:  StoredProcedure [dbo].[SehirSil]    Script Date: 20.03.2023 16:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SehirSil]
 @SehirNo int
 as begin
 delete from SehirlerBilgi where SehirNo=@SehirNo
 end
GO
/****** Object:  StoredProcedure [dbo].[SehirYenile]    Script Date: 20.03.2023 16:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SehirYenile]
 @SehirNo int,
 @SehirAdi varchar(50),
 @SehirBolge varchar(50),
 @SehirNufus varchar(50),
 @AracNo int
 as begin
 update SehirlerBilgi set
 SehirAdi=@SehirAdi,SehirBolge=@SehirBolge,SehirNufus=@SehirNufus where AracNo=@AracNo
 end
GO
/****** Object:  StoredProcedure [dbo].[SubeEkle]    Script Date: 20.03.2023 16:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SubeEkle]
@SubeAdi varchar(50),
@SubeAdres varchar(50),
@SubeTelefon nchar(11),
@SehirNo int
as begin
insert into SubelerBilgi
(SubeAdi,SubeAdres,SubeTelefon,SehirNo)values(@SubeAdi,@SubeAdi,@SubeTelefon,@SehirNo)
end
GO
/****** Object:  StoredProcedure [dbo].[SubelerListele]    Script Date: 20.03.2023 16:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SubelerListele]
as begin 
select*from SubelerBilgi
end
GO
/****** Object:  StoredProcedure [dbo].[SubeSil]    Script Date: 20.03.2023 16:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[SubeSil]
@Subeno int
as begin
delete from SubelerBilgi where SubeNo=@Subeno
end
GO
/****** Object:  StoredProcedure [dbo].[SubeYenile]    Script Date: 20.03.2023 16:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SubeYenile]
@SubeNo int,
@SubeAdi varchar(50),
@SubeAdres varchar(50),
@SubeTelefon nchar(11),
@SehirNo int 
as begin
update SubelerBilgi set
SubeAdi=@SubeAdi,SubeAdres=@SubeAdres,SubeTelefon=@SubeTelefon,SehirNo=@SehirNo where SubeNo=@SubeNo
end
GO
USE [master]
GO
ALTER DATABASE [Araclar] SET  READ_WRITE 
GO
