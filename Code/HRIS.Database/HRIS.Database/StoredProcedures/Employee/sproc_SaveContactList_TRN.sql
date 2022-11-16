-- =============================================
-- Author:		Vincent Pantia
-- Create date: 12/12/2021
-- Description:	Save Employee Contact List in Contact_TRN
-- =============================================
CREATE PROCEDURE [dbo].[sproc_SaveContactList_TRN]
	@RequestID	  VARCHAR(15),
	@ContactList  ContactList READONLY
AS
BEGIN
	DECLARE @InternalID				UNIQUEIDENTIFIER;
	DECLARE @Employee_InternalID	UNIQUEIDENTIFIER;
	DECLARE @PrimaryFlag			INT;
	DECLARE @Type					INT;
	DECLARE @Value					VARCHAR(50);
    DECLARE @CreatedBy				UNIQUEIDENTIFIER;
    DECLARE @ModifiedBy				UNIQUEIDENTIFIER;
    DECLARE @CreatedDate			DATETIME;
    DECLARE @ModifiedDate			DATETIME;

	-- Delete All Employee Contacts of specific Employee
	DELETE FROM Contact_MST WHERE Employee_InternalID IN (SELECT @Employee_InternalID FROM @ContactList)

	DECLARE ContactListCursor CURSOR FOR SELECT * FROM @ContactList;
	
	OPEN ContactListCursor;
	FETCH NEXT FROM ContactListCursor INTO @InternalID, @Employee_InternalID, @PrimaryFlag, @Type, @Value, 
										   @CreatedBy, @ModifiedBy, @CreatedDate, @ModifiedDate;

	WHILE @@FETCH_STATUS = 0
		BEGIN
			
			INSERT INTO Contact_TRN VALUES (@RequestID, @InternalID, @Employee_InternalID, @PrimaryFlag, @Type, @Value, 
											@CreatedBy, @ModifiedBy, @CreatedDate, @ModifiedDate)

			FETCH NEXT FROM ContactListCursor INTO @InternalID, @Employee_InternalID, @PrimaryFlag, @Type, @Value, 
												   @CreatedBy, @ModifiedBy, @CreatedDate, @ModifiedDate;
		END
	CLOSE ContactListCursor;
	
	DEALLOCATE ContactListCursor;		

END