IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_application_bank_comm]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[application] DROP CONSTRAINT [DF_application_bank_comm]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_application_opened_comm]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[application] DROP CONSTRAINT [DF_application_opened_comm]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_application_balance_comm]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[application] DROP CONSTRAINT [DF_application_balance_comm]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_application_acct_comm]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[application] DROP CONSTRAINT [DF_application_acct_comm]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_application_nsfod_comm]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[application] DROP CONSTRAINT [DF_application_nsfod_comm]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_application_sw_comm]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[application] DROP CONSTRAINT [DF_application_sw_comm]
END
GO
ALTER TABLE [dbo].[application] ADD [bank_comm] [nvarchar](255) NOT NULL CONSTRAINT [DF_application_bank_comm]  DEFAULT ('')
GO
ALTER TABLE [dbo].[application] ADD [opened_comm] [nvarchar](255) NOT NULL CONSTRAINT [DF_application_opened_comm]  DEFAULT ('')
GO
ALTER TABLE [dbo].[application] ADD [balance_comm] [nvarchar](255) NOT NULL CONSTRAINT [DF_application_balance_comm]  DEFAULT ('')
GO
ALTER TABLE [dbo].[application] ADD [acct_comm] [nvarchar](255) NOT NULL CONSTRAINT [DF_application_acct_comm]  DEFAULT ('')
GO
ALTER TABLE [dbo].[application] ADD [nsfod_comm] [nvarchar](255) NOT NULL CONSTRAINT [DF_application_nsfod_comm]  DEFAULT ('')
GO
ALTER TABLE [dbo].[application] ADD [sw_comm] [nvarchar](255) NOT NULL CONSTRAINT [DF_application_sw_comm]  DEFAULT ('')
GO

