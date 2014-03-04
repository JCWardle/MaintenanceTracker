CREATE TABLE [dbo].[Part]
(
	[PartId] INT IDENTITY(1,1) PRIMARY KEY, 
    [MaintenanceId] INT NOT NULL, 
    [Name] NVARCHAR(150) NULL, 
    [Cost] MONEY NOT NULL,
	FOREIGN KEY (MaintenanceId) REFERENCES Job (JobId)
)
