﻿CREATE TABLE [dbo].[Employee_MST]
(
	[InternalID]   UNIQUEIDENTIFIER	 NOT NULL PRIMARY KEY,
	[EmployeeID]   VARCHAR(15)		 NOT NULL,
	[FirstName]    VARCHAR(20)		 NOT NULL,
	[LastName]     VARCHAR(20)		 NOT NULL,
	[MiddleName]   VARCHAR(20)		 NULL,
	[Suffix]       VARCHAR(5)		 NULL,
	[Gender]	   VARCHAR(6)		 NOT NULL,
	[Birthdate]    DATETIME			 NOT NULL,
	[PlaceOfBirth] VARCHAR(30)		 NOT NULL,
	[Nationality]  VARCHAR(20)		 NOT NULL,
	[Religion]	   VARCHAR(20)		 NOT NULL,
	[CivilStatus]  VARCHAR(9)		 NOT NULL, 
	[M_FirstName]  VARCHAR(20)		 NOT NULL,
	[M_LastName]   VARCHAR(20)		 NOT NULL,
	[M_MiddleName] VARCHAR(20)		 NULL,
	[M_Suffix]     VARCHAR(5)		 NULL,
	[M_Birthdate]  DATETIME		     NOT NULL,
	[M_ContactNo]  VARCHAR(11)		 NULL,
	[F_FirstName]  VARCHAR(20)		 NOT NULL,
	[F_LastName]   VARCHAR(20)		 NOT NULL,
	[F_MiddleName] VARCHAR(20)		 NULL,
	[F_Suffix]     VARCHAR(5)		 NULL,
	[F_Birthdate]  DATETIME		     NOT NULL,
	[F_ContactNo]  VARCHAR(11)		 NULL,
    [Status]       INT				 NOT NULL, 
    [CreatedBy]    UNIQUEIDENTIFIER	 NOT NULL, 
    [ModifiedBy]   UNIQUEIDENTIFIER	 NULL,
    [CreatedDate]  DATETIME			 NOT NULL, 
    [ModifiedDate] DATETIME			 NULL
)
