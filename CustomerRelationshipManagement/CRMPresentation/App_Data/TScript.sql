USE [master]
GO
/****** Object:  Database [College]    Script Date: 08-03-2018 23:26:39 ******/
CREATE DATABASE [College]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'College', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\College.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'College_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\College_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [College] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [College].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [College] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [College] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [College] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [College] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [College] SET ARITHABORT OFF 
GO
ALTER DATABASE [College] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [College] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [College] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [College] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [College] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [College] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [College] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [College] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [College] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [College] SET  DISABLE_BROKER 
GO
ALTER DATABASE [College] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [College] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [College] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [College] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [College] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [College] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [College] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [College] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [College] SET  MULTI_USER 
GO
ALTER DATABASE [College] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [College] SET DB_CHAINING OFF 
GO
ALTER DATABASE [College] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [College] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [College] SET DELAYED_DURABILITY = DISABLED 
GO
USE [College]
GO
/****** Object:  Schema [Trans]    Script Date: 08-03-2018 23:26:39 ******/
CREATE SCHEMA [Trans]
GO
/****** Object:  Table [dbo].[CustomerDetails]    Script Date: 08-03-2018 23:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerDetails](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](50) NULL,
	[PrimaryMailID] [nvarchar](50) NULL,
	[PrimaryPhoneNo] [nvarchar](50) NULL,
	[Fax] [nvarchar](50) NULL,
	[Website] [nvarchar](50) NULL,
	[IndustryCategoryId] [int] NOT NULL,
	[BillingAddress] [nvarchar](50) NULL,
	[BillingAddress1] [nvarchar](50) NULL,
	[BillingCity] [nvarchar](50) NULL,
	[BillingState] [nvarchar](50) NULL,
	[BillingCountry] [nvarchar](50) NULL,
	[BillingPincode] [nvarchar](50) NULL,
	[ShippingAddress] [nvarchar](50) NULL,
	[ShippingAddress1] [nvarchar](50) NULL,
	[ShippingCity] [nvarchar](50) NULL,
	[ShippingState] [nvarchar](50) NULL,
	[ShippingCountry] [nvarchar](50) NULL,
	[ShippingPincode] [nvarchar](50) NULL,
	[ContactPersonName] [nvarchar](50) NULL,
	[ContactPersonNo] [nvarchar](50) NULL,
 CONSTRAINT [PK_CustomerDetails] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IndustryCategory]    Script Date: 08-03-2018 23:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IndustryCategory](
	[IndustryCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[IndustryCategoryName] [nvarchar](50) NULL,
	[Status] [char](1) NULL,
 CONSTRAINT [PK_IndustryCategory] PRIMARY KEY CLUSTERED 
(
	[IndustryCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MenuMaster]    Script Date: 08-03-2018 23:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MenuMaster](
	[MenuId] [int] IDENTITY(1,1) NOT NULL,
	[MenuName] [varchar](50) NULL,
	[MenuUrl] [varchar](200) NULL,
	[MenuParentId] [int] NULL,
	[Active] [bit] NULL,
	[ControllerName] [varchar](100) NULL,
	[ActionName] [varchar](100) NULL,
	[IconStyle] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MenuPrivilege]    Script Date: 08-03-2018 23:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuPrivilege](
	[PrivilegeID] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[MenuId] [int] NOT NULL,
	[Access] [int] NOT NULL,
 CONSTRAINT [PK_MenuPrivilege] PRIMARY KEY CLUSTERED 
(
	[PrivilegeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoleMaster]    Script Date: 08-03-2018 23:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RoleMaster](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RoleMenuMapping]    Script Date: 08-03-2018 23:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleMenuMapping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NULL,
	[MenuId] [int] NULL,
	[Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserAuthentication]    Script Date: 08-03-2018 23:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserAuthentication](
	[UserAuthID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
 CONSTRAINT [PK_UserAuthentication] PRIMARY KEY CLUSTERED 
(
	[UserAuthID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserMaster]    Script Date: 08-03-2018 23:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [varchar](20) NULL,
	[Name] [varchar](100) NULL,
	[RoleId] [int] NULL,
	[Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Trans].[LeadSource]    Script Date: 08-03-2018 23:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Trans].[LeadSource](
	[LeadSourceID] [int] IDENTITY(1,1) NOT NULL,
	[LeadSourceName] [nvarchar](100) NULL,
	[Status] [char](1) NULL,
 CONSTRAINT [PK_LeadSource] PRIMARY KEY CLUSTERED 
(
	[LeadSourceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[CustomerDetails] ON 

INSERT [dbo].[CustomerDetails] ([CustomerID], [CustomerName], [PrimaryMailID], [PrimaryPhoneNo], [Fax], [Website], [IndustryCategoryId], [BillingAddress], [BillingAddress1], [BillingCity], [BillingState], [BillingCountry], [BillingPincode], [ShippingAddress], [ShippingAddress1], [ShippingCity], [ShippingState], [ShippingCountry], [ShippingPincode], [ContactPersonName], [ContactPersonNo]) VALUES (4, N'Just Dial', N'JD@gmail.com', N'90944326423', NULL, N'www.JD.com', 1, N'Parvathy Nagar', N'Parvathy Nagar', N'Chennai', N'Tamilandu', N'India', N'600063', N'Parvathy Nagar', N'Parvathy Nagar', N'Chennai', N'Tamilandu', N'India', N'600063', N'Kumar', N'Ram')
INSERT [dbo].[CustomerDetails] ([CustomerID], [CustomerName], [PrimaryMailID], [PrimaryPhoneNo], [Fax], [Website], [IndustryCategoryId], [BillingAddress], [BillingAddress1], [BillingCity], [BillingState], [BillingCountry], [BillingPincode], [ShippingAddress], [ShippingAddress1], [ShippingCity], [ShippingState], [ShippingCountry], [ShippingPincode], [ContactPersonName], [ContactPersonNo]) VALUES (5, N'New India Test', N'ID@gmail.com', N'9551882666', N'044232902', N'www.NI.com', 6, N'Parvathy Nagar', N'Parvathy Nagar', N'Chennai', N'Tamilandu', N'India', N'600063', N'Parvathy Nagar', N'Parvathy Nagar', N'Chennai', N'Tamilandu', N'India', N'600063', N'Viji', N'Ravi')
INSERT [dbo].[CustomerDetails] ([CustomerID], [CustomerName], [PrimaryMailID], [PrimaryPhoneNo], [Fax], [Website], [IndustryCategoryId], [BillingAddress], [BillingAddress1], [BillingCity], [BillingState], [BillingCountry], [BillingPincode], [ShippingAddress], [ShippingAddress1], [ShippingCity], [ShippingState], [ShippingCountry], [ShippingPincode], [ContactPersonName], [ContactPersonNo]) VALUES (6, N'India Mart', N'IndiaMart@gmail.com', N'9629207469', N'044664321', N'www.IndiaMart.com', 7, N'First Strret', N'Second Street', N'Main City', N'Main State', N'Main Country', N'600064', N'First Strret', N'Second Street', N'Main City', N'Main State', N'Main Country', N'600064', N'Ram Kumar', N'9684839289')
SET IDENTITY_INSERT [dbo].[CustomerDetails] OFF
SET IDENTITY_INSERT [dbo].[IndustryCategory] ON 

INSERT [dbo].[IndustryCategory] ([IndustryCategoryId], [IndustryCategoryName], [Status]) VALUES (1, N'Education', N'Y')
INSERT [dbo].[IndustryCategory] ([IndustryCategoryId], [IndustryCategoryName], [Status]) VALUES (2, N'Construction', N'Y')
INSERT [dbo].[IndustryCategory] ([IndustryCategoryId], [IndustryCategoryName], [Status]) VALUES (3, N'Manufacturing', N'Y')
INSERT [dbo].[IndustryCategory] ([IndustryCategoryId], [IndustryCategoryName], [Status]) VALUES (4, N'Electric', N'Y')
INSERT [dbo].[IndustryCategory] ([IndustryCategoryId], [IndustryCategoryName], [Status]) VALUES (5, N'Gas and Sanitary service', N'Y')
INSERT [dbo].[IndustryCategory] ([IndustryCategoryId], [IndustryCategoryName], [Status]) VALUES (6, N'Mining', N'Y')
INSERT [dbo].[IndustryCategory] ([IndustryCategoryId], [IndustryCategoryName], [Status]) VALUES (7, N'Agriculture', N'Y')
INSERT [dbo].[IndustryCategory] ([IndustryCategoryId], [IndustryCategoryName], [Status]) VALUES (8, N'Forestry and Fishing', N'Y')
INSERT [dbo].[IndustryCategory] ([IndustryCategoryId], [IndustryCategoryName], [Status]) VALUES (9, N'Insurance and Real Estate', N'Y')
SET IDENTITY_INSERT [dbo].[IndustryCategory] OFF
SET IDENTITY_INSERT [dbo].[MenuMaster] ON 

INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [MenuUrl], [MenuParentId], [Active], [ControllerName], [ActionName], [IconStyle]) VALUES (1, N'Dashboard', N'Home/Dashboard', 0, 1, N'Home', N'Dashboard', N'fa fa-dashboard')
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [MenuUrl], [MenuParentId], [Active], [ControllerName], [ActionName], [IconStyle]) VALUES (2, N'Customer', N'#', 0, 1, NULL, NULL, N'fa fa-files-o')
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [MenuUrl], [MenuParentId], [Active], [ControllerName], [ActionName], [IconStyle]) VALUES (3, N'New Customer', N'Customer/NewCustomer', 2, 1, N'Customer', N'NewCustomer', NULL)
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [MenuUrl], [MenuParentId], [Active], [ControllerName], [ActionName], [IconStyle]) VALUES (4, N'View Customer', N'Customer/ViewCustomer', 2, 1, N'Customer', N'ViewCustomer', NULL)
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [MenuUrl], [MenuParentId], [Active], [ControllerName], [ActionName], [IconStyle]) VALUES (5, N'Company', N'#', 0, 1, NULL, NULL, N'fa fa-files-o')
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [MenuUrl], [MenuParentId], [Active], [ControllerName], [ActionName], [IconStyle]) VALUES (6, N'New Company', N'Company/NewCompany', 5, 1, N'Company', N'NewCompany', NULL)
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [MenuUrl], [MenuParentId], [Active], [ControllerName], [ActionName], [IconStyle]) VALUES (7, N'View Company', N'Company/ViewCompany', 5, 1, N'Company', N'ViewCompany', NULL)
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [MenuUrl], [MenuParentId], [Active], [ControllerName], [ActionName], [IconStyle]) VALUES (8, N'Industry', N'#', 0, 1, NULL, NULL, N'fa fa-laptop')
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [MenuUrl], [MenuParentId], [Active], [ControllerName], [ActionName], [IconStyle]) VALUES (9, N'New Industry', N'MasterSettings/NewIndustryCategory', 8, 1, N'MasterSettings', N'NewIndustryCategory', NULL)
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [MenuUrl], [MenuParentId], [Active], [ControllerName], [ActionName], [IconStyle]) VALUES (10, N'View Industry', N'MasterSettings/ViewIndustryCategory', 8, 1, N'MasterSettings', N'ViewIndustryCategory', NULL)
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [MenuUrl], [MenuParentId], [Active], [ControllerName], [ActionName], [IconStyle]) VALUES (11, N'Lead Source', N'#', 0, 1, NULL, NULL, N'fa fa-edit')
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [MenuUrl], [MenuParentId], [Active], [ControllerName], [ActionName], [IconStyle]) VALUES (12, N'New Lead Source', N'MasterSettings/NewLeadSource', 11, 1, N'MasterSettings', N'NewLeadSource', NULL)
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [MenuUrl], [MenuParentId], [Active], [ControllerName], [ActionName], [IconStyle]) VALUES (13, N'View Lead Source', N'MasterSettings/ViewLeadSource', 11, 1, N'MasterSettings', N'ViewLeadSource', NULL)
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [MenuUrl], [MenuParentId], [Active], [ControllerName], [ActionName], [IconStyle]) VALUES (14, N'Quotes', N'#', 0, 1, NULL, NULL, N'fa fa-table')
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [MenuUrl], [MenuParentId], [Active], [ControllerName], [ActionName], [IconStyle]) VALUES (15, N'New Quotes', N'Quote/GQuote', 14, 1, N'Quote', N'GQuote', NULL)
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [MenuUrl], [MenuParentId], [Active], [ControllerName], [ActionName], [IconStyle]) VALUES (16, N'View Quotes', N'Quote/ViewQuote', 14, 1, N'Quote', N'EQuote', NULL)
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [MenuUrl], [MenuParentId], [Active], [ControllerName], [ActionName], [IconStyle]) VALUES (17, N'Product', N'#', 0, 1, NULL, NULL, N'fa fa-folder')
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [MenuUrl], [MenuParentId], [Active], [ControllerName], [ActionName], [IconStyle]) VALUES (18, N'New Product', N'Product/NewProduct', 17, 1, N'Product', N'NewProduct', NULL)
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [MenuUrl], [MenuParentId], [Active], [ControllerName], [ActionName], [IconStyle]) VALUES (19, N'View Product', N'Product/ViewProduct', 17, 1, N'Product', N'ViewProduct', NULL)
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [MenuUrl], [MenuParentId], [Active], [ControllerName], [ActionName], [IconStyle]) VALUES (20, N'Masters Settings', N'#', 0, 1, NULL, NULL, N'fa fa-table')
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [MenuUrl], [MenuParentId], [Active], [ControllerName], [ActionName], [IconStyle]) VALUES (21, N'Lead Source', N'MasterSettings/ViewLeadSource', 20, 1, N'MasterSettings', N'ViewLeadSource', NULL)
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [MenuUrl], [MenuParentId], [Active], [ControllerName], [ActionName], [IconStyle]) VALUES (22, N'Industry Category', N'MasterSettings/ViewindustryCategory', 20, 1, N'MasterSettings', N'ViewindustryCategory', NULL)
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [MenuUrl], [MenuParentId], [Active], [ControllerName], [ActionName], [IconStyle]) VALUES (23, N'Company Details', N'Company/ViewCompany', 20, 1, N'Company', N'ViewCompany', NULL)
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [MenuUrl], [MenuParentId], [Active], [ControllerName], [ActionName], [IconStyle]) VALUES (24, N'Role', N'MasterSettings/Role', 20, 1, N'MasterSettings', N'Role', NULL)
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [MenuUrl], [MenuParentId], [Active], [ControllerName], [ActionName], [IconStyle]) VALUES (25, N'RoleMenuMapping', N'MasterSettings/RoleMenuMapping', 20, 1, N'MasterSettings', N'RoleMenuMapping', NULL)
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [MenuUrl], [MenuParentId], [Active], [ControllerName], [ActionName], [IconStyle]) VALUES (26, N'User Master', N'UserMaster/ViewUser', 20, 1, N'UserMaster', N'ViewUser', NULL)
SET IDENTITY_INSERT [dbo].[MenuMaster] OFF
SET IDENTITY_INSERT [dbo].[RoleMaster] ON 

INSERT [dbo].[RoleMaster] ([RoleId], [Name], [Active]) VALUES (1, N'Regular User', 1)
INSERT [dbo].[RoleMaster] ([RoleId], [Name], [Active]) VALUES (2, N'Admin', 1)
INSERT [dbo].[RoleMaster] ([RoleId], [Name], [Active]) VALUES (3, N'HR', 1)
INSERT [dbo].[RoleMaster] ([RoleId], [Name], [Active]) VALUES (4, N'Test User', 1)
SET IDENTITY_INSERT [dbo].[RoleMaster] OFF
SET IDENTITY_INSERT [dbo].[RoleMenuMapping] ON 

INSERT [dbo].[RoleMenuMapping] ([Id], [RoleId], [MenuId], [Active]) VALUES (1, 2, 1, 1)
INSERT [dbo].[RoleMenuMapping] ([Id], [RoleId], [MenuId], [Active]) VALUES (2, 2, 2, 1)
INSERT [dbo].[RoleMenuMapping] ([Id], [RoleId], [MenuId], [Active]) VALUES (3, 2, 3, 1)
INSERT [dbo].[RoleMenuMapping] ([Id], [RoleId], [MenuId], [Active]) VALUES (4, 2, 4, 1)
INSERT [dbo].[RoleMenuMapping] ([Id], [RoleId], [MenuId], [Active]) VALUES (5, 2, 5, 1)
INSERT [dbo].[RoleMenuMapping] ([Id], [RoleId], [MenuId], [Active]) VALUES (6, 2, 6, 1)
INSERT [dbo].[RoleMenuMapping] ([Id], [RoleId], [MenuId], [Active]) VALUES (7, 2, 7, 1)
INSERT [dbo].[RoleMenuMapping] ([Id], [RoleId], [MenuId], [Active]) VALUES (8, 2, 8, 1)
INSERT [dbo].[RoleMenuMapping] ([Id], [RoleId], [MenuId], [Active]) VALUES (9, 2, 9, 1)
INSERT [dbo].[RoleMenuMapping] ([Id], [RoleId], [MenuId], [Active]) VALUES (10, 2, 10, 1)
INSERT [dbo].[RoleMenuMapping] ([Id], [RoleId], [MenuId], [Active]) VALUES (11, 2, 11, 1)
INSERT [dbo].[RoleMenuMapping] ([Id], [RoleId], [MenuId], [Active]) VALUES (12, 2, 12, 1)
INSERT [dbo].[RoleMenuMapping] ([Id], [RoleId], [MenuId], [Active]) VALUES (13, 2, 13, 1)
INSERT [dbo].[RoleMenuMapping] ([Id], [RoleId], [MenuId], [Active]) VALUES (14, 2, 14, 1)
INSERT [dbo].[RoleMenuMapping] ([Id], [RoleId], [MenuId], [Active]) VALUES (15, 2, 15, 1)
INSERT [dbo].[RoleMenuMapping] ([Id], [RoleId], [MenuId], [Active]) VALUES (16, 2, 16, 1)
INSERT [dbo].[RoleMenuMapping] ([Id], [RoleId], [MenuId], [Active]) VALUES (17, 2, 17, 1)
INSERT [dbo].[RoleMenuMapping] ([Id], [RoleId], [MenuId], [Active]) VALUES (18, 2, 18, 1)
INSERT [dbo].[RoleMenuMapping] ([Id], [RoleId], [MenuId], [Active]) VALUES (19, 2, 19, 1)
INSERT [dbo].[RoleMenuMapping] ([Id], [RoleId], [MenuId], [Active]) VALUES (20, 2, 20, 1)
INSERT [dbo].[RoleMenuMapping] ([Id], [RoleId], [MenuId], [Active]) VALUES (21, 2, 21, 1)
INSERT [dbo].[RoleMenuMapping] ([Id], [RoleId], [MenuId], [Active]) VALUES (22, 2, 22, 1)
INSERT [dbo].[RoleMenuMapping] ([Id], [RoleId], [MenuId], [Active]) VALUES (23, 2, 23, 1)
INSERT [dbo].[RoleMenuMapping] ([Id], [RoleId], [MenuId], [Active]) VALUES (24, 2, 24, 1)
INSERT [dbo].[RoleMenuMapping] ([Id], [RoleId], [MenuId], [Active]) VALUES (25, 2, 25, 1)
INSERT [dbo].[RoleMenuMapping] ([Id], [RoleId], [MenuId], [Active]) VALUES (26, 2, 26, 1)
SET IDENTITY_INSERT [dbo].[RoleMenuMapping] OFF
SET IDENTITY_INSERT [dbo].[UserAuthentication] ON 

INSERT [dbo].[UserAuthentication] ([UserAuthID], [UserID], [UserName], [Password]) VALUES (1, 2, N'John', N'welcome')
INSERT [dbo].[UserAuthentication] ([UserAuthID], [UserID], [UserName], [Password]) VALUES (2, 4, N'karthik', N'welcome')
INSERT [dbo].[UserAuthentication] ([UserAuthID], [UserID], [UserName], [Password]) VALUES (4, 8, N'vinoth', N'welcome')
SET IDENTITY_INSERT [dbo].[UserAuthentication] OFF
SET IDENTITY_INSERT [dbo].[UserMaster] ON 

INSERT [dbo].[UserMaster] ([Id], [UserId], [Name], [RoleId], [Active]) VALUES (1, N'10001', N'Rahul', 1, 1)
INSERT [dbo].[UserMaster] ([Id], [UserId], [Name], [RoleId], [Active]) VALUES (2, N'10002', N'John', 2, 1)
INSERT [dbo].[UserMaster] ([Id], [UserId], [Name], [RoleId], [Active]) VALUES (3, N'10003', N'Mike', 3, 1)
INSERT [dbo].[UserMaster] ([Id], [UserId], [Name], [RoleId], [Active]) VALUES (4, NULL, N'Karthik Madhavan', 2, 1)
INSERT [dbo].[UserMaster] ([Id], [UserId], [Name], [RoleId], [Active]) VALUES (8, NULL, N'Vinoth Kumar', 2, 1)
SET IDENTITY_INSERT [dbo].[UserMaster] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [NonClusteredIndex-20180215-162259]    Script Date: 08-03-2018 23:26:39 ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex-20180215-162259] ON [Trans].[LeadSource]
(
	[LeadSourceName] ASC,
	[Status] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CustomerDetails]  WITH CHECK ADD  CONSTRAINT [FK_CustomerDetails_IndustryCategory] FOREIGN KEY([IndustryCategoryId])
REFERENCES [dbo].[IndustryCategory] ([IndustryCategoryId])
GO
ALTER TABLE [dbo].[CustomerDetails] CHECK CONSTRAINT [FK_CustomerDetails_IndustryCategory]
GO
/****** Object:  StoredProcedure [dbo].[usp_AddNewCustomer]    Script Date: 08-03-2018 23:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_AddNewCustomer]  
(  
    @CustomerID int ,
	@CustomerName nvarchar(50),
	@PrimaryMailID nvarchar(50) ,
	@PrimaryPhoneNo nvarchar(50) ,
	@Fax nvarchar(50) ,
	@Website nvarchar(50) ,
	@IndustryCategoryId int  ,
	@BillingAddress nvarchar(50) ,
	@BillingAddress1 nvarchar(50) ,
	@BillingCity nvarchar(50) ,
	@BillingState nvarchar(50) ,
	@BillingCountry nvarchar(50) ,
	@BillingPincode nvarchar(50) ,
	@ShippingAddress nvarchar(50) ,
	@ShippingAddress1 nvarchar(50) ,
	@ShippingCity nvarchar(50) ,
	@ShippingState nvarchar(50) ,
	@ShippingCountry nvarchar(50) ,
	@ShippingPincode nvarchar(50) ,
	@ContactPersonName nvarchar(50) ,
	@ContactPersonNo nvarchar(50)
)  
as  
BEGIN  
IF NOT EXISTS(SELECT 1 FROM [dbo].[CustomerDetails] WHERE CustomerID=@CustomerID  )
  INSERT INTO [dbo].[CustomerDetails]
           ([CustomerName]
           ,[PrimaryMailID]
           ,[PrimaryPhoneNo]
           ,[Fax]
           ,[Website]
           ,[IndustryCategoryId]
           ,[BillingAddress]
           ,[BillingAddress1]
           ,[BillingCity]
           ,[BillingState]
           ,[BillingCountry]
           ,[BillingPincode]
           ,[ShippingAddress]
           ,[ShippingAddress1]
           ,[ShippingCity]
           ,[ShippingState]
           ,[ShippingCountry]
           ,[ShippingPincode]
           ,[ContactPersonName]
           ,[ContactPersonNo])
     VALUES
           (@CustomerName
           ,@PrimaryMailID
           ,@PrimaryPhoneNo
           ,@Fax
           ,@Website
           ,@IndustryCategoryId
           ,@BillingAddress
           ,@BillingAddress1
           ,@BillingCity
           ,@BillingState
           ,@BillingCountry
           ,@BillingPincode
           ,@ShippingAddress
           ,@ShippingAddress1
           ,@ShippingCity
           ,@ShippingState
           ,@ShippingCountry
           ,@ShippingPincode
           ,@ContactPersonName
           ,@ContactPersonNo) 
End   


GO
/****** Object:  StoredProcedure [dbo].[usp_AddNewIndustryCategory]    Script Date: 08-03-2018 23:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[usp_AddNewIndustryCategory]  
(  
   @IndustryCategoryId int,  
   @IndustryCategoryName nvarchar (50),  
   @Status varchar (1)  
)  
as  
BEGIN  
IF NOT EXISTS(SELECT 1 FROM IndustryCategory WHERE IndustryCategoryId=@IndustryCategoryId  )
   Insert into IndustryCategory values(@IndustryCategoryName,@Status)  
End   

GO
/****** Object:  StoredProcedure [dbo].[usp_AddNewUser]    Script Date: 08-03-2018 23:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_AddNewUser]  
(  
    @Name nvarchar(50) ,
	@RoleId int,
	@Active bit 
	
)  
as  
BEGIN  

INSERT INTO [dbo].[UserMaster]
           (
           [Name]
           ,[RoleId]
           ,[Active])
     VALUES
           (@Name
           ,@RoleId
           ,@Active
           )
		    

		   END

GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteCustomer]    Script Date: 08-03-2018 23:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[usp_DeleteCustomer]
(
@CustomerID int
)
as
begin
Delete from [dbo].[CustomerDetails] where CustomerID=@CustomerID
End 

GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteIndustryCategory]    Script Date: 08-03-2018 23:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[usp_DeleteIndustryCategory]
(
@IndustryCategoryId int
)
as
begin
Delete from [dbo].[IndustryCategory] where IndustryCategoryId=@IndustryCategoryId
End 
GO
/****** Object:  StoredProcedure [dbo].[usp_GetAllCustomer]    Script Date: 08-03-2018 23:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[usp_GetAllCustomer]  
as  
begin  
SELECT [CustomerID]
      ,[CustomerName]
      ,[PrimaryMailID]
      ,[PrimaryPhoneNo]
      ,[Fax]
      ,[Website]
      ,[IndustryCategoryId]
      ,[BillingAddress]
      ,[BillingAddress1]
      ,[BillingCity]
      ,[BillingState]
      ,[BillingCountry]
      ,[BillingPincode]
      ,[ShippingAddress]
      ,[ShippingAddress1]
      ,[ShippingCity]
      ,[ShippingState]
      ,[ShippingCountry]
      ,[ShippingPincode]
      ,[ContactPersonName]
      ,[ContactPersonNo]
  FROM [dbo].[CustomerDetails]
End  

GO
/****** Object:  StoredProcedure [dbo].[usp_GetAllIndustryCategory]    Script Date: 08-03-2018 23:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[usp_GetAllIndustryCategory]  
as  
begin  
select [IndustryCategoryId]
      ,[IndustryCategoryName]
      ,[Status]
 from [dbo].[IndustryCategory]
End  
GO
/****** Object:  StoredProcedure [dbo].[usp_GetAllUser]    Script Date: 08-03-2018 23:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_GetAllUser]  
as  
begin  
SELECT [id]
      ,UM.[Name]
      ,UM.[RoleId]
      ,UA.UserName as UserName
      ,UA.Password as Password
	  ,RM.Name AS RoleName
	  ,UM.Active
      
  FROM [dbo].[UserMaster] as UM inner join UserAuthentication as UA on UA.UserID=UM.Id
  INNER JOIN RoleMaster RM ON RM.RoleId=UM.RoleId
End  

GO
/****** Object:  StoredProcedure [dbo].[usp_GetCustomerByID]    Script Date: 08-03-2018 23:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE Procedure [dbo].[usp_GetCustomerByID]
(
@CustomerID int
)  
as  
begin  
SELECT [CustomerID]
      ,[CustomerName]
      ,[PrimaryMailID]
      ,[PrimaryPhoneNo]
      ,[Fax]
      ,[Website]
      ,[IndustryCategoryId]
      ,[BillingAddress]
      ,[BillingAddress1]
      ,[BillingCity]
      ,[BillingState]
      ,[BillingCountry]
      ,[BillingPincode]
      ,[ShippingAddress]
      ,[ShippingAddress1]
      ,[ShippingCity]
      ,[ShippingState]
      ,[ShippingCountry]
      ,[ShippingPincode]
      ,[ContactPersonName]
      ,[ContactPersonNo]
  FROM [dbo].[CustomerDetails] WHERE CustomerID=@CustomerID
End  


GO
/****** Object:  StoredProcedure [dbo].[usp_GetMenuData]    Script Date: 08-03-2018 23:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_GetMenuData]
@UserId int   --user id as input parameter
as
begin                                                                    
                select mm.MenuID MID, mm.MenuName,mm.MenuURL,mm.MenuParentID,mm.ActionName,mm.ControllerName,mm.IconStyle from
                UserMaster um                                                       
                inner join RoleMenuMapping rm on um.RoleID=rm.RoleID                                                              
                inner join MenuMaster mm on mm.MenuId=rm.MenuID                                                   
                inner join RoleMaster br on br.RoleId =rm.RoleID                                                 
                where um.Id = @UserId  and rm.Active=1                -- add more active condition if required                                             
end

GO
/****** Object:  StoredProcedure [dbo].[usp_GetUserAuthByName]    Script Date: 08-03-2018 23:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[usp_GetUserAuthByName]
(
@UserName varchar(50)

)  
as  
begin  
SELECT[UserAuthID]
      ,[UserID]
      ,[UserName]
      ,[Password]
  FROM [dbo].[UserAuthentication] WHERE UserName=@UserName
End  



GO
/****** Object:  StoredProcedure [dbo].[usp_NewUserAuthentication]    Script Date: 08-03-2018 23:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_NewUserAuthentication]  
(  
    @UserID int ,
	@UserName nvarchar(50),
	@Password nvarchar(50) 
	
)  
as  
BEGIN  

INSERT INTO [dbo].[UserAuthentication]
           (
           [UserID]
           ,[UserName]
           ,[Password])
     VALUES
           (@UserID
           ,@UserName
           ,@Password
           )

		   END

GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateCustomer]    Script Date: 08-03-2018 23:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_UpdateCustomer]  
(  
    @CustomerID int ,
	@CustomerName nvarchar(50),
	@PrimaryMailID nvarchar(50) ,
	@PrimaryPhoneNo nvarchar(50) ,
	@Fax nvarchar(50) ,
	@Website nvarchar(50) ,
	@IndustryCategoryId int  ,
	@BillingAddress nvarchar(50) ,
	@BillingAddress1 nvarchar(50) ,
	@BillingCity nvarchar(50) ,
	@BillingState nvarchar(50) ,
	@BillingCountry nvarchar(50) ,
	@BillingPincode nvarchar(50) ,
	@ShippingAddress nvarchar(50) ,
	@ShippingAddress1 nvarchar(50) ,
	@ShippingCity nvarchar(50) ,
	@ShippingState nvarchar(50) ,
	@ShippingCountry nvarchar(50) ,
	@ShippingPincode nvarchar(50) ,
	@ContactPersonName nvarchar(50) ,
	@ContactPersonNo nvarchar(50)
)  
as  
BEGIN  
IF EXISTS(SELECT 1 FROM [dbo].[CustomerDetails] WHERE CustomerID=@CustomerID  )
  UPDATE  [dbo].[CustomerDetails] SET
           
		    [CustomerName]=@CustomerName
           ,[PrimaryMailID]=@PrimaryMailID
           ,[PrimaryPhoneNo]=@PrimaryPhoneNo
           ,[Fax]=@Fax
           ,[Website]=@Website
           ,[IndustryCategoryId]=@IndustryCategoryId
           ,[BillingAddress]=@BillingAddress
           ,[BillingAddress1]=@BillingAddress1
           ,[BillingCity]=@BillingCity
           ,[BillingState]=@BillingState
           ,[BillingCountry]=@BillingCountry
           ,[BillingPincode]=@BillingPincode
           ,[ShippingAddress]=@ShippingAddress
           ,[ShippingAddress1]=@ShippingAddress1
           ,[ShippingCity]=@ShippingCity
           ,[ShippingState]=@ShippingState
           ,[ShippingCountry]=@ShippingCountry
           ,[ShippingPincode]=@ShippingPincode
           ,[ContactPersonName]=@ContactPersonName
           ,[ContactPersonNo]=@ContactPersonNo
		   WHERE
		    CustomerID=@CustomerID

    
End   

GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateIndustryCategory]    Script Date: 08-03-2018 23:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[usp_UpdateIndustryCategory] 
(
@IndustryCategoryId int,
@IndustryCategoryName nvarchar (50),
@Status char (1)

)
as
begin
Update [dbo].[IndustryCategory]
set IndustryCategoryName=@IndustryCategoryName,

Status=@Status
where IndustryCategoryId=@IndustryCategoryId
End 
GO
/****** Object:  StoredProcedure [dbo].[usp_ValidateUser]    Script Date: 08-03-2018 23:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE Procedure [dbo].[usp_ValidateUser]
(
@UserName varchar(50),
@Password varchar(50)
)  
as  
begin  
SELECT[UserAuthID]
      ,[UserID]
      ,[UserName]
      ,[Password]
  FROM [dbo].[UserAuthentication] WHERE UserName=@UserName AND [Password]=@Password
End  


GO
USE [master]
GO
ALTER DATABASE [College] SET  READ_WRITE 
GO
