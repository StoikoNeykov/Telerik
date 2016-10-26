## 06. Transact SQL
### _Homework_

1.	_Create a database with two tables: `Persons(Id(PK), FirstName, LastName, SSN)` and `Accounts(Id(PK), PersonId(FK), Balance)`._
	*	_Insert few records for testing._
	*	_Write a stored procedure that selects the full names of all persons._

			CREATE DATABASE HomeworkDB
				GO

			CREATE TABLE Persons
				(
					Id INT NOT NULL IDENTITY PRIMARY KEY,
					FIrstName NVARCHAR(50) NOT NULL,
					LastName NVARCHAR (50) NOT NULL,
					SSN VARCHAR(10) NOT NULL
				)	
				GO
			
			CREATE TABLE Accounts
				(
					Id INT NOT NULL IDENTITY,
					PersonId INT FOREIGN KEY REFERENCES Persons (Id),
					Balance MONEY NOT NULL
				)
				GO

			INSERT INTO Persons (FIrstName, LastName, SSN)
				VALUES
					('Pesho', 'Georgiev', '123321123'),
					('Georgi', 'Petkov', '234234234'),
					('Stamat', 'Haralampiev', '090909099'),
					('Rosen', 'Dimitrov', '566565656')
				GO

			INSERT INTO Accounts (PersonId, Balance)
				VALUES
					(2, 20),
					(1, 20777),
					(3, 2880.72),
					(4, 3021.45)
				GO

			CREATE PROC usp_GetFullNames
				AS
					SELECT FIrstName + ' ' + LastName AS FullName FROM Persons
				GO

2.	_Create a stored procedure that accepts a number as a parameter and returns all persons who have more money in their accounts than the supplied number._

			CREATE PROC usp_Persons_WithMoreThen
				@money MONEY
				AS 
					SELECT p.FIrstName, p.LastName, a.Balance
					FROM Persons p
					JOIN Accounts a
						ON a.PersonId = p.Id
							WHERE a.Balance > @money
						ORDER BY a.Balance DESC

3.	_Create a function that accepts as parameters – sum, yearly interest rate and number of months._
	*	_It should calculate and return the new sum._
	*	_Write a `SELECT` to test whether the function works as expected._

			CREATE FUNCTION ufn_ApllyInterestRate
				(@sum MONEY, @interestRate DECIMAL(8, 3), @months INT)
				RETURNS MONEY
				AS
				BEGIN 
					DECLARE @result MONEY = @sum*(POWER(1 + @interestRate/12,@months))
					RETURN @result
				END
				GO

4.	_Create a stored procedure that uses the function from the previous example to give an interest to a person's account for one month._
	*	_It should take the `AccountId` and the interest rate as parameters._

			CREATE PROC usp_ApplyInterestRateForOneMonth
				@AccountId INT,
				@InterestRate DECIMAL(8,3)
				AS
					UPDATE Accounts
					SET Balance = dbo.ufn_ApllyInterestRate(Balance, @InterestRate, 1)
					WHERE id = @AccountId
				GO

5.	_Add two more stored procedures `WithdrawMoney(AccountId, money)` and `DepositMoney(AccountId, money)` that operate in transactions._

	CREATE PROC usp_WithdrawMoney
		@accountId int,
		@amount money = 0
		AS
			BEGIN TRAN
				UPDATE a
				SET a.Balance = a.Balance - @amount
				FROM Accounts AS a
				WHERE a.Id = @accountId
			COMMIT TRAN
		GO

	CREATE PROC usp_DepositMoney
		@accountId int,
		@amount money = 0
		AS
			BEGIN TRAN
				UPDATE a
				SET a.Balance = a.Balance + @amount
				FROM Accounts AS a
				WHERE a.Id = @accountId
			COMMIT TRAN
		GO

6.	_Create another table – `Logs(LogID, AccountID, OldSum, NewSum)`._
	*	_Add a trigger to the `Accounts` table that enters a new entry into the `Logs` table every time the sum on an account changes._

			CREATE TABLE Logs
				(
					LogID int NOT NULL IDENTITY PRIMARY KEY,
					AccountID int,
					OldSum money,
					NewSum money,
					CONSTRAINT FK_Logs_Accounts FOREIGN KEY (AccountID)
					REFERENCES Accounts(Id)
				)
				GO

			CREATE TRIGGER TR_AccountsUpdate ON Accounts FOR UPDATE
				AS
					INSERT INTO Logs(AccountID, OldSum, NewSum)
					SELECT i.Id, d.Balance, i.Balance
					FROM inserted AS i
					JOIN deleted AS d
						ON i.Id = d.Id
				GO

			UPDATE Accounts
				SET Balance = Balance + 100
				WHERE Id = 3
				GO

7.	_Define a function in the database `TelerikAcademy` that returns all Employee's names (first or middle or last name) and all town's names that are comprised of given set of letters._
	*	_Example_: '`oistmiahf`' will return '`Sofia`', '`Smith`', … but not '`Rob`' and '`Guy`'.

			USE TelerikAcademy
				GO

			CREATE FUNCTION ufn_CheckName (@nameToCheck NVARCHAR(50),@letters NVARCHAR(50)) RETURNS INT
				AS
				BEGIN
						DECLARE @i INT = 1
						DECLARE @currentChar NVARCHAR(1)
						WHILE (@i <= LEN(@nameToCheck))
							BEGIN
								SET @currentChar = SUBSTRING(@nameToCheck,@i,1)
									IF (CHARINDEX(LOWER(@currentChar),LOWER(@letters)) <= 0) 
										BEGIN  
											RETURN 0
										END
								SET @i = @i + 1
							END
						RETURN 1
				END
				GO
								
			CREATE FUNCTION ufn_CheckIfNameConsistsOfLetters (@searchString NVARCHAR(200)) 
				RETURNS @T TABLE (Name nvarchar(200))
				AS
				BEGIN
				DECLARE employeeCursor CURSOR READ_ONLY FOR
					(SELECT e.FirstName, e.LastName, t.Name FROM Employees e
						JOIN Addresses a ON e.AddressID = a.AddressID
						JOIN Towns t ON a.TownID=t.TownID)
				OPEN employeeCursor
				DECLARE @firstName NVARCHAR(200), 
				@lastName NVARCHAR(200), 
				@town NVARCHAR(200)
				DECLARE @tempTable TABLE (Name nvarchar(200))
				FETCH NEXT FROM employeeCursor INTO @firstName, @lastName, @town
				WHILE @@FETCH_STATUS = 0
				BEGIN
						DECLARE @i INT = 1
						DECLARE @match nvarchar(200) = NULL
						DECLARE @currentChar NVARCHAR(1)
						IF (dbo.ufn_CheckName(@firstName, @searchString) = 1)
							BEGIN
								SET @match = @firstName
							END
						IF (dbo.ufn_CheckName(@lastName, @searchString) = 1)
							BEGIN
								SET @match = @lastName
							END
						IF (dbo.ufn_CheckName(@town, @searchString) = 1)
							BEGIN
								SET @match = @town
							END
						IF @match IS NOT NULL
							INSERT INTO @tempTable
							VALUES (@match)
					FETCH NEXT FROM employeeCursor INTO @firstName, @lastName, @town
				END
				CLOSE employeeCursor
				DEALLOCATE employeeCursor
				INSERT INTO @T
				SELECT DISTINCT Name FROM @tempTable
				RETURN
				END
				GO

8.	_Using database cursor write a T-SQL script that scans all employees and their addresses and prints all pairs of employees that live in the same town._

		USE TelerikAcademy
			GO

		DECLARE employeeCursor CURSOR READ_ONLY FOR
			SELECT 
				emp1.FirstName + ' ' + emp1.LastName AS [First Employee], 
				t1.Name AS Town, 
				emp2.FirstName + ' ' + emp2.LastName AS [Second Employee]
			FROM Employees emp1, Employees emp2, Addresses a1, Towns t1, Addresses a2, Towns t2
				WHERE 
					emp1.AddressID = a1.AddressID AND 
					a1.TownID = t1.TownID AND 
					emp2.AddressID = a2.AddressID AND 
					a2.TownID = t2.TownID AND 
					t1.TownID = t2.TownID AND 
					emp1.EmployeeID != emp2.EmployeeID
				ORDER BY [First Employee], [Second Employee]
			OPEN employeeCursor
			DECLARE @firstEmployee nvarchar(200), 
					@secondEmployee nvarchar(200), 
					@townName nvarchar(100)
			FETCH NEXT FROM employeeCursor INTO @firstEmployee, @townName, @secondEmployee
			WHILE @@FETCH_STATUS = 0
				BEGIN
					PRINT @firstEmployee + ' and ' + @secondEmployee + ' both live in ' + @townName;
					FETCH NEXT FROM employeeCursor 
					INTO @firstEmployee, @townName, @secondEmployee
				END
			CLOSE employeeCursor
			DEALLOCATE employeeCursor

9.	_*Write a T-SQL script that shows for each town a list of all employees that live in it._
	*	_Sample output_:	
```sql
Sofia -> Martin Kulov, George Denchev
Ottawa -> Jose Saraiva
…
```

			USE TelerikAcademy
				GO

			CREATE TABLE #UsersTowns (ID INT IDENTITY, FullName NVARCHAR(50), TownName NVARCHAR(50))
				INSERT INTO #UsersTowns
				SELECT e.FirstName + ' ' + e.LastName, t.Name
								FROM Employees e
										INNER JOIN Addresses a
												ON a.AddressID = e.AddressID
										INNER JOIN Towns t
												ON t.TownID = a.TownID
								GROUP BY t.Name, e.FirstName, e.LastName
				DECLARE @name NVARCHAR(50)
				DECLARE @town NVARCHAR(50)
				
				DECLARE employeeCursor CURSOR READ_ONLY FOR
						SELECT DISTINCT ut.TownName
								FROM #UsersTowns ut     
				
				OPEN employeeCursor
				FETCH NEXT FROM employeeCursor
					INTO @town
				
					WHILE @@FETCH_STATUS = 0
						BEGIN
							DECLARE @empName nvarchar(MAX);
							SET @empName = N'';
							SELECT @empName += ut.FullName + N', '
							FROM #UsersTowns ut
							WHERE ut.TownName = @town
							PRINT @town + ' -> ' + LEFT(@empName,LEN(@empName)-1);
							FETCH NEXT FROM employeeCursor INTO @town
						END
				CLOSE employeeCursor
				DEALLOCATE employeeCursor
				DROP TABLE #UsersTowns

10.	_Define a .NET aggregate function `StrConcat` that takes as input a sequence of strings and return a single string that consists of the input strings separated by '`,`'._
	*	_For example the following SQL statement should return a single string:_

```sql
SELECT StrConcat(FirstName + ' ' + LastName)
FROM Employees
```
			USE TelerikAcademy
				GO

			IF NOT EXISTS (
					SELECT value
					FROM sys.configurations
					WHERE name = 'clr enabled' AND value = 1
				)
				BEGIN
					EXEC sp_configure @configname = clr_enabled, @configvalue = 1
					RECONFIGURE
				END
				GO

			IF (OBJECT_ID('dbo.concat') IS NOT NULL) 
					DROP Aggregate concat; 
				GO 

			IF EXISTS (SELECT * FROM sys.assemblies WHERE name = 'concat_assembly') 
					DROP assembly concat_assembly; 
				GO    

			CREATE Assembly concat_assembly 
				AUTHORIZATION dbo 
				FROM 'D:\Programming\Telerik-Academy\Databases Homeworks\Transact SQL\SqlStringConcatenation.dll' --- CHANGE THE LOCATION (SAME AS THIS .sql FILE)
				WITH PERMISSION_SET = SAFE; 
				GO 

			CREATE AGGREGATE dbo.concat ( 
					@Value NVARCHAR(MAX),
					@Delimiter NVARCHAR(4000) 
				) 
					RETURNS NVARCHAR(MAX) 
					EXTERNAL Name concat_assembly.concat; 
				GO 

			SELECT dbo.concat(FirstName + ' ' + LastName, ', ')
				FROM Employees
				GO

			DROP Aggregate concat; 
				DROP assembly concat_assembly; 
				GO