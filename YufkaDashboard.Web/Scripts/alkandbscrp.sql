USE [YufkaDB]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 7.12.2024 13:52:08 ******/
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
/****** Object:  Table [dbo].[StringGroup]    Script Date: 7.12.2024 13:52:08 ******/
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
/****** Object:  Table [dbo].[StringGroupLocale]    Script Date: 7.12.2024 13:52:08 ******/
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
/****** Object:  Table [dbo].[StringLocale]    Script Date: 7.12.2024 13:52:08 ******/
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
/****** Object:  Table [dbo].[Strings]    Script Date: 7.12.2024 13:52:08 ******/
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
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [Name], [Type], [UnitPrice], [Description], [CreatedDate], [Status]) VALUES (21, N'Yufka', 3, CAST(15.00 AS Decimal(18, 2)), NULL, CAST(N'2024-11-27T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Products] ([Id], [Name], [Type], [UnitPrice], [Description], [CreatedDate], [Status]) VALUES (22, N'Mantı', 4, CAST(215.00 AS Decimal(18, 2)), NULL, CAST(N'2024-11-27T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Products] ([Id], [Name], [Type], [UnitPrice], [Description], [CreatedDate], [Status]) VALUES (23, N'Yaş Kadayıf', 4, CAST(100.00 AS Decimal(18, 2)), NULL, CAST(N'2024-11-27T00:00:00.000' AS DateTime), 1)
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
/****** Object:  StoredProcedure [dbo].[AddProduct]    Script Date: 7.12.2024 13:52:08 ******/
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
/****** Object:  StoredProcedure [dbo].[AddString]    Script Date: 7.12.2024 13:52:08 ******/
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
/****** Object:  StoredProcedure [dbo].[AddStringLocale]    Script Date: 7.12.2024 13:52:08 ******/
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
/****** Object:  StoredProcedure [dbo].[pGetAllProducts]    Script Date: 7.12.2024 13:52:08 ******/
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
/****** Object:  StoredProcedure [dbo].[pGetAllStringGroupCurrentPage]    Script Date: 7.12.2024 13:52:08 ******/
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
/****** Object:  StoredProcedure [dbo].[pGetAllStringsByStringGroup]    Script Date: 7.12.2024 13:52:08 ******/
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
/****** Object:  StoredProcedure [dbo].[pGetAllStringsCurrentPage]    Script Date: 7.12.2024 13:52:08 ******/
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
/****** Object:  StoredProcedure [dbo].[pGetProductById]    Script Date: 7.12.2024 13:52:08 ******/
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
/****** Object:  StoredProcedure [dbo].[pGetStringById]    Script Date: 7.12.2024 13:52:08 ******/
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
/****** Object:  StoredProcedure [dbo].[UpdateProduct]    Script Date: 7.12.2024 13:52:08 ******/
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
/****** Object:  StoredProcedure [dbo].[UpdateString]    Script Date: 7.12.2024 13:52:08 ******/
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
/****** Object:  StoredProcedure [dbo].[UpdateStringLocale]    Script Date: 7.12.2024 13:52:08 ******/
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
