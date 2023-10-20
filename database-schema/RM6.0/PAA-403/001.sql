/****** Object:  Table [dbo].[credit_report]    Script Date: 8/21/2017 11:11:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[credit_report](
	[report_id] [varchar](36) NOT NULL,
	[application_id] [varchar](36) NOT NULL,
	[type] [varchar](20) NOT NULL,
	[data_blob] [nvarchar](max) NOT NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
	[end_user] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_credit_report] PRIMARY KEY CLUSTERED 
(
	[report_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[credit_report] ADD  CONSTRAINT [DF_credit_report_type]  DEFAULT ('Microbilt') FOR [type]
GO

ALTER TABLE [dbo].[credit_report] ADD  CONSTRAINT [DF_credit_report_data_blob]  DEFAULT ('') FOR [data_blob]
GO

ALTER TABLE [dbo].[credit_report] ADD  DEFAULT ('') FOR [end_user]
GO

ALTER TABLE [dbo].[credit_report]  WITH CHECK ADD  CONSTRAINT [FK_credit_report_application] FOREIGN KEY([application_id])
REFERENCES [dbo].[application] ([application_id])
GO

ALTER TABLE [dbo].[credit_report] CHECK CONSTRAINT [FK_credit_report_application]
GO
