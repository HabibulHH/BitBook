USE [BitBookDB]
GO
/****** Object:  Table [dbo].[BasicInformation]    Script Date: 6/14/2016 9:25:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BasicInformation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NULL,
	[Value] [nvarchar](50) NULL,
 CONSTRAINT [PK_BasicInformation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FriendList]    Script Date: 6/14/2016 9:25:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FriendList](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FriendId] [int] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_FriendList] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserTable]    Script Date: 6/14/2016 9:25:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[ProfilePicture] [varchar](50) NULL,
	[CoverPicture] [nvarchar](50) NULL,
	[DOB] [date] NULL,
	[Gender] [int] NULL,
 CONSTRAINT [PK_UserTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[FriendList] ON 

INSERT [dbo].[FriendList] ([Id], [FriendId], [UserId]) VALUES (6, 2, 1)
INSERT [dbo].[FriendList] ([Id], [FriendId], [UserId]) VALUES (7, 3, 1)
INSERT [dbo].[FriendList] ([Id], [FriendId], [UserId]) VALUES (8, 4, 1)
SET IDENTITY_INSERT [dbo].[FriendList] OFF
SET IDENTITY_INSERT [dbo].[UserTable] ON 

INSERT [dbo].[UserTable] ([Id], [Name], [Email], [Password], [UserName], [ProfilePicture], [CoverPicture], [DOB], [Gender]) VALUES (1, N'Hira', N'hira@gmail', N'1234', N'hira', NULL, NULL, NULL, 1)
INSERT [dbo].[UserTable] ([Id], [Name], [Email], [Password], [UserName], [ProfilePicture], [CoverPicture], [DOB], [Gender]) VALUES (2, N'Galib', N'g@e.com', N'123123', N'galib', NULL, NULL, NULL, 1)
INSERT [dbo].[UserTable] ([Id], [Name], [Email], [Password], [UserName], [ProfilePicture], [CoverPicture], [DOB], [Gender]) VALUES (3, N'taimoon', N'tai@moon', N'12323', N'taimoon', NULL, NULL, NULL, 1)
INSERT [dbo].[UserTable] ([Id], [Name], [Email], [Password], [UserName], [ProfilePicture], [CoverPicture], [DOB], [Gender]) VALUES (4, N'mamun', N'mamun@gmail.com', N'1223', N'mamun', NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[UserTable] OFF
ALTER TABLE [dbo].[FriendList]  WITH CHECK ADD  CONSTRAINT [FK_FriendList_UserTable] FOREIGN KEY([FriendId])
REFERENCES [dbo].[UserTable] ([Id])
GO
ALTER TABLE [dbo].[FriendList] CHECK CONSTRAINT [FK_FriendList_UserTable]
GO
