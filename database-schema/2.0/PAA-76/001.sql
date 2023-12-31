/****** Object:  ForeignKey [FK_role_feature_permission_feature_permission]    Script Date: 09/03/2015 21:55:24 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_role_feature_permission_feature_permission]') AND parent_object_id = OBJECT_ID(N'[dbo].[role_feature_permission]'))
ALTER TABLE [dbo].[role_feature_permission] DROP CONSTRAINT [FK_role_feature_permission_feature_permission]
GO
/****** Object:  ForeignKey [FK_role_feature_permission_role]    Script Date: 09/03/2015 21:55:24 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_role_feature_permission_role]') AND parent_object_id = OBJECT_ID(N'[dbo].[role_feature_permission]'))
ALTER TABLE [dbo].[role_feature_permission] DROP CONSTRAINT [FK_role_feature_permission_role]
GO
/****** Object:  ForeignKey [FK_user_role]    Script Date: 09/03/2015 21:55:24 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_user_role]') AND parent_object_id = OBJECT_ID(N'[dbo].[user]'))
ALTER TABLE [dbo].[user] DROP CONSTRAINT [FK_user_role]
GO
/****** Object:  Table [dbo].[role_feature_permission]    Script Date: 09/03/2015 21:55:24 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_role_feature_permission_feature_permission]') AND parent_object_id = OBJECT_ID(N'[dbo].[role_feature_permission]'))
ALTER TABLE [dbo].[role_feature_permission] DROP CONSTRAINT [FK_role_feature_permission_feature_permission]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_role_feature_permission_role]') AND parent_object_id = OBJECT_ID(N'[dbo].[role_feature_permission]'))
ALTER TABLE [dbo].[role_feature_permission] DROP CONSTRAINT [FK_role_feature_permission_role]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_role_feature_permission_is_allowed]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[role_feature_permission] DROP CONSTRAINT [DF_role_feature_permission_is_allowed]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[role_feature_permission]') AND type in (N'U'))
DROP TABLE [dbo].[role_feature_permission]
GO
/****** Object:  Table [dbo].[user]    Script Date: 09/03/2015 21:55:24 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_user_role]') AND parent_object_id = OBJECT_ID(N'[dbo].[user]'))
ALTER TABLE [dbo].[user] DROP CONSTRAINT [FK_user_role]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_user_password]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[user] DROP CONSTRAINT [DF_user_password]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_user_address]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[user] DROP CONSTRAINT [DF_user_address]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_user_email_address]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[user] DROP CONSTRAINT [DF_user_email_address]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[user]') AND type in (N'U'))
DROP TABLE [dbo].[user]
GO
/****** Object:  Table [dbo].[feature_permission]    Script Date: 09/03/2015 21:55:24 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[feature_permission]') AND type in (N'U'))
DROP TABLE [dbo].[feature_permission]
GO
/****** Object:  Table [dbo].[role]    Script Date: 09/03/2015 21:55:24 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_role_remark]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[role] DROP CONSTRAINT [DF_role_remark]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_role_create_by]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[role] DROP CONSTRAINT [DF_role_create_by]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[role]') AND type in (N'U'))
DROP TABLE [dbo].[role]
GO
/****** Object:  Table [dbo].[role]    Script Date: 09/03/2015 21:55:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[role]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[role](
	[role_id] [varchar](36) NOT NULL,
	[role_name] [nvarchar](255) NOT NULL,
	[remark] [text] NOT NULL CONSTRAINT [DF_role_remark]  DEFAULT (''),
	[create_by] [nvarchar](255) NOT NULL CONSTRAINT [DF_role_create_by]  DEFAULT (''),
 CONSTRAINT [PK_role] PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[role]') AND name = N'IX_role_name')
CREATE UNIQUE NONCLUSTERED INDEX [IX_role_name] ON [dbo].[role] 
(
	[role_name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[feature_permission]    Script Date: 09/03/2015 21:55:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[feature_permission]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[feature_permission](
	[feature_id] [varchar](36) NOT NULL,
	[feature_name] [nvarchar](255) NOT NULL,
	[parent_feature_id] [varchar](36) NULL,
 CONSTRAINT [PK_feature_permission] PRIMARY KEY CLUSTERED 
(
	[feature_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[user]    Script Date: 09/03/2015 21:55:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[user]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[user](
	[user_id] [varchar](36) NOT NULL,
	[role_id] [varchar](36) NOT NULL,
	[username] [nvarchar](255) NOT NULL,
	[password] [nvarchar](255) NOT NULL CONSTRAINT [DF_user_password]  DEFAULT (''),
	[address] [text] NOT NULL CONSTRAINT [DF_user_address]  DEFAULT (''),
	[email_address] [nvarchar](255) NOT NULL CONSTRAINT [DF_user_email_address]  DEFAULT (''),
	[other] [text] NOT NULL,
	[hired_date] [datetime] NOT NULL,
	[last_login] [datetime] NULL,
	[last_logout] [datetime] NULL,
	[status] [smallint] NOT NULL,
	[term_date] [datetime] NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[role_feature_permission]    Script Date: 09/03/2015 21:55:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[role_feature_permission]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[role_feature_permission](
	[role_id] [varchar](36) NOT NULL,
	[feature_id] [varchar](36) NOT NULL,
	[is_allowed] [bit] NOT NULL CONSTRAINT [DF_role_feature_permission_is_allowed]  DEFAULT ((0))
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_role_feature_permission_feature_permission]    Script Date: 09/03/2015 21:55:24 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_role_feature_permission_feature_permission]') AND parent_object_id = OBJECT_ID(N'[dbo].[role_feature_permission]'))
ALTER TABLE [dbo].[role_feature_permission]  WITH CHECK ADD  CONSTRAINT [FK_role_feature_permission_feature_permission] FOREIGN KEY([feature_id])
REFERENCES [dbo].[feature_permission] ([feature_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_role_feature_permission_feature_permission]') AND parent_object_id = OBJECT_ID(N'[dbo].[role_feature_permission]'))
ALTER TABLE [dbo].[role_feature_permission] CHECK CONSTRAINT [FK_role_feature_permission_feature_permission]
GO
/****** Object:  ForeignKey [FK_role_feature_permission_role]    Script Date: 09/03/2015 21:55:24 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_role_feature_permission_role]') AND parent_object_id = OBJECT_ID(N'[dbo].[role_feature_permission]'))
ALTER TABLE [dbo].[role_feature_permission]  WITH CHECK ADD  CONSTRAINT [FK_role_feature_permission_role] FOREIGN KEY([role_id])
REFERENCES [dbo].[role] ([role_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_role_feature_permission_role]') AND parent_object_id = OBJECT_ID(N'[dbo].[role_feature_permission]'))
ALTER TABLE [dbo].[role_feature_permission] CHECK CONSTRAINT [FK_role_feature_permission_role]
GO
/****** Object:  ForeignKey [FK_user_role]    Script Date: 09/03/2015 21:55:24 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_user_role]') AND parent_object_id = OBJECT_ID(N'[dbo].[user]'))
ALTER TABLE [dbo].[user]  WITH CHECK ADD  CONSTRAINT [FK_user_role] FOREIGN KEY([role_id])
REFERENCES [dbo].[role] ([role_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_user_role]') AND parent_object_id = OBJECT_ID(N'[dbo].[user]'))
ALTER TABLE [dbo].[user] CHECK CONSTRAINT [FK_user_role]
GO
