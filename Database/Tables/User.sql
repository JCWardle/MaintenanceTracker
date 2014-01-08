CREATE TABLE [dbo].[User]
(
	[Id] INT IDENTITY(1,1) PRIMARY KEY, 
    [Username] NVARCHAR(50) NULL, 
    [Password] NVARCHAR(200) NULL, 
    [Email] NVARCHAR(1000) NULL
)
