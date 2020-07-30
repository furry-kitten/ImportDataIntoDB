USE [TestBase]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TYPE [dbo].[InsertOffer] AS TABLE(
	[ID] [int] NULL,
	[Bid] [int] NULL,
	[Cbid] [int] NULL,
	[Available] [bit] NULL
)
GO
CREATE TYPE [dbo].[InsertAudioBook] AS TABLE(
	[ID] [int] NULL,
	[ProductID] [int] NULL,
	[CMI] [int] NULL,
	[PerformedBy] [varchar](30) NULL,
	[PerformanceType] [varchar](10) NULL,
	[Storage] [varchar](5) NULL,
	[Format] [varchar](5) NULL,
	[RecordingLenght] [varchar](10) NULL,
	[OfferID] [int] NULL
)
GO
CREATE TYPE [dbo].[InsertArtistTitle] AS TABLE(
	[ID] [int] NULL,
	[ProductID] [int] NOT NULL,
	[Artist] [varchar](30) NULL,
	[Title] text NULL,
	[Media] [varchar](10) NULL,
	[Year] [varchar](20) NULL,
	[Starring] [text] NULL,
	[Director] [varchar](30) NULL,
	[OriginalName] [varchar](30) NULL,
	[Country] [varchar](20) NULL,
	[OfferID] [int] NULL
)
GO
CREATE TYPE [dbo].[InsertTour] AS TABLE(
	[ID] [int] NULL,
	[ProductID] [int] NULL,
	[Delivery] [bit] NULL,
	[LocalDeliveryCost] [int] NULL,
	[WorldRegion] [varchar](15) NULL,
	[Country] [varchar](20) NULL,
	[Region] [varchar](30) NULL,
	[Days] [int] NULL,
	[SDateTour] [datetime] NULL,
	[EDateTour] [datetime] NULL,
	[Name] [varchar](10) NULL,
	[HostelStars] [varchar](6) NULL,
	[Room] [varchar](10) NULL,
	[Meal] [varchar](10) NULL,
	[Included] [text] NULL,
	[Transport] [varchar](10) NULL,
	[OfferID] [int] NULL
)
GO
CREATE TYPE [dbo].[BookCommonPart] AS TABLE(
	[ID] [int] NULL,
	[DownLoadable] [bit] NULL,
	[Auther] [varchar](30) NULL,
	[Name] [varchar](50) NULL,
	[Publicher] [varchar](50) NULL,
	[Language] [varchar](5) NULL,
	[Year] [int] NULL,
	[ISBN] [varchar](20) NULL
)
GO
CREATE TYPE [dbo].[InsertBook] AS TABLE(
	[ID] [int] NULL,
	[ProductID] [int] NULL,
	[CMI] [int] NULL,
	[Delivery] [bit] NULL,
	[Series] [text] NULL,
	[Binding] [varchar](30) NULL,
	[LocalDeliveryCost] [int] NULL,
	[Volume] [int] NULL,
	[Part] [int] NULL,
	[PageExtant] [int] NULL,
	[OfferID] [int] NULL
)
GO
CREATE TYPE [dbo].[InsertEventTicket] AS TABLE(
	[ID] [int] NULL,
	[ProductID] [int] NULL,
	[DeliveryPublic] [bit] NULL,
	[LocalDeliveryCont] [int] NULL,
	[Name] [text] NULL,
	[Place] [text] NULL,
	[HallPlan] [varchar](50) NULL,
	[HallName] [varchar](50) NULL,
	[HallPart] [varchar](50) NULL,
	[Date] [varchar](20) NULL,
	[IsPremiere] [int] NULL,
	[IsKids] [int] NULL,
	[OfferID] [int] NULL
)
GO
CREATE TYPE [dbo].[InsertProduct] AS TABLE(
	[ID] [int] NULL,
	[Price] [decimal](18, 0) NULL,
	[Url] [text] NULL,
	[Picture] [text] NULL,
	[Description] [text] NULL,
	[CurID] [varchar](5) NULL,
	[CatID] [int] NULL
)
GO
CREATE TYPE [dbo].[InsertVendor] AS TABLE(
	[ID] [int] NULL,
	[ProductID] [int] NULL,
	[Delivery] [bit] NULL,
	[ManufacturerWarranty] [bit] NULL,
	[LocalDeliveryCost] [int] NULL,
	[TypePrefix] [varchar](10) NULL,
	[Vendor] [varchar](5) NULL,
	[VendorCode] [varchar](10) NULL,
	[Model] [varchar](30) NULL,
	[CountryOrigin] [varchar](15) NULL,
	[OfferID] [int] NULL
)
GO

CREATE PROCEDURE [dbo].[InsertOfferProduct]
	@product dbo.InsertProduct READONLY,
	@offer InsertOffer READONLY
AS
BEGIN
	INSERT INTO dbo.Offer
	(
		[ID],
		[Bid],
		[Cbid],
		[Available]
	)
	SELECT
		[ID],
		[Bid],
		[Cbid],
		[Available]
	FROM 
		@offer

	INSERT INTO dbo.Product
	(
		[Price],
		[Url],
		[Picture],
		[Description],
		[CurID],
		[CatID]
	)
	SELECT 
		[Price],
		[Url],
		[Picture],
		[Description],
		[CurID],
		[CatID]
	FROM
	@product
END
GO
CREATE PROCEDURE [dbo].[InsertIntoCMI] 
	@cmi BookCommonPart READONLY
AS
BEGIN
	INSERT INTO [dbo].[BookCommonPart]
	(
		[DownLoadable]
		,[Auther]
		,[Name]
		,[Publicher]
		,[Language]
		,[Year]
		,[ISBN]
	)
	SELECT
		[DownLoadable]
		,[Auther]
		,[Name]
		,[Publicher]
		,[Language]
		,[Year]
		,[ISBN]
	FROM
			@cmi
END
GO
CREATE PROCEDURE [dbo].[InsertIntoVendor] 
	@userData InsertVendor READONLY,
	@product dbo.InsertProduct READONLY,
	@offer InsertOffer READONLY
AS
BEGIN
	IF (SELECT COUNT(Offer.ID) FROM Offer, @offer AS uof WHERE uof.ID = Offer.ID) = 0
	BEGIN
		exec TestBase.dbo.[InsertOfferProduct] @product, @offer

		INSERT INTO dbo.VendorModel 
		(
			[ProductID],
			[Delivery],
			[ManufacturerWarranty],
			[LocalDeliveryCost],
			[TypePrefix],
			[Vendor],
			[VendorCode],
			[Model],
			[CountryOrigin],
			[OfferID]
		)
		SELECT
			(SELECT MAX(ID) FROM Product),
			[Delivery],
			[ManufacturerWarranty],
			[LocalDeliveryCost],
			[TypePrefix],
			[Vendor],
			[VendorCode],
			[Model],
			[CountryOrigin],
			uof.[ID]
		FROM
			@userData, @offer as uof
		END
END
GO
CREATE PROCEDURE [dbo].[InsertIntoTour] 
	@userData InsertTour READONLY,
	@product dbo.InsertProduct READONLY,
	@offer InsertOffer READONLY
AS
BEGIN
	IF (SELECT COUNT(Offer.ID) FROM Offer, @offer AS uof WHERE uof.ID = Offer.ID) = 0
	BEGIN
		exec TestBase.dbo.[InsertOfferProduct] @product, @offer

		INSERT INTO dbo.Tour 
		(
			[ProductID],
			[Delivery],
			[WorldRegion],
			[Country],
			[Region],
			[Days],
			[SDateTour],
			[EDateTour],
			[Name],
			[HostelStars],
			[Room],
			[Meal],
			[Included],
			[Transport],
			[OfferID]
		)
		SELECT
			(SELECT MAX(ID) FROM Product),
			[Delivery],
			[WorldRegion],
			[Country],
			[Region],
			[Days],
			[SDateTour],
			[EDateTour],
			[Name],
			[HostelStars],
			[Room],
			[Meal],
			[Included],
			[Transport],
			uof.[ID]
		FROM
			@userData, @offer as uof
	END
END
GO
CREATE PROCEDURE [dbo].[InsertIntoEventTicket] 
	@userData InsertEventTicket READONLY,
	@product dbo.InsertProduct READONLY,
	@offer InsertOffer READONLY
AS
BEGIN
	IF (SELECT COUNT(Offer.ID) FROM Offer, @offer AS uof WHERE uof.ID = Offer.ID) = 0
	BEGIN
		exec TestBase.dbo.[InsertOfferProduct] @product, @offer

		INSERT INTO dbo.[EventTicket]
		(
			[ProductID]
			,[DeliveryPublic]
			,[LocalDeliveryCont]
			,[Name]
			,[Place]
			,[HallPlan]
			,[HallName]
			,[HallPart]
			,[Date]
			,[IsPremiere]
			,[IsKids]
			,[OfferID]
		)
		SELECT
			(SELECT MAX(ID) FROM Product)
			,[DeliveryPublic]
			,[LocalDeliveryCont]
			,[Name]
			,[Place]
			,[HallPlan]
			,[HallName]
			,[HallPart]
			,[Date]
			,[IsPremiere]
			,[IsKids]
			,uof.[ID]
		FROM
			@userData, @offer as uof
	END
END
GO
CREATE PROCEDURE [dbo].[InsertIntoBook] 
	@userData InsertBook READONLY,
	@cmi BookCommonPart READONLY,
	@product dbo.InsertProduct READONLY,
	@offer InsertOffer READONLY
AS
BEGIN
	IF (SELECT COUNT(Offer.ID) FROM Offer, @offer AS uof WHERE uof.ID = Offer.ID) = 0
	BEGIN
		exec TestBase.dbo.[InsertOfferProduct] @product, @offer

		EXEC TestBase.dbo.InsertIntoCMI @cmi

		INSERT INTO dbo.Book 
		(
			[ProductID]
			,[CMI]
			,[Delivery]
			,[Series]
			,[Binding]
			,[LocalDeliveryCost]
			,[Volume]
			,[Part]
			,[PageExtant]
			,[OfferID]
		)
		SELECT
			(SELECT MAX(ID) FROM Product)
			,(SELECT MAX(ID) FROM BookCommonPart)
			,[Delivery]
			,[Series]
			,[Binding]
			,[LocalDeliveryCost]
			,[Volume]
			,[Part]
			,[PageExtant]
			,uof.[ID]
		FROM
			@userData, @offer as uof
	END
END
GO
CREATE PROCEDURE [dbo].[InsertIntoAudioBook] 
	@userData InsertAudioBook READONLY,
	@cmi BookCommonPart READONLY,
	@product dbo.InsertProduct READONLY,
	@offer InsertOffer READONLY
AS
BEGIN
	IF (SELECT COUNT(Offer.ID) FROM Offer, @offer AS uof WHERE uof.ID = Offer.ID) = 0
	BEGIN
		exec TestBase.dbo.[InsertOfferProduct] @product, @offer

		EXEC TestBase.dbo.InsertIntoCMI @cmi

		INSERT INTO dbo.AudioBook 
		(
			[ProductID]
			,[CMI]
			,[PerformedBy]
			,[PerformanceType]
			,[Storage]
			,[Format]
			,[RecordingLenght]
			,[OfferID]
		)
		SELECT
			(SELECT MAX(ID) FROM Product)
			,(SELECT MAX(ID) FROM BookCommonPart)
			,[PerformedBy]
			,[PerformanceType]
			,[Storage]
			,[Format]
			,[RecordingLenght]
			,uof.[ID]
		FROM
			@userData, @offer as uof
	END
END
GO
CREATE PROCEDURE [dbo].[InsertIntoArtistTitle] 
	@userData InsertArtistTitle READONLY,
	@product dbo.InsertProduct READONLY,
	@offer InsertOffer READONLY
AS
BEGIN
	IF (SELECT COUNT(Offer.ID) FROM Offer, @offer AS uof WHERE uof.ID = Offer.ID) = 0
	BEGIN
		exec TestBase.dbo.[InsertOfferProduct] @product, @offer

		INSERT INTO dbo.ArtistTitle 
		(
			[ProductID]
			,[Artist]
			,[Title]
			,[Media]
			,[Year]
			,[Starring]
			,[Director]
			,[OriginalName]
			,[Country]
			,[OfferID]
		)
		SELECT
			(SELECT MAX(ID) FROM Product)
			,[Artist]
			,[Title]
			,[Media]
			,[Year]
			,[Starring]
			,[Director]
			,[OriginalName]
			,[Country]
			,uof.[ID]
		FROM
			@userData, @offer as uof
	END
END
GO
