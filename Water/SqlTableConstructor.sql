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

CREATE TABLE TaskQueue (
	ID int NOT NULL IDENTITY PRIMARY KEY,
	TaskType varchar(50) NOT NULL,
	TaskData varchar(MAX) NOT NULL,
	DateCreated DateTime NOT NULL,
	ScheduledStart DateTime NOT NULL,
	TaskPriority INT NOT NULL,
)

CREATE TABLE TaskExecutionLog (
	ID int NOT NULL IDENTITY PRIMARY KEY,
	TaskID int NOT NULL,
	TaskType varchar(50) NOT NULL,
	TaskData varchar(MAX),
	TaskStatus varchar(50) NOT NULL,
	StartedAt DateTime NOT NULL,
	CompletedAt DateTime,
	Duration float,
	ErrorMessage varchar(MAX),
	DateLogCreated DateTime NOT NULL,
)

CREATE TABLE ProductOrder (
	ID int NOT NULL IDENTITY PRIMARY KEY,
	UserID int NOT NULL,
	OrderDate DateTime NOT NULL,
	OrderType int NOT NULL
)

CREATE TABLE ProductOrderDetail(
	ID int NOT NULL IDENTITY PRIMARY KEY,
	OrderID int NOT NULL,
	ProductID int NOT NULL,
	Price Decimal NOT NULL,
	Quantity int NOT NULL
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
BEGIN
    IF NOT EXISTS (
        SELECT 1 FROM Basket WHERE UserID = @UserID
    )
    BEGIN
        INSERT INTO Basket (UserID, BasketType)
        VALUES (@UserID, 1);
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

CREATE PROCEDURE p_GetLibraryProductsByUserId_f
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

CREATE PROCEDURE p_ScheduleTask_i
	@TaskType varchar(50),
	@TaskData varchar(MAX),
	@TaskName varchar(50),
	@ScheduledStart DATETIME,
	@TaskPriority INT

	AS
	BEGIN
	INSERT INTO TaskQueue (TaskType, TaskData, TaskName, DateCreated, ScheduledStart, TaskPriority, TaskStatus)
		VALUES (@TaskType, @TaskData, @TaskName, GETDATE(), @ScheduledStart, @TaskPriority, 'Scheduled');
	END

CREATE PROCEDURE p_GetNextTaskByPriority_f
	AS 
	BEGIN
		SET NOCOUNT ON;
		DECLARE @TaskID int
	
		BEGIN TRY
			BEGIN TRANSACTION
				SELECT TOP 1 @TaskID = ID FROM TaskQueue 
				WHERE GETDATE() > ScheduledStart AND TaskStatus = 'Scheduled'
				ORDER BY TaskPriority DESC
				IF @TaskID IS NOT NULL
				BEGIN
					UPDATE TaskQueue
					SET TaskStatus = 'Queued' 
					WHERE ID = @TaskID
				END
				SELECT * FROM TaskQueue 
				WHERE ID = @TaskID;
			COMMIT;
		END TRY
		BEGIN CATCH
		ROLLBACK;
		SELECT ERROR_NUMBER() AS ErrorNumber, ERROR_MESSAGE() as ErrorMessage;
		END CATCH
	END;

CREATE PROCEDURE p_LogTaskComplete_i
	@TaskID int, 
	@TaskType varchar(50), 
	@TaskData varchar(max), 
	@TaskStatus varchar(50),
	@StartedAt DateTime,
	@CompletedAt DateTime,
	@Duration Float,
	@DateLogCreated DateTime
	AS
	INSERT INTO TaskExecutionLog (TaskID, TaskType, TaskData, TaskStatus, StartedAt, CompletedAt, Duration, DateLogCreated)
		VALUES (@TaskID, @TaskType, @TaskData, @TaskStatus, @StartedAt, @CompletedAt, @Duration, @DateLogCreated);

CREATE PROCEDURE p_LogTaskFailed_i
	@TaskID int, 
	@TaskType varchar(50), 
	@TaskData varchar(max), 
	@TaskStatus varchar(50),
	@StartedAt DateTime,
	@CompletedAt DateTime,
	@Duration Float,
	@ErrorMessage varchar(max),
	@DateLogCreated DateTime
	AS
	INSERT INTO TaskExecutionLog (TaskID, TaskType, TaskData, TaskStatus, StartedAt, CompletedAt, Duration, ErrorMessage, DateLogCreated)
		VALUES (@TaskID, @TaskType, @TaskData, @TaskStatus, @StartedAt, @CompletedAt, @Duration, @ErrorMessage, @DateLogCreated);

CREATE PROCEDURE p_AddOrderEntry_i
	@UserID int,
	@OrderDate DateTime,
	@OrderType int
	AS
	BEGIN
	INSERT INTO ProductOrder (UserID, OrderDate, OrderType)
		Values (@UserID, @OrderDate, @OrderType);

	SELECT * FROM ProductOrder WHERE UserID = @UserID AND OrderDate = @OrderDate AND OrderType = @OrderType
	END

CREATE PROCEDURE p_AddOrderDetailEntry_i
	@OrderID int, 
	@ProductID int,
	@Price decimal,
	@Quantity int
	AS
	BEGIN
	INSERT INTO ProductOrderDetail (OrderID, ProductID, Price, Quantity)
		VALUES (@OrderID, @ProductID, @Price, @Quantity)
	END