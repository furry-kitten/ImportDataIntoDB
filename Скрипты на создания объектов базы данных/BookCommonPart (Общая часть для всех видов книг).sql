USE [TestBase]
GO

/****** Object:  Table [dbo].[BookCommonPart]    Script Date: 30.07.2020 17:03:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BookCommonPart](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DownLoadable] [bit] NOT NULL,
	[Auther] [varchar](30) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Publicher] [varchar](50) NOT NULL,
	[Language] [varchar](5) NULL,
	[Year] [int] NOT NULL,
	[ISBN] [varchar](20) NULL,
 CONSTRAINT [PK_BookCommonPart] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

