/****** Object:  Table [dbo].[internet_tool]    Script Date: 11/9/2015 10:24:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[internet_tool](
	[id] [varchar](36) NOT NULL,
	[caption] [nvarchar](100) NOT NULL,
	[target] [varchar](2000) NOT NULL,
	[image] [varbinary](max) NULL,
	[order] [tinyint] NOT NULL,
 CONSTRAINT [PK_internet_tool] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
