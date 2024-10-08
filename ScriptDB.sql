CREATE DATABASE [CarsManagementDB]
GO
USE [CarsManagementDB]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 8/10/2024 10:57:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cars](
	[CarId] [int] IDENTITY(1,1) NOT NULL,
	[Make] [varchar](50) NOT NULL,
	[Model] [varchar](50) NOT NULL,
	[Year] [int] NOT NULL,
	[Type] [varchar](20) NOT NULL,
	[Seats] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UserCreated] [varchar](20) NOT NULL,
	[UpdatedAt] [datetime] NULL,
	[UserUpdated] [varchar](20) NULL,
	[DeletedAt] [datetime] NULL,
	[UserDeleted] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[CarId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cars] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Cars] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
