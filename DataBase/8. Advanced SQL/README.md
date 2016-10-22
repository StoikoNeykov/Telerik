## 05. Advanced SQL
### _Homework_

1.	_Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company._     
	*	_Use a nested `SELECT` statement._   

			SELECT FirstName + ' ' + LastName AS Employee, Salary
				FROM Employees
				WHERE Salary =
					(SELECT MIN(Salary) FROM Employees)

2.	_Write a SQL query to find the names and salaries of the employees that have a salary that is up to 10% higher than the minimal salary for the company._   

		SELECT FirstName + ' ' + LastName AS Employee, Salary
			FROM Employees
				WHERE Salary <
					((SELECT MIN(Salary) FROM Employees) * 1.1) 


3.	_Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department._   
	*	_Use a nested `SELECT` statement._  

			SELECT e.FirstName, e.LastName, d.Name AS Department, e.Salary
				FROM Employees e
				RIGHT OUTER JOIN Departments d
					ON d.DepartmentID = e.DepartmentID
						WHERE Salary = 
							(SELECT MIN(Salary) FROM Employees 
								WHERE DepartmentID = e.DepartmentID)
				ORDER BY e.DepartmentID

4.	_Write a SQL query to find the average salary in the department #1._ 

		SELECT AVG(Salary) AS AVERAGE
			FROM Employees
			WHERE DepartmentID = 1

5.	_Write a SQL query to find the average salary  in the "Sales" department._   

		SELECT AVG(Salary) AS AVERAGE
			FROM Employees e, Departments d
			WHERE e.DepartmentID = d.DepartmentID 
				AND d.Name = 'Sales'
   
6.	_Write a SQL query to find the number of employees in the "Sales" department._ 

		SELECT COUNT(e.EmployeeID) 
			FROM Employees e
				INNER JOIN Departments d
					ON e.DepartmentID = d.DepartmentID
				WHERE d.Name = 'Sales'	

7.	_Write a SQL query to find the number of all employees that have manager._  

		SELECT COUNT(e.EmployeeID) 
			FROM Employees e
				WHERE e.ManagerID IS NOT NULL	

8.	_Write a SQL query to find the number of all employees that have no manager._  

		SELECT COUNT(e.EmployeeID) 
			FROM Employees e
				WHERE e.ManagerID IS NULL

9.	_Write a SQL query to find all departments and the average salary for each of them._ 

		SELECT d.Name,
			AVG(e.Salary) as 'Average Salary'
				FROM Employees e JOIN Departments d
					ON e.DepartmentID = d.DepartmentID
			GROUP BY d.Name

10.	_Write a SQL query to find the count of all employees in each department and for each town._   

		SELECT d.Name AS DeptName, t.Name AS Town, COUNT(e.EmployeeID) AS EmpCount
			FROM Employees e 
				JOIN Departments d
					ON e.DepartmentID = d.DepartmentID
				JOIN Addresses a
					ON a.AddressID = e.AddressID
				JOIN Towns t
					ON a.TownID = t.TownID
			GROUP BY d.Name, t.Name, a.TownID

11.	_Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name._  

		SELECT m.FirstName, m.LastName
			FROM Employees m, Employees e
				WHERE e.ManagerID = m.EmployeeID
			GROUP BY m.FirstName, m.LastName
			HAVING COUNT(*) = 5

12.	_Write a SQL query to find all employees along with their managers. For employees that do not have manager display the value "(no manager)"._   

		SELECT e.FirstName, e.LastName, ISNULL(m.FirstName + ' ' + m.LastName, '(no manager)') AS Manager
			FROM Employees e
			LEFT OUTER JOIN Employees m
				ON e.ManagerID = m.EmployeeID

13.	_Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. Use the built-in `LEN(str)` function._ 

		SELECT e.FirstName, e.LastName
			FROM Employees e
			WHERE LEN(e.LastName) = 5

14.	_Write a SQL query to display the current date and time in the following format "`day.month.year hour:minutes:seconds:milliseconds`"._   
	*	_Search in Google to find how to format dates in SQL Server._   

			SELECT FORMAT(GETDATE(), 'dd.MMM.yyyy hh:m:ss:fff')
	
15.	_Write a SQL statement to create a table `Users`. Users should have username, password, full name and last login time._   
	*	_Choose appropriate data types for the table fields. Define a primary key column with a primary key constraint._    
	*	_Define the primary key column as identity to facilitate inserting records._   
	*	_Define unique constraint to avoid repeating usernames._   
	*	_Define a check constraint to ensure the password is at least 5 characters long._ 

			CREATE TABLE Users
				(
					[Id] INT NOT NULL IDENTITY PRIMARY KEY,
					[Username] NVARCHAR(50) NOT NULL UNIQUE,
					[Password] NVARCHAR(50) NOT NULL,
					[FullName] NVARCHAR(150) NOT NULL,
					[LastLogin] DATETIME NOT NULL,
					CONSTRAINT [Password] CHECK (LEN(Password) > 5)
				)

16.	_Write a SQL statement to create a view that displays the users from the `Users` table that have been in the system today._   
	*	_Test if the view works correctly._   

			CREATE VIEW TodayVisitors AS
				SELECT LastLogin FROM Users
				WHERE CONVERT(DATE, LastLogin) = CONVERT(DATE,GETDATE())

17.	_Write a SQL statement to create a table `Groups`. Groups should have unique name (use unique constraint)._   
	*	_Define primary key and identity column._  

			CREATE TABLE Groups
				(
					[Id] INT NOT NULL IDENTITY PRIMARY KEY,
					[Name] NVARCHAR(50) NOT NULL UNIQUE
				)	

18.	_Write a SQL statement to add a column `GroupID` to the table `Users`._   
	*	_Fill some data in this new column and as well in the `Groups table._   
	*	_Write a SQL statement to add a foreign key constraint between tables `Users` and `Groups` tables._  

			ALTER TABLE Users
				ADD GroupId INT
				GO
			
			ALTER TABLE Users
				ADD CONSTRAINT FK_Users_Groups
				FOREIGN KEY (GroupId)
				REFERENCES Groups(Id)
				GO
	 
19.	_Write SQL statements to insert several records in the `Users` and `Groups` tables._   
	
		INSERT INTO Groups 
			VALUES ('group1'),
					('group2'),
					('group3'),
					('group4'),
					('gropu5')
			GO
		
		INSERT INTO Users
			VALUES
				('Pesho', '123456', 'Pesho Parolata', GetDate(), 1),
				('Gosho', 'qwerty', 'Gosho Tikvata', GetDate(), 2),
				('Stamat', '123456q', 'Stamat Kubeto', GetDate(), 3)
			GO	

20.	_Write SQL statements to update some of the records in the `Users` and `Groups` tables._

		UPDATE Users
			SET [Password] = 'newPassBaby'
			WHERE [Username] = 'Pesho'

21.	_Write SQL statements to delete some of the records from the `Users` and `Groups` tables._  

		DELETE Users
			WHERE [Username] = 'Pesho'

22.	_Write SQL statements to insert in the `Users` table the names of all employees from the `Employees` table._   
	*	_Combine the first and last names as a full name._   
	*	_For username use the first letter of the first name + the last name (in lowercase)._   
	*	_Use the same for the password, and `NULL` for last login time._  

	*** Not really working coz Username should be unique 

		ALTER TABLE Users
			ALTER COLUMN [LastLogin] NVARCHAR(50) NULL 
			GO

		INSERT INTO Users
			([Username],[Password],[FullName], [LastLogin])
				SELECT LEFT(e.FirstName, 1) + LOWER(e.LastName),
					e.FirstName + ' ' + e.LastName,
					e.FirstName + ' ' + e.LastName,
					NULL
				FROM Employees e

23.	_Write a SQL statement that changes the password to `NULL` for all users that have not been in the system since 10.03.2010._  

		UPDATE Users
			SET [Password] = NULL
				WHERE DATEDIFF(DAY, LastLogin, '03.10.2010 00:00:00:000') > 0

24.	_Write a SQL statement that deletes all users without passwords (`NULL` password)._ 

		DELETE Users
			WHERE [Password] IS NULL

25.	_Write a SQL query to display the average employee salary by department and job title._ 

		SELECT AVG(e.Salary) AS AverageSalary, d.Name AS Department, e.JobTitle
			FROM Employees e
				JOIN Departments d
					ON e.DepartmentID = d.DepartmentID
			GROUP BY d.Name, e.JobTitle
			ORDER BY d.Name, e.JobTitle

26.	_Write a SQL query to display the minimal employee salary by department and job title along with the name of some of the employees that take it._ 

		SELECT e.FirstName, e.LastName, MIN(e.Salary) AS MinimalSalary, d.Name AS Department, e.JobTitle
			FROM Employees e
				JOIN Departments d
					ON e.DepartmentID = d.DepartmentID
			GROUP BY d.Name, e.JobTitle, e.FirstName, e.LastName
			ORDER BY d.Name, e.JobTitle

27.	_Write a SQL query to display the town where maximal number of employees work._  

		SELECT TOP 1 t.Name AS Town, COUNT(*) AS EmployeesCount
			FROM Employees e
				JOIN Addresses a
					ON e.AddressID = a.AddressID
				JOIN Towns t
					ON a.TownID = t.TownID
			GROUP BY t.Name
			ORDER BY EmployeesCount DESC

28.	_Write a SQL query to display the number of managers from each town._   

		SELECT t.Name AS Town, COUNT(DISTINCT e.ManagerID) AS ManagersCount
			FROM Employees e
				JOIN Addresses a
					ON e.AddressID = a.AddressID
				JOIN Towns t
					ON a.TownID = t.TownID
			GROUP BY t.Name
			ORDER BY ManagersCount DESC

29.	_Write a SQL to create table `WorkHours` to store work reports for each employee (employee id, date, task, hours, comments)._   
	*	_Don't forget to define  identity, primary key and appropriate foreign key._   
	*	_Issue few SQL statements to insert, update and delete of some data in the table._   
	*	_Define a table `WorkHoursLogs` to track all changes in the `WorkHours` table with triggers._   
		*	_For each change keep the old record data, the new record data and the command (insert / update / delete)._   

				CREATE TABLE WorkHours
				(
					[Id] INT IDENTITY PRIMARY KEY,
					[EmployeeId] INT NOT NULL,
					[Date] DATETIME,
					[Task] NVARCHAR(50),
					[Hours] INT,
					[Comments] VARCHAR(250),
					CONSTRAINT FK_WorkHours_Employees 
						FOREIGN KEY (EmployeeId) 
						REFERENCES Employees(EmployeeID)
				)	
				GO

				INSERT INTO WorkHours
					VALUES 
						(1, GETDATE(), 'Task1', 10, NULL),
						(2, GETDATE(), 'Task2', 9, NULL),
						(3, GETDATE(), 'Task3', 8, 'TODO')
					GO

				UPDATE WorkHours
					SET [Comments] = 'Doing nothing'
					WHERE [EmployeeId] = 1
					GO

				DELETE FROM WorkHours
					WHERE [Hours] = 9
					GO

				CREATE TABLE ReportsLogs
					(
						[Id] INT IDENTITY PRIMARY KEY,
						[EmployeeId] INT NOT NULL,
						[Date] DATETIME,
						[Task] NVARCHAR(50),
						[Hours] INT,
						[Comments] VARCHAR(250),
						[For] VARCHAR(50)
					)
					GO

				CREATE TRIGGER trg_WorkHours_Insert ON WorkHours
					FOR INSERT 
					AS
					INSERT INTO ReportsLogs([EmployeeId], [Date], [Task], [Hours], [Comments], [For])
						SELECT [EmployeeId], [Date], [Task], [Hours], [Comments], 'INSERT'
						FROM INSERTED
					GO

				CREATE TRIGGER trg_WorkHours_Delete ON WorkHours
					FOR DELETE 
					AS
					INSERT INTO ReportsLogs([EmployeeId], [Date], [Task], [Hours], [Comments], [For])
						SELECT [EmployeeId], [Date], [Task], [Hours], [Comments], 'DELETE'
						FROM DELETED
					GO

				CREATE TRIGGER trg_WorkHours_Update ON WorkHours
					FOR UPDATE 
					AS
					INSERT INTO ReportsLogs([EmployeeId], [Date], [Task], [Hours], [Comments], [For])
						SELECT [EmployeeId], [Date], [Task], [Hours], [Comments], 'UPDATE'
						FROM INSERTED
					GO

				INSERT INTO WorkHours
					VALUES(2, GETDATE(), 'Task2', 9, NULL)
					GO

				DELETE FROM  WorkHours 
					WHERE [Hours] = 9
					GO

				UPDATE WorkHours
					SET Comments = 'Done'
					WHERE Comments = 'TODO'

30.	_Start a database transaction, delete all employees from the '`Sales`' department along with all dependent records from the pother tables._   
	*	_At the end rollback the transaction._   

			BEGIN TRAN
				ALTER TABLE Departments
				DROP CONSTRAINT FK_Departments_Employees

				ALTER TABLE WorkHours
				DROP CONSTRAINT FK_WorkHours_Employees

				ALTER TABLE EmployeesProjects
				DROP CONSTRAINT FK_EmployeesProjects_Employees

				DELETE FROM Employees
				SELECT d.Name
				FROM Employees e
					JOIN Departments d
						ON e.DepartmentID = d.DepartmentID
				WHERE d.Name = 'Sales'
				GROUP BY d.Name
			ROLLBACK TRAN

31.	_Start a database transaction and drop the table `EmployeesProjects`._    
	*	_Now how you could restore back the lost table data?_ 

			USE TelerikAcademy

				BEGIN TRAN
					DROP TABLE EmployeesProjects
				ROLLBACK TRAN

32.	_Find how to use temporary tables in SQL Server._    
	*	_Using temporary tables backup all records from `EmployeesProjects` and restore them back after dropping and re-creating the table._   

			USE TelerikAcademy

				BEGIN TRAN
					SELECT *  INTO  #TempEmployeesProjects
					FROM EmployeesProjects

					DROP TABLE EmployeesProjects

					SELECT * INTO EmployeesPRojects
					FROM #TempEmployeesProjects
				ROLLBACK TRAN
