USE [TestBase]
GO

/****** Object:  Table [dbo].[Product]    Script Date: 30.07.2020 17:10:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Product](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Price] [decimal](18, 0) NOT NULL,
	[Url] [text] NOT NULL,
	[Picture] [text] NOT NULL,
	[Description] [text] NULL,
	[CurID] [varchar](5) NULL,
	[CatID] [int] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CatID])
REFERENCES [dbo].[Category] ([ID])
GO

ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO

ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Currency] FOREIGN KEY([CurID])
REFERENCES [dbo].[Currency] ([ID])
GO

ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Currency]
GO

