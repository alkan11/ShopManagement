USE [YufkaDB]
GO
/****** Object:  Table [dbo].[BasketDetail]    Script Date: 18.12.2024 23:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BasketDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BasketId] [int] NULL,
	[ProductId] [int] NULL,
	[Amount] [float] NULL,
	[Price] [decimal](18, 2) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_BasketDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Baskets]    Script Date: 18.12.2024 23:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Baskets](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[PaymentTypeId] [int] NULL,
	[TotalPrice] [decimal](18, 2) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Baskets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EndDay]    Script Date: 18.12.2024 23:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EndDay](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CashTotal] [decimal](18, 2) NULL,
	[CashDiff] [decimal](18, 2) NULL,
	[CreatedDate] [datetime] NULL,
	[Description] [nvarchar](max) NULL,
	[IsActive] [int] NULL,
 CONSTRAINT [PK_EndDay] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Files]    Script Date: 18.12.2024 23:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Files](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FolderId] [int] NULL,
	[Uuid] [nvarchar](300) NULL,
	[Description] [nvarchar](max) NULL,
	[FileName] [nvarchar](300) NULL,
	[CreatedDate] [datetime] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Files] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Folders]    Script Date: 18.12.2024 23:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Folders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NULL,
	[CreatedDate] [datetime] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Folders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 18.12.2024 23:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NULL,
	[Type] [int] NULL,
	[UnitPrice] [decimal](18, 2) NULL,
	[Description] [nvarchar](2500) NULL,
	[CreatedDate] [datetime] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StringGroup]    Script Date: 18.12.2024 23:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StringGroup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](1000) NULL,
	[CreatedDate] [date] NULL,
	[IsActive] [int] NULL,
 CONSTRAINT [PK_StringGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StringGroupLocale]    Script Date: 18.12.2024 23:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StringGroupLocale](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupId] [int] NULL,
	[LangId] [int] NULL,
	[Name] [nvarchar](1000) NULL,
 CONSTRAINT [PK_StringGroupLocale] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StringLocale]    Script Date: 18.12.2024 23:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StringLocale](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StringId] [int] NULL,
	[LangId] [int] NULL,
	[StringDescription] [nvarchar](1000) NULL,
	[Description1] [nvarchar](1000) NULL,
	[Description2] [nvarchar](1000) NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_StringLocale] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Strings]    Script Date: 18.12.2024 23:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Strings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupId] [int] NULL,
	[StringDescription] [nvarchar](800) NULL,
	[Value1] [int] NULL,
	[Value2] [int] NULL,
	[Description1] [nvarchar](1000) NULL,
	[Description2] [nvarchar](1000) NULL,
	[ParentId] [int] NULL,
	[IsActive] [int] NULL,
	[IsSystem] [int] NULL,
	[IsSystemValue] [int] NULL,
	[IsSystemKey] [nvarchar](500) NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_Strings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SummerGoes]    Script Date: 18.12.2024 23:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SummerGoes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SummerAmount] [decimal](18, 2) NULL,
	[CreatedDate] [datetime] NULL,
	[Description] [nvarchar](max) NULL,
	[IsActive] [int] NULL,
 CONSTRAINT [PK_SummerGoes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 18.12.2024 23:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](60) NULL,
	[Password] [nvarchar](60) NULL,
	[IsActive] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WriteIncome]    Script Date: 18.12.2024 23:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WriteIncome](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WriteIncomeAmount] [decimal](18, 2) NULL,
	[CreatedDate] [datetime] NULL,
	[Description] [nvarchar](max) NULL,
	[IsActive] [int] NULL,
 CONSTRAINT [PK_WriteIncome] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BasketDetail] ON 

INSERT [dbo].[BasketDetail] ([Id], [BasketId], [ProductId], [Amount], [Price], [Status]) VALUES (23, 14, 21, 10, CAST(150.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[BasketDetail] ([Id], [BasketId], [ProductId], [Amount], [Price], [Status]) VALUES (24, 15, 21, 7, CAST(105.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[BasketDetail] ([Id], [BasketId], [ProductId], [Amount], [Price], [Status]) VALUES (25, 16, 22, 1.5, CAST(322.50 AS Decimal(18, 2)), 1)
INSERT [dbo].[BasketDetail] ([Id], [BasketId], [ProductId], [Amount], [Price], [Status]) VALUES (26, 16, 21, 5, CAST(75.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[BasketDetail] ([Id], [BasketId], [ProductId], [Amount], [Price], [Status]) VALUES (27, 17, 21, 12, CAST(180.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[BasketDetail] ([Id], [BasketId], [ProductId], [Amount], [Price], [Status]) VALUES (32, 19, 29, 1, CAST(80.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[BasketDetail] ([Id], [BasketId], [ProductId], [Amount], [Price], [Status]) VALUES (33, 19, 31, 1, CAST(80.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[BasketDetail] ([Id], [BasketId], [ProductId], [Amount], [Price], [Status]) VALUES (34, 19, 21, 7, CAST(105.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[BasketDetail] ([Id], [BasketId], [ProductId], [Amount], [Price], [Status]) VALUES (35, 19, 29, 1, CAST(80.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[BasketDetail] ([Id], [BasketId], [ProductId], [Amount], [Price], [Status]) VALUES (37, 21, 21, 7, CAST(105.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[BasketDetail] ([Id], [BasketId], [ProductId], [Amount], [Price], [Status]) VALUES (39, 22, 24, 505, CAST(108.58 AS Decimal(18, 2)), 1)
SET IDENTITY_INSERT [dbo].[BasketDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[Baskets] ON 

INSERT [dbo].[Baskets] ([Id], [CreatedDate], [PaymentTypeId], [TotalPrice], [Status]) VALUES (14, CAST(N'2024-12-15T14:32:40.917' AS DateTime), 6, CAST(150.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Baskets] ([Id], [CreatedDate], [PaymentTypeId], [TotalPrice], [Status]) VALUES (15, CAST(N'2024-12-15T14:32:50.430' AS DateTime), 7, CAST(105.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Baskets] ([Id], [CreatedDate], [PaymentTypeId], [TotalPrice], [Status]) VALUES (16, CAST(N'2024-12-15T14:37:44.850' AS DateTime), 6, CAST(397.50 AS Decimal(18, 2)), 1)
INSERT [dbo].[Baskets] ([Id], [CreatedDate], [PaymentTypeId], [TotalPrice], [Status]) VALUES (17, CAST(N'2024-12-15T14:38:11.840' AS DateTime), 7, CAST(230.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Baskets] ([Id], [CreatedDate], [PaymentTypeId], [TotalPrice], [Status]) VALUES (19, CAST(N'2024-12-15T14:56:02.180' AS DateTime), 6, CAST(345.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Baskets] ([Id], [CreatedDate], [PaymentTypeId], [TotalPrice], [Status]) VALUES (20, CAST(N'2024-12-15T15:00:14.427' AS DateTime), 6, CAST(90.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Baskets] ([Id], [CreatedDate], [PaymentTypeId], [TotalPrice], [Status]) VALUES (21, CAST(N'2024-12-15T15:22:20.067' AS DateTime), 6, CAST(100.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Baskets] ([Id], [CreatedDate], [PaymentTypeId], [TotalPrice], [Status]) VALUES (22, CAST(N'2024-12-15T15:23:23.550' AS DateTime), 7, CAST(183.58 AS Decimal(18, 2)), 1)
SET IDENTITY_INSERT [dbo].[Baskets] OFF
GO
SET IDENTITY_INSERT [dbo].[EndDay] ON 

INSERT [dbo].[EndDay] ([Id], [CashTotal], [CashDiff], [CreatedDate], [Description], [IsActive]) VALUES (1, CAST(3000.00 AS Decimal(18, 2)), CAST(580.00 AS Decimal(18, 2)), CAST(N'2024-12-16T00:00:00.000' AS DateTime), N'test', 0)
SET IDENTITY_INSERT [dbo].[EndDay] OFF
GO
SET IDENTITY_INSERT [dbo].[Folders] ON 

INSERT [dbo].[Folders] ([Id], [Name], [CreatedDate], [Status]) VALUES (16, N'Mantı', CAST(N'2024-12-13T23:26:28.933' AS DateTime), 1)
INSERT [dbo].[Folders] ([Id], [Name], [CreatedDate], [Status]) VALUES (17, N'YeniŞehir Toptancı', CAST(N'2024-12-13T23:26:46.260' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Folders] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [Name], [Type], [UnitPrice], [Description], [CreatedDate], [Status]) VALUES (21, N'Yufka', 3, CAST(15.00 AS Decimal(18, 2)), NULL, CAST(N'2024-11-27T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Products] ([Id], [Name], [Type], [UnitPrice], [Description], [CreatedDate], [Status]) VALUES (22, N'Mantı (Kilogram)', 4, CAST(215.00 AS Decimal(18, 2)), N'Kilogram için kullanılacak.', CAST(N'2024-11-27T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Products] ([Id], [Name], [Type], [UnitPrice], [Description], [CreatedDate], [Status]) VALUES (23, N'Yaş Kadayıf', 3, CAST(50.00 AS Decimal(18, 2)), NULL, CAST(N'2024-11-27T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Products] ([Id], [Name], [Type], [UnitPrice], [Description], [CreatedDate], [Status]) VALUES (24, N'Mantı (Gram)', 5, CAST(215.00 AS Decimal(18, 2)), N'Satışlarda Gram cinsi için kullanılacak.', CAST(N'2024-12-15T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Products] ([Id], [Name], [Type], [UnitPrice], [Description], [CreatedDate], [Status]) VALUES (25, N'Silor', 3, CAST(75.00 AS Decimal(18, 2)), NULL, CAST(N'2024-12-15T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Products] ([Id], [Name], [Type], [UnitPrice], [Description], [CreatedDate], [Status]) VALUES (26, N'Erişte (Bizim)  ', 3, CAST(75.00 AS Decimal(18, 2)), NULL, CAST(N'2024-12-15T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Products] ([Id], [Name], [Type], [UnitPrice], [Description], [CreatedDate], [Status]) VALUES (27, N'Tarhana (Sade)(Kilogram)', 4, CAST(150.00 AS Decimal(18, 2)), NULL, CAST(N'2024-12-15T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Products] ([Id], [Name], [Type], [UnitPrice], [Description], [CreatedDate], [Status]) VALUES (28, N'Tarhana (Sade)(Gram)', 5, CAST(150.00 AS Decimal(18, 2)), NULL, CAST(N'2024-12-15T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Products] ([Id], [Name], [Type], [UnitPrice], [Description], [CreatedDate], [Status]) VALUES (29, N'Yufbi Baklavalık Yufka (500gr)', 3, CAST(80.00 AS Decimal(18, 2)), NULL, CAST(N'2024-12-15T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Products] ([Id], [Name], [Type], [UnitPrice], [Description], [CreatedDate], [Status]) VALUES (30, N'NGS KemalPaşa', 3, CAST(80.00 AS Decimal(18, 2)), NULL, CAST(N'2024-12-15T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Products] ([Id], [Name], [Type], [UnitPrice], [Description], [CreatedDate], [Status]) VALUES (31, N'NGS KemalPaşa (Peynir Tatlısı)', 3, CAST(80.00 AS Decimal(18, 2)), NULL, CAST(N'2024-12-15T00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[StringGroup] ON 

INSERT [dbo].[StringGroup] ([Id], [Name], [CreatedDate], [IsActive]) VALUES (1, N'SalesUnit', CAST(N'2024-11-25' AS Date), 1)
INSERT [dbo].[StringGroup] ([Id], [Name], [CreatedDate], [IsActive]) VALUES (2, N'PaymentType', CAST(N'2024-11-30' AS Date), 1)
SET IDENTITY_INSERT [dbo].[StringGroup] OFF
GO
SET IDENTITY_INSERT [dbo].[StringGroupLocale] ON 

INSERT [dbo].[StringGroupLocale] ([Id], [GroupId], [LangId], [Name]) VALUES (1, 1, 0, N'Satış Birimleri')
INSERT [dbo].[StringGroupLocale] ([Id], [GroupId], [LangId], [Name]) VALUES (2, 2, 0, N'Ödeme Tipleri')
SET IDENTITY_INSERT [dbo].[StringGroupLocale] OFF
GO
SET IDENTITY_INSERT [dbo].[StringLocale] ON 

INSERT [dbo].[StringLocale] ([Id], [StringId], [LangId], [StringDescription], [Description1], [Description2], [CreatedDate]) VALUES (7, 3, 0, N'Adet', N'Yufka için satış birimi', NULL, CAST(N'2024-11-25T00:00:00.000' AS DateTime))
INSERT [dbo].[StringLocale] ([Id], [StringId], [LangId], [StringDescription], [Description1], [Description2], [CreatedDate]) VALUES (8, 4, 0, N'Kilogram', N'Hassas ölçüler için satış birimi', NULL, CAST(N'2024-11-25T00:00:00.000' AS DateTime))
INSERT [dbo].[StringLocale] ([Id], [StringId], [LangId], [StringDescription], [Description1], [Description2], [CreatedDate]) VALUES (9, 5, 0, N'Gram', N'Hassas ölçüler için satış birimi', NULL, CAST(N'2024-11-25T00:00:00.000' AS DateTime))
INSERT [dbo].[StringLocale] ([Id], [StringId], [LangId], [StringDescription], [Description1], [Description2], [CreatedDate]) VALUES (10, 6, 0, N'Nakit', NULL, NULL, CAST(N'2024-11-30T00:00:00.000' AS DateTime))
INSERT [dbo].[StringLocale] ([Id], [StringId], [LangId], [StringDescription], [Description1], [Description2], [CreatedDate]) VALUES (11, 7, 0, N'Kredi/Banka Kartı', NULL, NULL, CAST(N'2024-11-30T00:00:00.000' AS DateTime))
INSERT [dbo].[StringLocale] ([Id], [StringId], [LangId], [StringDescription], [Description1], [Description2], [CreatedDate]) VALUES (12, 8, 0, N'Veresiye', NULL, NULL, CAST(N'2024-11-30T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[StringLocale] OFF
GO
SET IDENTITY_INSERT [dbo].[Strings] ON 

INSERT [dbo].[Strings] ([Id], [GroupId], [StringDescription], [Value1], [Value2], [Description1], [Description2], [ParentId], [IsActive], [IsSystem], [IsSystemValue], [IsSystemKey], [CreatedDate]) VALUES (3, 1, N'Adet', 0, 0, N'Yufka için satış birimi', NULL, 0, 1, 1, 0, N'ADT', CAST(N'2024-11-25T00:00:00.000' AS DateTime))
INSERT [dbo].[Strings] ([Id], [GroupId], [StringDescription], [Value1], [Value2], [Description1], [Description2], [ParentId], [IsActive], [IsSystem], [IsSystemValue], [IsSystemKey], [CreatedDate]) VALUES (4, 1, N'Kilogram', 0, 0, N'Hassas ölçüler için satış birimi', NULL, 0, 1, 1, 0, N'KLGM', CAST(N'2024-11-25T00:00:00.000' AS DateTime))
INSERT [dbo].[Strings] ([Id], [GroupId], [StringDescription], [Value1], [Value2], [Description1], [Description2], [ParentId], [IsActive], [IsSystem], [IsSystemValue], [IsSystemKey], [CreatedDate]) VALUES (5, 1, N'Gram', 0, 0, N'Hassas ölçüler için satış birimi', NULL, 0, 1, 1, 0, N'GRM', CAST(N'2024-11-25T00:00:00.000' AS DateTime))
INSERT [dbo].[Strings] ([Id], [GroupId], [StringDescription], [Value1], [Value2], [Description1], [Description2], [ParentId], [IsActive], [IsSystem], [IsSystemValue], [IsSystemKey], [CreatedDate]) VALUES (6, 2, N'Nakit', 0, 0, NULL, NULL, 0, 1, 0, 0, NULL, CAST(N'2024-11-30T00:00:00.000' AS DateTime))
INSERT [dbo].[Strings] ([Id], [GroupId], [StringDescription], [Value1], [Value2], [Description1], [Description2], [ParentId], [IsActive], [IsSystem], [IsSystemValue], [IsSystemKey], [CreatedDate]) VALUES (7, 2, N'Kredi/Banka Kartı', 0, 0, NULL, NULL, 0, 1, 0, 0, NULL, CAST(N'2024-11-30T00:00:00.000' AS DateTime))
INSERT [dbo].[Strings] ([Id], [GroupId], [StringDescription], [Value1], [Value2], [Description1], [Description2], [ParentId], [IsActive], [IsSystem], [IsSystemValue], [IsSystemKey], [CreatedDate]) VALUES (8, 2, N'Veresiye', 0, 0, NULL, NULL, 0, 1, 0, 0, NULL, CAST(N'2024-11-30T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Strings] OFF
GO
SET IDENTITY_INSERT [dbo].[SummerGoes] ON 

INSERT [dbo].[SummerGoes] ([Id], [SummerAmount], [CreatedDate], [Description], [IsActive]) VALUES (1, CAST(150.00 AS Decimal(18, 2)), CAST(N'2024-12-16T00:00:00.000' AS DateTime), N'test gider', 0)
SET IDENTITY_INSERT [dbo].[SummerGoes] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [UserName], [Password], [IsActive]) VALUES (1, N'alkan', N'alkan1608', 1)
INSERT [dbo].[Users] ([Id], [UserName], [Password], [IsActive]) VALUES (2, N'hazal', N'hazal1608', 1)
INSERT [dbo].[Users] ([Id], [UserName], [Password], [IsActive]) VALUES (3, N'yener', N'yener1608', 1)
INSERT [dbo].[Users] ([Id], [UserName], [Password], [IsActive]) VALUES (4, N'sebahat', N'sebahat1608', 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[WriteIncome] ON 

INSERT [dbo].[WriteIncome] ([Id], [WriteIncomeAmount], [CreatedDate], [Description], [IsActive]) VALUES (1, CAST(150.50 AS Decimal(18, 2)), CAST(N'2024-12-16T00:00:00.000' AS DateTime), N'awdawdawd', 0)
SET IDENTITY_INSERT [dbo].[WriteIncome] OFF
GO
/****** Object:  StoredProcedure [dbo].[AddBasket]    Script Date: 18.12.2024 23:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create     PROCEDURE [dbo].[AddBasket]
	@PaymentTypeId int,
    @TotalPrice DECIMAL(18,2),
    @Status INT,
	@CreatedDate datetime
AS
BEGIN
    INSERT INTO Baskets(PaymentTypeId, TotalPrice,Status,CreatedDate)
    VALUES (@PaymentTypeId, @TotalPrice,@Status,@CreatedDate);
	
	SELECT top(1)*
    FROM Baskets(nolock)
    WHERE Id = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[AddBasketDetail]    Script Date: 18.12.2024 23:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create     PROCEDURE [dbo].[AddBasketDetail]
	@BasketId int,
	@ProductId int,
	@Amount float,
    @Price DECIMAL(18,2),
    @Status INT
AS
BEGIN
    INSERT INTO BasketDetail(BasketId,ProductId,Amount,Price,Status)
    VALUES (@BasketId,@ProductId,@Amount,@Price,@Status);
	
	SELECT top(1)*
    FROM BasketDetail(nolock)
    WHERE Id = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[AddEndDay]    Script Date: 18.12.2024 23:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create     PROCEDURE [dbo].[AddEndDay]
    @CashTotal DECIMAL(18,2),
	@CashDiff DECIMAL(18,2),
	@CreatedDate datetime,
	@Description NVARCHAR(1500),
    @IsActive INT
AS
BEGIN
    INSERT INTO EndDay (CashTotal,CashDiff, CreatedDate, Description,IsActive)
    VALUES (@CashTotal, @CashDiff,@CreatedDate, @Description,@IsActive);
	
	SELECT top(1)*
    FROM EndDay (nolock)
    WHERE Id = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[AddFile]    Script Date: 18.12.2024 23:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE     PROCEDURE [dbo].[AddFile]
    @FolderId int,
	@Uuid nvarchar(100),
	@FileName nvarchar(200),
	@Description nvarchar(MAX),
	@CreatedDate datetime,
    @Status INT
AS
BEGIN
    INSERT INTO Files(FolderId,Uuid,Description,FileName,CreatedDate,Status)
    VALUES (@FolderId,@Uuid,@Description,@FileName, @CreatedDate,@Status);
	
	SELECT top(1)*
    FROM Files(nolock)
    WHERE Id = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[AddFolder]    Script Date: 18.12.2024 23:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   PROCEDURE [dbo].[AddFolder]
    @Name NVARCHAR(500),
	@CreatedDate datetime,
    @Status INT
AS
BEGIN
    INSERT INTO Folders(Name,CreatedDate,Status)
    VALUES (@Name, @CreatedDate,@Status);
	
	SELECT top(1)*
    FROM Folders(nolock)
    WHERE Id = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[AddProduct]    Script Date: 18.12.2024 23:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddProduct]
    @Name NVARCHAR(500),
	@Type int,
    @UnitPrice DECIMAL(18,2),
    @Status INT,
	@Description NVARCHAR(1500),
	@CreatedDate datetime
AS
BEGIN
    INSERT INTO Products (Name, Type, UnitPrice,Status,CreatedDate,Description)
    VALUES (@Name, @Type, @UnitPrice,@Status,@CreatedDate,@Description);
	
	SELECT top(1)*
    FROM Products(nolock)
    WHERE Id = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[AddString]    Script Date: 18.12.2024 23:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[AddString]
    @GroupId int,
	@StringDescription nvarchar(800),
    @Value1 int,
    @Value2 int,
	@Description1 NVARCHAR(1000),
	@Description2 NVARCHAR(1000),
	@ParentId int,
	@IsActive int,
	@IsSystem int,
	@IsSystemValue int,
	@IsSystemKey NVARCHAR(500),
	@CreatedDate datetime
AS
BEGIN
    INSERT INTO Strings(GroupId,StringDescription,Value1,Value2,Description1,Description2,ParentId,IsActive,IsSystem,IsSystemValue,IsSystemKey,CreatedDate)
    VALUES (@GroupId,@StringDescription,@Value1,@Value2,@Description1,@Description2,@ParentId,@IsActive,@IsSystem,@IsSystemValue,@IsSystemKey,@CreatedDate);
	
	SELECT top(1)*
    FROM Strings(nolock)
    WHERE Id = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[AddStringLocale]    Script Date: 18.12.2024 23:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[AddStringLocale]
	@StringId int,
	@LangId int,
	@StringDescription NVARCHAR(1000),
	@Description1 NVARCHAR(1000),
	@Description2 NVARCHAR(1000),
	@CreatedDate datetime
AS
BEGIN
    INSERT INTO StringLocale(StringId,LangId,StringDescription,Description1,Description2,CreatedDate)
    VALUES (@StringId,@LangId,@StringDescription,@Description1,@Description2,@CreatedDate);
	
	SELECT top(1)*
    FROM StringLocale(nolock)
    WHERE Id = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[AddSummerGoes]    Script Date: 18.12.2024 23:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   PROCEDURE [dbo].[AddSummerGoes]
    @SummerAmount DECIMAL(18,2),
	@CreatedDate datetime,
	@Description NVARCHAR(1500),
    @IsActive INT
AS
BEGIN
    INSERT INTO SummerGoes (SummerAmount, CreatedDate, Description,IsActive)
    VALUES (@SummerAmount, @CreatedDate, @Description,@IsActive);
	
	SELECT top(1)*
    FROM SummerGoes(nolock)
    WHERE Id = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[AddWriteIncome]    Script Date: 18.12.2024 23:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   PROCEDURE [dbo].[AddWriteIncome]
    @WriteIncomeAmount DECIMAL(18,2),
	@CreatedDate datetime,
	@Description NVARCHAR(1500),
    @IsActive INT
AS
BEGIN
    INSERT INTO WriteIncome (WriteIncomeAmount, CreatedDate, Description,IsActive)
    VALUES (@WriteIncomeAmount, @CreatedDate, @Description,@IsActive);
	
	SELECT top(1)*
    FROM WriteIncome(nolock)
    WHERE Id = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[pDeleteBasket]    Script Date: 18.12.2024 23:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create           PROCEDURE [dbo].[pDeleteBasket](@id int)
as
begin
delete Baskets where Id=@id
END
GO
/****** Object:  StoredProcedure [dbo].[pDeleteBasketDetail]    Script Date: 18.12.2024 23:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create           PROCEDURE [dbo].[pDeleteBasketDetail](@id int)
as
begin
delete BasketDetail where Id=@id
END
GO
/****** Object:  StoredProcedure [dbo].[pDeleteBasketDetailByBasketId]    Script Date: 18.12.2024 23:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create           PROCEDURE [dbo].[pDeleteBasketDetailByBasketId](@id int)
as
begin
delete BasketDetail where BasketId=@id
END
GO
/****** Object:  StoredProcedure [dbo].[pDeleteFile]    Script Date: 18.12.2024 23:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create       PROCEDURE [dbo].[pDeleteFile](@id int)
as
begin
delete Files where Id=@id
END
GO
/****** Object:  StoredProcedure [dbo].[pDeleteFolder]    Script Date: 18.12.2024 23:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create         PROCEDURE [dbo].[pDeleteFolder](@id int)
as
begin
delete Folders where Id=@id
END
GO
/****** Object:  StoredProcedure [dbo].[pFindFile]    Script Date: 18.12.2024 23:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create         PROCEDURE [dbo].[pFindFile](@id int)
AS
BEGIN
select Files.*,folders.Name as FolderName from Files
left outer join Folders (nolock) on Folders.Id=Files.FolderId
where Files.Id=@id
END;
GO
/****** Object:  StoredProcedure [dbo].[pFindFolder]    Script Date: 18.12.2024 23:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create     PROCEDURE [dbo].[pFindFolder](@id int)
AS
BEGIN
select * from Folders where Id=@id
END;
GO
/****** Object:  StoredProcedure [dbo].[pGetAllBaskets]    Script Date: 18.12.2024 23:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE       PROCEDURE [dbo].[pGetAllBaskets]
AS
BEGIN
select top(10) B.*
,S.StringDescription as PaymentTypeIdName
,BD.Id as BasketDetailId
,BD.ProductId
,P.Name as ProductIdName
,S2.StringDescription as TypeName
,BD.Amount
,BD.Price
,BD.Status
from Baskets B(nolock) 
inner join BasketDetail BD(nolock) on BD.BasketId=B.Id
left outer join Strings S(nolock) on S.Id=B.PaymentTypeId
left outer join Products P(nolock) on P.Id=BD.ProductId
left outer join Strings S2(nolock) on S2.Id=P.Type
order by CreatedDate DEsc
END;
GO
/****** Object:  StoredProcedure [dbo].[pGetAllFilesByFolderId]    Script Date: 18.12.2024 23:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[pGetAllFilesByFolderId](@id int)
AS
BEGIN
select Files.*,Folders.Name as FolderName from Files 
inner join Folders on Folders.Id=Files.FolderId
where FolderId=@id
END;
GO
/****** Object:  StoredProcedure [dbo].[pGetAllFolderMain]    Script Date: 18.12.2024 23:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE     PROCEDURE [dbo].[pGetAllFolderMain]
AS
BEGIN
select Fo.*,Count(Fi.Id) as FileCount from Folders Fo(nolock) 
left outer join Files Fi(nolock) on Fi.FolderId=Fo.Id
group by Fo.Id,Fo.Name,Fo.CreatedDate,Fo.Status,Fi.Id
END;
GO
/****** Object:  StoredProcedure [dbo].[pGetAllProducts]    Script Date: 18.12.2024 23:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pGetAllProducts]
AS
BEGIN
select P.*
,S.StringDescription as TypeName
from Products P(nolock)
left outer join StringGroup SG(nolock) on SG.Name='SalesUnit'
left outer join Strings S(nolock) on S.GroupId=SG.Id and S.Id=P.Type
END;
GO
/****** Object:  StoredProcedure [dbo].[pGetAllStringGroupCurrentPage]    Script Date: 18.12.2024 23:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE     PROCEDURE [dbo].[pGetAllStringGroupCurrentPage]
AS
BEGIN
select SG.Id,SG.CreatedDate,SG.IsActive,SGL.Name,SGL.LangId from StringGroup SG(nolock)
LEFT OUTER JOIN StringGroupLocale SGL(nolock) on SGL.GroupId=SG.Id
END;
GO
/****** Object:  StoredProcedure [dbo].[pGetAllStringsByStringGroup]    Script Date: 18.12.2024 23:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[pGetAllStringsByStringGroup](@groupName nvarchar(200),@langId int)
AS
BEGIN
select SG.Id,SG.CreatedDate,SG.IsActive,SGL.Name,SGL.LangId from StringGroup SG(nolock)
LEFT OUTER JOIN StringGroupLocale SGL(nolock) on SGL.GroupId=SG.Id
where SG.Name=@groupName and SGL.LangId=@langId
END;
GO
/****** Object:  StoredProcedure [dbo].[pGetAllStringsByStringGroupActive]    Script Date: 18.12.2024 23:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create     PROCEDURE [dbo].[pGetAllStringsByStringGroupActive](@groupName nvarchar(200),@langId int)
AS
BEGIN
select SG.Id,SG.CreatedDate,SG.IsActive,SGL.Name,SGL.LangId from StringGroup SG(nolock)
LEFT OUTER JOIN StringGroupLocale SGL(nolock) on SGL.GroupId=SG.Id
where SG.Name=@groupName and SGL.LangId=@langId and Sg.IsActive=1
END;

GO
/****** Object:  StoredProcedure [dbo].[pGetAllStringsCurrentPage]    Script Date: 18.12.2024 23:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[pGetAllStringsCurrentPage](@groupId int, @langid int)
AS
BEGIN
select S.Id,S.GroupId,SL.LangId,SL.StringDescription,S.Value1,s.Value2,SL.Description1,SL.Description2,S.ParentId,S.IsActive,S.IsSystem
,S.IsSystemKey,S.IsSystemValue,S.CreatedDate,SG.Name as GroupName from Strings S(nolock)
inner join StringLocale SL(nolock) on Sl.StringId=S.Id
LEFT OUTER JOIN StringGroup SG(nolock) on SG.ID=S.GroupId
where S.GroupId=@groupId and Sl.LangId=@langid
END;
GO
/****** Object:  StoredProcedure [dbo].[pGetAllStringsCurrentPageActive]    Script Date: 18.12.2024 23:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create     PROCEDURE [dbo].[pGetAllStringsCurrentPageActive](@groupId int, @langid int)
AS
BEGIN
select S.Id,S.GroupId,SL.LangId,SL.StringDescription,S.Value1,s.Value2,SL.Description1,SL.Description2,S.ParentId,S.IsActive,S.IsSystem
,S.IsSystemKey,S.IsSystemValue,S.CreatedDate,SG.Name as GroupName from Strings S(nolock)
inner join StringLocale SL(nolock) on Sl.StringId=S.Id
LEFT OUTER JOIN StringGroup SG(nolock) on SG.ID=S.GroupId
where S.GroupId=@groupId and Sl.LangId=@langid and S.IsActive=1
END;

GO
/****** Object:  StoredProcedure [dbo].[pGetAllUsers]    Script Date: 18.12.2024 23:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   PROCEDURE [dbo].[pGetAllUsers]
AS
BEGIN
select * from Users
END;
GO
/****** Object:  StoredProcedure [dbo].[pGetProductById]    Script Date: 18.12.2024 23:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE       PROCEDURE [dbo].[pGetProductById](@id int)
AS
BEGIN
select p.*,s.StringDescription as TypeName from Products p(nolock)
left outer join StringGroup SG(nolock) on SG.Name='SalesUnit'
left outer join Strings S(nolock) on S.GroupId=SG.Id and S.Id=P.Type
where P.Id=@id
END;
GO
/****** Object:  StoredProcedure [dbo].[pGetStringById]    Script Date: 18.12.2024 23:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE     PROCEDURE [dbo].[pGetStringById](@id int)
AS
BEGIN
select * from Strings where Id=@id
END;
GO
/****** Object:  StoredProcedure [dbo].[UpdateProduct]    Script Date: 18.12.2024 23:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[UpdateProduct]
    @Id int,
	@Name NVARCHAR(500),
    @Type int,
    @UnitPrice decimal(18,2),
	@Description NVARCHAR(1000),
	@CreatedDate datetime,
	@Status int
AS
BEGIN
    UPDATE Products
    SET 
    Name=@Name,
	Type=@Type,
    UnitPrice=@UnitPrice,
    Description=@Description,
	CreatedDate=@CreatedDate,
	Status=@Status
    WHERE Id = @Id;
END;
GO
/****** Object:  StoredProcedure [dbo].[UpdateString]    Script Date: 18.12.2024 23:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateString]
    @Id int,
	@GroupId int,
	@StringDescription nvarchar(800),
    @Value1 int,
    @Value2 int,
	@Description1 NVARCHAR(1000),
	@Description2 NVARCHAR(1000),
	@ParentId int,
	@IsActive int,
	@IsSystem int,
	@IsSystemValue int,
	@IsSystemKey NVARCHAR(500),
	@CreatedDate datetime
AS
BEGIN
    UPDATE Strings
    SET 
    GroupId=@GroupId,
	StringDescription=@StringDescription,
    Value1=@Value1,
    Value2=@Value2,
	Description1=@Description1,
	Description2=@Description2,
	ParentId=@ParentId,
	IsActive=@IsActive,
	IsSystem =@IsSystem,
	IsSystemValue=@IsSystemValue,
	IsSystemKey=IsSystemKey,
	CreatedDate=@CreatedDate
    WHERE Id = @Id;
END;
GO
/****** Object:  StoredProcedure [dbo].[UpdateStringLocale]    Script Date: 18.12.2024 23:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateStringLocale]
	@StringId int,
	@StringDescription nvarchar(800),
    @LangId int,
	@Description1 NVARCHAR(1000),
	@Description2 NVARCHAR(1000),
	@CreatedDate datetime
AS
BEGIN
    UPDATE StringLocale
    SET 
	StringDescription=@StringDescription,
	LangId=@LangId,
	Description1=@Description1,
	Description2=@Description2,
	CreatedDate=@CreatedDate
    WHERE StringId = @StringId;
END;
GO
