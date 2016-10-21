## Structured Query Language (SQL)
### _Homework_

1.	_What is SQL? What is DML? What is DDL? Recite the most important SQL commands._ <br />
        Structured Query Language is a special-purpose programming language designed for managing data held in a relational database management system (RDBMS), or for stream processing in a relational data stream management system (RDSMS).<br />
        The Data Manipulation Language (DML) is the subset of SQL used to add, update and delete data: SELECT, INSERT, UPDATE, DELETE.<br />
        The Data Definition Language (DDL) manages table and index structure. The most basic items of DDL are the CREATE, ALTER, RENAME, DROP and TRUNCATE statements:<br />
2.	_What is Transact-SQL (T-SQL)?_<br />
        Transact-SQL (T-SQL) is Microsoft's and Sybase's proprietary extension to the SQL (Structured Query Language) used to interact with relational databases.<br />
        T-SQL expands on the SQL standard to include procedural programming, local variables, various support functions for string processing, date processing, mathematics, etc. and changes to the DELETE and UPDATE statements.<br />
        Transact-SQL is central to using Microsoft SQL Server. All applications that communicate with an instance of SQL Server do so by sending Transact-SQL statements to the server, regardless of the user interface of the application.<br />
3.	_Start SQL Management Studio and connect to the database TelerikAcademy. Examine the major tables in the "TelerikAcademy" database._<br />
        ```sql
        SELECT * FROM sysobjects WHERE xtype='U' <br />
        ```
4.	_Write a SQL query to find all information about all departments (use "TelerikAcademy" database)._<br />
        ```sql
        SELECT * FROM Departments<br />
        ```
5.	_Write a SQL query to find all department names._<br />
        ```sql
        SELECT Name FROM Departments<br />
        ```
6.	_Write a SQL query to find the salary of each employee._<br />
        ```sql
        SELECT Salary FROM Employees<br />
        ```
7.	_Write a SQL to find the full name of each employee._<br />
        ```sql
        SELECT FirstName + ' ' + MiddleName + ' ' + LastName FROM Employees<br />
        ```
8.	_Write a SQL query to find the email addresses of each employee (by his first and last name). Consider that the mail domain is telerik.com. Emails should look like “John.Doe@telerik.com". The produced column should be named "Full Email Addresses"._<br />
        ```sql
        SELECT FirstName + '.' + LastName + '@telerik.com' AS "Full Email Addresses" FROM Employees<br />
        ```
9.	_Write a SQL query to find all different employee salaries._<br />
        ```sql
        SELECT DISTINCT Salary FROM Employees<br />
        ```
10.	_Write a SQL query to find all information about the employees whose job title is “Sales Representative“._<br />
        ```sql
        SELECT * FROM Employees WHERE [JobTitle] = 'Sales Representative'<br />
        ```
11.	_Write a SQL query to find the names of all employees whose first name starts with "SA"._<br />
        ```sql
        SELECT FirstName, MiddleName, LastName FROM Employees <br />
            WHERE FirstName LIKE 'SA%' <br />
        ```
12.	_Write a SQL query to find the names of all employees whose last name contains "ei"._<br />
        ```sql
        SELECT FirstName, MiddleName, LastName FROM Employees <br />
            WHERE LastName LIKE '%ei%' <br />
        ```
13.	_Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000]._<br />
        ```sql
        SELECT FirstName + ' ' + LastName AS Employee, Salary FROM Employees <br />
            WHERE Salary BETWEEN 20000 AND 30000<br />
        ```
14.	_Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600._<br />
        ```sql
        SELECT FirstName + ' ' + LastName AS Employee, Salary FROM Employees <br />
            WHERE Salary IN (25000, 14000, 12500, 23600)<br />
        ```
15.	_Write a SQL query to find all employees that do not have manager._<br />
        ```sql
        SELECT FirstName + ' ' + LastName AS Employee, ManagerID FROM Employees <br />
            WHERE ManagerID IS NULL<br />
        ```
16.	_Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary._<br />
        ```sql 
        SELECT FirstName + ' ' + LastName AS Employee, Salary FROM Employees <br />
            WHERE Salary > 50000<br />
            ORDER BY Salary DESC<br />
        ```
17. _Write a SQL query to find the top 5 best paid employees._<br />
        ```sql
        SELECT TOP(5) FirstName + ' ' + LastName AS Employee, Salary FROM Employees <br />
            ORDER BY Salary DESC 
        ```
18.	_Write a SQL query to find all employees along with their address. Use inner join with `ON` clause._<br />
        ```sql
        SELECT e.FirstName + ' ' + e.LastName AS Employee, a.AddressText AS Address FROM Employees e<br />
            INNER JOIN Addresses a<br />
                ON a.AddressID = e.AddressID<br />
        ```
19.	_Write a SQL query to find all employees and their address. Use equijoins (conditions in the `WHERE` clause)._<br />
        ```sql
        SELECT e.FirstName + ' ' + e.LastName AS Employee, a.AddressText AS Address<br />
            FROM Employees e ,Addresses a<br />
                WHERE a.AddressID = e.AddressID<br />
        ```
20. _Write a SQL query to find all employees along with their manager._<br />
        ```sql
        SELECT e.FirstName + ' ' + e.LastName AS Employee, <br />
			e.ManagerID,<br />
			m.FirstName +  ' ' + m.LastName AS Manager<br />
                FROM Employees e , Employees m<br />
				    WHERE m.ManagerID = e.ManagerID<br />
        ```
21.	_Write a SQL query to find all employees, along with their manager and their address. Join the 3 tables: `Employees e`, `Employees m` and `Addresses a`._<br />
        ```sql
            SELECT e.FirstName + ' ' + e.LastName AS Employee,<br />
				m.FirstName + ' ' + m.LastName AS Manager,<br />
				a.AddressText AS Address<br />		
		    FROM Employees e<br />
				INNER JOIN Addresses a<br />
					ON a.AddressID = e.AddressID<br />
				INNER JOIN Employees m<br />
					ON m.EmployeeID = e.ManagerID<br />
        ```
22.	_Write a SQL query to find all departments and all town names as a single list. Use `UNION`._<br />
        ```sql
        SELECT Name FROM Departments<br />
		UNION<br />
		SELECT Name FROM Towns<br />
        ```
23.	_Write a SQL query to find all the employees and the manager for each of them along with the employees that do not have manager. Use right outer join. Rewrite the query to use left outer join._<br />
        ```sql
         SELECT e.FirstName + ' ' + e.LastName AS Employee,<br />
		        m.FirstName + ' ' + m.LastName AS Manager<br />
            FROM Employees e<br />
	            RIGHT OUTER JOIN Employees m<br />
		            ON e.ManagerID = m.EmployeeID<br />
        ```
        ```sql
         SELECT e.FirstName + ' ' + e.LastName AS Employee,<br />
		        m.FirstName + ' ' + m.LastName AS Manager<br />
            FROM Employees e<br />
	            LEFT OUTER JOIN Employees m<br />
		            ON e.ManagerID = m.EmployeeID<br />
        ```
24. _Write a SQL query to find the names of all employees from the departments "Sales" and "Finance" whose hire year is between 1995 and 2005._<br />
        ```sql
        SELECT e.FirstName + ' ' + e.LastName AS Employee,<br />
		    d.Name AS Department,<br />
		    e.HireDate<br />
    FROM Employees e<br />
 	    INNER JOIN Departments d<br />
		    ON d.DepartmentID = e.DepartmentID<br />
	WHERE YEAR(e.HireDate) > 1995 AND YEAR(e.HireDate) < 2005<br />
        ```
