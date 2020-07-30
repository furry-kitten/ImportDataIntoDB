USE [TestBase]
GO

/****** Object:  Table [dbo].[AudioBook]    Script Date: 30.07.2020 16:59:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AudioBook](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NULL,
	[CMI] [int] NULL,
	[PerformedBy] [varchar](30) NULL,
	[PerformanceType] [varchar](10) NULL,
	[Storage] [varchar](5) NULL,
	[Format] [varchar](5) NULL,
	[RecordingLenght] [varchar](10) NULL,
	[OfferID] [int] NULL,
 CONSTRAINT [PK_AudioBook] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AudioBook]  WITH CHECK ADD  CONSTRAINT [FK_AudioBook_BookCommonPart] FOREIGN KEY([CMI])
REFERENCES [dbo].[BookCommonPart] ([ID])
GO

ALTER TABLE [dbo].[AudioBook] CHECK CONSTRAINT [FK_AudioBook_BookCommonPart]
GO

ALTER TABLE [dbo].[AudioBook]  WITH CHECK ADD  CONSTRAINT [FK_AudioBook_Offer] FOREIGN KEY([OfferID])
REFERENCES [dbo].[Offer] ([ID])
GO

ALTER TABLE [dbo].[AudioBook] CHECK CONSTRAINT [FK_AudioBook_Offer]
GO

ALTER TABLE [dbo].[AudioBook]  WITH CHECK ADD  CONSTRAINT [FK_AudioBook_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ID])
GO

ALTER TABLE [dbo].[AudioBook] CHECK CONSTRAINT [FK_AudioBook_Product]
GO

