/****** Object:  Table [dbo].[timecard]    Script Date: 11/23/2015 6:32:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[timecard](
	[timecard_id] [varchar](36) NOT NULL,
	[timecard_date_id] [varchar](36) NOT NULL,
	[login_time] [datetime] NOT NULL,
	[logout_time] [datetime] NULL,
 CONSTRAINT [PK_timecard] PRIMARY KEY CLUSTERED 
(
	[timecard_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[timecard_date]    Script Date: 11/23/2015 6:32:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[timecard_date](
	[timecard_date_id] [varchar](36) NOT NULL,
	[user_id] [varchar](36) NOT NULL,
	[timecard_date] [datetime] NOT NULL,
	[bonus] [decimal](18, 2) NOT NULL,
	[first_login] [datetime] NOT NULL,
	[last_logout] [datetime] NULL,
	[timecard_type] [tinyint] NOT NULL,
 CONSTRAINT [PK_timecard_date] PRIMARY KEY CLUSTERED 
(
	[timecard_date_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[timecard]  WITH CHECK ADD  CONSTRAINT [FK_timecard_timecard_date] FOREIGN KEY([timecard_date_id])
REFERENCES [dbo].[timecard_date] ([timecard_date_id])
GO
ALTER TABLE [dbo].[timecard] CHECK CONSTRAINT [FK_timecard_timecard_date]
GO
ALTER TABLE [dbo].[timecard_date]  WITH CHECK ADD  CONSTRAINT [FK_timecard_date_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[user] ([user_id])
GO
ALTER TABLE [dbo].[timecard_date] CHECK CONSTRAINT [FK_timecard_date_user]
GO
