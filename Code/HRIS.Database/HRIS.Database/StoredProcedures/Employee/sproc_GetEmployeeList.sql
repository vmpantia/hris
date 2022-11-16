-- =============================================
-- Author:		Vincent Pantia
-- Create date: 12/09/2021
-- Description:	Get Employee List
-- =============================================
CREATE PROCEDURE [dbo].[sproc_GetEmployeeList]
	@FilterBy VARCHAR(MAX),
	@FilterValue VARCHAR(MAX),
	@FilterFromDate DATETIME,
	@FilterToDate DATETIME,
	@PageNo INT,
	@PageSize INT
AS
BEGIN
	IF(@FilterFromDate IS NULL AND @FilterToDate IS NULL)
		BEGIN
			SET @FilterFromDate = (SELECT TOP 1 CreatedDate FROM Employee_MST ORDER BY CreatedDate)
			SET @FilterToDate = (SELECT TOP 1 CreatedDate FROM Employee_MST ORDER BY CreatedDate DESC)
		END

	IF(@FilterBy = 'EmployeeID')
		BEGIN
			SELECT * FROM Employee_MST
			WHERE EmployeeID LIKE '%' + @FilterValue + '%' AND
				  (CreatedDate BETWEEN @FilterFromDate AND @FilterToDate)
			ORDER BY EmployeeID
			OFFSET @PageSize * @PageNo ROW
			FETCH NEXT @PageSize ROW ONLY;
		END

	IF(@FilterBy = 'Name')
		BEGIN
			SELECT * FROM Employee_MST 
			WHERE FirstName LIKE '%' + @FilterValue + '%' OR
				  MiddleName LIKE '%' + @FilterValue + '%' OR
				  LastName LIKE '%' + @FilterValue + '%' AND
				  (CreatedDate BETWEEN @FilterFromDate AND @FilterToDate)
			ORDER BY EmployeeID
			OFFSET @PageSize * @PageNo ROW
			FETCH NEXT @PageSize ROW ONLY;
		END

	SELECT * FROM Employee_MST 
			WHERE CreatedDate BETWEEN @FilterFromDate AND @FilterToDate
			ORDER BY EmployeeID
			OFFSET @PageSize * @PageNo ROW
			FETCH NEXT @PageSize ROW ONLY;
END
