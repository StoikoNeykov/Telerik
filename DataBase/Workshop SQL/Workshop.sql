use NORTHWND
GO

CREATE TABLE Cities 
	(
		CityId INT NOT NULL IDENTITY PRIMARY KEY,
		Name NVARCHAR(15) NOT NULL UNIQUE
	)
	GO


INSERT INTO Cities (Name) 
	SELECT DISTINCT City FROM Employees WHERE City IS NOT NULL
	UNION 
	SELECT DISTINCT City FROM Customers WHERE City IS NOT NULL
	UNION 
	SELECT DISTINCT ShipCity FROM Orders WHERE ShipCity IS NOT NULL
	UNION
	SELECT DISTINCT City FROM Suppliers WHERE City IS NOT NULL
	GO

ALTER TABLE Customers
ADD CityId INT FOREIGN KEY REFERENCES Cities (CityId)
GO

ALTER TABLE Employees
ADD CityId INT FOREIGN KEY REFERENCES Cities (CityId)
GO

ALTER TABLE Suppliers
ADD CityId INT FOREIGN KEY REFERENCES Cities (CityId)
GO

ALTER TABLE Orders
ADD CityId INT FOREIGN KEY REFERENCES Cities (CityId)
GO

UPDATE Customers
SET CityId = c.CityId 
	FROM Cities c
	JOIN Customers cu
	ON cu.City = c.Name
GO

UPDATE Employees
SET CityId = c.CityId 
	FROM Cities c
	JOIN Employees e
	ON e.City = c.Name
GO

UPDATE Suppliers
SET CityId = c.CityId 
	FROM Cities c
	JOIN Suppliers s
	ON s.City = c.Name
GO

UPDATE Orders
SET CityId = c.CityId 
	FROM Cities c
	JOIN Orders o
	ON o.ShipCity = c.Name
GO

ALTER TABLE Orders
DROP COLUMN ShipCity
GO

CREATE TABLE Countries 
(
	CountryId INT NOT NULL IDENTITY PRIMARY KEY,
	Name NVARCHAR(15) NOT NULL UNIQUE
)
GO

ALTER TABLE Cities
ADD CountyId INT FOREIGN KEY REFERENCES Countries (CountryId)
GO

INSERT INTO Countries (Name) 
	SELECT DISTINCT Country FROM Employees WHERE Country IS NOT NULL
	UNION 
	SELECT DISTINCT Country FROM Customers WHERE Country IS NOT NULL
	UNION 
	SELECT DISTINCT ShipCountry FROM Orders WHERE ShipCountry IS NOT NULL
	UNION
	SELECT DISTINCT Country FROM Suppliers WHERE Country IS NOT NULL
	GO

UPDATE CIties
SET CountyId = c.CountryId 
	FROM Countries c
	JOIN Customers cu
	ON cu.Country = c.Name
	WHERE CIties.Name = cu.City
GO

UPDATE CIties
SET CountyId = c.CountryId 
	FROM Countries c
	JOIN Employees e
	ON e.Country = c.Name
	WHERE CIties.Name = e.City
GO

UPDATE CIties
SET CountyId = c.CountryId 
	FROM Countries c
	JOIN Suppliers s
	ON s.Country = c.Name 
	WHERE CIties.Name = s.City
GO

DROP INDEX City ON Customers
GO

ALTER TABLE Employees
DROP COLUMN City
GO

ALTER TABLE Customers
DROP COLUMN City
GO

ALTER TABLE Suppliers
DROP COLUMN City
GO

ALTER TABLE Orders
DROP COLUMN ShipCountry
GO

ALTER TABLE Employees
DROP COLUMN Country
GO

ALTER TABLE Customers
DROP COLUMN Country
GO

ALTER TABLE Suppliers
DROP COLUMN Country
GO