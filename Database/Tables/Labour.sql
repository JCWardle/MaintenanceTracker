CREATE TABLE [dbo].[Labour]
(
	[LabourId] INT IDENTITY(1,1) PRIMARY KEY, 
    [Time] NVARCHAR(10) NULL, 
    [Cost] MONEY NULL, 
    [MaintenanceId] INT NOT NULL,
	FOREIGN KEY (MaintenanceId) REFERENCES Job(JobId)
)
