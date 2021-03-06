/****** Object:  Database [Accountancy]    Script Date: 10-Jun-22 7:28:59 AM ******/
CREATE DATABASE [Accountancy] ON  PRIMARY 
( NAME = N'Accountancy', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS01\MSSQL\DATA\Accountancy.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Accountancy_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS01\MSSQL\DATA\Accountancy_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Accountancy].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Accountancy] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Accountancy] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Accountancy] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Accountancy] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Accountancy] SET ARITHABORT OFF 
GO
ALTER DATABASE [Accountancy] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Accountancy] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Accountancy] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Accountancy] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Accountancy] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Accountancy] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Accountancy] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Accountancy] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Accountancy] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Accountancy] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Accountancy] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Accountancy] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Accountancy] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Accountancy] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Accountancy] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Accountancy] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Accountancy] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Accountancy] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Accountancy] SET  MULTI_USER 
GO
ALTER DATABASE [Accountancy] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Accountancy] SET DB_CHAINING OFF 
GO
/****** Object:  Table [dbo].[FinancialElementType]    Script Date: 10-Jun-22 7:28:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FinancialElementType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_FinancialElementType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GeneralJournalEntries]    Script Date: 10-Jun-22 7:28:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeneralJournalEntries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
 CONSTRAINT [PK_GeneralJournal] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JournalEntries]    Script Date: 10-Jun-22 7:28:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JournalEntries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[JournalId] [int] NOT NULL,
	[ElementTypeId] [int] NOT NULL,
	[TransactionTypeId] [int] NOT NULL,
	[Amount] [int] NOT NULL,
 CONSTRAINT [PK_JournalEntries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactiontype]    Script Date: 10-Jun-22 7:28:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactiontype](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Transactiontype] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 10-Jun-22 7:28:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[LoginId] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[ImageURL] [varchar](50) NULL,
	[RegisteredOn] [datetime] NOT NULL,
	[IsVerified] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[FinancialElementType] ON 

INSERT [dbo].[FinancialElementType] ([Id], [TypeName]) VALUES (1, N'Asset')
INSERT [dbo].[FinancialElementType] ([Id], [TypeName]) VALUES (2, N'Expense')
INSERT [dbo].[FinancialElementType] ([Id], [TypeName]) VALUES (3, N'Liability')
INSERT [dbo].[FinancialElementType] ([Id], [TypeName]) VALUES (4, N'Revenue')
INSERT [dbo].[FinancialElementType] ([Id], [TypeName]) VALUES (5, N'Capital')
SET IDENTITY_INSERT [dbo].[FinancialElementType] OFF
GO
SET IDENTITY_INSERT [dbo].[GeneralJournalEntries] ON 

INSERT [dbo].[GeneralJournalEntries] ([Id], [UserId], [TransactionDate]) VALUES (1, 1, CAST(N'2022-06-10T07:14:26.023' AS DateTime))
SET IDENTITY_INSERT [dbo].[GeneralJournalEntries] OFF
GO
SET IDENTITY_INSERT [dbo].[JournalEntries] ON 

INSERT [dbo].[JournalEntries] ([Id], [JournalId], [ElementTypeId], [TransactionTypeId], [Amount]) VALUES (1, 1, 1, 1, 1000)
INSERT [dbo].[JournalEntries] ([Id], [JournalId], [ElementTypeId], [TransactionTypeId], [Amount]) VALUES (2, 1, 2, 1, 500)
INSERT [dbo].[JournalEntries] ([Id], [JournalId], [ElementTypeId], [TransactionTypeId], [Amount]) VALUES (3, 1, 3, 2, 1000)
INSERT [dbo].[JournalEntries] ([Id], [JournalId], [ElementTypeId], [TransactionTypeId], [Amount]) VALUES (4, 1, 4, 2, 250)
INSERT [dbo].[JournalEntries] ([Id], [JournalId], [ElementTypeId], [TransactionTypeId], [Amount]) VALUES (5, 1, 5, 2, 250)
SET IDENTITY_INSERT [dbo].[JournalEntries] OFF
GO
SET IDENTITY_INSERT [dbo].[Transactiontype] ON 

INSERT [dbo].[Transactiontype] ([Id], [TypeName]) VALUES (1, N'Debit')
INSERT [dbo].[Transactiontype] ([Id], [TypeName]) VALUES (2, N'Credit')
SET IDENTITY_INSERT [dbo].[Transactiontype] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [UserName], [Email], [LoginId], [Password], [ImageURL], [RegisteredOn], [IsVerified]) VALUES (1, N'HBL', N'hbl@hbl.com', N'hbl-123', N'123', N'1-Jaun.jpg', CAST(N'2022-06-10T04:04:27.687' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[GeneralJournalEntries]  WITH CHECK ADD  CONSTRAINT [FK_GeneralJournal_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[GeneralJournalEntries] CHECK CONSTRAINT [FK_GeneralJournal_Users]
GO
ALTER TABLE [dbo].[JournalEntries]  WITH CHECK ADD  CONSTRAINT [FK_JournalEntries_FinancialElementType] FOREIGN KEY([ElementTypeId])
REFERENCES [dbo].[FinancialElementType] ([Id])
GO
ALTER TABLE [dbo].[JournalEntries] CHECK CONSTRAINT [FK_JournalEntries_FinancialElementType]
GO
ALTER TABLE [dbo].[JournalEntries]  WITH CHECK ADD  CONSTRAINT [FK_JournalEntries_GeneralJournal] FOREIGN KEY([JournalId])
REFERENCES [dbo].[GeneralJournalEntries] ([Id])
GO
ALTER TABLE [dbo].[JournalEntries] CHECK CONSTRAINT [FK_JournalEntries_GeneralJournal]
GO
ALTER TABLE [dbo].[JournalEntries]  WITH CHECK ADD  CONSTRAINT [FK_JournalEntries_Transactiontype] FOREIGN KEY([TransactionTypeId])
REFERENCES [dbo].[Transactiontype] ([Id])
GO
ALTER TABLE [dbo].[JournalEntries] CHECK CONSTRAINT [FK_JournalEntries_Transactiontype]
GO
ALTER DATABASE [Accountancy] SET  READ_WRITE 
GO
