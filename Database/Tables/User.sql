CREATE TABLE [dbo].[User]
(
	[UserId] INT IDENTITY(1,1) PRIMARY KEY, 
    [Username] NVARCHAR(50) NULL, 
    [Password] NVARCHAR(200) NULL, 
    [Email] NVARCHAR(1000) NULL, 
    [Salt] NVARCHAR(20) NULL
)
