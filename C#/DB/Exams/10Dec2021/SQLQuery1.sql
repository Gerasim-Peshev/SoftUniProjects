--5
SELECT Manufacturer, Model, FlightHours, Condition FROM Aircraft
ORDER BY FlightHours DESC

--6
SELECT [p].FirstName, [p].LastName, [a].Manufacturer, [a].Model, [a].FlightHours FROM Pilots AS [p]
JOIN PilotsAircraft AS [pa] ON [p].Id = [pa].PilotId
JOIN Aircraft AS [a] ON [a].Id = [pa].AircraftId
WHERE [a].FlightHours IS NOT NULL AND [a].FlightHours < 304
ORDER BY [a].FlightHours DESC, [p].FirstName ASC

--7
SELECT TOP(20) [fd].Id, [fd].[Start], [p].FullName, [a].AirportName, [fd].TicketPrice FROM FlightDestinations AS [fd]
JOIN Airports AS [a] ON [fd].AirportId = [a].Id
JOIN Passengers AS [p] ON [fd].PassengerId = [p].Id
WHERE DAY([Start]) % 2 = 0
ORDER BY [fd].TicketPrice DESC, [a].AirportName ASC

--8
SELECT [a].Id, [a].Manufacturer, [a].FlightHours, COUNT([fd].Id) AS [FlightDestinationsCount], ROUND(AVG([fd].TicketPrice), 2) AS [AvgPrice] FROM Aircraft AS [a]
JOIN FlightDestinations AS [fd] ON [a].Id = [fd].AircraftId
GROUP BY [a].Id, [a].Manufacturer, [a].FlightHours
HAVING COUNT([fd].Id) >= 2
ORDER BY COUNT([fd].Id) DESC, [a].Id ASC

--9
SELECT [p].FullName, COUNT([a].Id), SUM([fd].TicketPrice) FROM Passengers AS [p]
JOIN FlightDestinations AS [fd] ON [p].Id = [fd].PassengerId
JOIN Aircraft AS [a] ON [fd].AircraftId = [a].Id
WHERE SUBSTRING(FullName, 2, 1) = 'a'
GROUP BY [p].FullName
HAVING COUNT([a].Id) > 1
ORDER BY [p].FullName

--10
SELECT [ap].AirportName, [fd].[Start] AS [DayTime], [fd].TicketPrice, [p].FullName, [ac].Manufacturer, [ac].Model FROM FlightDestinations AS [fd]
JOIN Passengers AS [p] ON [fd].PassengerId = [p].Id
JOIN Airports AS [ap] ON [fd].AirportId = [ap].Id
JOIN Aircraft AS [ac] ON [fd].AircraftId = [ac].Id
WHERE (DATEPART(HOUR, [fd].[Start]) BETWEEN 6 AND 20) AND [fd].TicketPrice > 2500
ORDER BY [ac].Model ASC