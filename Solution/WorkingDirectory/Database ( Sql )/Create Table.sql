create table Suppliers
(	
	Names varchar(50),
	Company varchar(50),
	OfficeAddress varchar(100),
	ResidentialAddress varchar(100),
	TPOffice varchar(100),
	TPResidential varchar(100),
	TPMobile varchar(100),
	Fax varchar(100),
	Email varchar(100),
	Web varchar(100),
)
GO

create table Catagory
(
	CatName varchar(100),
	Descriptions varchar(500),
	Supplier1 varchar(50),
	Supplier2 varchar(50),
	Supplier3 varchar(50)
)
GO

create table SubCatagory
(
	Catagory varchar(100),
	SubCatagory varchar(100),
	Descriptions varchar(500),
	Supplier1 varchar(50),
	Supplier2 varchar(50),
	Supplier3 varchar(50),
	Units varchar(20),	
)
GO

Create table ItemList
(
	ItemNo varchar(50),
	Descriptions varchar(500),
	Units varchar(20),
	Catagory varchar(100),
	SubCatagory varchar(100),
	StockPrice money,
	SalesPrice money,
	Discount int,
	UnitsInStock int,
	ROL int
)
GO

create table Transactions
(
	TransactionID varchar(20),
	TotalAmount money,
	Discount money,
	TraDateTime DateTime,	
	CashierID varchar(10),
	NoOfItems int,
	Profit money
)
GO

Create table InvoiceDetails
(
	TransactionID varchar(20),
	ItemNo varchar(50),
	Descriptions varchar(500),	
	Qty varchar(30),
	Units varchar(50),
	Catagory varchar(100),
	SubCatagory varchar(100),
	ItemPrice money,
	Discount money,
	TotalAmt money,
	Profit money
)
GO

Create table Cashier
(	
	CashierID varchar(30),
	CashierName varchar(100),
	Address varchar(100),
	NIC varchar(20),
	BirthDate datetime,
	Gender varchar(10),
	TelePhone varchar(30),
	Email varchar(50),	
)
GO
