USE [UserLoginDetails]
GO
/****** Object:  Table [dbo].[useraccount]    Script Date: 10/14/2022 11:12:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[useraccount](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Login Name] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Real Name] [nvarchar](50) NULL,
	[Department] [nvarchar](50) NULL,
	[Date of Birth] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
