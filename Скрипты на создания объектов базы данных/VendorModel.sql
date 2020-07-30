USE [TestBase]
GO

/****** Object:  Table [dbo].[VendorModel]    Script Date: 30.07.2020 17:12:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[VendorModel](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NULL,
	[Delivery] [bit] NULL,
	[ManufacturerWarranty] [bit] NULL,
	[LocalDeliveryCost] [int] NULL,
	[TypePrefix] [varchar](10) NULL,
	[Vendor] [varchar](5) NULL,
	[VendorCode] [varchar](10) NULL,
	[Model] [varchar](30) NULL,
	[CountryOrigin] [varchar](15) NULL,
	[OfferID] [int] NULL,
 CONSTRAINT [PK_VendorModel] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[VendorModel]  WITH CHECK ADD  CONSTRAINT [FK_VendorModel_Offer] FOREIGN KEY([OfferID])
REFERENCES [dbo].[Offer] ([ID])
GO

ALTER TABLE [dbo].[VendorModel] CHECK CONSTRAINT [FK_VendorModel_Offer]
GO

ALTER TABLE [dbo].[VendorModel]  WITH CHECK ADD  CONSTRAINT [FK_VendorModel_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ID])
GO

ALTER TABLE [dbo].[VendorModel] CHECK CONSTRAINT [FK_VendorModel_Product]
GO

