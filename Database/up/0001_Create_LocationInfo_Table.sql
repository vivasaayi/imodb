/****** Object:  Table [dbo].[LocationInfo]    Script Date: 25-03-2015 02:22:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LocationInfo](
	[DeviceId] [uniqueidentifier] NOT NULL,
	[ReaderId] [uniqueidentifier] NOT NULL,
	[TimeStamp] [datetime] NOT NULL,
	[Distance] [decimal](18, 0) NOT NULL
) ON [PRIMARY]

GO


