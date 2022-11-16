-- =============================================
-- Author:		Vincent Pantia
-- Create date: 12/09/2021
-- Description:	Save Employee_MST Record
-- =============================================
CREATE PROCEDURE [dbo].[sproc_SaveEmployee_MST]
	@InternalID    UNIQUEIDENTIFIER,
	@EmployeeID    VARCHAR(15),
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
	-- Save Employee Record
	IF EXISTS (SELECT * FROM Employee_MST WHERE InternalID = @InternalID)
		BEGIN
			UPDATE Employee_MST 
			SET --InternalID = @InternalID, No need to Update
				EmployeeID   = @EmployeeID,	
				FirstName    = @FirstName,
				LastName     = @LastName,
				MiddleName   = @MiddleName,
				Suffix       = @Suffix,
				Gender       = @Gender,
				Birthdate    = @Birthdate,
				PlaceOfBirth = @PlaceOfBirth,
				Nationality  = @Nationality,
				Religion     = @Religion,
				CivilStatus  = @CivilStatus,
				M_FirstName  = @M_FirstName,
				M_LastName   = @M_LastName,
				M_MiddleName = @M_MiddleName,
				M_Suffix     = @M_Suffix,
				M_Birthdate  = @M_Birthdate,
				M_ContactNo  = @M_ContactNo,
				F_FirstName  = @F_FirstName,
				F_LastName   = @F_LastName,
				F_MiddleName = @F_MiddleName,
				F_Suffix     = @F_Suffix,
				F_Birthdate  = @F_BirthDate,
				F_ContactNo  = @F_ContactNo,
				Status       = @Status,
				--CreatedBy  = @CreatedBy, No need to Update
				ModifiedBy   = @ModifiedBy,
				--CreatedDate= @CreatedDate, No need to Update
				ModifiedDate = @ModifiedDate
			WHERE InternalID = @InternalID
		END
	ELSE
		BEGIN
			INSERT INTO Employee_MST
			VALUES (@InternalID, @EmployeeID, @FirstName, @LastName, @MiddleName, @Suffix, @Gender,
					@Birthdate, @PlaceOfBirth, @Nationality, @Religion, @CivilStatus, 
					@M_FirstName, @M_LastName, @M_MiddleName, @M_Suffix, @M_Birthdate, @M_ContactNo,
					@F_FirstName, @F_LastName, @F_MiddleName, @F_Suffix, @F_Birthdate, @F_ContactNo,
				    @Status,@CreatedBy, @ModifiedBy, @CreatedDate, @ModifiedDate)
		END

	EXEC sproc_SaveContactList_MST @ContactList;
	EXEC sproc_SaveAddressList_MST @AddressList;
END