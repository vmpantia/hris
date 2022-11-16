-- =============================================
-- Author:		Vincent Pantia
-- Create date: 12/09/2021
-- Description:	Save Employee_TRN Record
-- =============================================
CREATE PROCEDURE [dbo].[sproc_SaveEmployee_TRN]
	@RequestID    VARCHAR(15),
	@InternalID    UNIQUEIDENTIFIER,
	@EmployeeID    VARCHAR(15) OUTPUT,
	@FirstName     VARCHAR(20),
	@LastName      VARCHAR(20),
	@MiddleName    VARCHAR(20),
	@Suffix        VARCHAR(5),
	@Gender        VARCHAR(6),
	@Birthdate	   DATETIME,
	@PlaceOfBirth  VARCHAR(30), 
	@Nationality   VARCHAR(20), 
	@Religion      VARCHAR(20), 
	@CivilStatus   VARCHAR(9), 
	@M_FirstName   VARCHAR(20),
	@M_LastName    VARCHAR(20),
	@M_MiddleName  VARCHAR(20),
	@M_Suffix      VARCHAR(5),
	@M_Birthdate   DATETIME,
	@M_ContactNo   VARCHAR(11),
	@F_FirstName   VARCHAR(20),
	@F_LastName    VARCHAR(20),
	@F_MiddleName  VARCHAR(20),
	@F_Suffix      VARCHAR(5),
	@F_Birthdate   DATETIME,
	@F_ContactNo   VARCHAR(11),
	@ContactList   ContactList READONLY,
	@AddressList   AddressList READONLY,
    @Status        INT, 
    @CreatedDate   DATETIME, 
    @ModifiedDate  DATETIME, 
    @CreatedBy     UNIQUEIDENTIFIER, 
    @ModifiedBy    UNIQUEIDENTIFIER
AS
BEGIN
	-- Get Latest EmployeeID 
	EXEC sproc_GetEmployeeID @EmployeeID OUTPUT; 
	
	-- Save Employee_TRN Record 
	INSERT INTO Employee_TRN
	VALUES (@RequestID, @InternalID, @EmployeeID, @FirstName, @LastName, @MiddleName, @Suffix, @Gender,
			@Birthdate, @PlaceOfBirth, @Nationality, @Religion, @CivilStatus, 
			@M_FirstName, @M_LastName, @M_MiddleName, @M_Suffix, @M_Birthdate, @M_ContactNo,
			@F_FirstName, @F_LastName, @F_MiddleName, @F_Suffix, @F_Birthdate, @F_ContactNo,
			@Status,@CreatedBy, @ModifiedBy, @CreatedDate, @ModifiedDate)
			
	EXEC sproc_SaveContactList_TRN @RequestID, @ContactList;
	EXEC sproc_SaveAddressList_TRN @RequestID, @AddressList;
END