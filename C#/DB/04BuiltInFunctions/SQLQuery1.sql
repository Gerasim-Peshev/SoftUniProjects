--1
SELECT FirstName, LastName FROM Employees
WHERE FirstName LIKE 'Sa%'

--2
SELECT FirstName, LastName FROM Employees
WHERE LastName LIKE '%ei%'

--3
SELECT FirstName FROM Employees
WHERE DepartmentID = 3 OR 
DepartmentID = 10 AND
Year(HireDate) > 1995 AND 
Year(HireDate) <= 2005

--4
SELECT FirstName, LastName FROM Employees
WHERE NOT JobTitle LIKE '%engineer%'

--5
SELECT [Name] FROM Towns
WHERE LEN([Name]) = 5 OR LEN([Name]) = 6
ORDER BY [Name]

--6
SELECT * FROM Towns
WHERE [Name] LIKE 'M%' OR [Name] LIKE 'K%' OR [Name] LIKE 'B%' OR [Name] LIKE 'E%'
ORDER BY [Name]

--7
SELECT * FROM Towns
WHERE [Name] NOT LIKE 'R%' AND [Name] NOT LIKE 'B%' AND [Name] NOT LIKE 'D%'
ORDER BY [Name]

--8
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName FROM Employees
WHERE YEAR(HireDate) > 2000

--9
SELECT FirstName, LastName FROM Employees
WHERE LEN(LastName) = 5

--10
SELECT EmployeeID, 
FirstName, 
LastName, 
Salary, 
DENSE_RANK() OVER(PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC

--11
SELECT * FROM (
SELECT EmployeeID, 
FirstName, 
LastName, 
Salary, 
DENSE_RANK() OVER(PARTITION BY Salary ORDER BY EmployeeID) AS RANK
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000

) AS [SUB]
WHERE [SUB].[RANK] = 2
ORDER BY [SUB].Salary DESC

USE Geography
--12
SELECT [CountryName], [IsoCode] FROM Countries
WHERE LOWER([CountryName]) LIKE '%a%a%a%'
ORDER BY IsoCode

--13
SELECT 
[p].PeakName, 
[r].RiverName, 
LOWER(CONCAT(SUBSTRING([p].[PeakName], 1, LEN([p].[PeakName]) - 1),
[r].[RiverName])) AS Mix 
FROM Peaks AS p, Rivers AS r
WHERE RIGHT(LOWER([p].[PeakName]), 1) = LEFT(LOWER([r].[RiverName]), 1)
ORDER BY Mix

USE Diablo
--14
SELECT TOP(50) [Name], FORMAT([Start], 'yyyy-MM-dd') AS [Start] FROM Games
WHERE YEAR([Start]) BETWEEN 2011 AND 2012
ORDER BY [Start], [Name]

--15
SELECT 
Username, 
SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email)) AS 'Email Provider' 
FROM [Users]
ORDER BY [Email Provider], Username

--16
SELECT Username, IpAddress FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username

--17
SELECT [Name], 
CASE
	WHEN DATEPART(HOUR ,[Start]) >= 0 AND DATEPART(HOUR, [Start]) < 12 THEN 'Morning'
	WHEN DATEPART(HOUR, [Start]) >= 12 AND DATEPART(HOUR, [Start]) < 18 THEN 'Afternoon'
	WHEN DATEPART(HOUR, [Start]) >= 18 AND DATEPART(HOUR, [Start]) < 24 THEN 'Evening'
END AS 'Part of the Day',
CASE
	WHEN Duration <= 3 THEN 'Extra Short'
	WHEN Duration > 3 AND Duration <= 6 THEN 'Short'
	WHEN Duration > 6 THEN 'Long'
	WHEN Duration IS NULL THEN 'Extra Long'
END AS 'Duration'
FROM Games
ORDER BY [Name], [Duration], [Part of the Day]

USE Orders
--18
SELECT ProductName, OrderDate, 
DATEADD(DAY, 3, OrderDate) AS 'OrderDate',
DATEADD(MONTH, 1, OrderDate) AS 'Deliver Due'
FROM Orders