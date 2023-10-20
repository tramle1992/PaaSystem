IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_application_company]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[application] DROP CONSTRAINT [DF_application_company]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_application_phone]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[application] DROP CONSTRAINT [DF_application_phone]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_application_reg_agent]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[application] DROP CONSTRAINT [DF_application_reg_agent]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_application_date_active]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[application] DROP CONSTRAINT [DF_application_date_active]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_application_state_active]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[application] DROP CONSTRAINT [DF_application_state_active]
END
GO
ALTER TABLE [dbo].[application] ADD [company] [nvarchar](255) NOT NULL CONSTRAINT [DF_application_company]  DEFAULT ('')
GO
ALTER TABLE [dbo].[application] ADD [phone] [nvarchar](255) NOT NULL CONSTRAINT [DF_application_phone]  DEFAULT ('')
GO
ALTER TABLE [dbo].[application] ADD [reg_agent] [nvarchar](255) NOT NULL CONSTRAINT [DF_application_reg_agent]  DEFAULT ('')
GO
ALTER TABLE [dbo].[application] ADD [date_active] [nvarchar](255) NOT NULL CONSTRAINT [DF_application_date_active]  DEFAULT ('')
GO
ALTER TABLE [dbo].[application] ADD [state_active] [nvarchar](255) NOT NULL CONSTRAINT [DF_application_state_active]  DEFAULT ('')
GO

