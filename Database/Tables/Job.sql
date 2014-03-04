CREATE TABLE [dbo].[Job]
(
	[JobId] INT IDENTITY(1,1) PRIMARY KEY, 
    [Date] DATETIME NOT NULL, 
    [Description] NVARCHAR(100) NULL, 
    [Km] NVARCHAR(50) NULL, 
    [VehicleId] INT NOT NULL,
	FOREIGN KEY (VehicleId) REFERENCES Vehicle (VehicleId)
)
