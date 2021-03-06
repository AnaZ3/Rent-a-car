USE [Rent-a-car]
GO
/****** Object:  Table [dbo].[Automobil]    Script Date: 21-Jul-17 3:19:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Automobil](
	[AutomobilId] [int] IDENTITY(1,1) NOT NULL,
	[TipId] [int] NOT NULL,
	[Brend] [nvarchar](50) NOT NULL,
	[Model] [nvarchar](50) NOT NULL,
	[Godina_proizvodnje] [int] NOT NULL,
	[Boja] [nvarchar](50) NOT NULL,
	[Cena_po_danu] [money] NOT NULL,
	[StanjeId] [int] NOT NULL,
	[Kapacitet_sedista] [int] NOT NULL,
	[Broj_vrata] [int] NOT NULL,
	[Vrsta_menjaca] [nvarchar](50) NOT NULL,
	[Tip_goriva] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Automobil] PRIMARY KEY CLUSTERED 
(
	[AutomobilId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Iznajmljivanje]    Script Date: 21-Jul-17 3:19:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Iznajmljivanje](
	[IznajmljivanjeId] [int] IDENTITY(1,1) NOT NULL,
	[AutomobilId] [int] NOT NULL,
	[Datum_preuzimanja] [date] NOT NULL,
	[Datum_vracanja] [date] NOT NULL,
	[Iznajmljivanje_klijentId] [int] NOT NULL,
	[OpisId] [int] NOT NULL,
	[Ukupna_cena] [money] NULL,
 CONSTRAINT [PK_Iznajmljivanje] PRIMARY KEY CLUSTERED 
(
	[IznajmljivanjeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Iznajmljivanje_klijent]    Script Date: 21-Jul-17 3:19:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Iznajmljivanje_klijent](
	[Iznajmljivanje_klijentId] [int] IDENTITY(1,1) NOT NULL,
	[KlijentId] [int] NOT NULL,
 CONSTRAINT [PK_Iznajmljivanje_klijent] PRIMARY KEY CLUSTERED 
(
	[Iznajmljivanje_klijentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Klijent]    Script Date: 21-Jul-17 3:19:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Klijent](
	[KlijentId] [int] IDENTITY(1,1) NOT NULL,
	[Ime] [nvarchar](50) NOT NULL,
	[Prezime] [nvarchar](50) NOT NULL,
	[Datum_rodjenja] [datetime] NOT NULL,
	[Br_vozacke_dozvole] [nvarchar](50) NOT NULL,
	[Kontakt_telefon] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_Kupac] PRIMARY KEY CLUSTERED 
(
	[KlijentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Opis_goriva]    Script Date: 21-Jul-17 3:19:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Opis_goriva](
	[OpisId] [int] IDENTITY(1,1) NOT NULL,
	[Opis] [nvarchar](50) NOT NULL,
	[Cena_goriva] [money] NOT NULL,
 CONSTRAINT [PK_Opis_goriva] PRIMARY KEY CLUSTERED 
(
	[OpisId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stanje]    Script Date: 21-Jul-17 3:19:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stanje](
	[StanjeId] [int] IDENTITY(1,1) NOT NULL,
	[Stanje] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Stanje] PRIMARY KEY CLUSTERED 
(
	[StanjeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tip]    Script Date: 21-Jul-17 3:19:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tip](
	[TipId] [int] IDENTITY(1,1) NOT NULL,
	[Naziv_tipa] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Kategorija] PRIMARY KEY CLUSTERED 
(
	[TipId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Automobil]  WITH CHECK ADD  CONSTRAINT [FK_Automobil_Stanje] FOREIGN KEY([StanjeId])
REFERENCES [dbo].[Stanje] ([StanjeId])
GO
ALTER TABLE [dbo].[Automobil] CHECK CONSTRAINT [FK_Automobil_Stanje]
GO
ALTER TABLE [dbo].[Automobil]  WITH CHECK ADD  CONSTRAINT [FK_Automobil_Tip] FOREIGN KEY([TipId])
REFERENCES [dbo].[Tip] ([TipId])
GO
ALTER TABLE [dbo].[Automobil] CHECK CONSTRAINT [FK_Automobil_Tip]
GO
ALTER TABLE [dbo].[Iznajmljivanje]  WITH CHECK ADD  CONSTRAINT [FK_Iznajmljivanje_Automobil] FOREIGN KEY([AutomobilId])
REFERENCES [dbo].[Automobil] ([AutomobilId])
GO
ALTER TABLE [dbo].[Iznajmljivanje] CHECK CONSTRAINT [FK_Iznajmljivanje_Automobil]
GO
ALTER TABLE [dbo].[Iznajmljivanje]  WITH CHECK ADD  CONSTRAINT [FK_Iznajmljivanje_Iznajmljivanje_klijent] FOREIGN KEY([Iznajmljivanje_klijentId])
REFERENCES [dbo].[Iznajmljivanje_klijent] ([Iznajmljivanje_klijentId])
GO
ALTER TABLE [dbo].[Iznajmljivanje] CHECK CONSTRAINT [FK_Iznajmljivanje_Iznajmljivanje_klijent]
GO
ALTER TABLE [dbo].[Iznajmljivanje]  WITH CHECK ADD  CONSTRAINT [FK_Iznajmljivanje_Opis_goriva] FOREIGN KEY([OpisId])
REFERENCES [dbo].[Opis_goriva] ([OpisId])
GO
ALTER TABLE [dbo].[Iznajmljivanje] CHECK CONSTRAINT [FK_Iznajmljivanje_Opis_goriva]
GO
ALTER TABLE [dbo].[Iznajmljivanje_klijent]  WITH CHECK ADD  CONSTRAINT [FK_Iznajmljivanje_klijent_Klijent] FOREIGN KEY([KlijentId])
REFERENCES [dbo].[Klijent] ([KlijentId])
GO
ALTER TABLE [dbo].[Iznajmljivanje_klijent] CHECK CONSTRAINT [FK_Iznajmljivanje_klijent_Klijent]
GO
/****** Object:  StoredProcedure [dbo].[DodajAutomobil]    Script Date: 21-Jul-17 3:19:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[DodajAutomobil]
(
@TipId int,
@Brend nvarchar(50),
@Model nvarchar(50),
@Godina_proizvodnje int,
@Boja nvarchar(50),
@Cena_po_danu money,
@StanjeId int,
@Kapacitet_sedista int,
@Broj_vrata int,
@Vrsta_menjaca nvarchar(50),
@Tip_goriva nvarchar(50)
)
AS
INSERT INTO Automobil  VALUES(@TipId,@Brend,@Model,@Godina_proizvodnje,@Boja,@Cena_po_danu,@StanjeId,@Kapacitet_sedista,@Broj_vrata,@Vrsta_menjaca,@Tip_goriva);

GO
/****** Object:  StoredProcedure [dbo].[DodajKlijenta]    Script Date: 21-Jul-17 3:19:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DodajKlijenta]
(
@KlijentId int OUTPUT,
@Ime nvarchar(50),
@Prezime nvarchar(50),
@Datum_rodjenja datetime,
@Br_vozacke_dozvole nvarchar(50),
@Kontakt_telefon nvarchar(50),
@Email nvarchar(50)=null
)
AS
INSERT INTO Klijent VALUES(@Ime,@Prezime,@Datum_rodjenja,@Br_vozacke_dozvole,@Kontakt_telefon,@Email)
SELECT @KlijentId=@@IDENTITY;
GO
/****** Object:  StoredProcedure [dbo].[IzbrisiAutomobil]    Script Date: 21-Jul-17 3:19:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CReATE PROC [dbo].[IzbrisiAutomobil]
(
@AutomobilId int
)
AS
DELETE FROM Automobil WHERE AutomobilId=@AutomobilId;
GO
/****** Object:  StoredProcedure [dbo].[PretraziIznajmljivanje]    Script Date: 21-Jul-17 3:19:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PretraziIznajmljivanje]
(
@KlijentId int
)
AS
DECLARE @ID int;
SET @ID=(SELECT Iznajmljivanje_klijentId FROM Iznajmljivanje_klijent WHERE KlijentId=@KlijentId);
IF(@ID is not null)
SELECT * FROM Iznajmljivanje WHERE Iznajmljivanje_klijentId=@ID;
GO
/****** Object:  StoredProcedure [dbo].[PretraziKorisnika]    Script Date: 21-Jul-17 3:19:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PretraziKorisnika]
(
@Ime nvarchar(50)
)
AS
SELECT * FROM Klijent WHERE Ime=@Ime;

GO
/****** Object:  StoredProcedure [dbo].[PromeniAutomobil]    Script Date: 21-Jul-17 3:19:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[PromeniAutomobil]
(
@AutomobilId int,
@TipId int,
@Brend nvarchar(50),
@Model nvarchar(50),
@Godina_proizvodnje int,
@Boja nvarchar(50),
@Cena_po_danu money,
@StanjeId int,
@Kapacitet_sedista int,
@Broj_vrata int,
@Vrsta_menjaca nvarchar(50),
@Tip_goriva nvarchar(50)
)
AS
UPDATE Automobil SET TipId=@TipId,Brend=@Brend,Model=@Model,Godina_proizvodnje=@Godina_proizvodnje,Boja=@Boja,
Cena_po_danu=@Cena_po_danu,StanjeId=@StanjeId,Kapacitet_sedista=@Kapacitet_sedista,Broj_vrata=@Broj_vrata,Vrsta_menjaca=@Vrsta_menjaca,Tip_goriva=@Tip_goriva

WHERE AutomobilId=@AutomobilId;
GO
/****** Object:  StoredProcedure [dbo].[PromeniIznajmljivanje]    Script Date: 21-Jul-17 3:19:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PromeniIznajmljivanje]
(
@IznajmljivanjeId int,
@AutomobilId int,
@Datum_preuzimanja date,
@Datum_vracanja date,
@OpisId int,
@Ukupna_cena money
)
AS
UPDATE Iznajmljivanje SET AutomobilId=@AutomobilId,Datum_preuzimanja=@Datum_preuzimanja,Datum_vracanja=@Datum_vracanja
,OpisId=@OpisId,@Ukupna_cena=@Ukupna_cena
WHERE IznajmljivanjeId=@IznajmljivanjeId;
GO
/****** Object:  StoredProcedure [dbo].[PromeniKlijenta]    Script Date: 21-Jul-17 3:19:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PromeniKlijenta]
(
@KlijentId int,
@Ime nvarchar(50),
@Prezime nvarchar(50),
@Datum_rodjenja datetime,
@Br_vozacke_dozvole nvarchar(50),
@Kontakt_telefon nvarchar(50),
@Email nvarchar(50)=null
)
AS
UPDATE Klijent SET Ime=@Ime,Prezime=@Prezime,Datum_rodjenja=@Datum_rodjenja,Br_vozacke_dozvole=@Br_vozacke_dozvole,Kontakt_telefon=@Kontakt_telefon,Email=@Email
WHERE KlijentId=@KlijentId;
GO
/****** Object:  StoredProcedure [dbo].[PronadjiAutomobil]    Script Date: 21-Jul-17 3:19:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PronadjiAutomobil]
(
@AutomobilId int
)
AS
SELECT * FROM Automobil WHERE AutomobilId=@AutomobilId;

GO
/****** Object:  StoredProcedure [dbo].[PronadjiOpisGoriva]    Script Date: 21-Jul-17 3:19:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PronadjiOpisGoriva]
(
@OpisGorivaId int
)
AS
SELECT * FROM Opis_goriva WHERE OpisId=@OpisGorivaId;
GO
/****** Object:  StoredProcedure [dbo].[UbaciIznajmljivanje]    Script Date: 21-Jul-17 3:19:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UbaciIznajmljivanje]
( 
@IznajmljivanjeId int OUTPUT,
@AutomobilId int,
@Datum_preuzimanja date,
@Datum_vracanja date,
@Iznajmljivanje_klijentId int,
@OpisId int,
@Ukupna_cena money
)
AS
INSERT INTO Iznajmljivanje VALUES(@AutomobilId,@Datum_preuzimanja,@Datum_vracanja,@Iznajmljivanje_klijentId,@OpisId,@Ukupna_cena);
SELECT @IznajmljivanjeId=@@IDENTITY;
GO
/****** Object:  StoredProcedure [dbo].[UbaciIznajmljivanje_Klijent]    Script Date: 21-Jul-17 3:19:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UbaciIznajmljivanje_Klijent]
(
@Iznajmljivanje_klijentId int OUTPUT,
@KlijentId int
)
AS
INSERT INTO Iznajmljivanje_klijent VALUES(@KlijentId)
SELECT @Iznajmljivanje_klijentId=@@IDENTITY;
GO
