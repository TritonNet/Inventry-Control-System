INSERT INTO Cashier VALUES('CSEGGG01','Kushan Hasithe Fernando','97/B,Elwala,Ukuwela','861340660v','1986/5/13','Male','+94662244524','kushan_hasithe@yahoo.com')





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

SELECT CatName FROM Catagory WHERE CatName='Soap'

select count(Company) FROM Suppliers WHERE Company='ABC'

DELETE FROM Suppliers WHERE Company='aa'

SELECT Company FROM Suppliers

alter table Suppliers drop column No

