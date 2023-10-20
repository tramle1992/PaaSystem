IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_review_comment_areas]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[review_comment] DROP CONSTRAINT [DF_review_comment_areas]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_review_comment_comment]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[review_comment] DROP CONSTRAINT [DF_review_comment_comment]
END

GO

/****** Object:  Table [dbo].[review_comment]    Script Date: 10/26/2015 06:25:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[review_comment]') AND type in (N'U'))
DROP TABLE [dbo].[review_comment]
GO

/****** Object:  Table [dbo].[review_comment]    Script Date: 10/26/2015 06:25:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[review_comment](
	[review_comment_id] [varchar](36) NOT NULL,
	[areas] [text] NOT NULL,
	[comment] [text] NOT NULL,
 CONSTRAINT [PK_review_comment] PRIMARY KEY CLUSTERED 
(
	[review_comment_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[review_comment] ADD  CONSTRAINT [DF_review_comment_areas]  DEFAULT ('') FOR [areas]
GO

ALTER TABLE [dbo].[review_comment] ADD  CONSTRAINT [DF_review_comment_comment]  DEFAULT ('') FOR [comment]
GO