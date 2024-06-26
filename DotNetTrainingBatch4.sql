USE [HTSDotNetCore]
GO
/****** Object:  Table [dbo].[tbl_blog]    Script Date: 5/4/2024 3:36:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_blog](
	[blogId] [int] NOT NULL,
	[blogTitle] [varchar](50) NULL,
	[blogContent] [varchar](255) NULL,
	[blogAuthor] [nvarchar](10) NULL,
 CONSTRAINT [PK_tbl_blog] PRIMARY KEY CLUSTERED 
(
	[blogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tbl_blog] ([blogId], [blogTitle], [blogContent], [blogAuthor]) VALUES (1, N'Technology', N'something in the rain', N'ag ag')
INSERT [dbo].[tbl_blog] ([blogId], [blogTitle], [blogContent], [blogAuthor]) VALUES (2, N'Technology', N'something in the rain', N'ag ag')
INSERT [dbo].[tbl_blog] ([blogId], [blogTitle], [blogContent], [blogAuthor]) VALUES (3, N'Medical', N'something in the winter', N'mg mg')
GO
