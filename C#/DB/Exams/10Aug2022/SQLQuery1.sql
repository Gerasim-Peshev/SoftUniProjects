--11
CREATE FUNCTION udf_GetTouristsCountOnATouristSite (@Site VARCHAR(100))
RETURNS INT
AS
BEGIN
DECLARE @res INT;

SET @res = (SELECT COUNT([t].Id) FROM Sites AS [s]
JOIN SitesTourists AS [st] ON [s].Id = [st].SiteId
JOIN Tourists AS [t] ON [st].TouristId = [t].Id
WHERE [s].[Name] = @Site)

RETURN @res
END

SELECT dbo.udf_GetTouristsCountOnATouristSite ('Regional History Museum – Vratsa')
SELECT dbo.udf_GetTouristsCountOnATouristSite ('Samuil’s Fortress')
SELECT dbo.udf_GetTouristsCountOnATouristSite ('Gorge of Erma River')