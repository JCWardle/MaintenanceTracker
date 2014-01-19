CREATE TABLE [dbo].[Vehicle]
(
	[VehicleId] INT IDENTITY(1,1) PRIMARY KEY, 
    [Make] NVARCHAR(512) NOT NULL, 
    [Model] NVARCHAR(512) NOT NULL, 
    [Year] DATE NOT NULL, 
    [Registration] NVARCHAR(100) NULL, 
    [UserId] INT NOT NULL,
	FOREIGN KEY (UserId) REFERENCES [User](UserId)
)
