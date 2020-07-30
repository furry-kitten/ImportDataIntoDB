USE [TestBase]
GO

/****** Object:  Table [dbo].[Book]    Script Date: 30.07.2020 17:00:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Book](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NULL,
	[CMI] [int] NULL,
	[Delivery] [bit] NULL,
	[Series] [text] NULL,
	[Binding] [varchar](30) NULL,
	[LocalDeliveryCost] [int] NULL,
	[Volume] [int] NULL,
	[Part] [int] NULL,
	[PageExtant] [int] NULL,
	[OfferID] [int] NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_BookCommonPart] FOREIGN KEY([CMI])
REFERENCES [dbo].[BookCommonPart] ([ID])
GO

ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_BookCommonPart]
GO

ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Offer] FOREIGN KEY([OfferID])
REFERENCES [dbo].[Offer] ([ID])
GO

ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Offer]
GO

ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ID])
GO

ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Product]
GO

