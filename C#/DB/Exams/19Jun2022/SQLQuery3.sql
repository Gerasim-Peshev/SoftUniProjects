--5
SELECT [Name], PhoneNumber, [Address], AnimalId, DepartmentId FROM Volunteers
ORDER BY [Name] ASC, AnimalId ASC, DepartmentId ASC

--6
SELECT [a].[Name], [at].AnimalType, FORMAT([a].BirthDate, 'dd.MM.yyyy') AS BirthDate FROM Animals AS [a]
JOIN AnimalTypes AS [at] ON [a].AnimalTypeId = [at].Id
ORDER BY [a].[Name]

--7
SELECT TOP(5) [o].[Name], COUNT([a].[Name]) AS [CountOfAnimals] FROM Owners AS [o]
JOIN Animals AS [a] ON [o].Id = [a].OwnerId
GROUP BY [o].[Name]
ORDER BY COUNT([a].[Name]) DESC, [o].[Name] 

--8
SELECT CONCAT([o].[Name], '-', [a].[Name]), [o].PhoneNumber, [ac].CageId FROM Owners AS [o]
JOIN Animals AS [a] ON [o].Id = [a].OwnerId
JOIN AnimalTypes AS [at] ON [a].AnimalTypeId = [at].Id
JOIN AnimalsCages AS [ac] ON [a].Id = [ac].AnimalId
WHERE [at].AnimalType = 'mammals'
ORDER BY [o].[Name] ASC, [a].[Name] DESC

--9
SELECT [Name], PhoneNumber, TRIM(REPLACE(REPLACE([Address], 'Sofia', ''), ',', '')) AS [Address] FROM Volunteers
WHERE [Address] LIKE '%Sofia%' AND DepartmentId = 2
ORDER BY [Name] ASC

--10
SELECT [a].[Name], YEAR([a].BirthDate) AS BirthYear, [at].AnimalType FROM Animals AS [a]
JOIN AnimalTypes AS [at] ON [a].AnimalTypeId = [at].Id
WHERE [a].OwnerId IS NULL AND YEAR([a].BirthDate) > 2017 AND [at].AnimalType <> 'Birds'
ORDER BY [a].[Name]