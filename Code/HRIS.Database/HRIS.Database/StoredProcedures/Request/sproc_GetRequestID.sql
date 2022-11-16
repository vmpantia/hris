-- =============================================
-- Author:		Vincent Pantia
-- Create date: 12/11/2021
-- Description:	Get latest RequestID
-- =============================================
CREATE PROCEDURE [dbo].[sproc_GetRequestID]
	@RequestID VARCHAR(15) OUTPUT
AS
BEGIN
    DECLARE @ReqLatestCount int;
	DECLARE @Date varchar(8) = CONVERT(varchar(8), GETDATE(), 112);

	SELECT @ReqLatestCount = COUNT(*) + 1 FROM Request_MST WHERE RequestDate = CONVERT(VARCHAR(10), GETDATE(), 111)

	SET @RequestID = CONCAT('REQ',									   -- Request Mark
							 @Date,									   -- Date Today
							 REPLICATE('0', 4 - LEN(@ReqLatestCount)), -- ID
							 @ReqLatestCount)						   -- ID
END