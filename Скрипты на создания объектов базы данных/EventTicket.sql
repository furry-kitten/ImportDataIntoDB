USE [TestBase]
GO

/****** Object:  Table [dbo].[EventTicket]    Script Date: 30.07.2020 17:06:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EventTicket](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NULL,
	[DeliveryPublic] [bit] NULL,
	[LocalDeliveryCont] [int] NULL,
	[Name] [text] NULL,
	[Place] [text] NULL,
	[HallPlan] [varchar](50) NULL,
	[HallPart] [varchar](50) NULL,
	[Date] [varchar](20) NULL,
	[IsPremiere] [int] NULL,
	[IsKids] [int] NULL,
	[OfferID] [int] NULL,
	[HallName] [varchar](50) NULL,
 CONSTRAINT [PK_EventTicket] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[EventTicket]  WITH CHECK ADD  CONSTRAINT [FK_EventTicket_Offer] FOREIGN KEY([OfferID])
REFERENCES [dbo].[Offer] ([ID])
GO

ALTER TABLE [dbo].[EventTicket] CHECK CONSTRAINT [FK_EventTicket_Offer]
GO

ALTER TABLE [dbo].[EventTicket]  WITH CHECK ADD  CONSTRAINT [FK_EventTicket_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ID])
GO

ALTER TABLE [dbo].[EventTicket] CHECK CONSTRAINT [FK_EventTicket_Product]
GO

