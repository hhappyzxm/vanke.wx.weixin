/****** Object:  Table [dbo].[DinnerPlaces]    Script Date: 5/30/2016 9:30:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DinnerPlaces](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Place] [nvarchar](50) NOT NULL,
	[Status] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
 CONSTRAINT [PK_DinnerPlaces] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DinnerRegisterHistories]    Script Date: 5/30/2016 9:30:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DinnerRegisterHistories](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[StaffID] [bigint] NOT NULL,
	[DinnerDate] [datetime] NOT NULL,
	[PeopleCount] [int] NOT NULL,
	[TypeID] [bigint] NOT NULL,
	[PlaceID] [bigint] NOT NULL,
	[Status] [int] NOT NULL,
	[Comment] [nvarchar](500) NULL,
	[RegisteredOn] [datetime] NOT NULL,
	[CancelledOn] [datetime] NULL,
	[CancelledBy] [bigint] NULL,
 CONSTRAINT [PK_DinnerRegisterHistories] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DinnerTypes]    Script Date: 5/30/2016 9:30:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DinnerTypes](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Status] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
 CONSTRAINT [PK_DinnerTypes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeDiscounts]    Script Date: 5/30/2016 9:30:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeDiscounts](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
 CONSTRAINT [PK_EmployeeDiscounts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ExternalPersonnelDiningRegisterHistories]    Script Date: 5/30/2016 9:30:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExternalPersonnelDiningRegisterHistories](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[StaffID] [bigint] NOT NULL,
	[CardQuantity] [int] NOT NULL,
	[Comment] [nvarchar](500) NOT NULL,
	[Status] [int] NOT NULL,
	[RegisteredOn] [datetime] NOT NULL,
	[CancelledOn] [datetime] NULL,
	[CancelledBy] [bigint] NULL,
 CONSTRAINT [PK_ExternalPersonnelDiningRegisterHistories] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Hotels]    Script Date: 5/30/2016 9:30:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotels](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
 CONSTRAINT [PK_Hotels] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IdleAssets]    Script Date: 5/30/2016 9:30:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IdleAssets](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[AreaID] [bigint] NOT NULL,
	[PlaceID] [bigint] NOT NULL,
	[ItemID] [bigint] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Unit] [varchar](50) NOT NULL,
	[ManagerStaffID] [bigint] NOT NULL,
	[Comment] [varchar](500) NOT NULL,
	[Status] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
 CONSTRAINT [PK_IdleAssets] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ItemBorrowHistories]    Script Date: 5/30/2016 9:30:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemBorrowHistories](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ItemID] [bigint] NOT NULL,
	[StaffID] [bigint] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[BorrowedOn] [datetime] NOT NULL,
	[CancelledOn] [datetime] NULL,
	[CancelledBy] [bigint] NULL,
 CONSTRAINT [PK_ItemBorrowHistories] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Items]    Script Date: 5/30/2016 9:30:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Status] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ItemStorageAreas]    Script Date: 5/30/2016 9:30:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ItemStorageAreas](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Area] [varchar](50) NOT NULL,
	[Status] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
 CONSTRAINT [PK_ItemStorageAreas] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ItemStoragePlaces]    Script Date: 5/30/2016 9:30:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ItemStoragePlaces](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[AreaID] [bigint] NOT NULL,
	[Place] [varchar](50) NOT NULL,
	[Status] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
 CONSTRAINT [PK_ItemStoragePlaces] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StaffRoles]    Script Date: 5/30/2016 9:30:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StaffRoles](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Role] [int] NOT NULL,
	[StaffID] [bigint] NOT NULL,
 CONSTRAINT [PK_StaffRoles] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Staffs]    Script Date: 5/30/2016 9:30:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Staffs](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[RealName] [nvarchar](50) NOT NULL,
	[LoginName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Status] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
 CONSTRAINT [PK_Staffs] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[DinnerRegisterHistories]  WITH CHECK ADD  CONSTRAINT [FK_DinnerRegisterHistories_DinnerPlaces] FOREIGN KEY([PlaceID])
REFERENCES [dbo].[DinnerPlaces] ([ID])
GO
ALTER TABLE [dbo].[DinnerRegisterHistories] CHECK CONSTRAINT [FK_DinnerRegisterHistories_DinnerPlaces]
GO
ALTER TABLE [dbo].[DinnerRegisterHistories]  WITH CHECK ADD  CONSTRAINT [FK_DinnerRegisterHistories_DinnerRegisterHistories] FOREIGN KEY([TypeID])
REFERENCES [dbo].[DinnerTypes] ([ID])
GO
ALTER TABLE [dbo].[DinnerRegisterHistories] CHECK CONSTRAINT [FK_DinnerRegisterHistories_DinnerRegisterHistories]
GO
ALTER TABLE [dbo].[DinnerRegisterHistories]  WITH CHECK ADD  CONSTRAINT [FK_DinnerRegisterHistories_Staffs] FOREIGN KEY([StaffID])
REFERENCES [dbo].[Staffs] ([ID])
GO
ALTER TABLE [dbo].[DinnerRegisterHistories] CHECK CONSTRAINT [FK_DinnerRegisterHistories_Staffs]
GO
ALTER TABLE [dbo].[ExternalPersonnelDiningRegisterHistories]  WITH CHECK ADD  CONSTRAINT [FK_ExternalPersonnelDiningRegisterHistories_Staffs] FOREIGN KEY([StaffID])
REFERENCES [dbo].[Staffs] ([ID])
GO
ALTER TABLE [dbo].[ExternalPersonnelDiningRegisterHistories] CHECK CONSTRAINT [FK_ExternalPersonnelDiningRegisterHistories_Staffs]
GO
ALTER TABLE [dbo].[IdleAssets]  WITH CHECK ADD  CONSTRAINT [FK_IdleAssets_Items] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Items] ([ID])
GO
ALTER TABLE [dbo].[IdleAssets] CHECK CONSTRAINT [FK_IdleAssets_Items]
GO
ALTER TABLE [dbo].[IdleAssets]  WITH CHECK ADD  CONSTRAINT [FK_IdleAssets_ItemStorageAreas] FOREIGN KEY([AreaID])
REFERENCES [dbo].[ItemStorageAreas] ([ID])
GO
ALTER TABLE [dbo].[IdleAssets] CHECK CONSTRAINT [FK_IdleAssets_ItemStorageAreas]
GO
ALTER TABLE [dbo].[IdleAssets]  WITH CHECK ADD  CONSTRAINT [FK_IdleAssets_ItemStoragePlaces] FOREIGN KEY([AreaID])
REFERENCES [dbo].[ItemStorageAreas] ([ID])
GO
ALTER TABLE [dbo].[IdleAssets] CHECK CONSTRAINT [FK_IdleAssets_ItemStoragePlaces]
GO
ALTER TABLE [dbo].[IdleAssets]  WITH CHECK ADD  CONSTRAINT [FK_IdleAssets_Staffs] FOREIGN KEY([ManagerStaffID])
REFERENCES [dbo].[Staffs] ([ID])
GO
ALTER TABLE [dbo].[IdleAssets] CHECK CONSTRAINT [FK_IdleAssets_Staffs]
GO
ALTER TABLE [dbo].[ItemBorrowHistories]  WITH CHECK ADD  CONSTRAINT [FK_ItemBorrowHistories_Items] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Items] ([ID])
GO
ALTER TABLE [dbo].[ItemBorrowHistories] CHECK CONSTRAINT [FK_ItemBorrowHistories_Items]
GO
ALTER TABLE [dbo].[ItemBorrowHistories]  WITH CHECK ADD  CONSTRAINT [FK_ItemBorrowHistories_Staffs] FOREIGN KEY([StaffID])
REFERENCES [dbo].[Staffs] ([ID])
GO
ALTER TABLE [dbo].[ItemBorrowHistories] CHECK CONSTRAINT [FK_ItemBorrowHistories_Staffs]
GO
ALTER TABLE [dbo].[ItemStoragePlaces]  WITH CHECK ADD  CONSTRAINT [FK_ItemStoragePlaces_ItemStorageAreas] FOREIGN KEY([AreaID])
REFERENCES [dbo].[ItemStorageAreas] ([ID])
GO
ALTER TABLE [dbo].[ItemStoragePlaces] CHECK CONSTRAINT [FK_ItemStoragePlaces_ItemStorageAreas]
GO
ALTER TABLE [dbo].[StaffRoles]  WITH CHECK ADD  CONSTRAINT [FK_StaffRoles_Staffs] FOREIGN KEY([StaffID])
REFERENCES [dbo].[Staffs] ([ID])
GO
ALTER TABLE [dbo].[StaffRoles] CHECK CONSTRAINT [FK_StaffRoles_Staffs]
GO