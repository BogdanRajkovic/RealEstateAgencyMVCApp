USE [AgencijaZaNekretnine]
GO
ALTER TABLE [dbo].[ZakazivanjeGledanjaNekretnine] DROP CONSTRAINT [fk_Zakazivanje_Osoba]
GO
ALTER TABLE [dbo].[ZakazivanjeGledanjaNekretnine] DROP CONSTRAINT [fk_Zakazivanje_Nekretnina]
GO
ALTER TABLE [dbo].[Nekretnina] DROP CONSTRAINT [fk_Nekretnina_Osoba]
GO
/****** Object:  Table [dbo].[ZakazivanjeGledanjaNekretnine]    Script Date: 12-Feb-20 1:40:19 PM ******/
DROP TABLE [dbo].[ZakazivanjeGledanjaNekretnine]
GO
/****** Object:  Table [dbo].[Osoba]    Script Date: 12-Feb-20 1:40:19 PM ******/
DROP TABLE [dbo].[Osoba]
GO
/****** Object:  Table [dbo].[Nekretnina]    Script Date: 12-Feb-20 1:40:19 PM ******/
DROP TABLE [dbo].[Nekretnina]
GO
USE [master]
GO
/****** Object:  Database [AgencijaZaNekretnine]    Script Date: 12-Feb-20 1:40:19 PM ******/
DROP DATABASE [AgencijaZaNekretnine]
GO
/****** Object:  Database [AgencijaZaNekretnine]    Script Date: 12-Feb-20 1:40:19 PM ******/
CREATE DATABASE [AgencijaZaNekretnine]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AgencijaZaNekretnine', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\AgencijaZaNekretnine.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'AgencijaZaNekretnine_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\AgencijaZaNekretnine_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [AgencijaZaNekretnine] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AgencijaZaNekretnine].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AgencijaZaNekretnine] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AgencijaZaNekretnine] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AgencijaZaNekretnine] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AgencijaZaNekretnine] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AgencijaZaNekretnine] SET ARITHABORT OFF 
GO
ALTER DATABASE [AgencijaZaNekretnine] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AgencijaZaNekretnine] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AgencijaZaNekretnine] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AgencijaZaNekretnine] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AgencijaZaNekretnine] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AgencijaZaNekretnine] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AgencijaZaNekretnine] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AgencijaZaNekretnine] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AgencijaZaNekretnine] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AgencijaZaNekretnine] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AgencijaZaNekretnine] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AgencijaZaNekretnine] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AgencijaZaNekretnine] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AgencijaZaNekretnine] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AgencijaZaNekretnine] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AgencijaZaNekretnine] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AgencijaZaNekretnine] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AgencijaZaNekretnine] SET RECOVERY FULL 
GO
ALTER DATABASE [AgencijaZaNekretnine] SET  MULTI_USER 
GO
ALTER DATABASE [AgencijaZaNekretnine] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AgencijaZaNekretnine] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AgencijaZaNekretnine] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AgencijaZaNekretnine] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [AgencijaZaNekretnine] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'AgencijaZaNekretnine', N'ON'
GO
USE [AgencijaZaNekretnine]
GO
/****** Object:  Table [dbo].[Nekretnina]    Script Date: 12-Feb-20 1:40:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nekretnina](
	[NekretninaID] [int] IDENTITY(1,1) NOT NULL,
	[Adresa] [varchar](max) NULL,
	[Opstina] [varchar](30) NULL,
	[Spratnost] [int] NULL,
	[Povrsina] [float] NULL,
	[Cena] [money] NULL,
	[Namestenost] [varchar](20) NULL,
	[VrstaNekretnine] [varchar](30) NULL,
	[Struktura] [varchar](30) NULL,
	[Stanje] [varchar](30) NULL,
	[Sprat] [int] NULL,
	[DodatneKarakteristike] [varchar](max) NULL,
	[Napomena] [varchar](max) NULL,
	[NekretnineSlike] [varchar](max) NULL,
	[VlasnikID] [int] NULL,
 CONSTRAINT [pk_Nekretnina] PRIMARY KEY CLUSTERED 
(
	[NekretninaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Osoba]    Script Date: 12-Feb-20 1:40:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Osoba](
	[OsobaID] [int] IDENTITY(1,1) NOT NULL,
	[Ime] [varchar](30) NULL,
	[Prezime] [varchar](30) NULL,
	[KorisnickoIme] [varchar](50) NULL,
	[Sifra] [varchar](50) NULL,
	[Pol] [varchar](1) NULL,
	[JMBG] [varchar](13) NULL,
	[BrojLicneKarte] [varchar](9) NULL,
	[Adresa] [varchar](max) NULL,
	[BrojMobilnog] [varchar](20) NULL,
	[Email] [varchar](max) NULL,
	[IsAdmin] [bit] NULL,
 CONSTRAINT [pk_Osoba] PRIMARY KEY CLUSTERED 
(
	[OsobaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZakazivanjeGledanjaNekretnine]    Script Date: 12-Feb-20 1:40:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZakazivanjeGledanjaNekretnine](
	[ZakazivanjeID] [int] IDENTITY(1,1) NOT NULL,
	[DatumVreme] [datetime] NULL,
	[NekretninaID] [int] NULL,
	[KupacID] [int] NULL,
 CONSTRAINT [pk_Zakazivanje] PRIMARY KEY CLUSTERED 
(
	[ZakazivanjeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Nekretnina] ON 

INSERT [dbo].[Nekretnina] ([NekretninaID], [Adresa], [Opstina], [Spratnost], [Povrsina], [Cena], [Namestenost], [VrstaNekretnine], [Struktura], [Stanje], [Sprat], [DodatneKarakteristike], [Napomena], [NekretnineSlike], [VlasnikID]) VALUES (12, N'Bulevar oslobodjenja 303', N'Savski venac', 11, 111111, 12345.0000, N'Namesten', N'Ostalo', N'Troiposoban', N'Staro', 5, N'ima topla voda', N'nema nista za napomenu', N'[{"Putanja":"IMG_20191027_142720.jpg"},{"Putanja":"IMG_20191027_142725.jpg"},{"Putanja":"IMG_20191027_142738.jpg"}]', 110)
INSERT [dbo].[Nekretnina] ([NekretninaID], [Adresa], [Opstina], [Spratnost], [Povrsina], [Cena], [Namestenost], [VrstaNekretnine], [Struktura], [Stanje], [Sprat], [DodatneKarakteristike], [Napomena], [NekretnineSlike], [VlasnikID]) VALUES (13, N'Erlaaer Platz 1/1/1103, Flat', N'Cukarica', 2, 123, 100000.0000, N'Namesten', N'Stan', N'Garsonjera', N'Novo', 2, NULL, NULL, N'[{"Putanja":"IMG_20191027_142532.jpg"},{"Putanja":"IMG_20191027_142537.jpg"},{"Putanja":"IMG_20191027_142542.jpg"},{"Putanja":"IMG_20191027_142546.jpg"},{"Putanja":"IMG_20191027_142659.jpg"}]', 110)
INSERT [dbo].[Nekretnina] ([NekretninaID], [Adresa], [Opstina], [Spratnost], [Povrsina], [Cena], [Namestenost], [VrstaNekretnine], [Struktura], [Stanje], [Sprat], [DodatneKarakteristike], [Napomena], [NekretnineSlike], [VlasnikID]) VALUES (14, N'Mike Ostojica 12', N'Vozdovac', 1, 78, 10.0000, N'Namesten', N'Stan', N'Garsonjera', N'Novo', 5, N'nema', N'nema', N'[{"Putanja":"IMG_20191027_142720.jpg"},{"Putanja":"IMG_20191027_142725.jpg"},{"Putanja":"IMG_20191027_142738.jpg"}]', 102)
INSERT [dbo].[Nekretnina] ([NekretninaID], [Adresa], [Opstina], [Spratnost], [Povrsina], [Cena], [Namestenost], [VrstaNekretnine], [Struktura], [Stanje], [Sprat], [DodatneKarakteristike], [Napomena], [NekretnineSlike], [VlasnikID]) VALUES (15, N'Bulevar oslobodjenja 303', N'Stari grad', 1, 78, 150000.0000, N'Nenamesten', N'Stan', N'Dvosoban', N'Novo', 1, N'nema', N'nema', N'[{"Putanja":"IMG_20191027_143342.jpg"},{"Putanja":"IMG_20191027_143358.jpg"},{"Putanja":"IMG_20191027_143410.jpg"}]', 102)
INSERT [dbo].[Nekretnina] ([NekretninaID], [Adresa], [Opstina], [Spratnost], [Povrsina], [Cena], [Namestenost], [VrstaNekretnine], [Struktura], [Stanje], [Sprat], [DodatneKarakteristike], [Napomena], [NekretnineSlike], [VlasnikID]) VALUES (16, N'Bulevar oslobodjenja 303', N'Barajevo', 1, 140, 50000.0000, N'Nenamesten', N'Kuca', N'Dvosoban', N'Staro', 1, N'velika njiva', N'velika njiva', N'[{"Putanja":"IMG_20191027_143453.jpg"},{"Putanja":"IMG_20191027_143454_1.jpg"},{"Putanja":"IMG_20191027_143503.jpg"}]', 111)
INSERT [dbo].[Nekretnina] ([NekretninaID], [Adresa], [Opstina], [Spratnost], [Povrsina], [Cena], [Namestenost], [VrstaNekretnine], [Struktura], [Stanje], [Sprat], [DodatneKarakteristike], [Napomena], [NekretnineSlike], [VlasnikID]) VALUES (17, N'Milovacka 14', N'Savski venac', 1, 89, 120000.0000, N'Namesten', N'Stan', N'Dvoiposoban', N'Staro', 5, N'Etazno grejanje, Klima, kamra,alarm ', NULL, N'[{"Putanja":"IMG_20191027_143119.jpg"},{"Putanja":"IMG_20191027_143124.jpg"},{"Putanja":"IMG_20191027_143130.jpg"}]', 112)
INSERT [dbo].[Nekretnina] ([NekretninaID], [Adresa], [Opstina], [Spratnost], [Povrsina], [Cena], [Namestenost], [VrstaNekretnine], [Struktura], [Stanje], [Sprat], [DodatneKarakteristike], [Napomena], [NekretnineSlike], [VlasnikID]) VALUES (18, NULL, N'Cukarica', 0, 0, 0.0000, N'Namesten', N'Stan', N'Garsonjera', N'Novo', 0, NULL, NULL, N'[{"Putanja":"IMG_20191027_142725.jpg"}]', 112)
INSERT [dbo].[Nekretnina] ([NekretninaID], [Adresa], [Opstina], [Spratnost], [Povrsina], [Cena], [Namestenost], [VrstaNekretnine], [Struktura], [Stanje], [Sprat], [DodatneKarakteristike], [Napomena], [NekretnineSlike], [VlasnikID]) VALUES (19, NULL, N'Cukarica', 0, 0, 0.0000, N'Namesten', N'Stan', N'Garsonjera', N'Novo', 0, NULL, NULL, N'[{"Putanja":"IMG_20191027_142812.jpg"}]', 112)
INSERT [dbo].[Nekretnina] ([NekretninaID], [Adresa], [Opstina], [Spratnost], [Povrsina], [Cena], [Namestenost], [VrstaNekretnine], [Struktura], [Stanje], [Sprat], [DodatneKarakteristike], [Napomena], [NekretnineSlike], [VlasnikID]) VALUES (20, NULL, N'Cukarica', 0, 0, 0.0000, N'Namesten', N'Stan', N'Garsonjera', N'Novo', 0, NULL, NULL, N'[{"Putanja":"IMG_20191027_142725.jpg"}]', 110)
INSERT [dbo].[Nekretnina] ([NekretninaID], [Adresa], [Opstina], [Spratnost], [Povrsina], [Cena], [Namestenost], [VrstaNekretnine], [Struktura], [Stanje], [Sprat], [DodatneKarakteristike], [Napomena], [NekretnineSlike], [VlasnikID]) VALUES (21, NULL, N'Cukarica', 0, 0, 0.0000, N'Namesten', N'Stan', N'Garsonjera', N'Novo', 0, NULL, NULL, N'[{"Putanja":"IMG_20191027_142725.jpg"}]', 110)
SET IDENTITY_INSERT [dbo].[Nekretnina] OFF
SET IDENTITY_INSERT [dbo].[Osoba] ON 

INSERT [dbo].[Osoba] ([OsobaID], [Ime], [Prezime], [KorisnickoIme], [Sifra], [Pol], [JMBG], [BrojLicneKarte], [Adresa], [BrojMobilnog], [Email], [IsAdmin]) VALUES (102, N'Milos', N'Miljkovic', N'MikiMiki', N'123456', N'm', N'123456789', N'13342313', N'Ljube Didica', N'0631954784', N'kibo.boki96@gmail.com', 0)
INSERT [dbo].[Osoba] ([OsobaID], [Ime], [Prezime], [KorisnickoIme], [Sifra], [Pol], [JMBG], [BrojLicneKarte], [Adresa], [BrojMobilnog], [Email], [IsAdmin]) VALUES (103, N'Bogdan', N'Rajkovic', N'BoggY', N'bogi123', N'1', N'1234567897777', N'002564985', N'Bulevar oslobodjenja 303', N'381631906996', N'kibo.boki96@gmail.com', 0)
INSERT [dbo].[Osoba] ([OsobaID], [Ime], [Prezime], [KorisnickoIme], [Sifra], [Pol], [JMBG], [BrojLicneKarte], [Adresa], [BrojMobilnog], [Email], [IsAdmin]) VALUES (104, N'Nikolina', N'Peric', N'NikiPeric', N'1234', N'1', N'1234567891111', N'213123554', N'Erlaaer Platz 1/1/1103, Flat', N'063190699666', N'kibo.boki96@gmail.com', 0)
INSERT [dbo].[Osoba] ([OsobaID], [Ime], [Prezime], [KorisnickoIme], [Sifra], [Pol], [JMBG], [BrojLicneKarte], [Adresa], [BrojMobilnog], [Email], [IsAdmin]) VALUES (105, N'Nikolina', N'Vuksic', N'PeraPeric', N'12324', N'Z', N'1234567891111', N'124244424', N'Erlaaer Platz 1/1/1103, Flat', N'063190699666', N'kibo.boki96@gmail.com', 0)
INSERT [dbo].[Osoba] ([OsobaID], [Ime], [Prezime], [KorisnickoIme], [Sifra], [Pol], [JMBG], [BrojLicneKarte], [Adresa], [BrojMobilnog], [Email], [IsAdmin]) VALUES (106, N'Jovana', N'Micic', N'Joca', N'124', N'Z', N'1234567891111', N'213123233', N'Bulevar oslobodjenja 303', N'063190699666', N'kibo.boki96@gmail.com', 0)
INSERT [dbo].[Osoba] ([OsobaID], [Ime], [Prezime], [KorisnickoIme], [Sifra], [Pol], [JMBG], [BrojLicneKarte], [Adresa], [BrojMobilnog], [Email], [IsAdmin]) VALUES (107, N'Milena', N'Pavic', N'PavicMilena', N'pavic123', N'Z', N'1231321231211', N'111111111', N'Mosorska 123', N'381631906554554', N'kibo.boki96@gmail.com', 0)
INSERT [dbo].[Osoba] ([OsobaID], [Ime], [Prezime], [KorisnickoIme], [Sifra], [Pol], [JMBG], [BrojLicneKarte], [Adresa], [BrojMobilnog], [Email], [IsAdmin]) VALUES (108, N'Bogdan', N'Vuksic', N'bogg1234', N'123', N'M', N'1234567891111', N'213123234', N'Erlaaer Platz 1/1/1103, Flat', N'063190699666', N'kibo.boki96@gmail.com', 0)
INSERT [dbo].[Osoba] ([OsobaID], [Ime], [Prezime], [KorisnickoIme], [Sifra], [Pol], [JMBG], [BrojLicneKarte], [Adresa], [BrojMobilnog], [Email], [IsAdmin]) VALUES (109, N'jovana', N'Micic', N'juca', N'123', N'Z', N'1234567891111', N'213123233', N'Bulevar oslobodjenja 303', N'063190699666', N'kibo.boki96@gmail.com', 0)
INSERT [dbo].[Osoba] ([OsobaID], [Ime], [Prezime], [KorisnickoIme], [Sifra], [Pol], [JMBG], [BrojLicneKarte], [Adresa], [BrojMobilnog], [Email], [IsAdmin]) VALUES (110, N'dza', N'red', N'dzare', N'123', N'M', N'1234567891111', N'213123525', N'Erlaaer Platz 1/1/1103, Flat', N'063190699666', N'kibo.boki96@gmail.com', 1)
INSERT [dbo].[Osoba] ([OsobaID], [Ime], [Prezime], [KorisnickoIme], [Sifra], [Pol], [JMBG], [BrojLicneKarte], [Adresa], [BrojMobilnog], [Email], [IsAdmin]) VALUES (111, N'Nikolina', N'Nikola', N'Nikola', N'123', N'M', N'1234567891111', N'213123222', N'Bulevar oslobodjenja 303', N'063190699666', N'kibo.boki96@gmail.com', 0)
INSERT [dbo].[Osoba] ([OsobaID], [Ime], [Prezime], [KorisnickoIme], [Sifra], [Pol], [JMBG], [BrojLicneKarte], [Adresa], [BrojMobilnog], [Email], [IsAdmin]) VALUES (112, N'Bogdan', N'Rajkovic', N'bogdanR19', N'123', N'M', N'1234567891111', N'213123222', N'Bulevar oslobodjenja 303', N'063190699666', N'bogdanrjkovic96@gmail.com', 0)
INSERT [dbo].[Osoba] ([OsobaID], [Ime], [Prezime], [KorisnickoIme], [Sifra], [Pol], [JMBG], [BrojLicneKarte], [Adresa], [BrojMobilnog], [Email], [IsAdmin]) VALUES (113, N'Nikolina', N'Rajkovic', N'123', N'123', N'M', N'1234567891111', N'123232332', N'Bulevar oslobodjenja 303', N'063190699666', N'gdfgdfgdf6@gmail.com', 0)
SET IDENTITY_INSERT [dbo].[Osoba] OFF
SET IDENTITY_INSERT [dbo].[ZakazivanjeGledanjaNekretnine] ON 

INSERT [dbo].[ZakazivanjeGledanjaNekretnine] ([ZakazivanjeID], [DatumVreme], [NekretninaID], [KupacID]) VALUES (3, CAST(N'2020-02-14T00:00:00.000' AS DateTime), 12, 102)
INSERT [dbo].[ZakazivanjeGledanjaNekretnine] ([ZakazivanjeID], [DatumVreme], [NekretninaID], [KupacID]) VALUES (4, CAST(N'2020-02-21T00:00:00.000' AS DateTime), 12, 110)
INSERT [dbo].[ZakazivanjeGledanjaNekretnine] ([ZakazivanjeID], [DatumVreme], [NekretninaID], [KupacID]) VALUES (5, CAST(N'2020-02-29T00:00:00.000' AS DateTime), 12, 110)
INSERT [dbo].[ZakazivanjeGledanjaNekretnine] ([ZakazivanjeID], [DatumVreme], [NekretninaID], [KupacID]) VALUES (6, CAST(N'2020-02-29T00:00:00.000' AS DateTime), 12, 110)
INSERT [dbo].[ZakazivanjeGledanjaNekretnine] ([ZakazivanjeID], [DatumVreme], [NekretninaID], [KupacID]) VALUES (7, CAST(N'2020-02-29T00:00:00.000' AS DateTime), 12, 110)
INSERT [dbo].[ZakazivanjeGledanjaNekretnine] ([ZakazivanjeID], [DatumVreme], [NekretninaID], [KupacID]) VALUES (8, CAST(N'2020-02-26T00:00:00.000' AS DateTime), 12, 111)
INSERT [dbo].[ZakazivanjeGledanjaNekretnine] ([ZakazivanjeID], [DatumVreme], [NekretninaID], [KupacID]) VALUES (9, CAST(N'2020-02-29T00:00:00.000' AS DateTime), 12, 111)
INSERT [dbo].[ZakazivanjeGledanjaNekretnine] ([ZakazivanjeID], [DatumVreme], [NekretninaID], [KupacID]) VALUES (10, CAST(N'2020-02-29T00:00:00.000' AS DateTime), 13, 112)
INSERT [dbo].[ZakazivanjeGledanjaNekretnine] ([ZakazivanjeID], [DatumVreme], [NekretninaID], [KupacID]) VALUES (11, CAST(N'2020-02-28T00:00:00.000' AS DateTime), 13, 110)
INSERT [dbo].[ZakazivanjeGledanjaNekretnine] ([ZakazivanjeID], [DatumVreme], [NekretninaID], [KupacID]) VALUES (12, CAST(N'2020-02-28T00:00:00.000' AS DateTime), 16, 110)
SET IDENTITY_INSERT [dbo].[ZakazivanjeGledanjaNekretnine] OFF
ALTER TABLE [dbo].[Nekretnina]  WITH CHECK ADD  CONSTRAINT [fk_Nekretnina_Osoba] FOREIGN KEY([VlasnikID])
REFERENCES [dbo].[Osoba] ([OsobaID])
GO
ALTER TABLE [dbo].[Nekretnina] CHECK CONSTRAINT [fk_Nekretnina_Osoba]
GO
ALTER TABLE [dbo].[ZakazivanjeGledanjaNekretnine]  WITH CHECK ADD  CONSTRAINT [fk_Zakazivanje_Nekretnina] FOREIGN KEY([NekretninaID])
REFERENCES [dbo].[Nekretnina] ([NekretninaID])
GO
ALTER TABLE [dbo].[ZakazivanjeGledanjaNekretnine] CHECK CONSTRAINT [fk_Zakazivanje_Nekretnina]
GO
ALTER TABLE [dbo].[ZakazivanjeGledanjaNekretnine]  WITH CHECK ADD  CONSTRAINT [fk_Zakazivanje_Osoba] FOREIGN KEY([KupacID])
REFERENCES [dbo].[Osoba] ([OsobaID])
GO
ALTER TABLE [dbo].[ZakazivanjeGledanjaNekretnine] CHECK CONSTRAINT [fk_Zakazivanje_Osoba]
GO
USE [master]
GO
ALTER DATABASE [AgencijaZaNekretnine] SET  READ_WRITE 
GO
