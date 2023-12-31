IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_payment_invoice]') AND parent_object_id = OBJECT_ID(N'[dbo].[payment]'))
ALTER TABLE [dbo].[payment] DROP CONSTRAINT [FK_payment_invoice]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_invoice_item_invoice]') AND parent_object_id = OBJECT_ID(N'[dbo].[invoice_item]'))
ALTER TABLE [dbo].[invoice_item] DROP CONSTRAINT [FK_invoice_item_invoice]
GO
/****** Object:  Table [dbo].[payment]    Script Date: 1/16/2016 1:59:12 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[payment]') AND type in (N'U'))
DROP TABLE [dbo].[payment]
GO
/****** Object:  Table [dbo].[invoice_item]    Script Date: 1/16/2016 1:59:12 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[invoice_item]') AND type in (N'U'))
DROP TABLE [dbo].[invoice_item]
GO
/****** Object:  Table [dbo].[invoice]    Script Date: 1/16/2016 1:59:12 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[invoice]') AND type in (N'U'))
DROP TABLE [dbo].[invoice]
GO
/****** Object:  Table [dbo].[invoice]    Script Date: 1/16/2016 1:59:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[invoice]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[invoice](
	[invoice_id] [varchar](36) NOT NULL,
	[client_name] [nvarchar](255) NULL,
	[sold_to_client_name] [nvarchar](255) NULL,
	[address] [nvarchar](255) NULL,
	[invoice_reference] [nvarchar](255) NULL,
	[customer_number] [nvarchar](10) NOT NULL,
	[invoice_comments] [text] NULL,
	[invoice_number] [int] NOT NULL,
	[invoice_date] [datetime] NOT NULL,
	[note_to_client] [nvarchar](255) NULL,
	[po_number] [nvarchar](255) NULL,
	[invoice_division] [nvarchar](255) NULL,
	[status] [tinyint] NOT NULL,
	[amount] [decimal](18, 2) NOT NULL,
	[balance] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_invoice] PRIMARY KEY CLUSTERED 
(
	[invoice_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[invoice_item]    Script Date: 1/16/2016 1:59:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[invoice_item]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[invoice_item](
	[invoice_item_id] [varchar](36) NOT NULL,
	[invoice_id] [varchar](36) NOT NULL,
	[application_id] [varchar](36) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[description] [nvarchar](600) NULL,
	[unit_price] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_invoice_item] PRIMARY KEY CLUSTERED 
(
	[invoice_item_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[payment]    Script Date: 1/16/2016 1:59:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[payment]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[payment](
	[payment_id] [varchar](36) NOT NULL,
	[invoice_id] [varchar](36) NOT NULL,
	[amount] [decimal](18, 2) NOT NULL,
	[date] [datetime] NOT NULL,
	[check] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_payment] PRIMARY KEY CLUSTERED 
(
	[payment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_invoice_item_invoice]') AND parent_object_id = OBJECT_ID(N'[dbo].[invoice_item]'))
ALTER TABLE [dbo].[invoice_item]  WITH CHECK ADD  CONSTRAINT [FK_invoice_item_invoice] FOREIGN KEY([invoice_id])
REFERENCES [dbo].[invoice] ([invoice_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_invoice_item_invoice]') AND parent_object_id = OBJECT_ID(N'[dbo].[invoice_item]'))
ALTER TABLE [dbo].[invoice_item] CHECK CONSTRAINT [FK_invoice_item_invoice]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_payment_invoice]') AND parent_object_id = OBJECT_ID(N'[dbo].[payment]'))
ALTER TABLE [dbo].[payment]  WITH CHECK ADD  CONSTRAINT [FK_payment_invoice] FOREIGN KEY([invoice_id])
REFERENCES [dbo].[invoice] ([invoice_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_payment_invoice]') AND parent_object_id = OBJECT_ID(N'[dbo].[payment]'))
ALTER TABLE [dbo].[payment] CHECK CONSTRAINT [FK_payment_invoice]
GO
