-- =============================================
-- Author:		Vincent Pantia
-- Create date: 12/12/2021
-- Description:	Save Employee Addres List in Address_MST
-- =============================================
CREATE PROCEDURE [dbo].[sproc_SaveAddressList_MST]
	@AddressList  AddressList READONLY
AS
BEGIN
	DECLARE @InternalID				UNIQUEIDENTIFIER;
	DECLARE @Employee_InternalID	UNIQUEIDENTIFIER;
	DECLARE @Type					INT;
	DECLARE @FirstLevel				VARCHAR(30);
	DECLARE @SecondLevel			VARCHAR(30);
	DECLARE @Barangay				VARCHAR(30);
	DECLARE @City					VARCHAR(30);
	DECLARE @Province				VARCHAR(30);
	DECLARE @Country				VARCHAR(30);
    DECLARE @CreatedBy				UNIQUEIDENTIFIER;
    DECLARE @ModifiedBy				UNIQUEIDENTIFIER;
    DECLARE @CreatedDate			DATETIME;
    DECLARE @ModifiedDate			DATETIME;

	-- Delete All Employee Address of specific Employee
	DELETE FROM Address_MST WHERE Employee_InternalID IN (SELECT @Employee_InternalID FROM @AddressList)

	DECLARE AddressListCursor CURSOR FOR SELECT * FROM @AddressList;
	
	OPEN AddressListCursor;
	FETCH NEXT FROM AddressListCursor INTO @InternalID, @Employee_InternalID, @Type, @FirstLevel, @SecondLevel, @Barangay, @City, 
										   @Province, @Country, @CreatedBy, @ModifiedBy, @CreatedDate, @ModifiedDate;

	WHILE @@FETCH_STATUS = 0
		BEGIN
			
			INSERT INTO Address_MST VALUES (@InternalID, @Employee_InternalID, @Type, @FirstLevel, @SecondLevel, @Barangay, @City, 
										    @Province, @Country, @CreatedBy, @ModifiedBy, @CreatedDate, @ModifiedDate)

			FETCH NEXT FROM AddressListCursor INTO @InternalID, @Employee_InternalID, @Type, @FirstLevel, @SecondLevel, @Barangay, @City, 
												   @Province, @Country, @CreatedBy, @ModifiedBy, @CreatedDate, @ModifiedDate;
		END
	CLOSE AddressListCursor;
	
	DEALLOCATE AddressListCursor;		

END