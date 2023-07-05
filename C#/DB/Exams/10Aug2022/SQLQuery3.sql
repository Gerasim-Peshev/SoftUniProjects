--5
SELECT [Name], Age, PhoneNumber, Nationality FROM Tourists
ORDER BY Nationality ASC, Age DESC, [Name] ASC

--6
SELECT [s].[Name], [l].[Name], [s].Establishment, [c].[Name] FROM Sites AS [s]
JOIN Locations AS [l] ON [s].LocationId = [l].Id
JOIN Categories AS [c] ON [s].CategoryId = [c].Id
ORDER BY [c].[Name] DESC, [l].[Name] ASC, [s].[Name] ASC

--7
SELECT [l].Province, [l].Municipality, [l].[Name], COUNT([s].Id) FROM Sites AS [s]
JOIN Locations AS [l] ON [s].LocationId = [l].Id
WHERE [l].Province = 'Sofia'
GROUP BY [l].Province, [l].Municipality, [l].[Name]
ORDER BY COUNT([s].Id) DESC, [l].[Name] ASC

--8
SELECT [s].[Name], [l].[Name], [l].Municipality, [l].Province, [s].Establishment FROM Sites AS [s]
JOIN Locations AS [l] ON [s].LocationId = [l].Id
WHERE ([l].[Name] LIKE '[^B]%' AND [l].[Name] LIKE '[^M]%' AND [l].[Name] LIKE '[^D]%') AND [s].Establishment LIKE '%BC'
ORDER BY [s].[Name] ASC

--9
SELECT [t].[Name], [t].Age, [t].PhoneNumber, [t].Nationality, 
CASE
WHEN [bp].[Name] IS NULL THEN '(no bonus prize)'
ELSE [bp].[Name]
END
FROM Tourists AS [t]
LEFT JOIN TouristsBonusPrizes AS [tbp] ON [t].Id = [tbp].TouristId
LEFT JOIN BonusPrizes AS [bp] ON [tbp].BonusPrizeId = [bp].Id
ORDER BY [t].[Name] ASC

--10
SELECT DISTINCT SUBSTRING([t].[Name], CHARINDEX(' ', [t].[Name]) + 1, LEN([t].[Name]) - CHARINDEX(' ', [t].[Name]) + 1) AS [LastName], [t].Nationality, [t].Age, [t].PhoneNumber FROM Sites AS [s]
JOIN Categories AS [c] ON [s].CategoryId = [c].Id
JOIN SitesTourists AS [st] ON [s].Id = [st].SiteId
JOIN Tourists AS [t] ON [st].TouristId = [t].Id
WHERE [c].[Name] = 'History and archaeology'
ORDER BY LastName ASC