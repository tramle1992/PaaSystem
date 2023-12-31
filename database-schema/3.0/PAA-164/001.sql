/****** Object:  Table [dbo].[zipcode]    Script Date: 11/30/2015 5:51:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[zipcode](
	[zipcode_id] [nvarchar](255) NOT NULL,
	[zipcode_name] [nvarchar](10) NOT NULL,
	[zipcode_type] [nvarchar](10) NOT NULL,
	[city] [nvarchar](255) NOT NULL,
	[city_type] [nvarchar](10) NOT NULL,
	[county] [nvarchar](255) NOT NULL,
	[state] [nvarchar](255) NOT NULL,
	[state_code] [nvarchar](10) NOT NULL,
	[area_code] [nvarchar](10) NOT NULL,
	[timezone] [nvarchar](255) NOT NULL,
	[gmt_offset] [int] NOT NULL,
	[dst] [bit] NOT NULL,
	[latitude] [decimal](18, 6) NOT NULL,
	[longitude] [decimal](18, 6) NOT NULL,
 CONSTRAINT [PK_zipcode] PRIMARY KEY CLUSTERED 
(
	[zipcode_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
