CREATE DATABASE PAYSETT;
GO
USE PAYSETT;
GO
---------------------------------------------------------------------------------
CREATE TABLE Category (
  CategoryName nvarchar(50) primary key,
);



CREATE TABLE Product (
  ID int IDENTITY(1,1) primary key,
  NameP nvarchar(100) NOT NULL,
  CodeP nvarchar(20) NOT NULL,
  DescriptionP nvarchar(500) NOT NULL,
  QuantityP int NOT NULL,
  UnitCostP Decimal(20,2) NOT NULL,
  CategoryP nvarchar(50) NOT NULL,
  CONSTRAINT fk_Category FOREIGN KEY (CategoryP) REFERENCES Category (CategoryName)
);
------------------------------------------------------------------------------------
INSERT INTO Category VALUES('Electronics');
INSERT INTO Category VALUES('Cars');
INSERT INTO Product VALUES('PC C740','P001', 'Laptop touchscreen', 10, 950, 'Electronics');
-------------------------------------------------------------------------------------
Create Procedure SP_Get_Products  
AS  
Begin  
SELECT  p.CodeP, c.CategoryName, p.NameP, p.QuantityP, p.UnitCostP
FROM Product p
INNER JOIN Category c
ON p.CategoryP = c.CategoryName
End  

EXECUTE SP_Get_Products
--***************************************
Create Procedure SP_Category_Exist    
@Category nvarchar(50)  
AS  
Begin 

SELECT c.CategoryName 
FROM Category c
WHERE c.CategoryName = @Category;
End

EXECUTE SP_Category_Exist
--*********************************************
Create Procedure SP_Create_Category    
@Category nvarchar(50)  
AS  
Begin 

INSERT INTO Category values(@Category);
End
--**********************************************
Create Procedure SP_Product_Ins  
@Name nvarchar(100),  
@Code nvarchar(20),  
@Description  nvarchar(500), 
@Quantity int,
@UnitCost Decimal(20,2),
@Category nvarchar(50)
AS  
Begin  
Insert into Product 
(NameP, CodeP, DescriptionP, QuantityP, UnitCostP, CategoryP) Values  
(@Name,@Code,@Description, @Quantity, @UnitCost, @Category)  
End 