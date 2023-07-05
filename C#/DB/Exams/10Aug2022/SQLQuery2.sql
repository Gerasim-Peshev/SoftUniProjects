--12
CREATE PROCEDURE usp_AnnualRewardLottery(@TouristName VARCHAR(50))
AS
BEGIN
SELECT [t].[Name],
CASE
WHEN COUNT([s].[Name]) >= 100 THEN 'Gold badge'
WHEN COUNT([s].[Name]) >= 50 THEN 'Silver badge'
WHEN COUNT([s].[Name]) >= 25 THEN 'Bronze badge'
END AS [Reward]
FROM Tourists AS [t]
JOIN SitesTourists AS [st] ON [t].Id = [st].TouristId
JOIN Sites AS [s] ON [st].SiteId = [s].Id
WHERE [t].[Name] = @TouristName
GROUP BY [t].[Name]
END

EXEC usp_AnnualRewardLottery 'Gerhild Lutgard'
EXEC usp_AnnualRewardLottery 'Teodor Petrov'
EXEC usp_AnnualRewardLottery 'Zac Walsh'
EXEC usp_AnnualRewardLottery 'Brus Brown'