USE [ArticleDB]
GO
/****** Object:  Table [dbo].[Articles]    Script Date: 11.12.2019 11:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ImagePath] [nvarchar](max) NULL,
	[Subject] [nvarchar](max) NULL,
	[Content] [nvarchar](max) NULL,
	[Date] [datetime2](7) NULL,
	[Author] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Articles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Articles] ON 

INSERT [dbo].[Articles] ([Id], [ImagePath], [Subject], [Content], [Date], [Author], [IsActive]) VALUES (1, N'test4.jpg', N'Test 4 Makale Konusu', N'Test 4 Makale İçerik', CAST(N'2019-10-12 00:00:00.0000000' AS DateTime2), N'Ertan Kanter', 1)
INSERT [dbo].[Articles] ([Id], [ImagePath], [Subject], [Content], [Date], [Author], [IsActive]) VALUES (2, N'test5.jpg', N'Test 5 Makale Konusu', N'Test 5 Makale İçerik', CAST(N'2019-12-11 00:00:00.0000000' AS DateTime2), N'John Doe', 1)
SET IDENTITY_INSERT [dbo].[Articles] OFF
