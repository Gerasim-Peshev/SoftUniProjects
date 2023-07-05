USE SoftUni
--1
SELECT TOP(5) [e].EmployeeID, [e].JobTitle, [a].AddressID, [a].AddressText FROM Employees AS [e]
JOIN Addresses AS [a] ON [e].AddressID = [a].AddressID
ORDER BY [a].AddressID

--2
SELECT TOP(50) [e].FirstName, [e].LastName, [t].[Name], [a].AddressText FROM Employees AS [e]
JOIN Addresses AS [a] ON [e].AddressID = [a].AddressID
JOIN Towns AS [t] ON [a].TownID = [t].TownID
ORDER BY [e].FirstName, [e].LastName

--3
SELECT [e].EmployeeID, [e].FirstName, [e].LastName, [d].[Name] FROM Employees AS [e]
JOIN Departments AS [d] ON [e].DepartmentID = [d].DepartmentID
WHERE [d].[Name] = 'Sales'
ORDER BY [e].EmployeeID

--4
SELECT TOP(5) [e].EmployeeID, [e].FirstName, [e].Salary, [d].[Name] FROM Employees AS [e]
JOIN Departments AS [d] ON [e].DepartmentID = [d].DepartmentID
WHERE [e].Salary > 15000
ORDER BY [e].DepartmentID

--5
SELECT TOP(3) [e].EmployeeID, [e].FirstName FROM Employees AS [e]
LEFT JOIN EmployeesProjects AS [ep] ON [e].EmployeeID = [ep].EmployeeID
WHERE [ep].ProjectID IS NULL
ORDER BY [ep].ProjectID

--6
SELECT [e].FirstName, [e].LastName, [e].HireDate, [d].[Name] FROM Employees AS [e]
JOIN Departments AS [d] ON [e].DepartmentID = [d].DepartmentID
WHERE [e].HireDate > '1999-1-1' AND ([d].[Name] = 'Sales' OR [d].[Name] = 'Finance')
ORDER BY [e].HireDate

--7
SELECT TOP(5) [e].EmployeeID, [e].FirstName, [p].[Name] FROM Employees AS [e]
JOIN EmployeesProjects AS [ep] ON [e].EmployeeID = [ep].EmployeeID
JOIN Projects AS [p] ON [ep].ProjectID = [p].ProjectID
WHERE [p].StartDate > '2002-08-13' AND [p].EndDate IS NULL
ORDER BY [e].EmployeeID

--8
SELECT [e].EmployeeID, [e].FirstName, 
CASE
WHEN YEAR([p].StartDate) >= 2005 THEN NULL
ELSE [p].[Name]
END
FROM Employees AS [e]
JOIN EmployeesProjects AS [ep] ON [e].EmployeeID = [ep].EmployeeID
JOIN Projects AS [p] ON [ep].ProjectID = [p].ProjectID
WHERE [e].EmployeeID = 24

--9
SELECT [e].EmployeeID, [e].FirstName, [e].ManagerID, [m].FirstName AS 'ManagerName' FROM Employees AS [e]
JOIN Employees AS [m] ON [e].ManagerID = [m].EmployeeID
WHERE [e].ManagerID IN (3, 7)
ORDER BY [e].EmployeeID

--10
SELECT TOP(50) [e].EmployeeID, ([e].FirstName + ' ' + [e].LastName) AS 'EmployeeName', ([m].FirstName + ' ' + [m].LastName) AS 'ManagerName', [d].[Name] FROM Employees AS [e]
JOIN Employees AS [m] ON [e].ManagerID = [m].EmployeeID
JOIN Departments AS [d] ON [e].DepartmentID = [d].DepartmentID
ORDER BY [e].EmployeeID

--11
SELECT TOP(1) AVG([e].Salary) AS 'MinAverageSalary' FROM Employees AS [e]
JOIN Departments AS [d] ON [e].DepartmentID = [d].DepartmentID
GROUP BY [d].[Name]
ORDER BY AVG([e].Salary)

USE Geography
--12
SELECT [c].CountryCode, [m].MountainRange, [p].PeakName, [p].Elevation FROM Countries AS [c]
JOIN MountainsCountries AS [mc] ON [c].CountryCode = [mc].CountryCode
JOIN Mountains AS [m] ON [mc].MountainId = [m].Id
JOIN Peaks AS [p] ON [m].Id = [p].MountainId
WHERE [c].CountryName = 'Bulgaria' AND [p].Elevation > 2835
ORDER BY [p].Elevation DESC

--13
SELECT CountryCode, COUNT(MountainId) FROM MountainsCountries
WHERE CountryCode IN ('US', 'RU', 'BG')
GROUP BY CountryCode

--14
SELECT TOP(5) [c].CountryName, [r].RiverName FROM Countries AS [c]
LEFT JOIN CountriesRivers AS [cr] ON [c].CountryCode = [cr].CountryCode
LEFT JOIN Rivers AS [r] ON [cr].RiverId = [r].Id
WHERE [c].ContinentCode = 'AF'
ORDER BY [c].CountryName

--15
SELECT [rc].ContinentCode, [rc].CurrencyCode, [rc].CountriesCount AS [CurrencyUsage] FROM (
SELECT *, DENSE_RANK() OVER(PARTITION BY [cr].ContinentCode ORDER BY [cr].CountriesCount DESC) AS [Rank] FROM (SELECT [cont].ContinentCode, [c].CurrencyCode, COUNT([c].CountryCode) AS [CountriesCount]
FROM Countries AS [c]
JOIN Continents AS [cont] ON [c].ContinentCode = [cont].ContinentCode
GROUP BY [cont].ContinentCode, [c].CurrencyCode
) AS [cr]
WHERE [cr].CountriesCount > 1) AS [rc]
WHERE [rc].[Rank] = 1

--16
SELECT COUNT([c].ContinentCode) AS [Count] FROM Countries AS [c]
LEFT JOIN MountainsCountries AS [mc] ON [c].CountryCode = [mc].CountryCode
WHERE [mc].MountainId IS NULL

--17
SELECT TOP(5) [c].[CountryName], 
	   MAX([p].[Elevation]) AS [HighestPeakElevation], 
	   MAX([r].[Length]) AS [LongestRiverLength]
	   FROM Countries AS [c]
LEFT JOIN MountainsCountries AS [mc] ON [c].CountryCode = [mc].CountryCode
LEFT JOIN Mountains AS [m] ON [mc].MountainId = [m].Id
LEFT JOIN Peaks AS [p] ON [m].Id = [p].MountainId
LEFT JOIN CountriesRivers AS [cr] ON [c].CountryCode = [cr].CountryCode
LEFT JOIN Rivers AS [r] ON [cr].RiverId = [r].Id
GROUP BY [c].CountryName
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, [c].CountryName
