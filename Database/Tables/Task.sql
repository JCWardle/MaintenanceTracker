CREATE TABLE [dbo].[Task]
(
	[TaskId] INT IDENTITY(1,1) PRIMARY KEY, 
    [MaintenanceId] INT NOT NULL, 
    [Description] NVARCHAR(256) NOT NULL,
	FOREIGN KEY (MaintenanceId) REFERENCES Job (JobId)
)
