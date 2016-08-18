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
create table Catagory
(
	CatName varchar(100),
	Descriptions varchar(500),
	Supplier1 varchar(50),
	Supplier2 varchar(50),
	Supplier3 varchar(50)
)
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
create table Transactions
(
	TransactionID varchar(20),
	TotalAmount money,
	Discount money,
	TraDateTime DateTime,	
	CashierID varchar(10),
)
Create table InvoiceDetails
(
	TransactionNo varchar(20),
	ItemNo varchar(50),
	Descriptions varchar(500),	
	Qty varchar(30),
	Units varchar(50),
	Catagory varchar(100),
	SubCatagory varchar(100),
	ItemPrice money,
	Discount money,
	TotalAmt money
)
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


select *from Suppliers
select *from Catagory
select *from SubCatagory
select *from ItemList
select *from Transactions
select *from InvoiceDetails
select *FROM Cashier

SELECT MAX(TransactionID) FROM Transactions

insert into Transactions(TransactionID) values('HUG100000009')

select ItemNo From ItemList Where UnitsInStock>ROL

delete from Transactions --where TransactionID='HUG10000001'


SELECT *FROM Transactions WHERE  TraDateTime>'1900-12-05 00:00:00 ' AND TraDateTime < '2078-12-05 23:59:59'

select *from InvoiceDetails Where 


delete from Transactions
delete from InvoiceDetails
delete from Cashier

SELECT SUM(Qty) FROM InvoiceDetails WHERE TransactionID=
SELECT SUM(NoOfItems) FROM Transactions WHERE TraDateTime>'2007/12/03 00:00:00' AND TraDateTime < '2007/12/03 23:59:59'
SELECT COUNT(TransactionID) FROM Transactions WHERE TraDateTime>'2007/12/03 00:00:00' AND TraDateTime < '2007/12/03 23:59:59'


SELECT StockPrice, round(StockPrice,2) FROM ItemList WHERE ItemNo='LUX0001'

INSERT INTO Cashier VALUES('CSEGGG01','Kushan Hasithe Fernando','97/B,Elwala,Ukuwela','861340660v','1986/5/13','Male','+94662244524','kushan_hasithe@yahoo.com')

SELECT CatName FROM Catagory WHERE CatName='Soap'

select count(Company) FROM Suppliers WHERE Company='ABC'

DELETE FROM Suppliers WHERE Company='aa'

SELECT Company FROM Suppliers

alter table Suppliers drop column No


