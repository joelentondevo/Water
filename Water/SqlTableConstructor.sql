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
	Username varchar(50) NOT NULL,
	Password varchar(50) NOT NULL
)
