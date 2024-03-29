USE [master]
GO
/****** Object:  Database [FstoreDB]    Script Date: 02-Jul-22 8:11:06 PM ******/
CREATE DATABASE [FstoreDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FstoreDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\FstoreDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FstoreDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\FstoreDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [FstoreDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FstoreDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FstoreDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FstoreDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FstoreDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FstoreDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FstoreDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [FstoreDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FstoreDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FstoreDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FstoreDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FstoreDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FstoreDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FstoreDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FstoreDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FstoreDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FstoreDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FstoreDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FstoreDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FstoreDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FstoreDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FstoreDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FstoreDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FstoreDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FstoreDB] SET RECOVERY FULL 
GO
ALTER DATABASE [FstoreDB] SET  MULTI_USER 
GO
ALTER DATABASE [FstoreDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FstoreDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FstoreDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FstoreDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FstoreDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FstoreDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'FstoreDB', N'ON'
GO
ALTER DATABASE [FstoreDB] SET QUERY_STORE = OFF
GO
USE [FstoreDB]
GO
/****** Object:  Table [dbo].[Member]    Script Date: 02-Jul-22 8:11:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Member](
	[MemberID] [int] NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[CompanyName] [varchar](40) NOT NULL,
	[City] [varchar](15) NOT NULL,
	[Country] [varchar](15) NOT NULL,
	[Password] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED 
(
	[MemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 02-Jul-22 8:11:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderID] [int] NOT NULL,
	[MemberID] [int] NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[RequiredDate] [datetime] NULL,
	[ShippedDate] [datetime] NULL,
	[Freight] [money] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 02-Jul-22 8:11:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[OrderID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[UnitPrice] [money] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Discount] [float] NOT NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC,
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 02-Jul-22 8:11:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] NOT NULL,
	[CategoryID] [int] NOT NULL,
	[ProductName] [varchar](40) NOT NULL,
	[Weight] [varchar](20) NOT NULL,
	[UnitPrice] [money] NOT NULL,
	[UnitInStock] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Member] ([MemberID], [Email], [CompanyName], [City], [Country], [Password]) VALUES (1, N'quannmse161529@fpt.edu.vn', N'Testco Inc', N'Ho Chi Minh', N'Viet Nam', N'123')
INSERT [dbo].[Member] ([MemberID], [Email], [CompanyName], [City], [Country], [Password]) VALUES (2, N'phuclnse161514@fpt.edu.vn', N'Alpha Inc', N'Ho Chi Minh', N'Viet Nam', N'123')
INSERT [dbo].[Member] ([MemberID], [Email], [CompanyName], [City], [Country], [Password]) VALUES (3, N'hieunmse130445@fpt.edu.vn', N'Linex Inc', N'Ho Chi Minh', N'Viet Nam', N'123')
INSERT [dbo].[Member] ([MemberID], [Email], [CompanyName], [City], [Country], [Password]) VALUES (4, N'namnvhse150925@fpt.edu.vn', N'Solnel Inc', N'Ho Chi Minh', N'Viet Nam', N'123')
INSERT [dbo].[Member] ([MemberID], [Email], [CompanyName], [City], [Country], [Password]) VALUES (5, N'nghialhse150939@fpt.edu.vn', N'Coxby Inc', N'Ho Chi Minh', N'Viet Nam', N'123')
GO
INSERT [dbo].[Order] ([OrderID], [MemberID], [OrderDate], [RequiredDate], [ShippedDate], [Freight]) VALUES (1, 2, CAST(N'2021-07-20T00:00:00.000' AS DateTime), CAST(N'2021-07-25T00:00:00.000' AS DateTime), CAST(N'2021-07-25T00:00:00.000' AS DateTime), 20000.0000)
INSERT [dbo].[Order] ([OrderID], [MemberID], [OrderDate], [RequiredDate], [ShippedDate], [Freight]) VALUES (2, 3, CAST(N'2022-03-15T00:00:00.000' AS DateTime), CAST(N'2022-03-19T00:00:00.000' AS DateTime), CAST(N'2022-03-19T00:00:00.000' AS DateTime), 150000.0000)
GO
INSERT [dbo].[OrderDetail] ([OrderID], [ProductID], [UnitPrice], [Quantity], [Discount]) VALUES (1, 1, 1000.0000, 20, 0)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductID], [UnitPrice], [Quantity], [Discount]) VALUES (2, 7, 150000.0000, 1, 0)
GO
INSERT [dbo].[Product] ([ProductID], [CategoryID], [ProductName], [Weight], [UnitPrice], [UnitInStock]) VALUES (1, 1, N'salt', N'500g', 1000.0000, 5000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [ProductName], [Weight], [UnitPrice], [UnitInStock]) VALUES (2, 1, N'peper', N'500g', 20000.0000, 5000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [ProductName], [Weight], [UnitPrice], [UnitInStock]) VALUES (3, 1, N'MSG', N'500g', 1500.0000, 5000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [ProductName], [Weight], [UnitPrice], [UnitInStock]) VALUES (4, 2, N'pot', N'1.5kg', 500000.0000, 400)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [ProductName], [Weight], [UnitPrice], [UnitInStock]) VALUES (5, 2, N'pan', N'2kg', 750000.0000, 300)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [ProductName], [Weight], [UnitPrice], [UnitInStock]) VALUES (6, 2, N'grilling pan', N'2.5kg', 850000.0000, 250)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [ProductName], [Weight], [UnitPrice], [UnitInStock]) VALUES (7, 3, N'chef knife', N'500g', 150000.0000, 200)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [ProductName], [Weight], [UnitPrice], [UnitInStock]) VALUES (8, 3, N'butcher knife', N'1.5kg', 200000.0000, 200)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [ProductName], [Weight], [UnitPrice], [UnitInStock]) VALUES (9, 3, N'filetting knife', N'200g', 130000.0000, 200)
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Member] FOREIGN KEY([MemberID])
REFERENCES [dbo].[Member] ([MemberID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Member]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([OrderID])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Product]
GO
USE [master]
GO
ALTER DATABASE [FstoreDB] SET  READ_WRITE 
GO
