CREATE TABLE [dbo].[Request_MST]
(
	[RequestID]	         VARCHAR(15)	     NOT NULL PRIMARY KEY,
    [FunctionID]         VARCHAR(5)			 NOT NULL, 
    [RequestStatus]      INT			     NOT NULL, 
	[RequestBy]          UNIQUEIDENTIFIER	 NULL,
    [RequestDate]        DATETIME			 NOT NULL,
	[ApprovedBy]         UNIQUEIDENTIFIER	 NULL,
    [ApprovedDate]       DATETIME			 NULL,
    [CompletedDate]      DATETIME			 NULL,
    [LastModifiedDate]   DATETIME			 NULL
)
