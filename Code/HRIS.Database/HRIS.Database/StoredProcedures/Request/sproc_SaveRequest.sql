-- =============================================
-- Author:		Vincent Pantia
-- Create date: 12/11/2021
-- Description:	Save Request
-- =============================================
CREATE PROCEDURE [dbo].[sproc_SaveRequest]
	@RequestID		   VARCHAR(15) OUTPUT,
	@FunctionID        VARCHAR(5),
	@RequestStatus	   INT,
	@RequestBy		   UNIQUEIDENTIFIER,
	@ApprovedBy		   UNIQUEIDENTIFIER,
    @RequestDate       DATETIME, 
    @ApprovedDate      DATETIME, 
    @CompletedDate	   DATETIME,
    @LastModifiedDate  DATETIME
AS
BEGIN
	-- Get Latest RequestID
	EXEC sproc_GetRequestID @RequestID OUTPUT; 

	-- Save Request
	IF EXISTS (SELECT * FROM Request_MST WHERE RequestID = @RequestID)
		BEGIN
			UPDATE Request_MST 
			SET --RequestID     = @RequestID,
			    --FunctionID    = @FunctionID,
				RequestStatus	= @RequestStatus,	
				--RequestBy     = @RequestBy,
				--RequestDate   = @RequestDate,
				ApprovedBy    = @ApprovedBy,	
				ApprovedDate  = @ApprovedDate,
				CompletedDate = @CompletedDate,
				LastModifiedDate  = @LastModifiedDate
			WHERE RequestID = @RequestID
		END
	ELSE
		BEGIN
			INSERT INTO Request_MST
			VALUES (@RequestID, @FunctionID, @RequestStatus, @RequestBy, @RequestDate,
					@ApprovedBy, @ApprovedDate, @CompletedDate, @LastModifiedDate)
		END
END