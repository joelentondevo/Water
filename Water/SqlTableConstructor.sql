-- TABLES

CREATE TABLE Product (
	ID int NOT NULL IDENTITY PRIMARY KEY,
	ProductName varchar(100) NOT NULL,
	ProductType int NOT NULL
)

CREATE TABLE UserRole (
	ID int NOT NULL IDENTITY PRIMARY KEY,
	UserID int NOT NULL,
	RoleID int NOT NULL
)

CREATE TABLE Roles (
	ID int NOT NULL IDENTITY PRIMARY KEY,
	RoleName varchar(100) NOT NULL
)

CREATE TABLE ProductListing (
	ID int NOT NULL IDENTITY PRIMARY KEY,
	ProductID int NOT NULL,
	Price Decimal NOT NULL,
	StartTime DateTime,
	EndTime DateTime
	)

CREATE TABLE UserAuthentication (
	ID int NOT NULL IDENTITY PRIMARY KEY,
	Username varchar(100) NOT NULL,
	Password varchar(100) NOT NULL
)

CREATE TABLE Basket (
	ID int IDENTITY NOT NULL PRIMARY KEY,
	UserID int NOT NULL,
	BasketType int NOT NULL,
)

CREATE TABLE BasketItem (
	ID int IDENTITY NOT NULL PRIMARY KEY,
	BasketID int NOT NULL,
	ProductID int NOT NULL,
	Quantity int NOT NULL,
	DateAdded DateTime NOT NULL
)
CREATE TABLE ProductLibrary (
	ID int NOT NULL IDENTITY PRIMARY KEY,
	ProductID int NOT NULL,
	UserID int NOT NULL,
	DateAdded DateTime,
	ProductKey VarChar(50) NOT NULL,
	)

CREATE TABLE ProductKey (
	ID int NOT NULL IDENTITY PRIMARY KEY,
	ProductID int NOT NULL,
	ProductKey VarChar(50) NOT NULL,
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

CREATE PROCEDURE p_GenerateUserBasket_f
    @UserID INT
AS
BEGIN
    -- Check if a basket already exists
    IF NOT EXISTS (
        SELECT 1 FROM Basket WHERE UserID = @UserID
    )
    BEGIN
        -- Insert new basket only if none exists
        INSERT INTO Basket (UserID, BasketType)
        VALUES (@UserID, 1); -- Assuming 1 is the default basket type
    END
END;

CREATE PROCEDURE p_AddItemToBasket_f
	@UserID int,
	@ProductID int,
	@Quantity int
	AS
	BEGIN
	Declare @BasketID int;

	SELECT @BasketID = ID FROM Basket WHERE UserID = @UserID;

	IF EXISTS (Select 1 From BasketItem Where BasketID = @BasketID And ProductID = @ProductID)
	BEGIN
		UPDATE BasketItem
		SET Quantity = Quantity + @Quantity
		WHERE BasketID = @BasketID AND ProductID = @ProductID;
	END
	ELSE
	BEGIN
		INSERT INTO BasketItem (BasketID, ProductID, Quantity, DateAdded)
		VALUES (@BasketID, @ProductID, @Quantity, GETDATE());
	END
	END;

CREATE PROCEDURE p_RemoveItemFromBasket_f
    @UserID INT,
    @ProductID INT
AS
BEGIN
    DECLARE @CurrentQuantity INT;
    
    SELECT @CurrentQuantity = Quantity
    FROM BasketItem
    WHERE BasketID = (SELECT ID FROM Basket WHERE UserID = @UserID)
    AND ProductID = @ProductID;

    IF @CurrentQuantity = 1
    BEGIN
        DELETE FROM BasketItem
        WHERE BasketID = (SELECT ID FROM Basket WHERE UserID = @UserID)
        AND ProductID = @ProductID;
    END
    ELSE
    BEGIN
        UPDATE BasketItem
        SET Quantity = Quantity - 1
        WHERE BasketID = (SELECT ID FROM Basket WHERE UserID = @UserID)
        AND ProductID = @ProductID;
    END
END;

CREATE PROCEDURE p_ClearBasket_f
	@UserID INT
AS
    BEGIN
        DELETE FROM BasketItem
        WHERE BasketID = (SELECT ID FROM Basket WHERE UserID = @UserID)
    END

CREATE PROCEDURE p_GetStoreItem_f
	@ProductID int
	AS
	SELECT * FROM ProductListing
	WHERE ProductID = @ProductID;

CREATE PROCEDURE p_GetBasketItems_f
	@UserID int
AS
BEGIN
	DECLARE @BasketID INT;
	SELECT @BasketID = ID FROM Basket WHERE UserID = @UserID;
	SELECT * FROM BasketItem
	WHERE BasketID = @BasketID;
END;

CREATE PROCEDURE p_GetProduct_f
	@ProductID int
	AS
	SELECT * FROM Product
	WHERE ID = @ProductID;

Alter PROCEDURE p_GetLibraryProductsByUserId_f
	@UserID int
	AS 
	SELECT lp.ProductKey, lp.DateAdded, lp.ProductId, p.Name AS ProductName, p.Type AS ProductType FROM LibraryProduct lp JOIN Product p ON lp.ProductId = p.ProductId WHERE lp.UserId = @UserId

CREATE PROCEDURE p_RemoveProductFromUser_f
	@UserID int,
	@ProductID int 
	AS
	DELETE From ProductLibrary
	WHERE UserID = @UserID AND ProductID = @ProductID

CREATE PROCEDURE p_AddProductToUser_f
	@UserID int, 
	@ProductID int, 
	@ProductKey varchar
	AS
	INSERT INTO ProductLibrary (UserID, ProductID, ProductKey, DateAdded)
		VALUES (@UserID, @ProductID, @ProductKey, GETDATE());