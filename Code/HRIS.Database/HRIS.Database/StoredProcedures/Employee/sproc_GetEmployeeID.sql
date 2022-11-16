-- =============================================
-- Author:		Vincent Pantia
-- Create date: 12/09/2021
-- Description:	Get latest EmployeeID
-- =============================================
CREATE PROCEDURE [dbo].[sproc_GetEmployeeID]
	@EmployeeID VARCHAR(15) OUTPUT
AS
BEGIN
    DECLARE @EmpLatestCount int;
	DECLARE @YearMonth varchar(6) = CONVERT(varchar(6), GETDATE(), 112);

	SELECT @EmpLatestCount = COUNT(*) + 1 FROM (SELECT EmployeeID FROM Employee_TRN GROUP BY EmployeeID) AS TRN

	SET @EmployeeID = CONCAT('EMP',									   -- Employee Mark
							 SUBSTRING(@YearMonth, 1, 2),   		   -- First 2 Number of the Year Created
							 SUBSTRING(@YearMonth, 5, 2),			   -- Month Created
							 SUBSTRING(@YearMonth, 3, 2),			   -- Last 2 Number of the Year Created
							 REPLICATE('0', 6 - LEN(@EmpLatestCount)), -- ID
							 @EmpLatestCount)						   -- ID
END