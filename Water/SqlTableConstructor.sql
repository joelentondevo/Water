﻿-- TABLES

CREATE TABLE Product (
	ID int NOT NULL PRIMARY KEY,
	ProductName varchar(100) NOT NULL,
	ProductType int NOT NULL
)

CREATE TABLE UserRole (
	ID int NOT NULL PRIMARY KEY,
	UserID int NOT NULL,
	RoleID int NOT NULL
)

CREATE TABLE Roles (
	ID int NOT NULL PRIMARY KEY,
	RoleName varchar(100) NOT NULL
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

CREATE TABLE Basket (
	ID int NOT NULL PRIMARY KEY,
	UserID int NOT NULL,
	BasketType int NOT NULL,
)

CREATE TABLE BasketItem (
	ID int NOT NULL PRIMARY KEY,
	BasketID int NOT NULL,
	ProductID int NOT NULL,
	Quantity int NOT NULL,
	DateAdded DateTime NOT NULL
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