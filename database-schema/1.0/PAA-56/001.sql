IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_resource_resource_type]') AND parent_object_id = OBJECT_ID(N'[dbo].[resource]'))
ALTER TABLE [dbo].[resource] DROP CONSTRAINT [FK_resource_resource_type]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_client_management_company]') AND parent_object_id = OBJECT_ID(N'[dbo].[client]'))
ALTER TABLE [dbo].[client] DROP CONSTRAINT [FK_client_management_company]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_resource_comment]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[resource] DROP CONSTRAINT [DF_resource_comment]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_resource_target]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[resource] DROP CONSTRAINT [DF_resource_target]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_report_type_default_price]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[report_type] DROP CONSTRAINT [DF_report_type_default_price]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_report_type_absolute_type_name]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[report_type] DROP CONSTRAINT [DF_report_type_absolute_type_name]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_report_type_type_name]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[report_type] DROP CONSTRAINT [DF_report_type_type_name]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_management_company_name]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[management_company] DROP CONSTRAINT [DF_management_company_name]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__client__customer__7C4F7684]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[client] DROP CONSTRAINT [DF__client__customer__7C4F7684]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_client_summaries]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[client] DROP CONSTRAINT [DF_client_summaries]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_client_web_pass]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[client] DROP CONSTRAINT [DF_client_web_pass]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_client_website_dir]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[client] DROP CONSTRAINT [DF_client_website_dir]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_client_special_criteria_info]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[client] DROP CONSTRAINT [DF_client_special_criteria_info]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_client_special_entry_info]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[client] DROP CONSTRAINT [DF_client_special_entry_info]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_client_default_verify_confirm_delivery]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[client] DROP CONSTRAINT [DF_client_default_verify_confirm_delivery]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_client_default_deliver_invoices_to]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[client] DROP CONSTRAINT [DF_client_default_deliver_invoices_to]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_client_default_deliver_confirmation_to]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[client] DROP CONSTRAINT [DF_client_default_deliver_confirmation_to]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_client_default_deliver_reports_to]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[client] DROP CONSTRAINT [DF_client_default_deliver_reports_to]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_client_credentialed]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[client] DROP CONSTRAINT [DF_client_credentialed]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_client_invoices_copies_number]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[client] DROP CONSTRAINT [DF_client_invoices_copies_number]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_client_confidentiality_cover]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[client] DROP CONSTRAINT [DF_client_confidentiality_cover]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_client_declination_letter]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[client] DROP CONSTRAINT [DF_client_declination_letter]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_client_client_revoked]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[client] DROP CONSTRAINT [DF_client_client_revoked]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_client_misc_comments]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[client] DROP CONSTRAINT [DF_client_misc_comments]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_client_billing_info]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[client] DROP CONSTRAINT [DF_client_billing_info]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_client_email]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[client] DROP CONSTRAINT [DF_client_email]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_client_fax]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[client] DROP CONSTRAINT [DF_client_fax]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_client_phone]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[client] DROP CONSTRAINT [DF_client_phone]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_client_other_addresses]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[client] DROP CONSTRAINT [DF_client_other_addresses]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_client_billing_address]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[client] DROP CONSTRAINT [DF_client_billing_address]
END

GO
/****** Object:  Table [dbo].[resource_type]    Script Date: 1/16/2016 2:28:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[resource_type]') AND type in (N'U'))
DROP TABLE [dbo].[resource_type]
GO
/****** Object:  Table [dbo].[resource]    Script Date: 1/16/2016 2:28:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[resource]') AND type in (N'U'))
DROP TABLE [dbo].[resource]
GO
/****** Object:  Table [dbo].[report_type]    Script Date: 1/16/2016 2:28:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[report_type]') AND type in (N'U'))
DROP TABLE [dbo].[report_type]
GO
/****** Object:  Table [dbo].[management_company]    Script Date: 1/16/2016 2:28:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[management_company]') AND type in (N'U'))
DROP TABLE [dbo].[management_company]
GO
/****** Object:  Table [dbo].[customer_number_setting]    Script Date: 1/16/2016 2:28:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[customer_number_setting]') AND type in (N'U'))
DROP TABLE [dbo].[customer_number_setting]
GO
/****** Object:  Table [dbo].[client]    Script Date: 1/16/2016 2:28:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[client]') AND type in (N'U'))
DROP TABLE [dbo].[client]
GO
/****** Object:  Table [dbo].[client]    Script Date: 1/16/2016 2:28:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[client]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[client](
	[client_id] [varchar](36) NOT NULL,
	[client_name] [nvarchar](255) NOT NULL,
	[billing_address] [nvarchar](255) NOT NULL,
	[other_addresses] [nvarchar](max) NULL,
	[phone] [nvarchar](255) NOT NULL,
	[fax] [nvarchar](255) NOT NULL,
	[email] [nvarchar](255) NOT NULL,
	[since] [datetime] NULL,
	[billing_info] [nvarchar](255) NOT NULL,
	[misc_comments] [nvarchar](255) NOT NULL,
	[contacts] [nvarchar](max) NULL,
	[management_company_id] [varchar](36) NULL,
	[invoice_divisions] [nvarchar](max) NULL,
	[client_revoked] [bit] NOT NULL,
	[invoice_lines] [nvarchar](max) NULL,
	[declination_letter] [bit] NOT NULL,
	[confidentiality_cover] [bit] NOT NULL,
	[invoices_copies_number] [int] NOT NULL,
	[credentialed] [bit] NOT NULL,
	[credit_type] [int] NULL,
	[default_deliver_reports_to] [nvarchar](255) NOT NULL,
	[default_deliver_confirmation_to] [nvarchar](255) NOT NULL,
	[default_deliver_invoices_to] [nvarchar](255) NOT NULL,
	[default_verify_confirm_delivery] [bit] NOT NULL,
	[special_entry_info] [nvarchar](max) NOT NULL,
	[special_criteria_info] [nvarchar](max) NOT NULL,
	[website_dir] [nvarchar](255) NOT NULL,
	[web_pass] [nvarchar](255) NOT NULL,
	[summaries] [bit] NOT NULL,
	[client_report_special_price] [nvarchar](max) NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
	[customer_number] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_client] PRIMARY KEY CLUSTERED 
(
	[client_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[customer_number_setting]    Script Date: 1/16/2016 2:28:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[customer_number_setting]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[customer_number_setting](
	[letter] [char](1) NOT NULL,
	[last_number] [int] NOT NULL,
 CONSTRAINT [PK_customer_number_settings] PRIMARY KEY CLUSTERED 
(
	[letter] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[management_company]    Script Date: 1/16/2016 2:28:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[management_company]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[management_company](
	[management_company_id] [varchar](36) NOT NULL,
	[name] [nvarchar](250) NOT NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
 CONSTRAINT [PK_management_company] PRIMARY KEY CLUSTERED 
(
	[management_company_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[report_type]    Script Date: 1/16/2016 2:28:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[report_type]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[report_type](
	[report_type_id] [varchar](36) NOT NULL,
	[type_name] [nvarchar](50) NOT NULL,
	[absolute_type_name] [nvarchar](50) NOT NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
	[default_price] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_report_type] PRIMARY KEY CLUSTERED 
(
	[report_type_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[resource]    Script Date: 1/16/2016 2:28:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[resource]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[resource](
	[resource_id] [varchar](36) NOT NULL,
	[resource_type_id] [varchar](36) NOT NULL,
	[name] [nvarchar](250) NOT NULL,
	[target] [nvarchar](250) NOT NULL,
	[comment] [text] NOT NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
 CONSTRAINT [PK_resource] PRIMARY KEY CLUSTERED 
(
	[resource_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[resource_type]    Script Date: 1/16/2016 2:28:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[resource_type]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[resource_type](
	[resource_type_id] [varchar](36) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
 CONSTRAINT [PK_resource_type] PRIMARY KEY CLUSTERED 
(
	[resource_type_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_client_billing_address]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[client] ADD  CONSTRAINT [DF_client_billing_address]  DEFAULT ('') FOR [billing_address]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_client_other_addresses]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[client] ADD  CONSTRAINT [DF_client_other_addresses]  DEFAULT ('') FOR [other_addresses]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_client_phone]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[client] ADD  CONSTRAINT [DF_client_phone]  DEFAULT ('') FOR [phone]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_client_fax]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[client] ADD  CONSTRAINT [DF_client_fax]  DEFAULT ('') FOR [fax]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_client_email]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[client] ADD  CONSTRAINT [DF_client_email]  DEFAULT ('') FOR [email]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_client_billing_info]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[client] ADD  CONSTRAINT [DF_client_billing_info]  DEFAULT ('') FOR [billing_info]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_client_misc_comments]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[client] ADD  CONSTRAINT [DF_client_misc_comments]  DEFAULT ('') FOR [misc_comments]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_client_client_revoked]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[client] ADD  CONSTRAINT [DF_client_client_revoked]  DEFAULT ((0)) FOR [client_revoked]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_client_declination_letter]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[client] ADD  CONSTRAINT [DF_client_declination_letter]  DEFAULT ((0)) FOR [declination_letter]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_client_confidentiality_cover]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[client] ADD  CONSTRAINT [DF_client_confidentiality_cover]  DEFAULT ((0)) FOR [confidentiality_cover]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_client_invoices_copies_number]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[client] ADD  CONSTRAINT [DF_client_invoices_copies_number]  DEFAULT ((0)) FOR [invoices_copies_number]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_client_credentialed]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[client] ADD  CONSTRAINT [DF_client_credentialed]  DEFAULT ((0)) FOR [credentialed]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_client_default_deliver_reports_to]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[client] ADD  CONSTRAINT [DF_client_default_deliver_reports_to]  DEFAULT ('') FOR [default_deliver_reports_to]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_client_default_deliver_confirmation_to]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[client] ADD  CONSTRAINT [DF_client_default_deliver_confirmation_to]  DEFAULT ('') FOR [default_deliver_confirmation_to]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_client_default_deliver_invoices_to]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[client] ADD  CONSTRAINT [DF_client_default_deliver_invoices_to]  DEFAULT ('') FOR [default_deliver_invoices_to]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_client_default_verify_confirm_delivery]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[client] ADD  CONSTRAINT [DF_client_default_verify_confirm_delivery]  DEFAULT ((0)) FOR [default_verify_confirm_delivery]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_client_special_entry_info]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[client] ADD  CONSTRAINT [DF_client_special_entry_info]  DEFAULT ('') FOR [special_entry_info]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_client_special_criteria_info]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[client] ADD  CONSTRAINT [DF_client_special_criteria_info]  DEFAULT ('') FOR [special_criteria_info]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_client_website_dir]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[client] ADD  CONSTRAINT [DF_client_website_dir]  DEFAULT ('') FOR [website_dir]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_client_web_pass]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[client] ADD  CONSTRAINT [DF_client_web_pass]  DEFAULT ('') FOR [web_pass]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_client_summaries]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[client] ADD  CONSTRAINT [DF_client_summaries]  DEFAULT ((0)) FOR [summaries]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__client__customer__7C4F7684]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[client] ADD  DEFAULT ('') FOR [customer_number]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_management_company_name]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[management_company] ADD  CONSTRAINT [DF_management_company_name]  DEFAULT ('') FOR [name]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_report_type_type_name]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[report_type] ADD  CONSTRAINT [DF_report_type_type_name]  DEFAULT ('') FOR [type_name]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_report_type_absolute_type_name]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[report_type] ADD  CONSTRAINT [DF_report_type_absolute_type_name]  DEFAULT ('') FOR [absolute_type_name]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_report_type_default_price]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[report_type] ADD  CONSTRAINT [DF_report_type_default_price]  DEFAULT ((0)) FOR [default_price]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_resource_target]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[resource] ADD  CONSTRAINT [DF_resource_target]  DEFAULT ('') FOR [target]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_resource_comment]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[resource] ADD  CONSTRAINT [DF_resource_comment]  DEFAULT ('') FOR [comment]
END

GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_client_management_company]') AND parent_object_id = OBJECT_ID(N'[dbo].[client]'))
ALTER TABLE [dbo].[client]  WITH CHECK ADD  CONSTRAINT [FK_client_management_company] FOREIGN KEY([management_company_id])
REFERENCES [dbo].[management_company] ([management_company_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_client_management_company]') AND parent_object_id = OBJECT_ID(N'[dbo].[client]'))
ALTER TABLE [dbo].[client] CHECK CONSTRAINT [FK_client_management_company]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_resource_resource_type]') AND parent_object_id = OBJECT_ID(N'[dbo].[resource]'))
ALTER TABLE [dbo].[resource]  WITH CHECK ADD  CONSTRAINT [FK_resource_resource_type] FOREIGN KEY([resource_type_id])
REFERENCES [dbo].[resource_type] ([resource_type_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_resource_resource_type]') AND parent_object_id = OBJECT_ID(N'[dbo].[resource]'))
ALTER TABLE [dbo].[resource] CHECK CONSTRAINT [FK_resource_resource_type]
GO
