/****** Object:  Table [dbo].[standard_template]    Script Date: 1/27/2016 1:33:43 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[standard_template]') AND type in (N'U'))
DROP TABLE [dbo].[standard_template]
GO
/****** Object:  Table [dbo].[standard_template]    Script Date: 1/27/2016 1:33:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[standard_template]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[standard_template](
	[id] [varchar](36) NOT NULL,
	[parent_id] [varchar](36) NOT NULL,
	[name] [nvarchar](1000) NOT NULL,
	[caption] [ntext] NULL,
	[index] [smallint] NOT NULL,
 CONSTRAINT [PK_standard_template] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'01067104-29e0-4c14-b3ae-53835e5c46ca', N'af7bb673-4182-40a5-88d0-51ff7bd4a0ed', N'Credit cannot be included verbatim due to a change in regulation. If the summary provided is insufficient, we will be allowed to transfer the entire report when we have a business license on file for your account.', N'<?xml version="1.0" encoding="utf-16"?><FinalCmtsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><FinalCmts>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f1\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f1\''B7\tab}{\*\pn\pnlvlcont\pnf1\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 Credit cannot be included verbatim due to a change in regulation. If the summary provided is insufficient, we will be allowed to transfer the entire report when we have a business license on file for your account.\par&#xD;
}&#xD;
</FinalCmts></FinalCmtsData>', 2)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'06ebbe14-3089-4007-baab-2a7ef2259146', N'355689a3-00b5-45f9-a064-439ae7d71f0d', N'Military', N'<?xml version="1.0" encoding="utf-16"?><EmpRefsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><EmpRefs>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f1\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f1\''B7\tab}{\*\pn\pnlvlcont\pnf1\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 Applicant lists a the military as Current employer.\par&#xD;
{\pntext\f1\''B7\tab}No reference available.\par&#xD;
}&#xD;
</EmpRefs></EmpRefsData>', 6)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'0b86ca00-844d-4840-85b5-32a3bf0a57bd', N'b082dc4c-0253-418c-ae26-3793934d7404', N'Applicant failed to answer the eviction question.', N'<?xml version="1.0" encoding="utf-16"?><FinalCmtsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><FinalCmts>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f1\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f1\''B7\tab}{\*\pn\pnlvlcont\pnf1\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 Applicant failed to answer the eviction question.\par&#xD;
}&#xD;
</FinalCmts></FinalCmtsData>', 3)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'0bb7ca78-53a2-495f-acd2-044d01c8bb16', N'e94a3c7d-d201-4851-b327-79bf5e147d36', N'Other', N'', 3)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'0ca1706f-3883-4ddd-9c0a-642d4f8102ba', N'fc55eb14-7d67-4800-9e94-55f34e9b8a0e', N'Employment/Income', N'', 3)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'0e0cdd49-d4dd-4e16-8850-8403bd7271e8', N'fc55eb14-7d67-4800-9e94-55f34e9b8a0e', N'False/Discrepant Info', N'', 4)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'1550ff50-ea4a-47d3-9cba-7077afb7ea56', N'e94a3c7d-d201-4851-b327-79bf5e147d36', N'Home Owner', N'', 2)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'2184b1b5-5e97-47ef-bec3-d96185fdb843', N'cbb5bade-d5ad-498e-9954-b66675a19ee8', N'No rental history.', N'<?xml version="1.0" encoding="utf-16"?><FinalCmtsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><FinalCmts>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f1\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f1\''B7\tab}{\*\pn\pnlvlcont\pnf1\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 No rental history.\par&#xD;
}&#xD;
</FinalCmts></FinalCmtsData>', 1)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'21c2637e-013e-4993-9861-bb4499fef0d5', N'60bea004-902a-4e15-850b-35b65a68d1b4', N'Employed Through Family', N'<?xml version="1.0" encoding="utf-16"?><EmpVerifs1Data xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"><SW>Current employer given by Applicant is a family member.</SW><Co>See proof of income.</Co><Tele /></EmpVerifs1Data>', 3)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'24a22ca8-64bc-437e-ad80-6ce5f02fa777', N'af7bb673-4182-40a5-88d0-51ff7bd4a0ed', N'This is a preliminary report. Recommendation is subject to change as further information is obtained.', N'<?xml version="1.0" encoding="utf-16"?><FinalCmtsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><FinalCmts>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f1\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f1\''B7\tab}{\*\pn\pnlvlcont\pnf1\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 This is a preliminary report. Recommendation is subject to change as further information is obtained.\par&#xD;
}&#xD;
</FinalCmts></FinalCmtsData>', 1)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'325d8fd9-d9af-43df-92af-bf3323a56146', N'0ca1706f-3883-4ddd-9c0a-642d4f8102ba', N'Short time on the job.', N'<?xml version="1.0" encoding="utf-16"?><FinalCmtsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><FinalCmts>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f1\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f1\''B7\tab}{\*\pn\pnlvlcont\pnf1\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 Short time on the job.\par&#xD;
}&#xD;
</FinalCmts></FinalCmtsData>', 6)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'355689a3-00b5-45f9-a064-439ae7d71f0d', N'0', N'Standard Refs. (Employment Info)', N'', 1)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'37b736da-2967-43b4-99b8-73ac683f02de', N'e5891e1c-84db-404d-a533-5ecdaa824e97', N'Retirement', N'<?xml version="1.0" encoding="utf-16"?><EmpVerifs2Data xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"><SW>Applicant lists retirement income.</SW><Co /><Tele /></EmpVerifs2Data>', 6)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'3948ca4a-9f7f-49bf-b55a-724e06198929', N'0ca1706f-3883-4ddd-9c0a-642d4f8102ba', N'No employment or income.', N'<?xml version="1.0" encoding="utf-16"?><FinalCmtsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><FinalCmts>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f1\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f1\''B7\tab}{\*\pn\pnlvlcont\pnf1\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 No employment or income.\par&#xD;
}&#xD;
</FinalCmts></FinalCmtsData>', 2)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'39611973-bb50-4e48-bbce-6e0fa0c00ab5', N'0bb7ca78-53a2-495f-acd2-044d01c8bb16', N'Residence Out of Country', N'<?xml version="1.0" encoding="utf-16"?><RentalRefsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><RentalRefs>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f1\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f1\''B7\tab}{\*\pn\pnlvlcont\pnf1\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 Current residence given is out of the country.\par&#xD;
{\pntext\f1\''B7\tab}This information is not verifiable.\par&#xD;
{\pntext\f1\''B7\tab}No further information available.\par&#xD;
}&#xD;
</RentalRefs></RentalRefsData>', 1)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'39b834d2-c705-491d-8d2b-be31cd86ce71', N'f59e8263-d428-459c-b5d3-4f400f740995', N'Family', N'<?xml version="1.0" encoding="utf-16"?><RentalRefsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><RentalRefs>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f1\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f1\''B7\tab}{\*\pn\pnlvlcont\pnf1\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 Current landlord given is a family member.\par&#xD;
{\pntext\f1\''B7\tab}Not a third party rental reference.\par&#xD;
{\pntext\f1\''B7\tab}No further information available.\par&#xD;
}&#xD;
</RentalRefs></RentalRefsData>', 2)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'3b9ac3c3-6960-409c-b504-d932c4d21ede', N'60bea004-902a-4e15-850b-35b65a68d1b4', N'Insufficient Information', N'<?xml version="1.0" encoding="utf-16"?><EmpVerifs1Data xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"><SW>Applicant provided insufficient information to attempt to verify Current employment.</SW><Co>See proof of income.</Co><Tele /></EmpVerifs1Data>', 10)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'3e5eaf2f-e920-4d85-ad88-99c8446d5610', N'60bea004-902a-4e15-850b-35b65a68d1b4', N'Student Employment', N'<?xml version="1.0" encoding="utf-16"?><EmpVerifs1Data xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"><SW>Applicant lists student employment.</SW><Co>See proof of income.</Co><Tele /></EmpVerifs1Data>', 5)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'3f872af8-db41-48d7-b6a1-9fd331f3a081', N'355689a3-00b5-45f9-a064-439ae7d71f0d', N'Employed with Client Applied', N'<?xml version="1.0" encoding="utf-16"?><EmpRefsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><EmpRefs>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f1\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f1\''B7\tab}{\*\pn\pnlvlcont\pnf1\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 Applicant lists Precision Body &amp; Paint, Inc. as Current employer.\par&#xD;
{\pntext\f1\''B7\tab}See Records.\par&#xD;
}&#xD;
</EmpRefs></EmpRefsData>', 7)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'43e21cc9-5a86-4997-b018-bd766fe351b3', N'60bea004-902a-4e15-850b-35b65a68d1b4', N'Retirement', N'<?xml version="1.0" encoding="utf-16"?><EmpVerifs1Data xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"><SW>Applicant lists retirement income.</SW><Co>See proof of income.</Co><Tele /></EmpVerifs1Data>', 6)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'442e95b1-5ef9-4292-a568-77f7622b0eeb', N'355689a3-00b5-45f9-a064-439ae7d71f0d', N'Employed Through Family', N'<?xml version="1.0" encoding="utf-16"?><EmpRefsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><EmpRefs>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f1\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f1\''B7\tab}{\*\pn\pnlvlcont\pnf1\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 Applicant lists a family member as Current employer.\par&#xD;
{\pntext\f1\''B7\tab}No third party reference available.\par&#xD;
}&#xD;
</EmpRefs></EmpRefsData>', 5)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'45c24e29-57a9-4449-a198-35c083972628', N'e5891e1c-84db-404d-a533-5ecdaa824e97', N'No Employment Given', N'<?xml version="1.0" encoding="utf-16"?><EmpVerifs2Data xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"><SW>Applicant provided no previous employment infomation.</SW><Co /><Tele /></EmpVerifs2Data>', 8)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'47f04d3a-437a-4f15-b90c-ba72f83560d7', N'1550ff50-ea4a-47d3-9cba-7077afb7ea56', N'Mortgage - In Bankruptcy', N'<?xml version="1.0" encoding="utf-16"?><RentalRefsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><RentalRefs>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f1\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f1\''B7\tab}{\*\pn\pnlvlcont\pnf1\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 Current mortgage verified.\par&#xD;
{\pntext\f1\''B7\tab}Account was included in a bankruptcy.\par&#xD;
{\pntext\f1\''B7\tab}No further information available.\par&#xD;
}&#xD;
</RentalRefs></RentalRefsData>', 3)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'48a05e74-5e9a-42ae-b6d1-589c1fdd4dab', N'e5891e1c-84db-404d-a533-5ecdaa824e97', N'Self-Employment', N'<?xml version="1.0" encoding="utf-16"?><EmpVerifs2Data xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"><SW>Applicant lists self-employment.</SW><Co /><Tele /></EmpVerifs2Data>', 7)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'4a170515-8ca4-4b3e-a5f2-15b710c9519e', N'60bea004-902a-4e15-850b-35b65a68d1b4', N'Fee-Based Verif. Service', N'<?xml version="1.0" encoding="utf-16"?><EmpVerifs1Data xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"><SW>Current employer given by Applicant verifies through a fee-based verification service.</SW><Co>See proof of income.</Co><Tele /></EmpVerifs1Data>', 2)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'4da7ebce-4bd1-4c25-ab8f-0abd2af674fa', N'e5891e1c-84db-404d-a533-5ecdaa824e97', N'Student Employment', N'<?xml version="1.0" encoding="utf-16"?><EmpVerifs2Data xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"><SW>Applicant lists student employment.</SW><Co /><Tele /></EmpVerifs2Data>', 5)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'4e585fc2-c4f1-452d-a0b2-80fc359c174d', N'0ca1706f-3883-4ddd-9c0a-642d4f8102ba', N'Low income.', N'<?xml version="1.0" encoding="utf-16"?><FinalCmtsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><FinalCmts>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f1\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f1\''B7\tab}{\*\pn\pnlvlcont\pnf1\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 Low income.\par&#xD;
}&#xD;
</FinalCmts></FinalCmtsData>', 5)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'52522db7-6733-4683-a99c-547754689106', N'0e0cdd49-d4dd-4e16-8850-8403bd7271e8', N'Credit Bureau reports that SSN given has never been issued.', N'<?xml version="1.0" encoding="utf-16"?><FinalCmtsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><FinalCmts>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f1\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f1\''B7\tab}{\*\pn\pnlvlcont\pnf1\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 Credit Bureau reports that SSN given has never been issued.\par&#xD;
}&#xD;
</FinalCmts></FinalCmtsData>', 4)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'54f098f9-e9ec-4262-9d21-00c0ec968e1f', N'e5891e1c-84db-404d-a533-5ecdaa824e97', N'Non-Employment Income', N'<?xml version="1.0" encoding="utf-16"?><EmpVerifs2Data xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"><SW>Applicant lists non-employment income.</SW><Co /><Tele /></EmpVerifs2Data>', 1)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'60bea004-902a-4e15-850b-35b65a68d1b4', N'0', N'Standard Verifs. 1 (Employment Info)', N'', 1)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'61ca79d0-a2ca-4a61-92c0-27e1776cb195', N'f59e8263-d428-459c-b5d3-4f400f740995', N'Friend', N'<?xml version="1.0" encoding="utf-16"?><RentalRefsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><RentalRefs>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f1\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f1\''B7\tab}{\*\pn\pnlvlcont\pnf1\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 Current landlord given is a personal friend.\par&#xD;
{\pntext\f1\''B7\tab}Not a third party rental reference.\par&#xD;
{\pntext\f1\''B7\tab}No further information available.\par&#xD;
}&#xD;
</RentalRefs></RentalRefsData>', 1)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'6551eb00-d87f-4bfd-9e2d-ad90945df350', N'f59e8263-d428-459c-b5d3-4f400f740995', N'Transitional Housing', N'<?xml version="1.0" encoding="utf-16"?><RentalRefsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><RentalRefs>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f1\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f1\''B7\tab}{\*\pn\pnlvlcont\pnf1\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 Current residence given is transitional housing.\par&#xD;
{\pntext\f1\''B7\tab}Not a third party rental reference.\par&#xD;
{\pntext\f1\''B7\tab}No further information available.\par&#xD;
}&#xD;
</RentalRefs></RentalRefsData>', 6)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'67653cbd-1e80-4004-8cf0-1bcd7e6ef4e7', N'0e0cdd49-d4dd-4e16-8850-8403bd7271e8', N'False information given regarding eviction history.', N'<?xml version="1.0" encoding="utf-16"?><FinalCmtsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><FinalCmts>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f1\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f1\''B7\tab}{\*\pn\pnlvlcont\pnf1\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 False information given regarding eviction history.\par&#xD;
}&#xD;
</FinalCmts></FinalCmtsData>', 2)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'697c8646-caeb-4398-a39d-3b75f2087c9b', N'1550ff50-ea4a-47d3-9cba-7077afb7ea56', N'Mortgage - Good Standing', N'<?xml version="1.0" encoding="utf-16"?><RentalRefsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><RentalRefs>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f1\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f1\''B7\tab}{\*\pn\pnlvlcont\pnf1\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 Current mortgage verified.\par&#xD;
{\pntext\f1\''B7\tab}Account shows good standing on the credit report.\par&#xD;
{\pntext\f1\''B7\tab}No further information available.\par&#xD;
}&#xD;
</RentalRefs></RentalRefsData>', 1)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'69c1c3bc-175f-4da6-b873-b0ab88e557fb', N'0bb7ca78-53a2-495f-acd2-044d01c8bb16', N'Insufficient Information', N'<?xml version="1.0" encoding="utf-16"?><RentalRefsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><RentalRefs>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f1\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f1\''B7\tab}{\*\pn\pnlvlcont\pnf1\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 Insufficient information given to attempt to verify Current residence.\par&#xD;
{\pntext\f1\''B7\tab}No further information available.\par&#xD;
}&#xD;
</RentalRefs></RentalRefsData>', 2)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'6f05fda3-2cce-4d0e-b615-f1ad6eb7eee9', N'60bea004-902a-4e15-850b-35b65a68d1b4', N'Non-Employment Income', N'<?xml version="1.0" encoding="utf-16"?><EmpVerifs1Data xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"><SW>Applicant lists non-employment income.</SW><Co>See proof of income.</Co><Tele /></EmpVerifs1Data>', 1)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'70e44f5f-f40b-4453-88d2-5767bbf07814', N'0e0cdd49-d4dd-4e16-8850-8403bd7271e8', N'False information given regarding criminal history.', N'<?xml version="1.0" encoding="utf-16"?><FinalCmtsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><FinalCmts>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f1\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f1\''B7\tab}{\*\pn\pnlvlcont\pnf1\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 False information given regarding criminal history.\par&#xD;
}&#xD;
</FinalCmts></FinalCmtsData>', 1)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'77837082-2d3e-4c60-a413-5f24ff160cb3', N'b0b24c8f-0bcb-4d62-9014-70fade83a82a', N'Credit report shows money owed to a landlord.', N'<?xml version="1.0" encoding="utf-16"?><FinalCmtsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><FinalCmts>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f1\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f1\''B7\tab}{\*\pn\pnlvlcont\pnf1\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 Credit report shows money owed to a landlord.\par&#xD;
}&#xD;
</FinalCmts></FinalCmtsData>', 3)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'7ef61a42-38b7-4907-9774-77738128a0a7', N'0bb7ca78-53a2-495f-acd2-044d01c8bb16', N'Reference Omitted per Client', N'<?xml version="1.0" encoding="utf-16"?><RentalRefsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><RentalRefs>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f1\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f1\''B7\tab}{\*\pn\pnlvlcont\pnf1\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 Current residence verification has been unavailable.\par&#xD;
{\pntext\f1\''B7\tab}Report sent per Precision Body &amp; Paint, Inc.\par&#xD;
}&#xD;
</RentalRefs></RentalRefsData>', 4)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'830a79f2-3bc2-40e0-9b85-8493ce331cf8', N'355689a3-00b5-45f9-a064-439ae7d71f0d', N'Self-Employment', N'<?xml version="1.0" encoding="utf-16"?><EmpRefsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><EmpRefs>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f1\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f1\''B7\tab}{\*\pn\pnlvlcont\pnf1\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 Applicant claims to be self-employed.\par&#xD;
{\pntext\f1\''B7\tab}See proof of self-employment.\par&#xD;
}&#xD;
</EmpRefs></EmpRefsData>', 2)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'84d5734d-6c6b-4f2c-88ca-117a088d2602', N'60bea004-902a-4e15-850b-35b65a68d1b4', N'Self-Employment', N'<?xml version="1.0" encoding="utf-16"?><EmpVerifs1Data xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"><SW>Applicant lists self-employment.</SW><Co>See proof of income.</Co><Tele /></EmpVerifs1Data>', 7)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'854d7cfe-a1c9-486b-82d7-df21bbc57b84', N'0ca1706f-3883-4ddd-9c0a-642d4f8102ba', N'See proof of income.', N'<?xml version="1.0" encoding="utf-16"?><FinalCmtsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><FinalCmts>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f1\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f1\''B7\tab}{\*\pn\pnlvlcont\pnf1\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 See proof of income.\par&#xD;
}&#xD;
</FinalCmts></FinalCmtsData>', 4)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'85862cc7-cb7e-4993-b1c7-2532608a91b3', N'0bb7ca78-53a2-495f-acd2-044d01c8bb16', N'Residence with Client Applied', N'<?xml version="1.0" encoding="utf-16"?><RentalRefsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><RentalRefs>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f1\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f1\''B7\tab}{\*\pn\pnlvlcont\pnf1\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 Applicant lists Precision Body &amp; Paint, Inc. as Current landlord.\par&#xD;
{\pntext\f1\''B7\tab}See records.\par&#xD;
}&#xD;
</RentalRefs></RentalRefsData>', 3)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'865ddb3d-d908-4502-8c39-18d9b0b29407', N'355689a3-00b5-45f9-a064-439ae7d71f0d', N'Fee-Based Verif. Service', N'<?xml version="1.0" encoding="utf-16"?><EmpRefsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><EmpRefs>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f1\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f1\''B7\tab}{\*\pn\pnlvlcont\pnf1\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 This employer verifies through a fee-based verification service.\par&#xD;
{\pntext\f1\''B7\tab}No verification available.\par&#xD;
}&#xD;
</EmpRefs></EmpRefsData>', 4)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'86adecf7-bcb9-410a-bacf-af309434f06a', N'60bea004-902a-4e15-850b-35b65a68d1b4', N'No Employment Given', N'<?xml version="1.0" encoding="utf-16"?><EmpVerifs1Data xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"><SW>Applicant provided no Current employment information.</SW><Co /><Tele /></EmpVerifs1Data>', 8)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'8736f822-8677-488d-8d5f-33921e1ed328', N'f59e8263-d428-459c-b5d3-4f400f740995', N'Hotel', N'<?xml version="1.0" encoding="utf-16"?><RentalRefsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><RentalRefs>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f1\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f1\''B7\tab}{\*\pn\pnlvlcont\pnf1\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 Current residence given is a hotel.\par&#xD;
{\pntext\f1\''B7\tab}Not a third party rental reference.\par&#xD;
{\pntext\f1\''B7\tab}No further information available.\par&#xD;
}&#xD;
</RentalRefs></RentalRefsData>', 3)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'87a6e411-2e65-4148-bed0-9dc7b95967a1', N'0e0cdd49-d4dd-4e16-8850-8403bd7271e8', N'False information given regarding residence history.', N'<?xml version="1.0" encoding="utf-16"?><FinalCmtsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><FinalCmts>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f1\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f1\''B7\tab}{\*\pn\pnlvlcont\pnf1\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 False information given regarding residence history.\par&#xD;
}&#xD;
</FinalCmts></FinalCmtsData>', 3)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'897a14a8-a109-4d39-94f0-67f5d69a6d5a', N'e5891e1c-84db-404d-a533-5ecdaa824e97', N'Fee-Based Verif. Service', N'<?xml version="1.0" encoding="utf-16"?><EmpVerifs2Data xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"><SW>Previous employer given by Applicant verifies through a fee-based verification service.</SW><Co /><Tele /></EmpVerifs2Data>', 2)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'8b69f5cb-ac2b-44f5-964f-a75c832901a6', N'1550ff50-ea4a-47d3-9cba-7077afb7ea56', N'Unverifiable', N'<?xml version="1.0" encoding="utf-16"?><RentalRefsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><RentalRefs>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f1\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f1\''B7\tab}{\*\pn\pnlvlcont\pnf1\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 Applicant claims to own the Current residence.\par&#xD;
{\pntext\f1\''B7\tab}No mortgages appear on the credit report.\par&#xD;
{\pntext\f1\''B7\tab}Address given could not be verified.\par&#xD;
{\pntext\f1\''B7\tab}See proof of home ownership.\par&#xD;
}&#xD;
</RentalRefs></RentalRefsData>', 5)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'8ee6b4d2-9c51-4410-9d2b-55517f789cdd', N'e5891e1c-84db-404d-a533-5ecdaa824e97', N'Full-Time Student', N'<?xml version="1.0" encoding="utf-16"?><EmpVerifs2Data xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"><SW>Applicant was a full-time student.</SW><Co /><Tele /></EmpVerifs2Data>', 4)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'912c1e26-d55f-4404-b498-19d630797b1e', N'b0b24c8f-0bcb-4d62-9014-70fade83a82a', N'No credit report could be obtained.', N'<?xml version="1.0" encoding="utf-16"?><FinalCmtsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><FinalCmts>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f1\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f1\''B7\tab}{\*\pn\pnlvlcont\pnf1\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 No credit report could be obtained.\par&#xD;
}&#xD;
</FinalCmts></FinalCmtsData>', 4)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'9ab1f8dd-6504-4bb6-aa46-a239d30df92c', N'e5891e1c-84db-404d-a533-5ecdaa824e97', N'Employed Through Family', N'<?xml version="1.0" encoding="utf-16"?><EmpVerifs2Data xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"><SW>Previous employer given by Applicant is a family member.</SW><Co /><Tele /></EmpVerifs2Data>', 3)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'9c1ee177-5334-43f5-9686-2db699f946fc', N'cbb5bade-d5ad-498e-9954-b66675a19ee8', N'Negative rental history.', N'<?xml version="1.0" encoding="utf-16"?><FinalCmtsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><FinalCmts>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f1\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f1\''B7\tab}{\*\pn\pnlvlcont\pnf1\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 Negative rental history.\par&#xD;
}&#xD;
</FinalCmts></FinalCmtsData>', 3)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'a26b3ab2-db3c-404d-925e-19a407cbc713', N'60bea004-902a-4e15-850b-35b65a68d1b4', N'Military', N'<?xml version="1.0" encoding="utf-16"?><EmpVerifs1Data xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"><SW>Current employer given by Applicant is the military.</SW><Co>See proof of income.</Co><Tele /></EmpVerifs1Data>', 9)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'a48744b0-99a2-4996-9422-a0260aaf3fbb', N'355689a3-00b5-45f9-a064-439ae7d71f0d', N'Insufficient Information', N'<?xml version="1.0" encoding="utf-16"?><EmpRefsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><EmpRefs>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f1\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f1\''B7\tab}{\*\pn\pnlvlcont\pnf1\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 Applicant lists insufficient information to attempt to verify this employment.\par&#xD;
{\pntext\f1\''B7\tab}No further information available.\par&#xD;
}&#xD;
</EmpRefs></EmpRefsData>', 3)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'acc432ae-d4d3-434b-818c-93dda6e2b04c', N'355689a3-00b5-45f9-a064-439ae7d71f0d', N'No Performance Info Given', N'<?xml version="1.0" encoding="utf-16"?><EmpRefsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><EmpRefs>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fnil\fcharset128 Arial Unicode MS;}{\f1\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f2\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f2\''B7\tab}{\*\pn\pnlvlcont\pnf2\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 This employer will not provide performance-related information.\par&#xD;
{\pntext\f2\''B7\tab}No reference available.\f1\par&#xD;
}&#xD;
</EmpRefs></EmpRefsData>', 1)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'ae0628e7-c7a7-4d76-8f59-8434b240f6af', N'cbb5bade-d5ad-498e-9954-b66675a19ee8', N'Short amount of rental history.', N'<?xml version="1.0" encoding="utf-16"?><FinalCmtsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><FinalCmts>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f1\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f1\''B7\tab}{\*\pn\pnlvlcont\pnf1\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 Short amount of rental history.\par&#xD;
}&#xD;
</FinalCmts></FinalCmtsData>', 2)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'af7bb673-4182-40a5-88d0-51ff7bd4a0ed', N'fc55eb14-7d67-4800-9e94-55f34e9b8a0e', N'Warning/Disclaimer', N'', 6)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'b082dc4c-0253-418c-ae26-3793934d7404', N'fc55eb14-7d67-4800-9e94-55f34e9b8a0e', N'Lack of Information', N'', 5)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'b0b24c8f-0bcb-4d62-9014-70fade83a82a', N'fc55eb14-7d67-4800-9e94-55f34e9b8a0e', N'Credit', N'', 2)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'b5d444af-d886-4f3e-a9fe-10572634c364', N'0bb7ca78-53a2-495f-acd2-044d01c8bb16', N'Homeless', N'<?xml version="1.0" encoding="utf-16"?><RentalRefsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><RentalRefs>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f1\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f1\''B7\tab}{\*\pn\pnlvlcont\pnf1\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 Applicant provided no Current residence information.\par&#xD;
{\pntext\f1\''B7\tab}Not verifiable information.\par&#xD;
{\pntext\f1\''B7\tab}No further information available.\par&#xD;
}&#xD;
</RentalRefs></RentalRefsData>', 5)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'b6743e08-21e0-4116-973a-e0579be22566', N'0e0cdd49-d4dd-4e16-8850-8403bd7271e8', N'The SSA shows a discrepancy with the number provided and requests that the applicant visit the nearest SSA location.', N'<?xml version="1.0" encoding="utf-16"?><FinalCmtsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><FinalCmts>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f1\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f1\''B7\tab}{\*\pn\pnlvlcont\pnf1\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 The SSA shows a discrepancy with the number provided and requests that the applicant visit the nearest SSA location.\par&#xD;
}&#xD;
</FinalCmts></FinalCmtsData>', 6)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'b98e7a7b-1bb1-41f8-9672-322d040a19e3', N'0e0cdd49-d4dd-4e16-8850-8403bd7271e8', N'Credit Bureau reports that SSN given was issued prior to the birthdate.', N'<?xml version="1.0" encoding="utf-16"?><FinalCmtsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><FinalCmts>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f1\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f1\''B7\tab}{\*\pn\pnlvlcont\pnf1\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 Credit Bureau reports that SSN given was issued prior to the birthdate.\par&#xD;
}&#xD;
</FinalCmts></FinalCmtsData>', 5)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'bd2c2c0a-e66e-44dc-b673-2780254abdc8', N'0ca1706f-3883-4ddd-9c0a-642d4f8102ba', N'No verified employment.', N'<?xml version="1.0" encoding="utf-16"?><FinalCmtsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><FinalCmts>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f1\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f1\''B7\tab}{\*\pn\pnlvlcont\pnf1\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 No verified employment.\par&#xD;
}&#xD;
</FinalCmts></FinalCmtsData>', 3)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'c8a864d9-fc86-4a7d-9f95-9268d4da4d98', N'f59e8263-d428-459c-b5d3-4f400f740995', N'Student Housing', N'<?xml version="1.0" encoding="utf-16"?><RentalRefsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><RentalRefs>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f1\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f1\''B7\tab}{\*\pn\pnlvlcont\pnf1\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 Current residence given is student housing.\par&#xD;
{\pntext\f1\''B7\tab}Not a third party rental reference.\par&#xD;
{\pntext\f1\''B7\tab}No further information available\par&#xD;
}&#xD;
</RentalRefs></RentalRefsData>', 5)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'cb6e5af1-de6e-4d8b-bfd0-c26fc4a20f6f', N'b082dc4c-0253-418c-ae26-3793934d7404', N'General lack of information.', N'<?xml version="1.0" encoding="utf-16"?><FinalCmtsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><FinalCmts>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f1\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f1\''B7\tab}{\*\pn\pnlvlcont\pnf1\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 General lack of information.\par&#xD;
}&#xD;
</FinalCmts></FinalCmtsData>', 1)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'cbb5bade-d5ad-498e-9954-b66675a19ee8', N'fc55eb14-7d67-4800-9e94-55f34e9b8a0e', N'Rental', N'', 1)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'd4a036b9-58bd-4a8f-875f-0217248aa00e', N'b0b24c8f-0bcb-4d62-9014-70fade83a82a', N'Negative credit established since bankruptcy.', N'<?xml version="1.0" encoding="utf-16"?><FinalCmtsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><FinalCmts>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f1\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f1\''B7\tab}{\*\pn\pnlvlcont\pnf1\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 Negative credit established since bankruptcy.\par&#xD;
}&#xD;
</FinalCmts></FinalCmtsData>', 2)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'd763b151-a9fa-497c-a046-a39334ded75f', N'e5891e1c-84db-404d-a533-5ecdaa824e97', N'Insufficient Information', N'<?xml version="1.0" encoding="utf-16"?><EmpVerifs2Data xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"><SW>Applicant provided insufficient information to attempt to verify previous employment.</SW><Co /><Tele /></EmpVerifs2Data>', 10)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'd832d856-97d0-43f0-9be3-edc312c4374c', N'1550ff50-ea4a-47d3-9cba-7077afb7ea56', N'Verified Home Ownership', N'<?xml version="1.0" encoding="utf-16"?><RentalRefsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><RentalRefs>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f1\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f1\''B7\tab}{\*\pn\pnlvlcont\pnf1\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 Current home ownership verified.\par&#xD;
{\pntext\f1\''B7\tab}Government records show the applicant as the owner.\par&#xD;
{\pntext\f1\''B7\tab}No further information available.\par&#xD;
}&#xD;
</RentalRefs></RentalRefsData>', 4)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'dd350e95-6d2b-48e2-9f8f-713bd428f45e', N'e5891e1c-84db-404d-a533-5ecdaa824e97', N'Military', N'<?xml version="1.0" encoding="utf-16"?><EmpVerifs2Data xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"><SW>Previous employer given by Applicant is the military.</SW><Co /><Tele /></EmpVerifs2Data>', 9)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'e19f0702-3067-46f9-9eb5-bd0c250bb461', N'1550ff50-ea4a-47d3-9cba-7077afb7ea56', N'Mortgage - Late Payments', N'<?xml version="1.0" encoding="utf-16"?><RentalRefsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><RentalRefs>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f1\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f1\''B7\tab}{\*\pn\pnlvlcont\pnf1\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 Current mortgage verified.\par&#xD;
{\pntext\f1\''B7\tab}Account shows a history of late payments.\par&#xD;
{\pntext\f1\''B7\tab}No further information available.\par&#xD;
}&#xD;
</RentalRefs></RentalRefsData>', 2)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'e5891e1c-84db-404d-a533-5ecdaa824e97', N'0', N'Standard Verifs. 2 (Employment Info)', N'', 1)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'e8a907d3-ac1e-4b85-8971-8e0657c46258', N'60bea004-902a-4e15-850b-35b65a68d1b4', N'Full-Time Student', N'<?xml version="1.0" encoding="utf-16"?><EmpVerifs1Data xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"><SW>Applicant is a full-time student.</SW><Co /><Tele /></EmpVerifs1Data>', 4)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'e94a3c7d-d201-4851-b327-79bf5e147d36', N'0', N'Standard Refs. (Rental Info)', N'', 1)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'eb36013d-5bdc-4cb1-afd4-27f8114c9bff', N'f59e8263-d428-459c-b5d3-4f400f740995', N'Employer', N'<?xml version="1.0" encoding="utf-16"?><RentalRefsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><RentalRefs>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f1\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f1\''B7\tab}{\*\pn\pnlvlcont\pnf1\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 Current residence given is provided by an employer.\par&#xD;
{\pntext\f1\''B7\tab}Not a third party rental reference.\par&#xD;
{\pntext\f1\''B7\tab}No further information available.\par&#xD;
}&#xD;
</RentalRefs></RentalRefsData>', 4)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'ef0de90d-ba28-4347-9f06-8dae5957be9d', N'b082dc4c-0253-418c-ae26-3793934d7404', N'Applicant failed to answer the criminal question.', N'<?xml version="1.0" encoding="utf-16"?><FinalCmtsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><FinalCmts>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f1\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f1\''B7\tab}{\*\pn\pnlvlcont\pnf1\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 Applicant failed to answer the criminal question.\par&#xD;
}&#xD;
</FinalCmts></FinalCmtsData>', 2)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'f4e0540c-2517-4346-b471-2c6fe5ea1f91', N'b0b24c8f-0bcb-4d62-9014-70fade83a82a', N'Negative credit.', N'<?xml version="1.0" encoding="utf-16"?><FinalCmtsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><FinalCmts>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f1\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f1\''B7\tab}{\*\pn\pnlvlcont\pnf1\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 Negative credit.\par&#xD;
}&#xD;
</FinalCmts></FinalCmtsData>', 1)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'f4eec1c5-1348-48d9-8367-07fb31bff7bd', N'0ca1706f-3883-4ddd-9c0a-642d4f8102ba', N'No employment.', N'<?xml version="1.0" encoding="utf-16"?><FinalCmtsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><FinalCmts>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f1\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f1\''B7\tab}{\*\pn\pnlvlcont\pnf1\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 No employment.\par&#xD;
}&#xD;
</FinalCmts></FinalCmtsData>', 1)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'f59e8263-d428-459c-b5d3-4f400f740995', N'e94a3c7d-d201-4851-b327-79bf5e147d36', N'Non-Third Party', N'', 1)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'f9fba9fd-d24f-4164-ba88-693f3e3b8c54', N'f59e8263-d428-459c-b5d3-4f400f740995', N'Military Housing', N'<?xml version="1.0" encoding="utf-16"?><RentalRefsData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><RentalRefs>{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fswiss\fprq2\fcharset128 Arial Unicode MS;}{\f1\fnil\fcharset2 Symbol;}}&#xD;
{\colortbl ;\red64\green64\blue64;}&#xD;
\viewkind4\uc1\pard{\pntext\f1\''B7\tab}{\*\pn\pnlvlcont\pnf1\pnindent500{\pntxtb\''B7}}\fi-10\li10\cf1\lang1033\b\f0\fs23 Current residence given is military housing.\par&#xD;
{\pntext\f1\''B7\tab}Not a third party rental reference.\par&#xD;
{\pntext\f1\''B7\tab}No further information available.\par&#xD;
}&#xD;
</RentalRefs></RentalRefsData>', 7)
INSERT [dbo].[standard_template] ([id], [parent_id], [name], [caption], [index]) VALUES (N'fc55eb14-7d67-4800-9e94-55f34e9b8a0e', N'0', N'Standard Comments (Final Info)', N'', 1)
