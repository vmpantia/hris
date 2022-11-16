CREATE TABLE [dbo].[Address_MST]
(
	[InternalID]			UNIQUEIDENTIFIER	 NOT NULL PRIMARY KEY,
	[Employee_InternalID]   UNIQUEIDENTIFIER	 NOT NULL,
	[Type]					INT					 NOT NULL,
	[FirstLevel]			VARCHAR(30)			 NOT NULL,
	[SecondLevel]			VARCHAR(30)			 NOT NULL,
	[Barangay]				VARCHAR(30)			 NOT NULL,
	[City]					VARCHAR(30)			 NOT NULL,
	[Province]				VARCHAR(30)			 NOT NULL,
	[Country]				VARCHAR(30)			 NOT NULL,
    [CreatedBy]				UNIQUEIDENTIFIER	 NOT NULL, 
    [ModifiedBy]			UNIQUEIDENTIFIER	 NULL,
    [CreatedDate]			DATETIME			 NOT NULL, 
    [ModifiedDate]			DATETIME			 NULL
)
