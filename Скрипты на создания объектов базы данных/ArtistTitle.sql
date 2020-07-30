USE [TestBase]
GO

/****** Object:  Table [dbo].[ArtistTitle]    Script Date: 30.07.2020 16:58:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ArtistTitle](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[Artist] [varchar](30) NULL,
	[Title] [text] NULL,
	[Media] [varchar](10) NULL,
	[Year] [varchar](20) NULL,
	[Starring] [text] NULL,
	[Director] [varchar](30) NULL,
	[OriginalName] [varchar](30) NULL,
	[Country] [varchar](20) NULL,
	[OfferID] [int] NULL,
 CONSTRAINT [PK_ArtistTitle] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[ArtistTitle]  WITH CHECK ADD  CONSTRAINT [FK_ArtistTitle_Offer] FOREIGN KEY([OfferID])
REFERENCES [dbo].[Offer] ([ID])
GO

ALTER TABLE [dbo].[ArtistTitle] CHECK CONSTRAINT [FK_ArtistTitle_Offer]
GO

ALTER TABLE [dbo].[ArtistTitle]  WITH CHECK ADD  CONSTRAINT [FK_ArtistTitle_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ID])
GO

ALTER TABLE [dbo].[ArtistTitle] CHECK CONSTRAINT [FK_ArtistTitle_Product]
GO

