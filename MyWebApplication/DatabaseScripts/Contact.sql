

/****** Object:  Table [dbo].[Contact]    Script Date: 18-Aug-19 3:09:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Contact](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL CONSTRAINT [DF_Contact_Name]  DEFAULT (''),
	[Phone] [nvarchar](30) NOT NULL CONSTRAINT [DF_Contact_Phone]  DEFAULT (''),
	[Email] [nvarchar](30) NOT NULL CONSTRAINT [DF_Contact_Email]  DEFAULT (''),
	[Address] [nvarchar](30) NOT NULL CONSTRAINT [DF_Contact_Address]  DEFAULT (''),
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


