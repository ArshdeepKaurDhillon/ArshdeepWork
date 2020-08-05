CREATE DATABASE SALE_DB
USE SALE_DB
drop table sale
select * from customer
CREATE TABLE Sale(SaleNumber INT NOT NULL PRIMARY KEY IDENTITY(1,1),
                  SaleDate DATE NOT NULL,
				  CustomerName VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES Customer(CustomerName),
				  Salesperson VARCHAR(20) NOT NULL,
				  Subtotal VARCHAR(10) NOT NULL,
				  Gst VARCHAR(10) NOT NULL,
				  SaleTotal VARCHAR(10) NOT NULL,
				  Time time NOt nUll)
				  
		  
CREATE TABLE Customer(CustomerName VARCHAR(20) NOT NULL PRIMARY KEY,
                      Address VARCHAR(20) NOT NULL,
					  City VARCHAR(15) NOT NULL,
					  Province VARCHAR(15) NOT NULL,
					  PostalCode VARCHAR(6) NOT NULL)
               
CREATE TABLE Item(ItemCode VARCHAR(6) NOT NULL PRIMARY KEY,
                  Description VARCHAR(20) NOT NULL,
				  UnitPrice VARCHAR(10) NOT NULL,
				  Quantity varchar(10) Not Null,
				  Flag varchar(10) NOT NULL)


CREATE TABLE SaleItem(SaleNumber int not null,
			ItemCode VARCHAR(6) NOT NULL,
			Quantity varchar(6) NOT NULL,
			ItemTotal VARCHAR(10) NOT NULL)
SELECT * FROM ITEM

ALTER TABLE SaleItem 
ADD
CONSTRAINT PK_SALE_ITEM PRIMARY KEY([SaleNumber],[ItemCode]),
CONSTRAINT FK_SALE FOREIGN KEY(SaleNumber) REFERENCES Sale(SaleNumber),
CONSTRAINT FK_ITEM FOREIGN KEY(ItemCode) REFERENCES Item(ItemCode)

drop procedure AddSale

create  procedure AddSale
(@SaleDate Date = null,@CustomerName varchar(15) = null,@Salesperson varchar(15)= null,
@Subtotal VARCHAR(10) = null,@Gst VARCHAR(10) = null,@SaleTotal VARCHAR(10) = null,@Time datetime = null)
AS 
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1


IF @SaleDate IS NULL
	RAISERROR('AddSale-SaleDate PARAMETER',16,1)

ELSE IF @CustomerName IS NULL
	RAISERROR('AddSale-CustomerName',16,1)

ELSE IF @Salesperson IS NULL
	RAISERROR('AddItem-Salesperson ',16,1)
ELSE IF @Subtotal IS NULL
	RAISERROR('AddSale-Subtotal',16,1)
ELSE IF @Gst IS NULL
	RAISERROR('AddSale-Gst',16,1)


ELSE IF @SaleTotal IS NULL
	RAISERROR('AddSale-Saletotal',16,1)

ELSE IF @Time IS NULL
	RAISERROR('AddSale-Time',16,1)
ELSE
	BEGIN
		INSERT INTO Sale(SaleDate,CustomerName,Salesperson,Subtotal,Gst,SaleTotal,Time)
		VALUES(@SaleDate,@CustomerName,@Salesperson,@Subtotal,@Gst,@SaleTotal,@Time)

		IF @@ERROR = 0
			SET @ReturnCode = 0

		ELSE
			RAISERROR('ERROR IN INSERT',16,1)

	END

RETURN @ReturnCode

select * from sale


drop procedure AddSaleItem
create  procedure AddSaleItem
(@SaleNumber int = null,@ItemCode varchar(6) = null,@Quantity VARCHAR(10) = null,@ItemTotal VARCHAR(10) = null)
AS 
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

IF @SaleNumber is null
	RAISERROR('AddSaleItem procedure: SaleNumber parameter',16,1)

ELSE IF @ItemCode IS NULL
	RAISERROR('AddSaleItem-ItemCode PARAMETER',16,1)

ELSE IF @Quantity IS NULL
	RAISERROR('AddSaleItem-Quantity',16,1)


ELSE
	BEGIN
		INSERT INTO SaleItem(SaleNumber,ItemCode,Quantity,ItemTotal)
		values(@SaleNumber,@ItemCode,@Quantity,@ItemTotal)

		IF @@ERROR = 0
			SET @ReturnCode = 0

		ELSE
			RAISERROR('ERROR IN INSERT',16,1)

	END

RETURN @ReturnCode


SELECT * FROM SaleItem

EXECUTE AddSaleItem "3","1","2","21"

CREATE PROCEDURE AddItem
(@ItemCode VARCHAR(10) = NULL,@Description VARCHAR(15) = NULL,@UnitPrice varchar(10) = NULL,@Quantity varchar(10) = Null,@Flag varchar(15) = NUll)
AS 
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

IF @ItemCode IS NULL
	RAISERROR('AddItem-ItemCode PARAMETER',16,1)

ELSE IF @Description IS NULL
	RAISERROR('AddItem-Description',16,1)

ELSE IF @UnitPrice IS NULL
	RAISERROR('AddItem-UnitPrice',16,1)
ELSE IF @Quantity IS NULL
	RAISERROR('AddItem-UnitPrice',16,1)

ELSE IF @Flag IS NULL
	RAISERROR('AddItem-Flag',16,1)



ELSE
	BEGIN
		INSERT INTO Item(ItemCode,Description,UnitPrice,Quantity,Flag) VALUES(@ItemCode,@Description,@UnitPrice,@Quantity,@Flag)

		IF @@ERROR = 0
			SET @ReturnCode = 0

		ELSE
			RAISERROR('ERROR IN INSERT',16,1)

	END

RETURN @ReturnCode

execute AddItem "1","haata",'10',50,"Available"
select * from sale
EXECUTE AddSaleItem '8002','a12345','2','34'

create procedure UpdateQuantity
(@ItemCode varchar(10) = null,@Quantity varchar(10) = null)
as
DECLARE @ReturnCode Int
SET @ReturnCode = 1

IF @ItemCode is null
	RAISERROR('UpdateQuantity: ItemCode parameter',16,1)
ELSE IF @Quantity is null
	RAISERROR('UpdateQuantity: Quantity parametr',16,1)

	else
	BEGIN
		UPDATE Item
		set 	
		Quantity=@Quantity
		where ItemCode=@ItemCode
	
		IF	@@ERROR = 0
		SET @ReturnCode = 0

		ELSE
		RAISERROR('UpdateQuantity',16,1)
	end


RETURN @ReturnCode

select * from item
execute UpdateQuantity 'a12345','60'

CREATE PROCEDURE DeleteItem(@ItemCode VARCHAR(15) = NULL)
AS
DECLARE @ReturnCode INT
SET @ReturnCode = 1

IF @ItemCode IS NULL
	RAISERROR('DELETEItem-ItemCode',16,1)

ELSE
BEGIN

DELETE FROM Item WHERE ItemCode = @ItemCode

IF
@@ERROR = 0
SET @ReturnCode = 0

ELSE
RAISERROR('DELETE QUERY',16,1)

END

RETURN @ReturnCode




CREATE PROCEDURE UpdateItem
(@ItemCode varchar(6) = Null,@Description varchar(15) = NULL,@Quantity varchar(10) = Null,@UnitPrice varchar(10) = NULL)
AS
DECLARE @ReturnCode INT
SET @ReturnCode = 1

IF @ItemCode IS NULL
	RAISERROR('Procedure UPDATE-Item: ItemCode',16,1)

ELSE IF @Description IS NULL
	RAISERROR('Procedure UPDATE-Item: Quantity',16,1)

ELSE IF @Quantity IS NULL
	RAISERROR('Procedure UPDATE-Item: Quantity',16,1)

ELSE IF @UnitPrice IS NULL
	RAISERROR('Procedure UPDATE-Item: UnitPrice',16,1)
ELSE
BEGIN
	UPDATE Item
	SET 
	
	ItemCode=@ItemCode,
	Description=@Description,
	Quantity = @Quantity,
	UnitPrice=@UnitPrice
	WHERE ItemCode = @ItemCode

IF @@ERROR = 0
	SET @ReturnCode = 0

ELSE
RAISERROR('UPDATE QUERY ERROR',16,1)

END

RETURN @ReturnCode

drop procedure UpdateFlag
CREATE PROCEDURE UpdateFlag(@ItemCode varchar(6) = Null,@Flag varchar(15) = Null)
AS
DECLARE @ReturnCode INT
SET @ReturnCode = 1

IF @ItemCode IS NULL
	RAISERROR('Procedure UpdateFlag: ItemCode',16,1)

ELSE IF @Flag IS NULL
	RAISERROR('Procedure UpdateFlag: Flag',16,1)

ELSE
BEGIN
	UPDATE Item
	SET 
	
	ItemCode=@ItemCode,
	Flag = @Flag
	WHERE ItemCode = @ItemCode

IF @@ERROR = 0
	SET @ReturnCode = 0

ELSE
RAISERROR('UPDATE QUERY ERROR',16,1)

END

RETURN @ReturnCode

execute UpdateFlag '1','Available'


CREATE PROCEDURE AddCustomer
(@CustomerName VARCHAR(10) = NULL,@Address VARCHAR(15) = NULL,@City VARCHAR(15) = NULL,@Province VARCHAR(15) = NULL,
@PostalCode VARCHAR(15) = NULL)
AS 
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

IF @CustomerName IS NULL
	RAISERROR('AddCustomer-CustomerName PARAMETER',16,1)

ELSE IF @Address IS NULL
	RAISERROR('AddCustomer-Address',16,1)

ELSE IF @City IS NULL
	RAISERROR('AddCustomer-City',16,1)

ELSE IF @Province IS NULL
	RAISERROR('AddCustomer-Province',16,1)

ELSE IF @PostalCode IS NULL
	RAISERROR('AddCustomer- PostalCode',16,1)

ELSE
	BEGIN
		INSERT INTO Customer(CustomerName,Address,City,Province,PostalCode) VALUES(@CustomerName,@Address,@City,@Province,@PostalCode)

		IF @@ERROR = 0
			SET @ReturnCode = 0

		ELSE
			RAISERROR('ERROR IN INSERT',16,1)

	END

RETURN @ReturnCode

select * from sale

CREATE PROCEDURE DeleteCustomer(@CustomerName VARCHAR(15) = NULL)
AS
DECLARE @ReturnCode INT
SET @ReturnCode = 1

IF @CustomerName IS NULL
	RAISERROR('DELETECustomer-CustomerName',16,1)

ELSE
BEGIN

DELETE FROM Customer WHERE CustomerName = @CustomerName

IF
@@ERROR = 0
SET @ReturnCode = 0

ELSE
RAISERROR('DELETE QUERY',16,1)

END

RETURN @ReturnCode


select * from customer

CREATE PROCEDURE UpdateCustomer(@CustomerName VARCHAR(15) = NULL,@Address VARCHAR(15) = NULL,
@City VARCHAR(15) = NULL,@Province VARCHAR(10) = null,
@PostalCode VARCHAR(15) = NULL)
AS
DECLARE @ReturnCode INT
SET @ReturnCode = 1

IF @CustomerName IS NULL
	RAISERROR('UPDATE-CustomerName',16,1)

ELSE
BEGIN
	UPDATE Customer
	SET	Address = @Address,
	City = @City,
	Province=@Province,
	 PostalCode = @PostalCode
	WHERE CustomerName = @CustomerName

IF @@ERROR = 0
	SET @ReturnCode = 0

ELSE
RAISERROR('UPDATE QUERY ERROR',16,1)

END

RETURN @ReturnCode




CREATE PROCEDURE GetItem(@ItemCode VARCHAR(10) = NULL)
AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	IF @ItemCode IS NULL
		RAISERROR('GetItem: REQUIRED PARAMETER',16,1)

	ELSE
		BEGIN
			SELECT ItemCode,Description,UnitPrice,Quantity,Flag
			FROM Item WHERE ItemCode = @ItemCode


			IF @@ERROR  = 0
				SET @ReturnCode = 0
			ELSE
				RAISERROR('GetItem-SELECT ERROR',16,1)
			END

		RETURN @ReturnCode

execute GetItem 1

CREATE PROCEDURE GetCustomer(@CustomerName VARCHAR(10) = NULL)
AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	IF @CustomerName IS NULL
		RAISERROR('GetItem: REQUIRED PARAMETER',16,1)

	ELSE
		BEGIN
			SELECT CustomerName,Address,City,Province,PostalCode
			FROM Customer WHERE CustomerName = @CustomerName


			IF @@ERROR  = 0
				SET @ReturnCode = 0
			ELSE
				RAISERROR('GetCustomer-SELECT ERROR',16,1)
			END

		RETURN @ReturnCode


SELECT * FROM ITEM

select * from Customer



CREATE PROCEDURE GetSaleNumber(@Time time = NULL)
AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	IF @Time IS NULL
		RAISERROR('GetSaleNumber: REQUIRED PARAMETER',16,1)

	ELSE
		BEGIN
			SELECT SaleNumber
			FROM Sale WHERE time = @time


			IF @@ERROR  = 0
				SET @ReturnCode = 0
			ELSE
				RAISERROR('SaleNumber-SELECT ERROR',16,1)
			END

		RETURN @ReturnCode

create procedure  UpdateSaleItem
(@SaleNumber int = null,@ItemCode varchar(6) = null,@Quantity int = null)
AS
DECLARE @ReturnCode NT
SET @ReturnCode = 1

IF @SaleNumber IS NULL
	RAISERROR('Procedure UPDATE-SaleItem: SaleNumber',16,1)
IF @ItemCode IS NULL
	RAISERROR('Procedure UPDATE-SaleItem: ItemCode',16,1)
IF @Quantity IS NULL
	RAISERROR('Procedure UPDATE-SaleItem: Quantity',16,1)

ELSE
BEGIN
	UPDATE SaleItem
	SET 
	SaleNumber=@SaleNumber,
	ItemCode = @ItemCode,
	Quantity = @Quantity,
	ItemTotal = (select SaleItem.Quantity *  Item.UnitPrice from Item,SaleItem where Item.ItemCode = SaleItem.ItemCode
	

IF @@ERROR = 0
	SET @ReturnCode = 0

ELSE
RAISERROR('UPDATE QUERY ERROR',16,1)
END
RETURN @ReturnCode

select * from SALEITEM
Execute UpdateQuantity 'a12345',50