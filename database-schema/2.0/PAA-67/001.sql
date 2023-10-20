/****** Object:  Table [dbo].[application]    Script Date: 09/05/2015 09:54:03 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_application_last_name]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[application] DROP CONSTRAINT [DF_application_last_name]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_application_first_name]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[application] DROP CONSTRAINT [DF_application_first_name]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_application_middle_name]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[application] DROP CONSTRAINT [DF_application_middle_name]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_application_app_ssn]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[application] DROP CONSTRAINT [DF_application_app_ssn]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_application_house_number]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[application] DROP CONSTRAINT [DF_application_house_number]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_application_street_address]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[application] DROP CONSTRAINT [DF_application_street_address]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_application_city]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[application] DROP CONSTRAINT [DF_application_city]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_application_state]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[application] DROP CONSTRAINT [DF_application_state]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_application_postal_code]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[application] DROP CONSTRAINT [DF_application_postal_code]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_application_report_community]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[application] DROP CONSTRAINT [DF_application_report_community]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_application_report_management]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[application] DROP CONSTRAINT [DF_application_report_management]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_application_unit_number]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[application] DROP CONSTRAINT [DF_application_unit_number]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_application_rent_amount]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[application] DROP CONSTRAINT [DF_application_rent_amount]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_application_movein_date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[application] DROP CONSTRAINT [DF_application_movein_date]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_application_report_special_field]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[application] DROP CONSTRAINT [DF_application_report_special_field]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_application_page_received]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[application] DROP CONSTRAINT [DF_application_page_received]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_application_location_name]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[application] DROP CONSTRAINT [DF_application_location_name]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_application_screener_name]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[application] DROP CONSTRAINT [DF_application_screener_name]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_application_position_applied]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[application] DROP CONSTRAINT [DF_application_position_applied]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_application_company_applied]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[application] DROP CONSTRAINT [DF_application_company_applied]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_application_credit_info]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[application] DROP CONSTRAINT [DF_application_credit_info]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_application_credit_refs]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[application] DROP CONSTRAINT [DF_application_credit_refs]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_application_emp_ver]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[application] DROP CONSTRAINT [DF_application_emp_ver]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_application_emp_refs]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[application] DROP CONSTRAINT [DF_application_emp_refs]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_application_rental_refs]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[application] DROP CONSTRAINT [DF_application_rental_refs]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_application_charges]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[application] DROP CONSTRAINT [DF_application_charges]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_application_evictions]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[application] DROP CONSTRAINT [DF_application_evictions]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_application_staff_comments]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[application] DROP CONSTRAINT [DF_application_staff_comments]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_application_final_comments]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[application] DROP CONSTRAINT [DF_application_final_comments]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_application_recommendation]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[application] DROP CONSTRAINT [DF_application_recommendation]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_application_priority_1]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[application] DROP CONSTRAINT [DF_application_priority_1]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_application_contact_attempt]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[application] DROP CONSTRAINT [DF_application_contact_attempt]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_application_invoice_division]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[application] DROP CONSTRAINT [DF_application_invoice_division]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_application_credit_pulled]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[application] DROP CONSTRAINT [DF_application_credit_pulled]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[application]') AND type in (N'U'))
DROP TABLE [dbo].[application]
GO
/****** Object:  Table [dbo].[application]    Script Date: 09/05/2015 09:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[application]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[application](
	[application_id] [varchar](36) NOT NULL,
	[last_name] [nvarchar](255) NOT NULL CONSTRAINT [DF_application_last_name]  DEFAULT (''),
	[first_name] [nvarchar](255) NOT NULL CONSTRAINT [DF_application_first_name]  DEFAULT (''),
	[middle_name] [nvarchar](255) NOT NULL CONSTRAINT [DF_application_middle_name]  DEFAULT (''),
	[app_ssn] [nvarchar](50) NOT NULL CONSTRAINT [DF_application_app_ssn]  DEFAULT (''),
	[birth_date] [datetime] NULL,
	[house_number] [nvarchar](255) NOT NULL CONSTRAINT [DF_application_house_number]  DEFAULT (''),
	[street_address] [nvarchar](255) NOT NULL CONSTRAINT [DF_application_street_address]  DEFAULT (''),
	[city] [nvarchar](100) NOT NULL CONSTRAINT [DF_application_city]  DEFAULT (''),
	[state] [nvarchar](100) NOT NULL CONSTRAINT [DF_application_state]  DEFAULT (''),
	[postal_code] [nvarchar](100) NOT NULL CONSTRAINT [DF_application_postal_code]  DEFAULT (''),
	[client_id] [varchar](36) NULL,
	[report_type_id] [varchar](36) NULL,
	[report_community] [nvarchar](255) NOT NULL CONSTRAINT [DF_application_report_community]  DEFAULT (''),
	[report_management] [nvarchar](255) NOT NULL CONSTRAINT [DF_application_report_management]  DEFAULT (''),
	[unit_number] [nvarchar](100) NOT NULL CONSTRAINT [DF_application_unit_number]  DEFAULT (''),
	[rent_amount] [nvarchar](100) NOT NULL CONSTRAINT [DF_application_rent_amount]  DEFAULT (''),
	[movein_date] [nvarchar](100) NOT NULL CONSTRAINT [DF_application_movein_date]  DEFAULT (''),
	[report_special_field] [nvarchar](255) NOT NULL CONSTRAINT [DF_application_report_special_field]  DEFAULT (''),
	[page_received] [int] NOT NULL CONSTRAINT [DF_application_page_received]  DEFAULT ((1)),
	[location_id] [varchar](36) NOT NULL,
	[location_name] [nvarchar](255) NOT NULL CONSTRAINT [DF_application_location_name]  DEFAULT (''),
	[received_date] [datetime] NOT NULL,
	[completed_date] [datetime] NULL,
	[screener_id] [varchar](36) NOT NULL,
	[screener_name] [nvarchar](255) NOT NULL CONSTRAINT [DF_application_screener_name]  DEFAULT (''),
	[position_applied] [nvarchar](255) NOT NULL CONSTRAINT [DF_application_position_applied]  DEFAULT (''),
	[company_applied] [nvarchar](255) NOT NULL CONSTRAINT [DF_application_company_applied]  DEFAULT (''),
	[credit_info] [text] NOT NULL CONSTRAINT [DF_application_credit_info]  DEFAULT (''),
	[credit_refs] [text] NOT NULL CONSTRAINT [DF_application_credit_refs]  DEFAULT (''),
	[emp_ver] [text] NOT NULL CONSTRAINT [DF_application_emp_ver]  DEFAULT (''),
	[emp_refs] [text] NOT NULL CONSTRAINT [DF_application_emp_refs]  DEFAULT (''),
	[rental_refs] [text] NOT NULL CONSTRAINT [DF_application_rental_refs]  DEFAULT (''),
	[charges] [text] NOT NULL CONSTRAINT [DF_application_charges]  DEFAULT (''),
	[evictions] [text] NOT NULL CONSTRAINT [DF_application_evictions]  DEFAULT (''),
	[staff_comments] [text] NOT NULL CONSTRAINT [DF_application_staff_comments]  DEFAULT (''),
	[final_comments] [text] NOT NULL CONSTRAINT [DF_application_final_comments]  DEFAULT (''),
	[recommendation] [text] NOT NULL CONSTRAINT [DF_application_recommendation]  DEFAULT (''),
	[priority] [int] NOT NULL CONSTRAINT [DF_application_priority_1]  DEFAULT ((0)),
	[contact_attempt] [text] NOT NULL CONSTRAINT [DF_application_contact_attempt]  DEFAULT (''),
	[invoice_division] [nvarchar](255) NOT NULL CONSTRAINT [DF_application_invoice_division]  DEFAULT (''),
	[credit_pulled] [nvarchar](255) NOT NULL CONSTRAINT [DF_application_credit_pulled]  DEFAULT (''),
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
 CONSTRAINT [PK_application] PRIMARY KEY CLUSTERED 
(
	[application_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[application]') AND name = N'IX_client')
CREATE NONCLUSTERED INDEX [IX_client] ON [dbo].[application] 
(
	[client_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[application]') AND name = N'IX_first_name')
CREATE NONCLUSTERED INDEX [IX_first_name] ON [dbo].[application] 
(
	[first_name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[application]') AND name = N'IX_location')
CREATE NONCLUSTERED INDEX [IX_location] ON [dbo].[application] 
(
	[location_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[application]') AND name = N'IX_screener')
CREATE NONCLUSTERED INDEX [IX_screener] ON [dbo].[application] 
(
	[screener_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

