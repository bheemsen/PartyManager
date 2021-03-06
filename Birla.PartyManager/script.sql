USE [PartyFundDb]
GO
/****** Object:  Table [dbo].[CollectionMaster]    Script Date: 10/1/2017 1:27:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CollectionMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[Amount] [int] NULL,
	[PaidDate] [datetime] NULL,
	[AcceptedBy] [int] NULL,
 CONSTRAINT [PK_CollectionMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventMaster]    Script Date: 10/1/2017 1:27:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventMaster](
	[EventId] [int] IDENTITY(1,1) NOT NULL,
	[EventName] [varchar](500) NULL,
	[EventVenue] [varchar](500) NULL,
	[EventDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[Amount] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_EventMaster] PRIMARY KEY CLUSTERED 
(
	[EventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserCollection]    Script Date: 10/1/2017 1:27:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserCollection](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EventId] [int] NULL,
	[UserId] [int] NULL,
	[Amount] [int] NULL,
	[IsCollected] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_Collection] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserMaster]    Script Date: 10/1/2017 1:27:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserMaster](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](150) NULL,
	[LastName] [varchar](150) NULL,
	[UserPassword] [nvarchar](100) NULL,
	[Email] [varchar](250) NULL,
	[Address] [varchar](500) NULL,
	[ContactNo] [varchar](50) NULL,
	[UserType] [int] NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_UserMaster] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTypeMaster]    Script Date: 10/1/2017 1:27:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTypeMaster](
	[UserTypeId] [int] IDENTITY(1,1) NOT NULL,
	[UserType] [varchar](250) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_tblUserTypeMaster] PRIMARY KEY CLUSTERED 
(
	[UserTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[EventMaster] ADD  CONSTRAINT [DF_EventMaster_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[UserCollection] ADD  CONSTRAINT [DF_Collection_IsCollected]  DEFAULT ((0)) FOR [IsCollected]
GO
ALTER TABLE [dbo].[UserMaster] ADD  CONSTRAINT [DF_UserMaster_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[UserTypeMaster] ADD  CONSTRAINT [DF_tblUserTypeMaster_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[UserTypeMaster] ADD  CONSTRAINT [DF_UserTypeMaster_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[UserTypeMaster] ADD  CONSTRAINT [DF_UserTypeMaster_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
ALTER TABLE [dbo].[UserCollection]  WITH CHECK ADD  CONSTRAINT [FK_UserCollection_UserMaster] FOREIGN KEY([EventId])
REFERENCES [dbo].[EventMaster] ([EventId])
GO
ALTER TABLE [dbo].[UserCollection] CHECK CONSTRAINT [FK_UserCollection_UserMaster]
GO
ALTER TABLE [dbo].[UserCollection]  WITH CHECK ADD  CONSTRAINT [FK_UserCollection_UserMaster1] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserMaster] ([UserId])
GO
ALTER TABLE [dbo].[UserCollection] CHECK CONSTRAINT [FK_UserCollection_UserMaster1]
GO
ALTER TABLE [dbo].[UserMaster]  WITH CHECK ADD  CONSTRAINT [FK_UserMaster_UserTypeMaster] FOREIGN KEY([UserType])
REFERENCES [dbo].[UserTypeMaster] ([UserTypeId])
GO
ALTER TABLE [dbo].[UserMaster] CHECK CONSTRAINT [FK_UserMaster_UserTypeMaster]
GO
