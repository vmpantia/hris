CREATE TABLE [dbo].[Contact_MST]
(
	[InternalID]			UNIQUEIDENTIFIER	 NOT NULL PRIMARY KEY,
	[Employee_InternalID]   UNIQUEIDENTIFIER	 NOT NULL,
	[PrimaryFlag]			INT					 NOT NULL,
	[Type]					INT					 NOT NULL,
	[Value]					VARCHAR(50)			 NOT NULL,
    [CreatedBy]				UNIQUEIDENTIFIER	 NOT NULL, 
    [ModifiedBy]			UNIQUEIDENTIFIER	 NULL,
    [CreatedDate]			DATETIME			 NOT NULL, 
    [ModifiedDate]			DATETIME			 NULL
)
