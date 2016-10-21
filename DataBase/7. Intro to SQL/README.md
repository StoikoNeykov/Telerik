## Structured Query Language (SQL)
### _Homework_

1.	_What is SQL? What is DML? What is DDL? Recite the most important SQL commands._ <br /> 
        Structured Query Language is a special-purpose programming language designed for managing data held in a relational database management system (RDBMS), or for stream processing in a relational data stream management system (RDSMS).   
        The Data Manipulation Language (DML) is the subset of SQL used to add, update and delete data: SELECT, INSERT, UPDATE, DELETE.   
        The Data Definition Language (DDL) manages table and index structure. The most basic items of DDL are the CREATE, ALTER, RENAME, DROP and TRUNCATE statements:   
2.	_What is Transact-SQL (T-SQL)?_ <br />    
        Transact-SQL (T-SQL) is Microsoft's and Sybase's proprietary extension to the SQL (Structured Query Language) used to interact with relational databases.   
        T-SQL expands on the SQL standard to include procedural programming, local variables, various support functions for string processing, date processing, mathematics, etc. and changes to the DELETE and UPDATE statements.   
        Transact-SQL is central to using Microsoft SQL Server. All applications that communicate with an instance of SQL Server do so by sending Transact-SQL statements to the server, regardless of the user interface of the application.   
3.	_Start SQL Management Studio and connect to the database TelerikAcademy. Examine the major tables in the "TelerikAcademy" database._ <br />    
        
        ```sql   
        SELECT * FROM sysobjects WHERE xtype='U'    
        ```   
4.	_Write a SQL query to find all information about all departments (use "TelerikAcademy" database)._ <br />    
        
        ```sql   
        SELECT * FROM Departments   
        ```   
5.	_Write a SQL query to find all department names._ <br />    
        
        ```sql   
        SELECT Name FROM Departments   
        ```   
6.	_Write a SQL query to find the salary of each employee._ <br />    
        
        ```sql   
        SELECT Salary FROM Employees   
        ```   
7.	_Write a SQL to find the full name of each employee._ <br />    
        
        ```sql   
        SELECT FirstName + ' ' + MiddleName + ' ' + LastName FROM Employees   
        ```   
8.	_Write a SQL query to find the email addresses of each employee (by his first and last name). Consider that the mail domain is telerik.com. Emails should look like “John.Doe@telerik.com". The produced column should be named "Full Email Addresses"._ <br />    
        
        ```sql   
        SELECT FirstName + '.' + LastName + '@telerik.com' AS "Full Email Addresses" FROM Employees   
        ```   
9.	_Write a SQL query to find all different employee salaries._ <br />    
        
        ```sql   
        SELECT DISTINCT Salary FROM Employees   
        ```   
10.	_Write a SQL query to find all information about the employees whose job title is “Sales Representative“._ <br />    
        
        ```sql   
        SELECT * FROM Employees WHERE [JobTitle] = 'Sales Representative'   
        ```   
11.	_Write a SQL query to find the names of all employees whose first name starts with "SA"._ <br />    
        
        ```sql   
        SELECT FirstName, MiddleName, LastName FROM Employees    
            WHERE FirstName LIKE 'SA%'    
        ```   
12.	_Write a SQL query to find the names of all employees whose last name contains "ei"._ <br />    
        
        ```sql   
        SELECT FirstName, MiddleName, LastName FROM Employees    
            WHERE LastName LIKE '%ei%'    
        ```   
13.	_Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000]._ <br />    
        
        ```sql   
        SELECT FirstName + ' ' + LastName AS Employee, Salary FROM Employees    
            WHERE Salary BETWEEN 20000 AND 30000   
        ```   
14.	_Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600._ <br />    
        
        ```sql   
        SELECT FirstName + ' ' + LastName AS Employee, Salary FROM Employees    
            WHERE Salary IN (25000, 14000, 12500, 23600)   
        ```   
15.	_Write a SQL query to find all employees that do not have manager._ <br />    
        
        ```sql   
        SELECT FirstName + ' ' + LastName AS Employee, ManagerID FROM Employees    
            WHERE ManagerID IS NULL   
        ```   
16.	_Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary._ <br /> 
        
        ```sql 
        SELECT FirstName + ' ' + LastName AS Employee, Salary FROM Employees    
            WHERE Salary > 50000   
            ORDER BY Salary DESC   
        ```
17. _Write a SQL query to find the top 5 best paid employees._ <br /> 
        
        ```sql
        SELECT TOP(5) FirstName + ' ' + LastName AS Employee, Salary FROM Employees    
            ORDER BY Salary DESC    
        ```
18.	_Write a SQL query to find all employees along with their address. Use inner join with `ON` clause._ <br /> 
        
        ```sql
        SELECT e.FirstName + ' ' + e.LastName AS Employee, a.AddressText AS Address   
        FROM Employees e     
            INNER JOIN Addresses a     
                ON a.AddressID = e.AddressID   
        ```
19.	_Write a SQL query to find all employees and their address. Use equijoins (conditions in the `WHERE` clause)._ <br /> 
        
        ```sql
        SELECT e.FirstName + ' ' + e.LastName AS Employee, a.AddressText AS Address   
            FROM Employees e ,Addresses a   
                WHERE a.AddressID = e.AddressID   
        ```
20. _Write a SQL query to find all employees along with their manager._ <br /> 
        
        ```sql
        SELECT e.FirstName + ' ' + e.LastName AS Employee,    
			e.ManagerID,   
			m.FirstName +  ' ' + m.LastName AS Manager   
                FROM Employees e , Employees m   
			WHERE m.ManagerID = e.ManagerID   
        ```
21.	_Write a SQL query to find all employees, along with their manager and their address. Join the 3 tables: `Employees e`, `Employees m` and `Addresses a`._ <br /> 
        
        ```sql
            SELECT e.FirstName + ' ' + e.LastName AS Employee,    
				m.FirstName + ' ' + m.LastName AS Manager,   
				a.AddressText AS Address	   			
		    FROM Employees e   
				INNER JOIN Addresses a   
					ON a.AddressID = e.AddressID   
				INNER JOIN Employees m   
					ON m.EmployeeID = e.ManagerID   
        ```
22.	_Write a SQL query to find all departments and all town names as a single list. Use `UNION`._ <br /> 
        
        ```sql
        SELECT Name FROM Departments   
	UNION   
	SELECT Name FROM Towns   
        ```
23.	_Write a SQL query to find all the employees and the manager for each of them along with the employees that do not have manager. Use right outer join. Rewrite the query to use left outer join._ <br /> 
        
        ```sql
         SELECT e.FirstName + ' ' + e.LastName AS Employee,   
		        m.FirstName + ' ' + m.LastName AS Manager   
            FROM Employees e   
	            RIGHT OUTER JOIN Employees m   
		            ON e.ManagerID = m.EmployeeID   
        ```
        
        ```sql
         SELECT e.FirstName + ' ' + e.LastName AS Employee,   
		        m.FirstName + ' ' + m.LastName AS Manager   
            FROM Employees e   
	            LEFT OUTER JOIN Employees m   
		            ON e.ManagerID = m.EmployeeID   
        ```
24. _Write a SQL query to find the names of all employees from the departments "Sales" and "Finance" whose hire year is between 1995 and 2005._ <br /> 
        
        ```sql
        SELECT e.FirstName + ' ' + e.LastName AS Employee,   
		    d.Name AS Department,   
		    e.HireDate
    FROM Employees e   
 	    INNER JOIN Departments d   
		    ON d.DepartmentID = e.DepartmentID   
	WHERE YEAR(e.HireDate) > 1995 AND YEAR(e.HireDate) < 2005   
        ```
