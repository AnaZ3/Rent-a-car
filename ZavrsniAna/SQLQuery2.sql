--KLIJENT PROCEDURE

CREATE PROC PromeniKlijenta
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


--IZVRSENO 



CREATE PROC PromeniIznajmljivanje
(
@IznajmljivanjeId int,
@AutomobilId int,
@Datum_preuzimanja date,
@Datum_vracanja date,
@RaucnId int=null,
@OpisId int
)
AS
UPDATE Iznajmljivanje SET AutomobilId=@AutomobilId,Datum_preuzimanja=@Datum_preuzimanja,Datum_vracanja=@Datum_vracanja,RacunId=@RaucnId
,OpisId=@OpisId
WHERE IznajmljivanjeId=@IznajmljivanjeId;
GO




CREATE PROC UbaciPlacanje
(
@PlacanjeId int OUTPUT,
@KlijentId int,
@Datum_Placanja date,
@Iznos money
)
AS
INSERT INTO Placanje VALUES(@KlijentId,@Datum_Placanja,@Iznos);
SELECT @PlacanjeId=@@IDENTITY;
GO

CREATE PROC PromeniPlacanje 
(
@PlacanjeId int,
@KlijentId int,
@Datum_Placanja date,
@Iznos money
)
AS
UPDATE Placanje SET KlijentId=@KlijentId,Datum_placanja=@Datum_Placanja,Iznos=@Iznos WHERE PlacanjeId=@PlacanjeId;
GO


CREATE PROC UbaciRacun
(
@RacunId int OUTPUT,
@KlijentId int,
@Iznos int,
@cena_po_danu money,
@cena_goriva money,
@PlacanjeId int
)
AS
INSERT INTO Racun VALUES(@KlijentId,@Iznos,@cena_po_danu,@cena_goriva,@PlacanjeId);
SELECT @RacunId=@@IDENTITY;
GO

CREATE PROC PromeniRacun
(
@RacunId int,
@KlijentId int,
@Iznos int,
@cena_po_danu money,
@cena_goriva money,
@PlacanjeId int
)
AS
UPDATE Racun SET KlijentId=@KlijentId,Iznos=@Iznos,cena_po_danu=@cena_po_danu,PlacanjeId=@PlacanjeId
WHERE RacunId=@RacunId
GO


DROP TABLE Placanje;


