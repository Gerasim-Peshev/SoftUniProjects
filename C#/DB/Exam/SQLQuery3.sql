--5
SELECT [Name], Rating FROM Boardgames
ORDER BY YearPublished ASC, [Name] DESC

--6
SELECT [bg].Id, [bg].[Name], [bg].YearPublished, [c].[Name] FROM Boardgames AS [bg]
JOIN Categories AS [c] ON [bg].CategoryId = [c].Id
WHERE [c].[Name] IN ('Strategy Games', 'Wargames')
ORDER BY [bg].YearPublished DESC

--7
SELECT [c].Id, CONCAT([c].FirstName, ' ', [c].LastName) AS [CreatorName], [c].Email FROM Creators AS [c]
LEFT JOIN CreatorsBoardgames AS [cb] ON [c].Id = [cb].CreatorId
LEFT JOIN Boardgames AS [b] ON [cb].BoardgameId = [b].Id
WHERE [cb].BoardgameId IS NULL

--8
SELECT TOP(5) [bg].[Name], [bg].Rating, [c].[Name] FROM Boardgames AS [bg]
JOIN PlayersRanges AS [pr] ON [bg].PlayersRangeId = [pr].Id
JOIN Categories AS [c] ON [bg].CategoryId = [c].Id
WHERE ([bg].Rating > 7.00 AND [bg].[Name] LIKE '%a%') OR ([bg].Rating > 7.50 AND [pr].PlayersMin = 2 AND [pr].PlayersMax = 5)
ORDER BY [bg].[Name] ASC, [bg].Rating DESC

--9
SELECT CONCAT([c].[FirstName], ' ', [c].LastName), [c].Email, MAX([b].Rating) AS [Rating] FROM Creators AS [c]
JOIN CreatorsBoardgames AS [cb] ON [c].Id = [cb].CreatorId
JOIN Boardgames AS [b] ON [cb].BoardgameId = [b].Id
WHERE [c].Email LIKE '%.com'
GROUP BY CONCAT([c].[FirstName], ' ', [c].LastName), [c].Email
ORDER BY CONCAT([c].[FirstName], ' ', [c].LastName) ASC

--10
SELECT [c].LastName, CEILING(AVG([b].Rating)), [p].[Name] FROM Creators AS [c]
JOIN CreatorsBoardgames AS [cb] ON [c].Id = [cb].CreatorId
JOIN Boardgames AS [b] ON [cb].BoardgameId = [b].Id
JOIN Publishers AS [p] ON [b].PublisherId = [p].Id
WHERE [p].[Name] = 'Stonemaier Games'
GROUP BY [c].LastName, [p].[Name]
ORDER BY AVG([b].Rating) DESC

--11
CREATE FUNCTION udf_CreatorWithBoardgames(@name VARCHAR(30))
RETURNS INT
AS 
BEGIN

DECLARE @res INT

SET @res = (
SELECT COUNT(*) FROM Creators AS [c]
JOIN CreatorsBoardgames AS [cb] ON [c].Id = [cb].CreatorId
JOIN Boardgames AS [b] ON [cb].BoardgameId = [b].Id
WHERE [c].FirstName = @name
)

RETURN @res
END

--12
CREATE PROCEDURE usp_SearchByCategory(@category VARCHAR(50))
AS
BEGIN
SELECT [b].[Name], [b].YearPublished, [b].Rating, [c].[Name], [p].[Name], CONCAT([pr].PlayersMin, ' ', 'people') AS [MinPlayers], CONCAT([pr].PlayersMax, ' ', 'people') AS [MaxPlayers] FROM Categories AS [c]
JOIN Boardgames AS [b] ON [c].Id = [b].CategoryId
JOIN PlayersRanges AS [pr] ON [b].PlayersRangeId = [pr].Id
JOIN Publishers AS [p] ON [b].PublisherId = [p].Id
WHERE [c].[Name] = @category
ORDER BY [p].[Name] ASC, [b].YearPublished DESC
END