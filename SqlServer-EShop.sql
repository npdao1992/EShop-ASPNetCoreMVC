USE [master]
GO
/****** Object:  Database [EShop]    Script Date: 9/12/2024 5:34:18 PM ******/
CREATE DATABASE [EShop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EShop', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\EShop.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EShop_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\EShop_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [EShop] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EShop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EShop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EShop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EShop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EShop] SET ARITHABORT OFF 
GO
ALTER DATABASE [EShop] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [EShop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EShop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EShop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EShop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EShop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EShop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EShop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EShop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EShop] SET  ENABLE_BROKER 
GO
ALTER DATABASE [EShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EShop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EShop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EShop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EShop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EShop] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [EShop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EShop] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EShop] SET  MULTI_USER 
GO
ALTER DATABASE [EShop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EShop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EShop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EShop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EShop] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EShop] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [EShop] SET QUERY_STORE = OFF
GO
USE [EShop]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 9/12/2024 5:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 9/12/2024 5:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 9/12/2024 5:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 9/12/2024 5:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 9/12/2024 5:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 9/12/2024 5:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 9/12/2024 5:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[Occupation] [nvarchar](max) NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[RoleId] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 9/12/2024 5:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Brands]    Script Date: 9/12/2024 5:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brands](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Slug] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Brands] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 9/12/2024 5:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Slug] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 9/12/2024 5:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[OrderCode] [nvarchar](max) NULL,
	[ProductId] [bigint] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 9/12/2024 5:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderCode] [nvarchar](max) NULL,
	[UserName] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 9/12/2024 5:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Slug] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[BrandId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Image] [nvarchar](max) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240907064226_Initial', N'6.0.33')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240910045334_IdentityMigration', N'6.0.33')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240910083735_CreateCheckout', N'6.0.33')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240910091110_CreateCheckout', N'6.0.33')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240910091806_CreateCheckout', N'6.0.33')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240910093158_EditLongProductIdInOrderDetails', N'6.0.33')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240910100558_EditLongProductIdInProductModel_ForeignKeyProductIdInOrderDetails', N'6.0.33')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'1cf5ac07-b552-4b63-902e-57ffd3dbc41d', N'Test2', N'TEST2', N'cd346941-aa85-4f08-97ac-6c466a9f0639')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'1db220f8-7167-470a-a70f-2b8803835d26', N'Admin', N'ADMIN', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'3fc3fc93-4555-4bc1-bc2f-09dc58e94a35', N'Author', N'AUTHOR', N'4bf4f17d-7446-4d8f-b4dd-14226d5e3bf5')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'914d93e2-e976-4741-b825-6b95b6bb2c8d', N'User', N'USER', N'5ac61a3d-efa8-4cce-8a2a-f959277c692e')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'9e00e7b9-e21b-4af2-962b-086169d86ae8', N'Sales', N'SALES', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'a8a3aa69-fe7e-4741-8b31-c87274e4fca1', N'Test5', N'TEST5', N'4f0faac4-8348-452e-8ae3-42ae6ae27bca')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'bbda9bad-77fd-411d-b725-008a87fe80d8', N'Test6', N'TEST6', N'380f0f04-de7f-4ebc-806a-46cf20685041')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'bd1299f9-bce6-4460-9e9d-50fa046b1e56', N'Public 2', N'PUBLIC 2', N'007e4cd3-e1ea-473d-9900-d9270c321954')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'cfcebce5-caaf-49ff-93d8-69c9118d99dc', N'Publisher', N'PUBLISHER', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'e6364b8e-9f9c-4aca-802e-ed36b288344b', N'Test3', N'TEST3', N'de5924a4-0139-4493-a1b3-fcb9ae021c4c')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'fa645a57-efa1-4f2a-941c-28b43280294b', N'Test4', N'TEST4', N'036d1191-4d3a-4d39-9217-a5b9a69208c3')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0e671145-8d38-4fe8-bb0a-eab2329a2ddc', N'1db220f8-7167-470a-a70f-2b8803835d26')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'00a0f9bb-5db1-4795-aa89-3813cb48afdf', N'3fc3fc93-4555-4bc1-bc2f-09dc58e94a35')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'01a40f5d-7f1d-4836-b6ea-df85ebf4a6f6', N'3fc3fc93-4555-4bc1-bc2f-09dc58e94a35')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4fb7fe2a-f76e-4c44-9a6f-03311f339551', N'3fc3fc93-4555-4bc1-bc2f-09dc58e94a35')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5dc9716f-308f-43e6-a645-b6eb6cf2b20d', N'3fc3fc93-4555-4bc1-bc2f-09dc58e94a35')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'084eeee3-a91e-4b1a-ac09-3d7ba0ee7db5', N'9e00e7b9-e21b-4af2-962b-086169d86ae8')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'bdf0edc8-4017-4978-b861-2e9a1c948c44', N'9e00e7b9-e21b-4af2-962b-086169d86ae8')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e4c7bc7a-2eb1-475f-9700-0fc6d2eb28e2', N'9e00e7b9-e21b-4af2-962b-086169d86ae8')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'439ecf0b-90be-400a-867f-321fe425b71b', N'cfcebce5-caaf-49ff-93d8-69c9118d99dc')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'832bd676-772c-4846-8b67-9147d0a272f9', N'cfcebce5-caaf-49ff-93d8-69c9118d99dc')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e7cc23c7-4140-4958-9439-35bbdc4eaf78', N'cfcebce5-caaf-49ff-93d8-69c9118d99dc')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Occupation], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [RoleId]) VALUES (N'00a0f9bb-5db1-4795-aa89-3813cb48afdf', NULL, N'phuc5', N'PHUC5', N'phuc5@gmail.com', N'PHUC5@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEKVQAUAgSjRwz8W8aWOmh/iY9dxkkbvqR0uW5S6JyMU/Be4xd3dCeUEHOzWqcqDLKw==', N'6Z7ZMTFH5J472YHESWXKXNKXH74X7LB5', N'616be028-0245-4044-a8e1-b59d9b109a1f', N'88888888', 0, 0, NULL, 1, 0, N'3fc3fc93-4555-4bc1-bc2f-09dc58e94a35')
INSERT [dbo].[AspNetUsers] ([Id], [Occupation], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [RoleId]) VALUES (N'01a40f5d-7f1d-4836-b6ea-df85ebf4a6f6', NULL, N'phuc1', N'PHUC1', N'phuc1@gmail.com', N'PHUC1@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEAnffCV3iYP48TK+TtRRwEP5fgqsr/SDVa8iz5t058CKmUYh/mRiwyf8bE0b3PJc8w==', N'LN7QAYCWAAU3DGPXWV4WVZTOT2VIYXIA', N'96739853-9fac-4174-af73-c2321a36db5b', N'88888888', 0, 0, NULL, 1, 0, N'3fc3fc93-4555-4bc1-bc2f-09dc58e94a35')
INSERT [dbo].[AspNetUsers] ([Id], [Occupation], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [RoleId]) VALUES (N'084eeee3-a91e-4b1a-ac09-3d7ba0ee7db5', NULL, N'test', N'TEST', N'test@gmail.com', N'TEST@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEKl6sDuEf8jKbzVtupK0TTYtQyABoTvbXQtpBLR3cMzl8+L0lb3G7Tby9O4WMgGZLw==', N'KYJUPTWZKNXU4SQ6ZJ2SGBENKSRJOMS7', N'63ec2922-83a2-49b1-bf62-a25ee7ccc486', N'88888888', 0, 0, NULL, 1, 0, N'9e00e7b9-e21b-4af2-962b-086169d86ae8')
INSERT [dbo].[AspNetUsers] ([Id], [Occupation], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [RoleId]) VALUES (N'0e671145-8d38-4fe8-bb0a-eab2329a2ddc', NULL, N'phucadmin', N'PHUCADMIN', N'phucadmin@gmail.com', N'PHUCADMIN@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEL4l64cp9UDpq/gl8xLaD07HS+xjBqrrsD7zR9EjopQHxIh2xSjqKvVQ2kVFU5MEAg==', N'35N2KNBABGP3E6J3HNWSIBMPKXUAPWNT', N'b0830674-f13a-411a-a92b-b8010aacece9', N'0909090909', 0, 0, NULL, 1, 0, N'3fc3fc93-4555-4bc1-bc2f-09dc58e94a35')
INSERT [dbo].[AspNetUsers] ([Id], [Occupation], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [RoleId]) VALUES (N'15d09641-e151-4396-91ff-fef7ef0c6790', NULL, N'phuc4', N'PHUC4', N'phuc4@gmail.com', N'PHUC4@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEKui83OTrT6YsKf58zDp9TxWrPLXILiWTQMpzkWSqrHgp4bwEJims8GUS6AKvrWv6Q==', N'LEB3O33FXI72KDQIN32P35D6VWFEP6GQ', N'8457b7dc-ee36-436e-823b-04881de9e829', N'88888888', 0, 0, NULL, 1, 0, N'6ce8caf8-2679-4609-8b6c-4e57255f5622')
INSERT [dbo].[AspNetUsers] ([Id], [Occupation], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [RoleId]) VALUES (N'439ecf0b-90be-400a-867f-321fe425b71b', NULL, N'phuc7', N'PHUC7', N'phuc7@gmail.com', N'PHUC7@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEBiX6Jvj1kF55E1Hnez0Kdc3BRtmV7fkqxhPtfgqyabXTsNXhnWGeIJdbO0IuLktjw==', N'BV7GKLM4R5WEPGZ6XAQGXTVF62EQCB3B', N'db452de5-695a-4bab-ba3d-6f3be67128e5', N'1111111', 0, 0, NULL, 1, 0, N'cfcebce5-caaf-49ff-93d8-69c9118d99dc')
INSERT [dbo].[AspNetUsers] ([Id], [Occupation], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [RoleId]) VALUES (N'4fb7fe2a-f76e-4c44-9a6f-03311f339551', NULL, N'phucauthor', N'PHUCAUTHOR', N'phucauthor@gmail.com', N'PHUCAUTHOR@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEGzu58hayp48qFqEzQZhG/DyrqbnIPoExzltXnbGVs3LbIShatZI05lybcSnHlfSnA==', N'EX7VGB53RUAZXUYOQTBTGR2FNZZ2MDHO', N'7a0ddbfd-064f-4a0c-ac54-ffabf03f5587', N'88888888', 0, 0, NULL, 1, 0, N'3fc3fc93-4555-4bc1-bc2f-09dc58e94a35')
INSERT [dbo].[AspNetUsers] ([Id], [Occupation], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [RoleId]) VALUES (N'5dc9716f-308f-43e6-a645-b6eb6cf2b20d', NULL, N'phuc3', N'PHUC3', N'phuc3@gmail.com', N'PHUC3@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEETrfOBJWex89G2LEetut0I+TTkHvbmJPkqGzHuDVbl05uAhe7oYwv4qR1KjVid8ew==', N'LROEZZHZDT5AD2FRAUR7CLSW2UEJZUS7', N'd24257be-59e6-49a6-9111-8d09707989c6', N'88888888', 0, 0, NULL, 1, 0, N'3fc3fc93-4555-4bc1-bc2f-09dc58e94a35')
INSERT [dbo].[AspNetUsers] ([Id], [Occupation], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [RoleId]) VALUES (N'832bd676-772c-4846-8b67-9147d0a272f9', NULL, N'phucpublisher', N'PHUCPUBLISHER', N'phucpublisher@gmail.com', N'PHUCPUBLISHER@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEBd4yhkLSS+pSPaubqh2GZfdL4PGGbdNqH//8KyNQatZw1HzQHUpgg8YK0yfQ2ixlw==', N'M3ET5L4PRU33DOL2HPU6QTWY46I4TFMA', N'a2127654-5de6-4b37-94f4-56102bd03b30', N'0909090909', 0, 0, NULL, 1, 0, N'cfcebce5-caaf-49ff-93d8-69c9118d99dc')
INSERT [dbo].[AspNetUsers] ([Id], [Occupation], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [RoleId]) VALUES (N'bdf0edc8-4017-4978-b861-2e9a1c948c44', NULL, N'phuc6', N'PHUC6', N'phuc6@gmail.com', N'PHUC6@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEEgi7/dJrqPd83b9ivNNsVUtLFMYeo4D7/fOVi4cgWbXECZwHE+8RAaZ8qkaS31u4w==', N'XMACC3KJEK2672ZZNFKEEX5XFZ3ODO64', N'82cc2ad1-8e1f-4f68-a63b-df6391dcd3dc', N'88888888', 0, 0, NULL, 1, 0, N'9e00e7b9-e21b-4af2-962b-086169d86ae8')
INSERT [dbo].[AspNetUsers] ([Id], [Occupation], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [RoleId]) VALUES (N'e4c7bc7a-2eb1-475f-9700-0fc6d2eb28e2', NULL, N'phucsaler', N'PHUCSALER', N'phucsaler@gmail.com', N'PHUCSALER@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEDc4HTv+pOjbRAtVa92a/jhVUNu/G9TkLeeVYtjY8B8+qtkOpUGRQy4b1J+dFVa70Q==', N'56UJW3CM4P3IC3LR7JB4YFVT5QI22PMM', N'd2f35a69-879e-440c-8248-969f0053d56f', N'222222', 0, 0, NULL, 1, 0, N'9e00e7b9-e21b-4af2-962b-086169d86ae8')
INSERT [dbo].[AspNetUsers] ([Id], [Occupation], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [RoleId]) VALUES (N'e7cc23c7-4140-4958-9439-35bbdc4eaf78', NULL, N'phuc2', N'PHUC2', N'phuc2@gmail.com', N'PHUC2@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEDIewijRi3YuIwE7HeNK44EbYOvmQcQoOCdPL0uWX2Ga18K2yluv8Am+xJohzSM5bw==', N'OUXCXURUZGLPADRCG5G6VSA3LL2X7PEU', N'0c893747-0863-4888-9136-6d8ed86e3402', N'88888888', 0, 0, NULL, 1, 0, N'cfcebce5-caaf-49ff-93d8-69c9118d99dc')
GO
SET IDENTITY_INSERT [dbo].[Brands] ON 

INSERT [dbo].[Brands] ([Id], [Name], [Description], [Slug], [Status]) VALUES (9, N'Apple', N'Apple is Large Brand in the world', N'apple', 1)
INSERT [dbo].[Brands] ([Id], [Name], [Description], [Slug], [Status]) VALUES (10, N'Samsung', N'Samsung is Large Brand in the world', N'samsung', 1)
INSERT [dbo].[Brands] ([Id], [Name], [Description], [Slug], [Status]) VALUES (11, N'Dell', N'dell', N'Dell', 1)
INSERT [dbo].[Brands] ([Id], [Name], [Description], [Slug], [Status]) VALUES (12, N'Oppo', N'Oppo', N'Oppo', 1)
INSERT [dbo].[Brands] ([Id], [Name], [Description], [Slug], [Status]) VALUES (13, N'Acer', N'Acer', N'Acer', 1)
INSERT [dbo].[Brands] ([Id], [Name], [Description], [Slug], [Status]) VALUES (14, N'Asus', N'Asus', N'Asus', 1)
INSERT [dbo].[Brands] ([Id], [Name], [Description], [Slug], [Status]) VALUES (15, N'Microsoft', N'Microsoft is an American multinational corporation headquartered in Redmond, Washington 2', N'Microsoft', 1)
INSERT [dbo].[Brands] ([Id], [Name], [Description], [Slug], [Status]) VALUES (16, N'Amazon', N'Amazon', N'Amazon', 1)
INSERT [dbo].[Brands] ([Id], [Name], [Description], [Slug], [Status]) VALUES (17, N'Huawei', N'Huawei', N'Huawei', 1)
INSERT [dbo].[Brands] ([Id], [Name], [Description], [Slug], [Status]) VALUES (18, N'Xiao mi', N'Xiao mi', N'Xiao-mi', 1)
INSERT [dbo].[Brands] ([Id], [Name], [Description], [Slug], [Status]) VALUES (19, N'Sony', N'Sony', N'Sony', 1)
INSERT [dbo].[Brands] ([Id], [Name], [Description], [Slug], [Status]) VALUES (20, N'Intel', N'Intel', N'Intel', 1)
INSERT [dbo].[Brands] ([Id], [Name], [Description], [Slug], [Status]) VALUES (22, N'Hikvision', N'Hikvision', N'Hikvision', 1)
SET IDENTITY_INSERT [dbo].[Brands] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name], [Description], [Slug], [Status]) VALUES (9, N'Macbook Pro', N'Macbook is Large Brand in the world 2', N'Macbook-Pro', 1)
INSERT [dbo].[Categories] ([Id], [Name], [Description], [Slug], [Status]) VALUES (10, N'Desktop', N'Pc is Smart Products in the world', N'Desktop', 0)
INSERT [dbo].[Categories] ([Id], [Name], [Description], [Slug], [Status]) VALUES (11, N'Tablet 2023 Pro', N'Tablet is the smart thick devices', N'Tablet-2023-Pro', 1)
INSERT [dbo].[Categories] ([Id], [Name], [Description], [Slug], [Status]) VALUES (12, N'Accessories', N'Accessories', N'Accessories', 1)
INSERT [dbo].[Categories] ([Id], [Name], [Description], [Slug], [Status]) VALUES (13, N'RAM', N'RAM', N'RAM', 1)
INSERT [dbo].[Categories] ([Id], [Name], [Description], [Slug], [Status]) VALUES (14, N'chip', N'chip', N'chip', 1)
INSERT [dbo].[Categories] ([Id], [Name], [Description], [Slug], [Status]) VALUES (15, N'Shoes', N'Shoes', N'Shoes', 1)
INSERT [dbo].[Categories] ([Id], [Name], [Description], [Slug], [Status]) VALUES (16, N'Drivers', N'Drivers', N'Drivers', 1)
INSERT [dbo].[Categories] ([Id], [Name], [Description], [Slug], [Status]) VALUES (17, N'Graphic Card', N'Graphic Card', N'Graphic-Card', 1)
INSERT [dbo].[Categories] ([Id], [Name], [Description], [Slug], [Status]) VALUES (18, N'Mainboard', N'Mainboard', N'Mainboard', 1)
INSERT [dbo].[Categories] ([Id], [Name], [Description], [Slug], [Status]) VALUES (19, N'Mouse', N'Mouse', N'Mouse', 1)
INSERT [dbo].[Categories] ([Id], [Name], [Description], [Slug], [Status]) VALUES (20, N'Apple Watch', N'Apple Watch', N'Apple-Watch', 1)
INSERT [dbo].[Categories] ([Id], [Name], [Description], [Slug], [Status]) VALUES (21, N'Headphone', N'Headphone', N'Headphone', 1)
INSERT [dbo].[Categories] ([Id], [Name], [Description], [Slug], [Status]) VALUES (22, N'Tablet', N'Tablet', N'Tablet', 1)
INSERT [dbo].[Categories] ([Id], [Name], [Description], [Slug], [Status]) VALUES (23, N'Printer', N'Printer', N'Printer', 1)
INSERT [dbo].[Categories] ([Id], [Name], [Description], [Slug], [Status]) VALUES (24, N'Sim', N'Sim', N'Sim', 1)
INSERT [dbo].[Categories] ([Id], [Name], [Description], [Slug], [Status]) VALUES (25, N'Card', N'Card', N'Card', 1)
INSERT [dbo].[Categories] ([Id], [Name], [Description], [Slug], [Status]) VALUES (26, N'Clothes', N'Clothes', N'Clothes', 1)
INSERT [dbo].[Categories] ([Id], [Name], [Description], [Slug], [Status]) VALUES (27, N'Keyboard', N'Keyboard', N'Keyboard', 1)
INSERT [dbo].[Categories] ([Id], [Name], [Description], [Slug], [Status]) VALUES (28, N'Monitor', N'Monitor', N'Monitor', 1)
INSERT [dbo].[Categories] ([Id], [Name], [Description], [Slug], [Status]) VALUES (29, N'Case', N'Case', N'Case', 1)
INSERT [dbo].[Categories] ([Id], [Name], [Description], [Slug], [Status]) VALUES (31, N'Test 111', N'test 222222', N'Test-111', 1)
INSERT [dbo].[Categories] ([Id], [Name], [Description], [Slug], [Status]) VALUES (32, N'Camera', N'Camera', N'Camera', 1)
INSERT [dbo].[Categories] ([Id], [Name], [Description], [Slug], [Status]) VALUES (33, N'PowerPC', N'PowerPC', N'PowerPC', 1)
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderDetails] ON 

INSERT [dbo].[OrderDetails] ([Id], [UserName], [OrderCode], [ProductId], [Price], [Quantity]) VALUES (1, N'admin11@gmail.com', N'c0ee556d-39e2-4f02-b83f-3da90f79afca', 11, CAST(1233.00 AS Decimal(18, 2)), 5)
INSERT [dbo].[OrderDetails] ([Id], [UserName], [OrderCode], [ProductId], [Price], [Quantity]) VALUES (2, N'admin11@gmail.com', N'c0ee556d-39e2-4f02-b83f-3da90f79afca', 14, CAST(222.00 AS Decimal(18, 2)), 2)
INSERT [dbo].[OrderDetails] ([Id], [UserName], [OrderCode], [ProductId], [Price], [Quantity]) VALUES (3, N'admin11@gmail.com', N'f95526ef-b42f-477c-94ad-12d627440d84', 11, CAST(1233.00 AS Decimal(18, 2)), 5)
INSERT [dbo].[OrderDetails] ([Id], [UserName], [OrderCode], [ProductId], [Price], [Quantity]) VALUES (4, N'admin11@gmail.com', N'f95526ef-b42f-477c-94ad-12d627440d84', 14, CAST(222.00 AS Decimal(18, 2)), 3)
INSERT [dbo].[OrderDetails] ([Id], [UserName], [OrderCode], [ProductId], [Price], [Quantity]) VALUES (5, N'admin11@gmail.com', N'462aaedc-baeb-48fa-aaac-b2955ddb7905', 15, CAST(2222.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[OrderDetails] ([Id], [UserName], [OrderCode], [ProductId], [Price], [Quantity]) VALUES (6, N'admin11@gmail.com', N'462aaedc-baeb-48fa-aaac-b2955ddb7905', 14, CAST(222.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[OrderDetails] ([Id], [UserName], [OrderCode], [ProductId], [Price], [Quantity]) VALUES (7, N'admin11@gmail.com', N'462aaedc-baeb-48fa-aaac-b2955ddb7905', 11, CAST(1233.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[OrderDetails] ([Id], [UserName], [OrderCode], [ProductId], [Price], [Quantity]) VALUES (8, N'admin11@gmail.com', N'8ced0640-d7ad-4234-85dd-feb02de86359', 11, CAST(1233.00 AS Decimal(18, 2)), 3)
INSERT [dbo].[OrderDetails] ([Id], [UserName], [OrderCode], [ProductId], [Price], [Quantity]) VALUES (9, N'admin11@gmail.com', N'8ced0640-d7ad-4234-85dd-feb02de86359', 14, CAST(222.00 AS Decimal(18, 2)), 2)
INSERT [dbo].[OrderDetails] ([Id], [UserName], [OrderCode], [ProductId], [Price], [Quantity]) VALUES (10, N'admin11@gmail.com', N'8ced0640-d7ad-4234-85dd-feb02de86359', 15, CAST(2222.00 AS Decimal(18, 2)), 3)
SET IDENTITY_INSERT [dbo].[OrderDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([Id], [OrderCode], [UserName], [CreatedDate], [Status]) VALUES (1, N'd16468c9-cd97-41ce-8452-8706d1160b96', N'admin11@gmail.com', CAST(N'2024-09-10T16:22:33.1856993' AS DateTime2), 1)
INSERT [dbo].[Orders] ([Id], [OrderCode], [UserName], [CreatedDate], [Status]) VALUES (2, N'5c565647-10d7-4d72-981f-b4a50da641fb', N'admin11@gmail.com', CAST(N'2024-09-10T16:23:52.2349051' AS DateTime2), 1)
INSERT [dbo].[Orders] ([Id], [OrderCode], [UserName], [CreatedDate], [Status]) VALUES (3, N'c0ee556d-39e2-4f02-b83f-3da90f79afca', N'admin11@gmail.com', CAST(N'2024-09-10T16:34:23.5681990' AS DateTime2), 1)
INSERT [dbo].[Orders] ([Id], [OrderCode], [UserName], [CreatedDate], [Status]) VALUES (4, N'f95526ef-b42f-477c-94ad-12d627440d84', N'admin11@gmail.com', CAST(N'2024-09-10T16:35:17.5429452' AS DateTime2), 1)
INSERT [dbo].[Orders] ([Id], [OrderCode], [UserName], [CreatedDate], [Status]) VALUES (5, N'462aaedc-baeb-48fa-aaac-b2955ddb7905', N'admin11@gmail.com', CAST(N'2024-09-10T16:37:24.8899689' AS DateTime2), 1)
INSERT [dbo].[Orders] ([Id], [OrderCode], [UserName], [CreatedDate], [Status]) VALUES (6, N'8ced0640-d7ad-4234-85dd-feb02de86359', N'admin11@gmail.com', CAST(N'2024-09-10T17:25:26.5319096' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [Name], [Slug], [Description], [Price], [BrandId], [CategoryId], [Image]) VALUES (11, N'PC DELL 2', N'PC-DELL-2', N'<p>PC is Best</p>
', CAST(1233.00 AS Decimal(18, 2)), 10, 10, N'36cdf8de-c900-4749-905d-957118bd8d38_pc3.jpg')
INSERT [dbo].[Products] ([Id], [Name], [Slug], [Description], [Price], [BrandId], [CategoryId], [Image]) VALUES (14, N'Macbook Pro 2024', N'Macbook-Pro-2024', N'<p>Macbook is Best 2</p>
', CAST(222.00 AS Decimal(18, 2)), 9, 9, N'97564448-7a4a-4ecc-a846-53064a1735cc_1.jpg')
INSERT [dbo].[Products] ([Id], [Name], [Slug], [Description], [Price], [BrandId], [CategoryId], [Image]) VALUES (15, N'PC 2024', N'PC-2024', N'<p>SP 3 Edit</p>
', CAST(2222.00 AS Decimal(18, 2)), 13, 10, N'3d3eaca5-a5a0-4517-9abb-a1a0f9a09ae4_bo-pc-gia-lap-dual-xeon-e5-2680-v4-x99-f8d-rx-550-4g-280x280.jpg')
INSERT [dbo].[Products] ([Id], [Name], [Slug], [Description], [Price], [BrandId], [CategoryId], [Image]) VALUES (18, N'PC 4', N'PC-4', N'<p>444</p>
', CAST(444.00 AS Decimal(18, 2)), 13, 10, N'90197429-134e-4829-8e79-0e3462da6a6a_bo-pc-i5-13400f-b760m-rtx-3060-280x280.jpg')
INSERT [dbo].[Products] ([Id], [Name], [Slug], [Description], [Price], [BrandId], [CategoryId], [Image]) VALUES (19, N'PC 5', N'PC-5', N'<p>555</p>
', CAST(5555.00 AS Decimal(18, 2)), 14, 10, N'75f140b6-f46b-4b17-b676-600f8f9c2045_bo-pc-i5-14600k-b760m-wifi-rtx-3060-ti-280x280.jpg')
INSERT [dbo].[Products] ([Id], [Name], [Slug], [Description], [Price], [BrandId], [CategoryId], [Image]) VALUES (20, N'PC 6', N'PC-6', N'<p>666</p>
', CAST(666.00 AS Decimal(18, 2)), 18, 10, N'2ef364b0-68f6-4d9d-a3f1-79f02d45232b_bo-pc-i5-13600k-b660m-rtx-3060-280x280.jpg')
INSERT [dbo].[Products] ([Id], [Name], [Slug], [Description], [Price], [BrandId], [CategoryId], [Image]) VALUES (21, N'HP 7', N'HP-7', N'<p>7</p>
', CAST(777.00 AS Decimal(18, 2)), 17, 21, N'2a91f5b4-b423-462c-a911-288ec9b4770c_Gaming-gear-280x280.png')
INSERT [dbo].[Products] ([Id], [Name], [Slug], [Description], [Price], [BrandId], [CategoryId], [Image]) VALUES (22, N'Màn hình Acer', N'Màn-hình-Acer', N'<p>M&agrave;n h&igrave;nh</p>
', CAST(789.00 AS Decimal(18, 2)), 13, 17, N'85326bfb-d2ec-4dfd-9a9f-76b778b12e83_Man-hinh-280x280.png')
INSERT [dbo].[Products] ([Id], [Name], [Slug], [Description], [Price], [BrandId], [CategoryId], [Image]) VALUES (23, N'Camera full HD', N'Camera-full-HD', N'<p>Camera HD</p>
', CAST(7812.00 AS Decimal(18, 2)), 18, 32, N'9b56ce64-4112-4c02-af8c-bfde7daab7f5_Camera-3-280x280.png')
INSERT [dbo].[Products] ([Id], [Name], [Slug], [Description], [Price], [BrandId], [CategoryId], [Image]) VALUES (24, N'Camera 8P', N'Camera-8P', N'<p>A camera is&nbsp;<strong>an instrument used to capture and store images and videos</strong>, either digitally via an electronic image sensor, or chemically via a light-sensitive material such as photographic film.</p>
', CAST(11111.00 AS Decimal(18, 2)), 22, 32, N'7acc2b45-ebe1-497e-ad3f-ef973e444585_Camera-3-280x280.png')
INSERT [dbo].[Products] ([Id], [Name], [Slug], [Description], [Price], [BrandId], [CategoryId], [Image]) VALUES (25, N'Nguồn 500W PC', N'Nguồn-500W-PC', N'<p><em><strong>Nguồn PC</strong></em></p>
', CAST(7335.00 AS Decimal(18, 2)), 11, 33, N'ab370dee-5f6c-4547-84fd-a8cdb703d566_phu-kien-1-280x280.png')
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 9/12/2024 5:34:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 9/12/2024 5:34:18 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 9/12/2024 5:34:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 9/12/2024 5:34:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 9/12/2024 5:34:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 9/12/2024 5:34:18 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 9/12/2024 5:34:18 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderDetails_ProductId]    Script Date: 9/12/2024 5:34:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderDetails_ProductId] ON [dbo].[OrderDetails]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_BrandId]    Script Date: 9/12/2024 5:34:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Products_BrandId] ON [dbo].[Products]
(
	[BrandId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_CategoryId]    Script Date: 9/12/2024 5:34:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Products_CategoryId] ON [dbo].[Products]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Products_ProductId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Brands_BrandId] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brands] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Brands_BrandId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories_CategoryId]
GO
USE [master]
GO
ALTER DATABASE [EShop] SET  READ_WRITE 
GO
