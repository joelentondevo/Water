-- TABLES

CREATE TABLE Product (
	ID int NOT NULL PRIMARY KEY,
	ProductName varchar(100) NOT NULL,
	ProductType int NOT NULL
)

CREATE TABLE ProductListing (
	ID int NOT NULL PRIMARY KEY,
	ProductID int NOT NULL,
	Price Decimal NOT NULL,
	StartTime DateTime,
	EndTime DateTime
	)

CREATE TABLE UserAuthentication (
	ID int NOT NULL PRIMARY KEY,
	Username varchar(100) NOT NULL,
	Password varchar(100) NOT NULL
)

-- STORED PROCEDURES

CREATE PROCEDURE p_GetAllStoreItems_f

AS
	SELECT * from  ProductListing

CREATE PROCEDURE p_AddAuthenticationDetails_f
		@Username varchar(100),
		@Password varchar(100)
AS

	INSERT INTO UserAuthentication (Username, Password)
	VALUES (@Username, @Password)
CREATE PROCEDURE p_FetchAuthenticationDetails_f
		@Username varchar(100)
AS
	SELECT * FROM UserAuthentication
	WHERE Username = @Username