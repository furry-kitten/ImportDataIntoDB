USE [TestBase]
GO

/****** Object:  Table [dbo].[Tour]    Script Date: 30.07.2020 17:11:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tour](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NULL,
	[Delivery] [bit] NULL,
	[WorldRegion] [varchar](15) NULL,
	[Country] [varchar](20) NULL,
	[Region] [varchar](20) NULL,
	[Days] [int] NULL,
	[SDateTour] [datetime] NULL,
	[EDateTour] [datetime] NULL,
	[Name] [varchar](10) NULL,
	[HostelStars] [varchar](6) NULL,
	[Room] [varchar](10) NULL,
	[Meal] [varchar](10) NULL,
	[Included] [text] NULL,
	[Transport] [varchar](10) NULL,
	[OfferID] [int] NULL,
	[LocalDeliveryCost] [int] NULL,
 CONSTRAINT [PK_Tour] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Tour]  WITH CHECK ADD  CONSTRAINT [FK_Tour_Offer] FOREIGN KEY([OfferID])
REFERENCES [dbo].[Offer] ([ID])
GO

ALTER TABLE [dbo].[Tour] CHECK CONSTRAINT [FK_Tour_Offer]
GO

ALTER TABLE [dbo].[Tour]  WITH CHECK ADD  CONSTRAINT [FK_Tour_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ID])
GO

ALTER TABLE [dbo].[Tour] CHECK CONSTRAINT [FK_Tour_Product]
GO

