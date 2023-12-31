/****** Object:  Table [dbo].[system_configuration]    Script Date: 1/23/2016 12:16:48 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[system_configuration]') AND type in (N'U'))
DROP TABLE [dbo].[system_configuration]
GO
/****** Object:  Table [dbo].[system_configuration]    Script Date: 1/23/2016 12:16:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[system_configuration]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[system_configuration](
	[config_id] [varchar](36) NOT NULL,
	[backup_location] [varchar](500) NOT NULL,
	[backup_time] [time](0) NOT NULL,
	[backup_enabled] [bit] NOT NULL,
	[working_hour_from] [time](0) NOT NULL,
	[working_hour_to] [time](0) NOT NULL,
	[number_apps_bonus] [smallint] NOT NULL,
	[billing_email_confirmation] [varchar](100) NOT NULL,
	[ftp_uri] [varchar](100) NOT NULL,
	[ftp_username] [varchar](100) NOT NULL,
	[ftp_password] [varchar](100) NOT NULL,
	[auto_save_time_interval] [int] NOT NULL,
 CONSTRAINT [PK_system_configuration] PRIMARY KEY CLUSTERED 
(
	[config_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[system_configuration] ([config_id], [backup_location], [backup_time], [backup_enabled], [working_hour_from], [working_hour_to], [number_apps_bonus], [billing_email_confirmation], [ftp_uri], [ftp_username], [ftp_password], [auto_save_time_interval]) VALUES (N'0', N'E:\PAA-Prj\GIT', CAST(N'22:00:00' AS Time), 1, CAST(N'08:00:00' AS Time), CAST(N'16:00:00' AS Time), 21, N'bill@bemrose.com', N'ftp://127.0.0.1', N'jadele', N'123456', 60)
