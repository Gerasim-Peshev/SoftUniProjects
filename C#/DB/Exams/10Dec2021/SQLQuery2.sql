--11
CREATE FUNCTION udf_FlightDestinationsByEmail(@email VARCHAR(50))
RETURNS INT
AS
BEGIN

DECLARE @res INT

SET @res = (
SELECT COUNT([fd].Id) FROM Passengers AS [p]
JOIN FlightDestinations AS [fd] ON [p].Id = [fd].PassengerId
WHERE [p].Email = @email
GROUP BY [p].Email
)

IF(@res IS NULL)
BEGIN
SET @res = 0
END

RETURN @res
END

--12
CREATE PROCEDURE usp_SearchByAirportName(@airportName VARCHAR(70))
AS
BEGIN
SELECT [ap].AirportName,
[p].FullName,
CASE
WHEN [fd].TicketPrice <= 400 THEN 'Low'
WHEN [fd].TicketPrice BETWEEN 401 AND 1500 THEN 'Medium'
WHEN [fd].TicketPrice >= 1501 THEN 'High'
END AS [LevelOfTickerPrice],
[ac].Manufacturer,
[ac].Condition,
[at].TypeName
FROM Airports AS [ap]
JOIN FlightDestinations AS [fd] ON [ap].Id = [fd].AirportId
JOIN Passengers AS [p] ON [p].Id = [fd].PassengerId
JOIN Aircraft AS [ac] ON [ac].Id = [fd].AircraftId
JOIN AircraftTypes AS [at] ON [ac].TypeId = [at].Id
WHERE [ap].AirportName = @airportName
ORDER BY [ac].Manufacturer, [p].FullName
END